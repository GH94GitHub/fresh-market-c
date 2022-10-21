using AutoMapper;
using FreshMarket.Data;
using FreshMarket.Dtos;
using FreshMarket.Exceptions.UserExceptions;
using FreshMarket.Models;
using FreshMarket.Repositories;

namespace FreshMarket.Services
{
    public class SubscriptionService
    {
        private readonly ApplicationDbContext _context;
        private readonly Mapper _mapper;
        private readonly UserRepository _userRepository;

        public SubscriptionService(ApplicationDbContext context, Mapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _userRepository = new UserRepository(context);
        }

        /// <summary>
        /// Changes the users subscription, or adds one if they currently don't have one
        /// </summary>
        /// <returns></returns>
        /// <exception cref="UserIdNotExistsException"></exception>
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
    }
}
