using Microsoft.AspNetCore.Http;
using Red_Social.Core.Application.Helpers;
using Red_Social.Core.Application.Interfaces.Repositories;
using Red_Social.Core.Application.Interfaces.Services;
using Red_Social.Core.Application.ViewModels.Post;
using Red_Social.Core.Application.ViewModels.User;
using Red_Social.Core.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Red_Social.Core.Application.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _anuncioRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserViewModel? userViewModel;

        public PostService(IPostRepository anuncioRepository, IHttpContextAccessor httpContextAccessor)
        {
            _anuncioRepository = anuncioRepository;
            _httpContextAccessor = httpContextAccessor;
            userViewModel = _httpContextAccessor.HttpContext.Session.Get<UserViewModel>("user");
        }


        Task<PostViewModel> IPostService.GetAnuncioyDetalles(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(SavePostViewModel vm)
        {
            throw new NotImplementedException();
        }

        public Task<SavePostViewModel> Add(SavePostViewModel vm)
        {
            throw new NotImplementedException();
        }

        Task<SavePostViewModel> IGenericService<SavePostViewModel, PostViewModel>.GetByIdSaveViewModel(int id)
        {
            throw new NotImplementedException();
        }

        Task<List<PostViewModel>> IGenericService<SavePostViewModel, PostViewModel>.GetAllViewModel()
        {
            throw new NotImplementedException();
        }

        Task IGenericService<SavePostViewModel, PostViewModel>.Update(SavePostViewModel vm)
        {
            throw new NotImplementedException();
        }

        Task<SavePostViewModel> IGenericService<SavePostViewModel, PostViewModel>.Add(SavePostViewModel vm)
        {
            throw new NotImplementedException();
        }

        Task IGenericService<SavePostViewModel, PostViewModel>.Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
