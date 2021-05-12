using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.ch07.bfs
{
    public delegate void TraverseAction<TVertex>(TVertex vertex, BfsTraverseSession<TVertex> currentSession) where TVertex : notnull;

    public class BfsTraverseSession<TVertex> where TVertex : notnull
    {
        static readonly TraverseAction<TVertex> defaultAction = (vertex, currentSession) => { };

        readonly BfsProcessor processor = new();
        readonly BfsGraphTraverser<TVertex> traverser = new();
        readonly HashSet<TVertex> discovered = new();
        readonly IGraph<TVertex> graph;
        readonly Dictionary<TVertex, TVertex> parents = new();
        readonly HashSet<TVertex> roots = new();
        
        TraverseAction<TVertex> beforeTraverse = defaultAction;
        TraverseAction<TVertex> afterTraverse = defaultAction;
        TraverseAction<TVertex> beforeExploration = defaultAction;
        TraverseAction<TVertex> afterExploration = defaultAction;

        internal BfsTraverseSession(IGraph<TVertex> graph)
        {
            this.graph = graph;
            processor.session = this;
        }

        public BfsTraverseSession<TVertex> BeforeTraversingComponent(TraverseAction<TVertex>? action)
        {
            beforeTraverse = action ?? beforeTraverse;
            return this;
        }

        public BfsTraverseSession<TVertex> AfterTraversingComponent(TraverseAction<TVertex>? action)
        {
            afterTraverse = action ?? afterTraverse;
            return this;
        }

        public BfsTraverseSession<TVertex> BeforeExploration(TraverseAction<TVertex>? action)
        {
            beforeExploration = action ?? beforeExploration;
            return this;
        }

        public BfsTraverseSession<TVertex> WhenExploringEdge(Action<Edge<TVertex>> action)
        {
            return this;
        }

        public BfsTraverseSession<TVertex> AfterExploration(TraverseAction<TVertex>? action)
        {
            afterExploration = action ?? afterExploration;
            return this;
        }

        public void Run()
        {
            foreach (TVertex vertex in graph.Vertices)
            {
                if (!Discovered(vertex))
                {
                    roots.Add(vertex);
                    beforeTraverse(vertex, this);
                    traverser.TraverseWeakComponent(graph, vertex, processor, discovered);
                    afterTraverse(vertex, this);
                }
            }
        }

        public bool Discovered(TVertex vertex) => discovered.Contains(vertex);

        public bool IsRootOfTraversing(TVertex vertex) => roots.Contains(vertex);

        private class BfsProcessor : IGraphTraverseProcessor<TVertex>
        {
            public BfsTraverseSession<TVertex>? session;

            public void AfterExploration(TVertex parent, TVertex vertex)
            {
                session!.afterExploration(vertex, session);
            }

            public void BeforeExploration(TVertex parent, TVertex vertex)
            {
                session!.parents[vertex] = parent;
                session!.beforeExploration(vertex, session);
            }

            public void ProcessEdge(Edge<TVertex> edge)
            {
            }
        }
    }

    public class BfsTraverseSession
    {
        private BfsTraverseSession() { }

        public static BfsTraverseSession<TVertex> For<TVertex>(IGraph<TVertex> graph) where TVertex : notnull
        {
            return new BfsTraverseSession<TVertex>(graph);
        }
    }
}