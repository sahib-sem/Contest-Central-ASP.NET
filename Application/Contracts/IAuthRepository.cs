using Application.Dto.Authentication.Dto;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IAuthRepository
    {

         Task<ApplicationUser> Register(RegisterUserDto user);

        //Task<LoginResponseDto> Login(LoginUserDto user);

        // Task<bool> UserExists(string username);

    }
}
