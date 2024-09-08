﻿using AutoMapper;
using CadastroPets.Application.DTOs;
using CadastroPets.Application.Interfaces;
using CadastroPets.Domain.Entities;
using CadastroPets.Infrastructure.Interfaces;

namespace CadastroPets.Application.Services
{
    public class UserService : IUserService
    {
        #region Properties

        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        #endregion

        #region Constructors

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        #endregion

        #region Queries

        public UserDto GetUserById(int id)
        {
            var user = _userRepository.GetByIdAsync(id);
            var userDto = _mapper.Map<UserDto>(user);
            return userDto;
        }

        #endregion

        #region Persistence

        public async Task<int> CreateUserAsync(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await _userRepository.AddAsync(user);
            return user.Id;
        }

        #endregion
    }
}
