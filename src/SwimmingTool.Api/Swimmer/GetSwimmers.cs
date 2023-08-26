using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using MinimalApi.Endpoint;
using SwimmingTool.Application.Swimmers.Queries;

namespace SwimmingTool.Api.Swimmer
{
    public class Query : IEndpoint<IResult, Queries.GetSwimmers, IMediator>
    {
        public void AddRoute(IEndpointRouteBuilder app)
        {
            app.MapGet("swimmers",
            async (IMediator mediator) =>
            {
                return await HandleAsync(new Queries.GetSwimmers(), mediator);
            })
            .Produces<ReadModels.SwimmersList>()
            .WithTags("GetSwimmers");
        }

        public async Task<IResult> HandleAsync(Queries.GetSwimmers request, IMediator mediator)
        {
            return Results.Ok(await mediator.Send(request)); 
        }
    }
}