using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.ch07
{
    public interface IGraphTraverseProcessor<TVertex> where TVertex : notnull
    {
        // void BeforeTraversingWeakComponent(TVertex vertex);

        void BeforeExploration(TVertex? parent, TVertex vertex);

        void AfterExploration(TVertex? parent, TVertex vertex);

        void ProcessEdge(Edge<TVertex> edge);
    }

    //public interface IGraphTraverseProcessor<TVertex, TContext> where TVertex : notnull
    //{
    //    void BeforeTraversingWeakComponent(TVertex vertex);

    //    void BeforeExploration(TVertex vertex, TContext context);

    //    void AfterExploration(TVertex vertex, TContext context);

    //    void ProcessEdge(Edge<TVertex> edge, TContext context);
    //}
}
