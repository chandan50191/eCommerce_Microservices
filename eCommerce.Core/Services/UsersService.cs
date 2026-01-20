using System;
using AutoMapper;
using eCommerce.Core.DTOs;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServiceContracts;

namespace eCommerce.Core.Services;

internal class UsersService(IUsersRepository usersRepository, IMapper mapper) : IUsersService
{
    private readonly IUsersRepository _usersRepository = usersRepository;
    private readonly IMapper _mapper = mapper;
    public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
    {
        ApplicationUser? user = await _usersRepository.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);

        if(user == null) return null;

        // return new AuthenticationResponse(user.UserID, user.Email, user.PersonName, user.Gender, "token", Success: true);

        return _mapper.Map<AuthenticationResponse>(user) with {Success = true, Token = "token"};
    }

    public async Task<AuthenticationResponse?> Register(RegisterRequest registerRequest)
    {
        // ApplicationUser user = new ApplicationUser()
        // {
        //     PersonName = registerRequest.PersonName,
        //     Email = registerRequest.Email,
        //     Password = registerRequest.Password,
        //     Gender = registerRequest.Gender.ToString()
        // };
       ApplicationUser user = _mapper.Map<ApplicationUser>(registerRequest);

       ApplicationUser? registerUser = await _usersRepository.AddUser(user);

       if(registerUser == null) return null;

       // return new AuthenticationResponse(registerUser.UserID, registerUser.Email, registerUser.PersonName, registerUser.Gender, "token", Success: true);

       return _mapper.Map<AuthenticationResponse>(user) with {Success = true, Token = "token"};
    }
}
