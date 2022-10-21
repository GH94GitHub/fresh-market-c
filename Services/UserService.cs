using AutoMapper;
using FreshMarket.Data;
using FreshMarket.Dtos;
using FreshMarket.Exceptions;
using FreshMarket.Exceptions.Postgres;
using FreshMarket.Exceptions.UserExceptions;
using FreshMarket.Models;
using FreshMarket.Repositories;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace FreshMarket.Services
{
    public class UserService
    {
        private readonly ApplicationDbContext _context;
        private readonly Mapper _mapper;
        private readonly UserRepository _userRepository;

        public UserService(ApplicationDbContext context, Mapper mapper, UserRepository userRepository)
        {
            _context = context;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        /// <summary>
        /// Gets a user by Id
        /// </summary>
        /// <exception cref="UserIdNotExistsException"></exception>
        public async Task<UserDto> GetUser(int userId)
        {
            var user = await _userRepository.Get(userId);

            return _mapper.Map<UserDto>(user) ?? throw new UserIdNotExistsException(userId);
        }

        /// <summary>
        /// Creates a user
        /// </summary>
        /// <exception cref="ModelCannotHaveIdException"></exception>
        /// <exception cref="PostgresException"></exception>
        /// <exception cref="UniqueViolationException"></exception>
        public async Task<UserDto> CreateUser(UserToCreate userToCreate)
        {
            if (userToCreate.Id != 0)
                throw new ModelCannotHaveIdException(userToCreate);

            try
            {
                var user = _mapper.Map<User>(userToCreate);

                foreach (var userAllergy in user.Allergies)
                {
                    _context.Entry(userAllergy).State = EntityState.Unchanged;
                }
                foreach (var userDishPreference in user.DishPreferences)
                {
                    _context.Entry(userDishPreference).State = EntityState.Unchanged;
                }
                _context.Entry(user.Subscription.Tier).State = EntityState.Unchanged;
                user.Subscription.ExpirationDate = user.Subscription.ExpirationDate.ToUniversalTime();

                await _context.users.AddAsync(user);
                await _context.SaveChangesAsync();
                return _mapper.Map<UserDto>(user);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException is not PostgresException postgresException)
                    throw dbUpdateException;
                postgresException.HandleException<User>();
                throw dbUpdateException;
            }
        }

        /// <summary>
        /// Updates a user
        /// </summary>
        /// <exception cref="UserNotExistsException"></exception>
        /// <exception cref="PostgresException"></exception>
        /// <exception cref="UniqueViolationException"></exception>
        public async Task<UserDto> UpdateUser(PartialUser partialUser)
        {
            var user = await _userRepository.Get(partialUser.Id);
            var type = user.Allergies.GetType();
            if (user == null)
                throw new UserIdNotExistsException(partialUser.Id);

            user = _mapper.Map(partialUser, user);
            try
            {
                _context.Update(user);
                await _context.SaveChangesAsync();
                return _mapper.Map<UserDto>(user);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException is not PostgresException postgresException)
                    throw dbUpdateException;
                postgresException.HandleException<User>();
                throw dbUpdateException;
            }
        }

        /// <summary>
        /// Deletes a user
        /// </summary>
        /// <exception cref="UserIdNotExistsException"></exception>
        public async Task<bool> DeleteUser(int id)
        {
            var user = await _context.users.FindAsync(id);
            if (user == null)
                throw new UserIdNotExistsException(id);

            _context.users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Changes the users subscription, or adds one if they currently don't have one
        /// </summary>
        /// <returns></returns>
        /// <exception cref="UserIdNotExistsException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task UpdateSubscription(int userId, SubscriptionDto subscriptionDto)
        {
            var user = await _userRepository.Get(userId);

            if (user == null)
                throw new UserIdNotExistsException(userId);

            subscriptionDto.ExpirationDate = subscriptionDto.ExpirationDate.ToUniversalTime();
            if (user.Subscription == null)
            {
                if (subscriptionDto.Id != 0)
                    throw new Exception("Cannot add subscription");

                user.Subscription = _mapper.Map<Subscription>(subscriptionDto);
            }
            else
            {
                if (user.Subscription.Id != subscriptionDto.Id || user.Id != subscriptionDto.UserId)
                    throw new Exception("");


                _context.Entry(user.Subscription).CurrentValues.SetValues(subscriptionDto);
            }



            await _context.SaveChangesAsync();
        }

        //todo: update user allergies
        //todo: update user dish preferences
    }
}
