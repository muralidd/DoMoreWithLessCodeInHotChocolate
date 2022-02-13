using System;
using System.Linq;
using Example.Abstractions;
using Example.DataAccess;
using System.Threading.Tasks;
using Graphql;

namespace Example.Graphql
{
    public class Query
    {
        private readonly IUserRepository _userRepository;
        private readonly IBookingsRepository _bookingsRepository;

        public Query(
            IUserRepository userRepository,
            IBookingsRepository bookingsRepository)
        {
            _userRepository = userRepository;
            _bookingsRepository = bookingsRepository;
        }

        //[UsePaging]
        //[UseSorting]
        //[UseFiltering]
        [UseOffsetPaging]
        [UseCustomSorting]
        public IQueryable<User> GetUsers()
        {
            return _userRepository.GetUsers();
        }

        public Task<User> GetUser(Guid userId)
        {
            return _userRepository.GetUserAsync(userId);
        }

        public IQueryable<Booking> GetBookings()
        {
            return _bookingsRepository.GetBookings();
        }
    }
}