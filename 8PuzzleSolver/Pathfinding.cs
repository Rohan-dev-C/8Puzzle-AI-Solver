using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Failed8PuzzleSolver
{
    internal class Pathfinding<T> where T: IComparable<T>
    { 
    //{
    //      public static List<Vertex<Point>> AStar(Puzzle<int> graph, Vertex<int> starting, Vertex<int> ending, Func<Point, Point, double> Heur)
    //    {
    //        if (starting == null || ending == null || Heur == null)
    //        {
    //            return null;
    //        }
    //        List<Vertex<int>> moves = new List<Vertex<int>>();
    //        PriorityQueue<Vertex<int>, double> priorityQueue = new PriorityQueue<Vertex<int>, double>();
    //        Dictionary<Vertex<int>, double> distances = new Dictionary<Vertex<int>, double>();
    //        Dictionary<Vertex<int>, Vertex<int>> founders = new Dictionary<Vertex<int>, Vertex<int>>();
    //        Vertex<Point> curr = null;

    //        foreach (Vertex<Point> a in graph.Vertices)
    //        {
    //            a.isVisited = false;
    //            a.founder = null;
    //            a.FinalDistance = double.PositiveInfinity;
    //            a.CumulativeDistance = double.PositiveInfinity;
    //        }
    //        starting.FinalDistance = 0;
    //        starting.CumulativeDistance = 0;
    //        priorityQueue.Enqueue(starting, starting.CumulativeDistance);

    //        while (priorityQueue.Count > 0)
    //        {
    //            if (curr == ending)
    //            {
    //                while (curr != null)
    //                {
    //                    moves.Add(curr);
    //                    curr = founders[curr];
    //                }
    //                break;
    //            }
    //            curr = priorityQueue.Dequeue();
    //            if (curr.isVisited)
    //            {
    //                continue;
    //            }
    //            double tentDistance = 0;
    //            foreach (Edge<Point> a in curr.Neighbors)
    //            {
    //                if (a.StartingPoint != curr)
    //                {
    //                    continue;
    //                }
    //                if (!a.EndingPoint.isVisited)
    //                {
    //                    tentDistance = Heur(a.EndingPoint.point, ending.point) + a.Distance;
    //                    if (tentDistance < curr.FinalDistance)
    //                    {
    //                        distances.Add(a.EndingPoint, distances[curr] + a.Distance);
    //                        founders.Add(a.EndingPoint, curr);
    //                        priorityQueue.Enqueue(a.EndingPoint, distances[a.EndingPoint]);
    //                    }
    //                }
    //                a.StartingPoint.isVisited = true;
    //                curr.isVisited = true;
    //            }
    //        }
    //        return moves;
    //    }



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

    }
}
