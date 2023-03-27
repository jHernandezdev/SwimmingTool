using MediatR;
using MinimalApi.Endpoint;
using SwimmingTool.Domain;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static SwimmingTool.Application.Swimmers.Commands.V1;

namespace SwimmingTool.Api.Swimmer;

public class Create :
  IEndpoint<IResult, CreateSwimmerCommand>,
  IEndpoint<IResult, CreateSwimmerExtendedCommand>
{
  private readonly IMediator mediator;

  public Create(IMediator mediator)
  {
    this.mediator = mediator;
  }

  public void AddRoute(IEndpointRouteBuilder app)
  {
    app.MapPost("/swimmers", (CreateSwimmerCommand command) =>
    {
      return HandleAsync(command);
    })
        .Produces<SwimmerCreateRespone>()
        .WithTags("SwimmersApi");

    app.MapPost("/swimmers/extended", (CreateSwimmerExtendedCommand command) =>
    {
      return HandleAsync(command);
    })
        .Produces<SwimmerCreateRespone>()
        .WithTags("SwimmersApi");
  }

  public async Task<IResult> HandleAsync(CreateSwimmerCommand command)
  {
    var result = await mediator.Send(command);
    return Results.Created($"/swimmers/{result.Id}", result);
  }

  public async Task<IResult> HandleAsync(CreateSwimmerExtendedCommand command)
  {
    var result = await mediator.Send(command);
    return Results.Created($"/swimmers/{result.Id}", result);
  }
}