using Application.Contracts;
using Application.Dto.Authentication.Dto;
using Application.Dto.Authentication.Validator;
using Application.Exceptions;
using Application.Features.Authentication.Requests;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authentication.Handlers.Queries
{
    public class LoginUserRequestHanlder : IRequestHandler<LoginUserRequest, LoginResponseDto>
    {

        // readonly IAuthRepository _authRepository;
        private readonly IAuthRepository _authRepository;
        readonly IMapper _mapper;
 
        public LoginUserRequestHanlder(IAuthRepository authRepository, IMapper mapper)
        {
          
            _authRepository = authRepository;
            _mapper = mapper;
 
        }
        public async Task<LoginResponseDto> Handle(LoginUserRequest request, CancellationToken cancellationToken)
        {
            var validator = new LoginUserDtoValidator();
            var validationResult = await validator.ValidateAsync(request.LoginUserDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }
            try
            {
                //var res = await _authRepository.Login(request.LoginUserDto);
                return new LoginResponseDto();
            }

            catch(Exception e)
            {
                throw new Exception("Failed to Login");
            }
            


        }   
    }
}
