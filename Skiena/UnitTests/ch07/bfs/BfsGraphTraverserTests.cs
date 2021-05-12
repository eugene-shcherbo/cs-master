using Algorithms.ch07;
using Algorithms.ch07.bfs;
using Algorithms.common.extenstions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.ch07.bfs
{
    public class BfsGraphTraverserTests
    {
        [Fact]
        public void TestTraverseTree()
        {
            var bfsTraverser = new BfsGraphTraverser<int>();
            var graph = GetGraph();

            var traverseTree = bfsTraverser.TraverseWeakComponent(graph, 1);

            Assert.Equal(5, traverseTree.GetParent(6));
            Assert.Equal(3, traverseTree.GetParent(4));
            Assert.Equal(2, traverseTree.GetParent(5));
            Assert.Equal(2, traverseTree.GetParent(3));
            Assert.Equal(1, traverseTree.GetParent(2));
            Assert.Equal(1, traverseTree.GetParent(7));
            Assert.Equal(1, traverseTree.GetParent(8));
        }

        private IGraph<int> GetGraph()
        {
            var graph = new AdjacencyListGraph<int>();
            graph.ConnectUndirected(1, 8);
            graph.ConnectUndirected(1, 7);
            graph.ConnectUndirected(1, 2);
            graph.ConnectUndirected(2, 3);
            graph.ConnectUndirected(2, 5);
            graph.ConnectUndirected(3, 5);
            graph.ConnectUndirected(3, 4);
            graph.ConnectUndirected(4, 5);
            graph.ConnectUndirected(5, 6);

            return graph;
        }
    }
}
