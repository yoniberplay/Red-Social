using Red_Social.Core.Application.Interfaces.Services;
using Red_Social.Core.Application.ViewModels.Friendship;
using Red_Social.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Red_Social.Core.Application.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Red_Social.Core.Application.ViewModels.User;
using Red_Social.Core.Application.Helpers;

namespace Red_Social.Core.Application.Services
{
    public class FriendshipService : GenericService<SaveFriendViewModel, FriendshipViewModel, Friendship>, IFriendship
    {
        private readonly IFriendshipRepository _ifriendRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserViewModel? userViewModel;
        private readonly IMapper _mapper;

        public FriendshipService(IFriendshipRepository ifriendRepository, IHttpContextAccessor httpContextAccessor, IMapper mapper) : base(ifriendRepository, mapper)
        {
            _ifriendRepository = ifriendRepository;
            _httpContextAccessor = httpContextAccessor;
            userViewModel = _httpContextAccessor.HttpContext.Session.Get<UserViewModel>("user");
            _mapper = mapper;
        }

        
    }
}
