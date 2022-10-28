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
        private readonly IPostRepository _ipostRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserViewModel? userViewModel;

        public PostService(IPostRepository ipostRepository, IHttpContextAccessor httpContextAccessor)
        {
            _ipostRepository = ipostRepository;
            _httpContextAccessor = httpContextAccessor;
            userViewModel = _httpContextAccessor.HttpContext.Session.Get<UserViewModel>("user");
        }


        Task<PostViewModel> GetPostsandDetails(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(SavePostViewModel vm)
        {
            throw new NotImplementedException();
        }

        public async Task<SavePostViewModel> Add(SavePostViewModel spvm)
        {
            Post post = new();
            post.UserId = userViewModel.Id;
            post.ImgUrl = spvm.ImgUrl;
            post.Text = spvm.Text;


            post = await _ipostRepository.AddAsync(post);

            SavePostViewModel poVm = new();

            poVm.UserId = post.UserId;
            poVm.ImgUrl = post.ImgUrl;
            poVm.Text = post.Text;

            return poVm;
        }
        public async Task<List<PostViewModel>> GetAllMyPost()
        {
            var mypostlist = await _ipostRepository.GetAllAsync();

            //var lista = mypostlist.Where(p => p.UserId == userViewModel.Id).ToList();
            //TRABAJO PENDIENTE AQUI    
            return mypostlist.Where(p => p.UserId == userViewModel.Id).Select(p => new PostViewModel
            {
                Text = p.Text,
                ImgUrl = p.ImgUrl,
                UserId = p.UserId
            }).ToList();
        }

        Task<PostViewModel> IPostService.GetPostsandDetails(int id)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SavePostViewModel> GetByIdSaveViewModel(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<PostViewModel>> GetAllViewModel()
        {
            throw new NotImplementedException();
        }

        
    }
}
