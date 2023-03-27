using FluentValidation;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace SwimmingTool.Application.Swimmers.Commands;

public static class V1
{
    public record CreateSwimmerExtendedCommand(string FirstName, string LastName, string category) : IRequest<SwimmerCreateRespone>;    
    public record CreateSwimmerCommand(string Name, string category) : IRequest<SwimmerCreateRespone>;
    public record SwimmerCreateRespone(int Id, string Name, string Category);


    public class CreateSwimmerCommandValidator : AbstractValidator<CreateSwimmerCommand>
    {
        public CreateSwimmerCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(100);
        }
    }

    public class CreateSwimmerExtendedCommandValidator : AbstractValidator<CreateSwimmerExtendedCommand>
    {
        public CreateSwimmerExtendedCommandValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.LastName)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}