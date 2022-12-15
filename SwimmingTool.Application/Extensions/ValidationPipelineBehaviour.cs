using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SwimmingTool.Application.Swimmers.Commands;
using SwimmingTool.Domain;

namespace SwimmingTool.Application.Extensions;

public static class ValidationPipelineBehaviour
{
    public static IServiceCollection AddValidationPipelineBehaviour(this IServiceCollection services)
    {
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        return services;
    }
}

public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;
    private readonly IAsyncRepository<Swimmer, int> swimmerRepository;

    public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators, IAsyncRepository<Swimmer, int> swimmerRepository)
    {
        _validators = validators;
        this.swimmerRepository = swimmerRepository;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        if (_validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);
            var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
            var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();
            if (failures.Count != 0)
                throw new ValidationException(failures);
        }
        return await next();
    }
}