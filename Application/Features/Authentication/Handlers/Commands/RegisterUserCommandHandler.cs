using Application.Common;
using Application.Contracts;
using Application.Dto.Authentication.Dto;
using Application.Dto.Authentication.Validator;
using Application.Exceptions;
using AutoMapper;
using Domain.Entites;
using MediatR;
using Microsoft.AspNetCore.Identity;
using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authentication.Handlers.Commands
{
    public class RegisterUserRequestHandler : IRequestHandler<RegisterUserRequest, RegisterResponseDto>
    {

        readonly IMapper _mapper;
        private readonly IAuthRepository _authRepository;

        public RegisterUserRequestHandler(IAuthRepository authRepository, IMapper mapper)
        {
            _mapper = mapper;
            _authRepository= authRepository;

        }
        public async Task<RegisterResponseDto> Handle(RegisterUserRequest request, CancellationToken cancellationToken)
        {


            var validator = new RegisterUserDtoValidator();
            var validationResult = await validator.ValidateAsync(request.RegisterUserDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            try
            {
                var registeredUser = await _authRepository.Register(request.RegisterUserDto);
                return _mapper.Map<RegisterResponseDto>(registeredUser);
             
            }
            catch(Exception e)
            {
                Console.WriteLine("???????????????????????????????????????????????????");
                Console.WriteLine(e);
                Console.WriteLine("???????????????????????????????????????????????????");
                throw new Exception("User or Email Already Exists");
            }




        }
    }
}