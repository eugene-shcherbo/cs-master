using Algorithms.common.extenstions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.ch07
{
    public class TraverseTree<TVertex> where TVertex : notnull
    {
        private readonly Dictionary<TVertex, TVertex> parents;
        private readonly TVertex root;

        public TraverseTree(TVertex root)
        {
            this.root = root;
            parents = new();
        }

        public TVertex? GetParent(TVertex child)
        {
            if (!parents.ContainsKey(child))
            {
                throw new ArgumentException($"There is no {nameof(child)} vertex in the tree");
            }

            if (IsRoot(child))
            {
                return default;
            }

            return parents[child];
        }

        public bool IsRoot(TVertex vertex) => vertex.Equals(root!);

        public void Add(TVertex parent, TVertex child)
        {
            if (parents.ContainsKey(child))
            {
                return;
            }

            parents.Add(child, parent);
        }
    }
}
