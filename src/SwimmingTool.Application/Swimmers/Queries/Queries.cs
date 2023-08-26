using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace SwimmingTool.Application.Swimmers.Queries
{
    public class Queries
    {
        public record GetSwimmers(): IRequest<ReadModels.SwimmersList>;
    }
}