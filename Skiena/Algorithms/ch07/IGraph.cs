using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.ch07
{
    public interface IGraph<TVertex> where TVertex : notnull
    {
        IEnumerable<TVertex> GetNeighbours(TVertex vertex);

        IEnumerable<Edge<TVertex>> GetOutgoingEdges(TVertex vertex);

        bool Connected(TVertex start, TVertex end);

        int Size { get; }

        void Add(TVertex vertex);

        void Connect(TVertex start, TVertex end);

        IEnumerable<TVertex> Vertices { get; }
    }
}
