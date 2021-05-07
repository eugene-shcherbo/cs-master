using Algorithms.common.extenstions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.ch07
{
    public class AdjacencyListGraph<TVertex> : IGraph<TVertex> where TVertex : notnull
    {
        private readonly IEqualityComparer<TVertex> vertexComparer;
        private readonly Dictionary<TVertex, List<Edge<TVertex>>> adjacencyLists;

        public AdjacencyListGraph(IEqualityComparer<TVertex>? vertexComparer = null)
        {
            this.vertexComparer = vertexComparer ?? EqualityComparer<TVertex>.Default;
            adjacencyLists = new(this.vertexComparer);
        }

        public int Size => adjacencyLists.Keys.Count;

        public IEnumerable<TVertex> Vertices => adjacencyLists.Keys;

        public void Add(TVertex vertex)
        {
            if (!adjacencyLists.ContainsKey(vertex))
            {
                adjacencyLists.Add(vertex, new());
            }
        }

        public void Connect(TVertex start, TVertex end)
        {
            Add(start);
            Add(end);

            if (Connected(start, end))
            {
                return;
            }

            var newEdge = new Edge<TVertex>(start, end);
            adjacencyLists[start].Add(newEdge);
        }

        public bool Connected(TVertex start, TVertex end)
        {
            if (!adjacencyLists.ContainsKey(start) || !adjacencyLists.ContainsKey(end))
            {
                return false;
            }

            List<Edge<TVertex>> adjList = adjacencyLists[start];

            foreach (Edge<TVertex> edge in adjList)
            {
                if (edge.Start.SameAs(start, vertexComparer) && edge.End.SameAs(end, vertexComparer))
                {
                    return true;
                }
            }

            return false;
        }

        public IEnumerable<TVertex> GetNeighbours(TVertex vertex)
        {
            if (!adjacencyLists.ContainsKey(vertex))
            {
                throw new ArgumentException($"Vertex {vertex} is not in the graph");
            }

            return adjacencyLists[vertex].Select(e => e.End);
        }

        public IEnumerable<Edge<TVertex>> GetOutgoingEdges(TVertex vertex)
        {
            if (!adjacencyLists.ContainsKey(vertex))
            {
                throw new ArgumentException($"Vertex {vertex} is not in the graph");
            }

            return adjacencyLists[vertex];
        }
    }
}