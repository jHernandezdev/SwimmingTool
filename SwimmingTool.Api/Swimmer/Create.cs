using MinimalApi.Endpoint;
using SwimmingTool.Domain;

namespace SwimmingTool.Api.Swimmer
{
    public class Create : IEndpoint<IResult, CreateSwimmerCommand>
    {
        private IAsyncRepository<Domain.Swimmer, int> _swimmerRepository;
        public void AddRoute(IEndpointRouteBuilder app)
        {
            app.MapPost("/swimmers", async (CreateSwimmerCommand command, IAsyncRepository<Domain.Swimmer, int> swimmerRepository) =>
            {
                _swimmerRepository = swimmerRepository;
                return await HandleAsync(command);
            })
                .Produces<SwimmerCreateRespone>()
                .WithTags("SwimmersApi");
        }

        public async Task<IResult> HandleAsync(CreateSwimmerCommand command)
        {
            var swimmer = Domain.Swimmer.CreateSwimmer(command.Name, command.category);
            await _swimmerRepository.AddAsync(swimmer, new CancellationToken());
            var response = new SwimmerCreateRespone(swimmer.Id, swimmer.Name, swimmer.Category);
            return Results.Created($"/swimmers/{swimmer.Id}", response);

        }
    }
}
