using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwimmingTool.Application.Swimmers.Queries
{
    public class ReadModels
    {
        public record Swimmer (int Id, string Name, string Category);
        public record SwimmersList (IEnumerable<Swimmer> Swimmers);
    }
}