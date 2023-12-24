using Application.Dto.Authentication.Dto;
using Application.Features.Authentication.Handlers.Commands;
using MediatR;

public class RegisterUserRequest : IRequest<RegisterResponseDto>
{
    public RegisterUserDto RegisterUserDto { get; set; }
}