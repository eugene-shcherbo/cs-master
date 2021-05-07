using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.ch07
{
    public interface IGraphTraverser<TVertex> where TVertex : notnull
    {
        TraverseTree<TVertex> TraverseWeakComponent(
            IGraph<TVertex> graph,
            TVertex root,
            IGraphTraverseProcessor<TVertex>? processor = null);
    }
}