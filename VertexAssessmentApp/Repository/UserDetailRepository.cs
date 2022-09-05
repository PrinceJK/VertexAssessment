using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using VertexAssessmentApp.Interface;
using VertexAssessmentApp.Models;
using VertexAssessmentApp.Models.Context;
using VertexAssessmentApp.ViewModel;

namespace VertexAssessmentApp.Repository
{
    public class UserDetailRepository : IUserDetailRepository
    {
        private readonly SQLContext _sqlContext;
        public UserDetailRepository(SQLContext sQLContext)
        {
            _sqlContext = sQLContext;
        }
        public async Task<Guid> AddUserDetailsAsync(UserDetailsViewModel model)
        {
            var user = new UserDetails
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                MiddleName = model.MiddleName,
                StreetAddress = model.StreetAddress,
                City = model.City,
                Zip = model.Zip,
                Phone = model.Phone,
            };
            var addedUser = await _sqlContext.AddAsync(user);
            await _sqlContext.SaveChangesAsync();
            return addedUser.Entity.Id;
        }

        public async Task<UserDetailsViewModel> GetUserDetails(Guid id)
        {
            var user = await _sqlContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null) return null;

            return new UserDetailsViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                MiddleName = user.MiddleName,
                StreetAddress = user.StreetAddress,
                City = user.City,
                Zip = user.Zip,
                Phone = user.Phone,
            };
        }
    }
}
