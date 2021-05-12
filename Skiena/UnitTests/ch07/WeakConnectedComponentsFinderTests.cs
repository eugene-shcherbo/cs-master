using Algorithms.ch07;
using Algorithms.common.extenstions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.ch07
{
    public abstract class WeakConnectedComponentsFinderTests
    {
        [Fact]
        public void ConnectedGraph()
        {
            IGraph<int> graph = GetConnectedGraph();

            IWeakConnectedComponentsFinder finder = GetFinder();
            IEnumerable<ISet<int>> components = finder.Find(graph);

            Assert.Single(components);
            Assert.Equal(5, components.ElementAt(0).Count);
            Assert.Equal(new[] { 1, 2, 3, 4, 5 }, components.ElementAt(0).OrderBy(v => v));
        }

        [Fact]
        public void DisconnectedGraph()
        {
            IGraph<int> graph = GetDisconnectedGraph();

            IWeakConnectedComponentsFinder finder = GetFinder();
            IEnumerable<ISet<int>> components = finder.Find(graph);

            Assert.Equal(4, components.Count());
            Assert.Equal(new[] { 1, 2, 3, 4, 5 }, components.ElementAt(0).OrderBy(v => v));
            Assert.Equal(new[] { 6, 7, 8 }, components.ElementAt(1).OrderBy(v => v));
            Assert.Equal(new[] { 10, 11 }, components.ElementAt(2).OrderBy(v => v));
            Assert.Equal(new[] { 15 }, components.ElementAt(3).OrderBy(v => v));
        }

        private static IGraph<int> GetConnectedGraph()
        {
            var graph = new AdjacencyListGraph<int>();
            graph.ConnectUndirected(1, 2);
            graph.ConnectUndirected(2, 3);
            graph.ConnectUndirected(4, 5);
            graph.ConnectUndirected(3, 5);

            return graph;
        }

        private static IGraph<int> GetDisconnectedGraph()
        {
            var graph = new AdjacencyListGraph<int>();
            graph.ConnectUndirected(1, 2);
            graph.ConnectUndirected(2, 3);
            graph.ConnectUndirected(4, 5);
            graph.ConnectUndirected(3, 5);

            graph.ConnectUndirected(6, 7);
            graph.ConnectUndirected(7, 8);

            graph.ConnectUndirected(10, 11);

            graph.Add(15);

            return graph;
        }

        protected abstract IWeakConnectedComponentsFinder GetFinder();
    }
}
