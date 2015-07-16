using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFS
{
  

       public interface ITagged<TTag>
        {
            TTag Tag { get; set; }
        }

         
        public interface IEdge<TVertex>
        {
            TVertex Source { get; }
            TVertex Target { get; }
        }
        interface IGraph<TVertex>
        {
            IEnumerable<TVertex> GetNeighbours(TVertex v);
        }
     
        public interface IEdgeList<TVertex, TEdge>
        : IList<TEdge>
         where TEdge : IEdge<TVertex>
        {
            /// <summary>
            /// Trims excess allocated space
            /// </summary>
            void TrimExcess();
            /// <summary>
            /// Gets a clone of this list
            /// </summary>
            /// <returns></returns>

            IEdgeList<TVertex, TEdge> Clone();
        }

        public class UndirectedEdge<TVertex>
        : IEdge<TVertex>
        {
            private readonly TVertex source;
            private readonly TVertex target;

            /// <summary>
            /// Initializes a new instance of the <see cref="Edge&lt;TVertex&gt;"/> class.
            /// </summary>
            /// <param name="source">The source.</param>
            /// <param name="target">The target.</param>
            public UndirectedEdge(TVertex source, TVertex target)
            {
                Contract.Requires(source != null);
                Contract.Requires(target != null);
                Contract.Requires(Comparer<TVertex>.Default.Compare(source, target) <= 0);
                Contract.Ensures(this.source.Equals(source));
                Contract.Ensures(this.target.Equals(target));

                this.source = source;
                this.target = target;
            }

            /// <summary>
            /// Gets the source vertex
            /// </summary>
            /// <value></value>
            public TVertex Source
            {
                get { return this.source; }
            }

            /// <summary>
            /// Gets the target vertex
            /// </summary>
            /// <value></value>
            public TVertex Target
            {
                get { return this.target; }
            }

            /// <summary>
            /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
            /// </summary>
            /// <returns>
            /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
            /// </returns>
            public override string ToString()
            {
                return String.Format(
                    "{0}<->{1}",
                    this.Source,
                    this.Target);
            }
        }

        class VertexEdgeDictionary<TVertex, TEdge>
        : Dictionary<TVertex, IEdgeList<TVertex, TEdge>>
        where TEdge : IEdge<TVertex>
        {
            public VertexEdgeDictionary() { }
            public VertexEdgeDictionary(int capacity)
                : base(capacity)
            { }
            public VertexEdgeDictionary(IEqualityComparer<TVertex> vertexComparer)
                : base(vertexComparer)
            { }
            public VertexEdgeDictionary(int capacity, IEqualityComparer<TVertex> vertexComparer)
                : base(capacity, vertexComparer)
            { }


        public VertexEdgeDictionary<TVertex, TEdge> Clone()
            {
                var clone = new VertexEdgeDictionary<TVertex, TEdge>(this.Count);
                foreach (var kv in this)
                    clone.Add(kv.Key, kv.Value.Clone());
                return clone;
            }
        }

        public sealed class EdgeList<TVertex, TEdge>
       : List<TEdge>
       , IEdgeList<TVertex, TEdge>
 
       where TEdge : IEdge<TVertex>
       {
            public EdgeList()
            { }

            public EdgeList(int capacity)
                : base(capacity)
            { }

            public EdgeList(EdgeList<TVertex, TEdge> list)
                : base(list)
            { }

            public EdgeList<TVertex, TEdge> Clone()
            {
                return new EdgeList<TVertex, TEdge>(this);
            }

            IEdgeList<TVertex, TEdge> IEdgeList<TVertex, TEdge>.Clone()
            {
                return this.Clone();
            }

 
        }

        public delegate bool EdgeEqualityComparer<TVertex, TEdge>(TEdge edge, TVertex source, TVertex target)
        where TEdge : IEdge<TVertex>;
        public class UndirectedGraph<TVertex, TEdge> : IGraph<TVertex>
            where TEdge : IEdge<TVertex>
        { 
            private readonly VertexEdgeDictionary<TVertex, TEdge> adjacentEdges;
            private readonly EdgeEqualityComparer<TVertex, TEdge> edgeEqualityComparer;

            private int edgeCount = 0;
            private int edgeCapacity = 6;

            /// <summary>
            /// Gets a value indicating if the vertices of edge match (source, target)
            /// </summary>
            /// <typeparam name="TVertex">type of the vertices</typeparam>
            /// <typeparam name="TEdge">type of the edges</typeparam>
            /// <param name="edge"></param>
            /// <param name="source"></param>
            /// <param name="target"></param>
            /// <returns></returns>
            public static bool SortedVertexEquality<TVertex, TEdge>(
 
                TEdge edge,
                TVertex source,
                TVertex target)
                where TEdge : IEdge<TVertex>
            {
                Contract.Requires(edge != null);
                Contract.Requires(source != null);
                Contract.Requires(target != null);
                Contract.Requires(Comparer<TVertex>.Default.Compare(source, target) <= 0);

                return edge.Source.Equals(source) && edge.Target.Equals(target);
            }

         public static EdgeEqualityComparer<TVertex, TEdge> GetUndirectedVertexEquality<TVertex, TEdge>()
         where TEdge : IEdge<TVertex>
            {
                if (typeof(UndirectedEdge<TVertex>).IsAssignableFrom(typeof(TEdge)))
                    return new EdgeEqualityComparer<TVertex, TEdge>(SortedVertexEquality<TVertex, TEdge>);
                else
                    return new EdgeEqualityComparer<TVertex, TEdge>(UndirectedVertexEquality<TVertex, TEdge>);
            }

         public static bool UndirectedVertexEquality<TVertex, TEdge>(

          TEdge edge,
          TVertex source,
          TVertex target)
          where TEdge : IEdge<TVertex>
            {
                Contract.Requires(edge != null);
                Contract.Requires(source != null);
                Contract.Requires(target != null);

                return (edge.Source.Equals(source) && edge.Target.Equals(target)) ||
                    (edge.Target.Equals(source) && edge.Source.Equals(target));
            }
            public int EdgeCapacity
            {
                get { return this.edgeCapacity; }
                set
                {
                    this.edgeCapacity = value;
                }
            }

            public UndirectedGraph()
                : this(true)
            { }

            public UndirectedGraph(bool allowParallelEdges)
                : this(allowParallelEdges, GetUndirectedVertexEquality<TVertex, TEdge>())
            {
                //this.allowParallelEdges = allowParallelEdges;
            }

            public UndirectedGraph(bool allowParallelEdges, EdgeEqualityComparer<TVertex, TEdge> edgeEqualityComparer)
                : this(allowParallelEdges, edgeEqualityComparer, -1)
            {
            }

            public UndirectedGraph(bool allowParallelEdges, EdgeEqualityComparer<TVertex, TEdge> edgeEqualityComparer, int vertexCapacity)
                : this(allowParallelEdges, edgeEqualityComparer, vertexCapacity, EqualityComparer<TVertex>.Default)
            { }

            public UndirectedGraph(bool allowParallelEdges, EdgeEqualityComparer<TVertex, TEdge> edgeEqualityComparer, int vertexCapacity, IEqualityComparer<TVertex> vertexComparer)
            {
                Contract.Requires(edgeEqualityComparer != null);
                Contract.Requires(vertexComparer != null);

                //this.allowParallelEdges = allowParallelEdges;
                this.edgeEqualityComparer = edgeEqualityComparer;
                if (vertexCapacity > -1)
                    this.adjacentEdges = new VertexEdgeDictionary<TVertex, TEdge>(vertexCapacity, vertexComparer);
                else
                    this.adjacentEdges = new VertexEdgeDictionary<TVertex, TEdge>(vertexComparer);
            }

            public EdgeEqualityComparer<TVertex, TEdge> EdgeEqualityComparer
            {
                get
                {
                    Contract.Ensures(Contract.Result<EdgeEqualityComparer<TVertex, TEdge>>() != null);
                    return this.edgeEqualityComparer;
                }
            }

            private IEdgeList<TVertex, TEdge> AddAndReturnEdges(TVertex v)
            {
                IEdgeList<TVertex, TEdge> edges;
                if (!this.adjacentEdges.TryGetValue(v, out edges))
                    this.adjacentEdges[v] = edges = this.EdgeCapacity < 0
                        ? new EdgeList<TVertex, TEdge>()
                        : new EdgeList<TVertex, TEdge>(this.EdgeCapacity);

                return edges;
            }

            private bool ContainsEdgeBetweenVertices(IEnumerable<TEdge> edges, TEdge edge)
            {
                Contract.Requires(edges != null);
                Contract.Requires(edge != null);

                var source = edge.Source;
                var target = edge.Target;
                foreach (var e in edges)
                    if (this.EdgeEqualityComparer(e, source, target))
                        return true;
                return false;
            }


            public bool AddVerticesAndEdge(TEdge edge)
            {
                var sourceEdges = this.AddAndReturnEdges(edge.Source);
                var targetEdges = this.AddAndReturnEdges(edge.Target);

                if (this.ContainsEdgeBetweenVertices(sourceEdges, edge))
                    return false;

                sourceEdges.Add(edge);
                if (!IsSelfEdge<TVertex, TEdge>(edge))
                    targetEdges.Add(edge);
                this.edgeCount++;
                //this.OnEdgeAdded(edge);

                return true;
            }

            public IEnumerable<TVertex> GetNeighbours(TVertex v)
            {
                IEdgeList<TVertex, TEdge> edges;

                if (this.adjacentEdges.TryGetValue(v, out edges))
                {
                    return edges.Select(q => q.Source.Equals(v) ? q.Target : q.Source).ToList();
                }
                else 
                {
                    return null; 
                }

            }

            public IEdgeList<TVertex, TEdge> GetAdjacentEdges(TVertex v)
            {
                IEdgeList<TVertex, TEdge> edges;

                if (this.adjacentEdges.TryGetValue(v, out edges))
                {
                    return edges;
                }
                else
                {
                    return null;
                }

            }

            public static bool IsSelfEdge<TVertex, TEdge>(
            TEdge edge)
            where TEdge : IEdge<TVertex>
            {
                Contract.Requires(edge != null);
                Contract.Ensures(Contract.Result<bool>() == (edge.Source.Equals(edge.Target)));

                return edge.Source.Equals(edge.Target);
            }
        }
       

    class Program
    {

      public static IEnumerable<TVertex> DepthFirstTraversal<TVertex>(IGraph<TVertex> graph,
      TVertex start)
        {
            var visited = new HashSet<TVertex>();
            var stack = new Stack<TVertex>();

            stack.Push(start);

            while (stack.Count != 0)
            {
                var current = stack.Pop();

                if (!visited.Add(current))
                    continue;

                yield return current;

                var neighbours = graph.GetNeighbours(current).Where(node => !visited.Contains(node));
                 
                foreach (var neighbour in neighbours.Reverse())
                {
                    stack.Push(neighbour);
                }
            }
        }

   //   public static IEnumerable<IEdge<TVertex>> DepthFirstTraversal<TVertex>(IGraph<TVertex> graph,
   //TVertex start)
   //   {
   //       var visited = new HashSet<TVertex>();
   //       var stack = new Stack<TVertex>();

   //       stack.Push(start);

   //       while (stack.Count != 0)
   //       {
   //           var current = stack.Pop();

   //           if (!visited.Add(current))
   //               continue;

   //           yield return current;

   //           var neighbours = graph.GetNeighbours(current).Where(node => !visited.Contains(node));

   //           // If you don't care about the left-to-right order, remove the Reverse
   //           foreach (var neighbour in neighbours.Reverse())
   //           {
   //               stack.Push(neighbour);
   //           }
   //       }
   //   }

        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            UndirectedGraph<int, IEdge<int>> graph = new UndirectedGraph<int, IEdge<int>>();

            using (DataClasses1DataContext database = new DataClasses1DataContext())
            {
                var edges = database.SMConnectivities.Where(q => q.FromObjectID > 0 && q.ConnectivityHWStatus == 1).ToList();

                edges.ForEach(n =>
                {
                    var e = new UndirectedEdge<int>(n.FromObjectID, n.ToObjectID);
                    graph.AddVerticesAndEdge(e);
                });

            }

            stopwatch.Stop();
            Console.WriteLine("Create the graph cost:" + stopwatch.ElapsedMilliseconds);

            Stopwatch stopwatch_1 = new Stopwatch();
            stopwatch_1.Start();
             
            var nodes = DepthFirstTraversal(graph, 1286589);

            stopwatch_1.Stop();
            Console.WriteLine("Find path for {0} from the graph cost:{1}", 1286589, stopwatch_1.ElapsedMilliseconds);


            Stopwatch stopwatch_2 = new Stopwatch();
            stopwatch_2.Start();

            var foundEdges = new EdgeList<int,IEdge<int>> {};

            foreach (var node in nodes)
            {
                var adjacentEdges = graph.GetAdjacentEdges(node);

                foreach(var edge in adjacentEdges)
                {
                    if(!foundEdges.Exists(q=> q.Source.Equals(edge.Source) && q.Target.Equals(edge.Target)||( q.Source.Equals(edge.Target) && q.Target.Equals(edge.Source))))
                         foundEdges.Add(edge);
                }
               
            }

            stopwatch_2.Stop();
            Console.WriteLine("Find edges for {0} from the graph cost:{1}", 1286589, stopwatch_1.ElapsedMilliseconds);
              
            Console.ReadKey();
        }
 
       
         
     
    }
 
}
