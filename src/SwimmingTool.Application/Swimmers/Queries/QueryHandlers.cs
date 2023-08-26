using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SwimmingTool.Domain;

namespace SwimmingTool.Application.Swimmers.Queries
{
    public class QueryHandlers : IRequestHandler<Queries.GetSwimmers, ReadModels.SwimmersList>
    {
        private readonly IAsyncRepository<Swimmer, int> swimmerRepository;
        public QueryHandlers(IAsyncRepository<Swimmer, int> swimmerRepository)
        {
            this.swimmerRepository = swimmerRepository;
        }

        public async Task<ReadModels.SwimmersList> Handle(Queries.GetSwimmers request, CancellationToken cancellationToken)
        {
            var swimmers = await swimmerRepository.ListAllAsync(cancellationToken);

            ReadModels.SwimmersList swimmersList = new(swimmers.Select(s => new ReadModels.Swimmer(s.Id, s.Name, s.Category)).ToList());
            return swimmersList;
        }
    }
}