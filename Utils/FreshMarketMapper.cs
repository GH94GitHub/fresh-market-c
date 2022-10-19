using System.Collections;
using AutoMapper;
using FreshMarket.Dtos;
using FreshMarket.Models;

namespace FreshMarket.Utils
{
    public static class FreshMarketMapper
    {
        private static readonly MapperConfiguration _mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<User, UserDto>()
                .AfterMap((src, dest) =>
                {
                    if(dest.Subscription != null)
                        dest.Subscription.User = null;
                });
            cfg.CreateMap<UserToCreate, User>();
            cfg.CreateMap<UserToCreate, User>();
            cfg.CreateMap<PartialUser, User>()
                .ForAllMembers(opt =>
                {
                    opt.Condition((source, dest, member) => member != null);
                });
        });

        public static Mapper GetMapper()
        {
            return new Mapper(_mapperConfig);
        }
    }
}
