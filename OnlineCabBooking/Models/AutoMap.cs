using CabBookingEntity;

namespace OnlineCabBooking.Models
{
    public class AutoMap
    {
        public static void Mapping()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<SignUpVM, User>();
                config.CreateMap<SignInVM, User>();
                config.CreateMap<LocationVM, Location>();
                config.CreateMap<SignUpNextVM, Cab>();
            });
        }
    }
}