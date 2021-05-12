using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.ch07
{
    public interface IWeakConnectedComponentsFinder
    {
        public IEnumerable<ISet<TVertex>> Find<TVertex>(IGraph<TVertex> graph) where TVertex : notnull;
    }
}
