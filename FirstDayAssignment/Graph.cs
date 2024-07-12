using FirstDayAssignment;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDayAssignment
{
    public class Vertex<T> where T : IComparable<T>
    {
        public List<Edge<T>> Neighbors { get; set; }
        public int NeighborCount => Neighbors.Count;

        public Vertex(T value)
        {
            this.value = value;
            Neighbors = new List<Edge<T>>();
        }
        public T value; 
    }

    public class VertexWrapper<T> where T : IComparable<T>
    {
        public Vertex<T> vertex;
        public VertexWrapper(Vertex<T> vertex, VertexWrapper<T> prev, double CumulativeDist)
        {
            this.vertex = vertex;
            this.prevWrapper = prev; 
            this.CumulativeDistance = CumulativeDist;
        }
        public VertexWrapper<T> prevWrapper; 
        public Vertex<T> founder;
        public double FinalDistance;
        public double CumulativeDistance;
    }

    public class Edge<T> where T: IComparable<T>
    {
        public Vertex<T> StartingPoint { get; set; }
        public Vertex<T> EndingPoint { get; set; }
        public float Distance { get; set; }

        public Edge(Vertex<T> startingPoint, Vertex<T> endingPoint, float distance)
        {
            StartingPoint = startingPoint;
            EndingPoint = endingPoint;
            Distance = distance;
        }
    }
    internal class Graph<T>
        where T : IComparable<T>
    {

        public List<Vertex<T>> Vertices { get; private set; }
        public int VerticesCount => Vertices.Count;
        public void AddVertex(T vertex)
        {
            Vertex<T> vertex1 = new Vertex<T>(vertex);
            Vertices.Add(vertex1);
        }
        public Graph()
        {
            Vertices = new List<Vertex<T>>();
        }
        public bool AddEdge(T a, T b, float distance)
        {
            Vertex<T> v1 = Search(a);
            Vertex<T> v2 = Search(b);
            v1.Neighbors.Add(new Edge<T>(v1, v2, distance));
            return true;
        }

        public Vertex<T> Search(T value)
        {
            for (int i = 0; i < Vertices.Count; i++)
            {
                if (Vertices[i].value.CompareTo(value) == 0)
                {
                    return Vertices[i];
                }
            }
            return null;
        }


        public VertexWrapper<T> DFSSelection(List<VertexWrapper<T>> vertices, List<VertexWrapper<T>> currPath)
        {
            VertexWrapper<T> node = vertices[^1];
            vertices.Remove(node);
            currPath.Add(node);
            return node;
        }

        public VertexWrapper<T> BFSSelection(List<VertexWrapper<T>> vertices, List<VertexWrapper<T>> currPath) 
        {
            VertexWrapper<T> node = vertices[0];
            vertices.Remove(node);
            currPath.Add(node); 
            return node;
        }

        public VertexWrapper<T> DjikstraSelection(List<VertexWrapper<T>> vertices, List<VertexWrapper<T>> currPath) 
        {
            VertexWrapper<T> node = vertices[0];
            foreach (VertexWrapper<T> v in vertices)
            {
                for (int i = 0; i < v.vertex.NeighborCount; i++)
                {
                    if(node.CumulativeDistance.CompareTo(v.CumulativeDistance) > 0)
                    {
                        node = v; 
                    }
                }
            }
            vertices.Remove(node);
            currPath.Add(node);
            return node; 
        }

        public VertexWrapper<T> AStarSelection(List<VertexWrapper<T>> vertices, Func<VertexWrapper<T>, VertexWrapper<T>, VertexWrapper<T>> heuristic)
        {
            return null; 
        }

        static public double Manhattan(Point point, Point goal)
        {
            double dx = Math.Abs(point.X - goal.X);
            double dy = Math.Abs(point.Y - goal.Y);

            return (dx + dy);
        }
        static public double Euclidian(Point point, Point goal)
        {
            double dx = Math.Abs(point.X - goal.X);
            double dy = Math.Abs(point.Y - goal.Y);

            return Math.Sqrt(dx * dx + dy * dy);
        }
        static public double Chebyshev(Point point, Point goal)
        {
            double dx = Math.Abs(point.X - goal.X);
            double dy = Math.Abs(point.Y - goal.Y);

            return dx + dy + (-2) * Math.Min(dx, dy);
        }
        static public double Octile(Point point, Point goal)
        {
            double dx = Math.Abs(point.X - goal.X);
            double dy = Math.Abs(point.Y - goal.Y);

            return dx + dy + (Math.Sqrt(2) - 2) * Math.Min(dx, dy);
        }

        public List<Vertex<T>> BestFirstSearch(T start, T end, Func<List<VertexWrapper<T>>, List<VertexWrapper<T>>, VertexWrapper<T>> selection)
        {
            HashSet<Vertex<T>> visited = new HashSet<Vertex<T>>();

            Vertex<T> starting = Search(start);
            Vertex<T> ending = Search(end);
            visited.Clear(); 
            List<Vertex<T>> result = new List<Vertex<T>>();
            List<VertexWrapper<T>> Frontier = new List<VertexWrapper<T>>(); 
            List<VertexWrapper<T>> WrapperPath = new List<VertexWrapper<T>>(); 
            VertexWrapper<T> curr = null;
            var temp = new VertexWrapper<T>(starting, null, 0);
            Frontier.Add(temp);
            while (Frontier.Count >= 0)
            {
                curr = selection(Frontier, WrapperPath); 
                visited.Add(curr.vertex); 
                if (curr.vertex == ending)
                {
                    while (curr.prevWrapper != null)
                    {
                        result.Add(curr.vertex);
                        curr = curr.prevWrapper;
                    }
                    return result;
                }
                for (int i = 0; i < curr.vertex.Neighbors.Count; i++)
                {
                    if (!visited.Contains(curr.vertex.Neighbors[i].EndingPoint))
                    {
                        Frontier.Add(new VertexWrapper<T>(curr.vertex.Neighbors[i].EndingPoint, curr, curr.CumulativeDistance + curr.vertex.Neighbors[i].Distance));
                    }
                }
                if (Frontier.Count == 0)
                {
                    while(curr.prevWrapper != null)
                    {
                        result.Add(curr.vertex);
                        curr = curr.prevWrapper; 
                    }
                    return result;
                }
            }
            return null;
        }

            

        public List<Vertex<T>> DFS(T start, T end)
        {
            HashSet<Vertex<T>> visited = new HashSet<Vertex<T>>();

            Vertex<T> vertex1 = Search(start);
            Vertex<T> ending = Search(end);
            Stack<Vertex<T>> stack = new Stack<Vertex<T>>();
            visited.Clear(); 
            List<Vertex<T>> result = new List<Vertex<T>>();
            stack.Push(vertex1);
            Vertex<T> curr = null;
            result.Add(stack.Peek()); 
            while (stack.Count >= 0)
            {
                curr = stack.Pop();
                if (!result.Contains(curr))
                {
                    result.Add(curr);
                }
                visited.Add(curr);
                if (curr == ending)
                {
                    return result;
                }
                for (int i = 0; i < curr.Neighbors.Count; i++)
                {
                    if (!visited.Contains(curr.Neighbors[i].EndingPoint))
                    {
                        stack.Push(curr.Neighbors[i].EndingPoint);
                    }
                }
                if (stack.Count == 0)
                {
                    return result;
                }
            }
            return result;
        }
        public List<Vertex<T>> BFS(T start, T end)
        {
            HashSet<Vertex<T>> visited = new HashSet<Vertex<T>>();

            Vertex<T> vertex1 = Search(start);
            Vertex<T> ending = Search(end);
            Queue<Vertex<T>> q = new Queue<Vertex<T>>();
            visited.Clear(); 
            List<Vertex<T>> result = new List<Vertex<T>>(); 
            q.Enqueue(vertex1);
            result.Add(q.Peek()); 
            Vertex<T> curr = null;
            while (q.Count >= 0)
            {
                curr = q.Dequeue();
                if (!result.Contains(curr))
                {
                    result.Add(curr);
                }
                visited.Add(curr);
                for (int i = 0; i < curr.Neighbors.Count; i++)
                {
                    if (curr == ending)
                    {
                        return result;
                    }
                    if (curr.Neighbors.Count > 0 && !visited.Contains(curr.Neighbors[i].EndingPoint))
                    {
                        q.Enqueue(curr.Neighbors[i].EndingPoint);
                    }
                }
            }
            return result;
        }
        public static List<Vertex<T>> Djikstra(Graph<T> graph, T starting, T ending)
        {
            HashSet<Vertex<T>> visited = new HashSet<Vertex<T>>();

            List<Vertex<T>> path = new List<Vertex<T>>();
            PriorityQueue<Vertex<T>, double> priorityQueue = new PriorityQueue<Vertex<T>, double>();

            Vertex<T> start = graph.Search(starting);
            Vertex<T> end = graph.Search(ending);
            Dictionary<Vertex<T>, double> distances = new Dictionary<Vertex<T>, double>();
            Dictionary<Vertex<T>, Vertex<T>> founders = new Dictionary<Vertex<T>, Vertex<T>>();
            Vertex<T> curr = null;
            foreach (Vertex<T> a in graph.Vertices)
            {
                visited.Clear(); 
            }
            priorityQueue.Enqueue(start, 0);
            distances.Add(start, 0);
            founders.Add(start, null);

            while (priorityQueue.Count > 0)
            {
                if (curr == end)
                {
                    while (curr != null)
                    {
                        path.Add(curr);
                        curr = founders[curr];
                    }
                    break;
                }
                curr = priorityQueue.Dequeue();
                if (visited.Contains(curr) == true)
                {
                    continue;
                }

                visited.Add(curr); 
                foreach (Edge<T> a in curr.Neighbors)
                {
                    if (a.EndingPoint == curr)
                    {
                        continue;
                    }
                    if (!visited.Contains(a.EndingPoint))
                    {
                        if (distances.ContainsKey(a.EndingPoint))
                        {
                            if (distances[curr] + a.Distance < distances[a.EndingPoint])
                            {
                                distances[a.EndingPoint] = distances[curr] + a.Distance;
                                founders[a.EndingPoint] = curr;
                                priorityQueue.Enqueue(a.EndingPoint, distances[a.EndingPoint]);
                            }
                        }
                        else
                        {
                            priorityQueue.Enqueue(a.EndingPoint, distances[curr] + a.Distance);
                            distances.Add(a.EndingPoint, a.Distance + distances[curr]);
                            founders.Add(a.EndingPoint, curr);
                        }

                    }
                }
            }
            return path;
        }

    }
}
