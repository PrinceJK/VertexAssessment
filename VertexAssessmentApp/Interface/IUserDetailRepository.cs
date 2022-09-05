using System;
using System.Threading.Tasks;
using VertexAssessmentApp.ViewModel;

namespace VertexAssessmentApp.Interface
{
    public interface IUserDetailRepository
    {
        Task<Guid> AddUserDetailsAsync(UserDetailsViewModel model);

        Task<UserDetailsViewModel> GetUserDetails(Guid id);
    }
}
