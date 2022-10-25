using Red_Social.Core.Application.ViewModels.User;
using System.Threading.Tasks;

namespace Red_Social.Core.Application.Interfaces.Services
{
    public interface IUserService : IGenericService<SaveUserViewModel, UserViewModel>
    {
        Task<UserViewModel> Login(LoginViewModel vm);
        Task<UserViewModel> GetByIdViewModel(int id);
    }
}
