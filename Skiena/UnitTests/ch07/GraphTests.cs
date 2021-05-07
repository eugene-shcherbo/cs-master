using Algorithms.ch07;
using Algorithms.ch07.bfs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.ch07
{
    public abstract class GraphTests
    {
        [Fact]
        public void TestAddVertices()
        {
            IGraph<int> graph = GetGraph();

            Assert.Equal(0, graph.Size);

            graph.Add(1);
            graph.Add(2);
            graph.Connect(3, 4);

            Assert.Equal(4, graph.Size);
        }

        [Fact]
        public void TestConnectivity()
        {
            IGraph<int> graph = GetGraph();

            graph.Connect(1, 7);
            graph.Add(6);

            Assert.True(graph.Connected(1, 7));
            Assert.False(graph.Connected(7, 1));
            Assert.False(graph.Connected(6, 1));
        }

        [Fact]
        public void TestNeighbours()
        {
            IGraph<int> graph = GetGraph();

            graph.Connect(1, 7);
            graph.Connect(7, 1);
            graph.Connect(1, 2);
            graph.Connect(1, 8);

            Assert.Equal(new[] { 7, 2, 8 }, graph.GetNeighbours(1));
            Assert.Equal(new[] { 1 }, graph.GetNeighbours(7));
            Assert.Equal(Array.Empty<int>(), graph.GetNeighbours(2));
        }

        protected abstract IGraph<int> GetGraph();
    }
}
