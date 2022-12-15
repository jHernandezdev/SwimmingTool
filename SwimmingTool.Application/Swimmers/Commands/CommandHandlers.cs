using MediatR;
using SwimmingTool.Domain;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static SwimmingTool.Application.Swimmers.Commands.V1;

namespace SwimmingTool.Application.Swimmers.Commands;

public class CommandHandlers:
  IRequestHandler<V1.CreateSwimmerCommand, V1.SwimmerCreateRespone>,
  IRequestHandler<V1.CreateSwimmerExtendedCommand, V1.SwimmerCreateRespone>
{
  private readonly IAsyncRepository<Swimmer, int> swimmerRepository;

  public CommandHandlers(IAsyncRepository<Swimmer, int> swimmerRepository)
  {
    this.swimmerRepository = swimmerRepository;
  }

  public async Task<V1.SwimmerCreateRespone> Handle(V1.CreateSwimmerCommand request, CancellationToken cancellationToken)
  {
    var swimmer = Swimmer.CreateSwimmer(request.Name, request.category);

    await swimmerRepository.AddAsync(swimmer, new CancellationToken());

    return new SwimmerCreateRespone(swimmer.Id, swimmer.Name, swimmer.Category);    
  }

  public async Task<V1.SwimmerCreateRespone> Handle(V1.CreateSwimmerExtendedCommand request, CancellationToken cancellationToken)
  {
    var swimmer = Swimmer.CreateSwimmer($"{request.FirstName} {request.LastName}", request.category);

    await swimmerRepository.AddAsync(swimmer, new CancellationToken());

    return new SwimmerCreateRespone(swimmer.Id, swimmer.Name, swimmer.Category);
  }
}
