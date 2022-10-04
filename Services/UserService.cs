using FreshMarket.Data;
using FreshMarket.Dtos;
using FreshMarket.Exceptions;
using FreshMarket.Exceptions.Postgres;
using FreshMarket.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace FreshMarket.Services
{
    public class UserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets a user by Id
        /// </summary>
        /// <exception cref="UserIdNotExistsException"></exception>
        public async Task<User> GetUser(int userId)
        {
            var user = await _context.users.FindAsync(userId);

            return user ?? throw new UserIdNotExistsException(userId);
        }

        /// <summary>
        /// Creates a user
        /// </summary>
        /// <exception cref="ModelCannotHaveIdException"></exception>
        /// <exception cref="PostgresException"></exception>
        /// <exception cref="UniqueViolationException"></exception>
        public async Task<User> CreateUser(User user)
        {
            if (user.Id != 0)
                throw new ModelCannotHaveIdException(user);

            try
            {
                await _context.users.AddAsync(user);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException is PostgresException postgresException)
                    postgresException.HandleException<User>();
                else
                    throw dbUpdateException;
            }

            return user;
        }

        /// <summary>
        /// Updates a user
        /// </summary>
        /// <exception cref="UserNotExistsException"></exception>
        public async Task<User> UpdateUser(UserDto userDto)
        {
            var user = await _context.users.FindAsync(userDto.Id);
            if (user == null)
                throw new UserNotExistsException(userDto);

            _context.Entry(user).CurrentValues.SetValues(userDto);
            await _context.SaveChangesAsync();
            return user;
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
    }
}
