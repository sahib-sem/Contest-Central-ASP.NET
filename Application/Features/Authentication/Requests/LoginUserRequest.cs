using Application.Dto.Authentication.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authentication.Requests
{
    public class LoginUserRequest : IRequest<LoginResponseDto>
    {
        public LoginUserDto LoginUserDto { get; set; } = null!;
    }
}
