using Red_Social.Core.Application.ViewModels.User;
using Red_Social.Core.Domain.Entities;
using System.Threading.Tasks;

namespace Red_Social.Core.Application.Interfaces.Services
{
    public interface IUserService : IGenericService<SaveUserViewModel, UserViewModel,User>
    {
        Task<UserViewModel> Login(LoginViewModel vm);
        Task<UserViewModel> GetByIdViewModel(int id);

        Task<UserViewModel> Restorepass(ForgotPassViewModel fm);
    }
}
