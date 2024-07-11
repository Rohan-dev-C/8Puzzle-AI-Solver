using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real8PuzzleSolver
{
    public class GameState
    {
        public int[,] currentState = new int[3, 3];
        public (int, int) currentBlank => GetBlankIndex(currentState);
        public (int, int)[] moveableIndexs => GetMoveAbleIndexes(currentBlank);

        public GameState(int[,] state)
        {
            this.currentState = state; 
        }

        public List<GameState> GenerateNextNeighbors()
        {
            List<GameState> neighbors = new List<GameState>();
            foreach (var index in moveableIndexs)
            {
                int[,] savedCurrentState = (int[,])currentState.Clone();
                var temp = savedCurrentState[index.Item1, index.Item2];
                savedCurrentState[index.Item1, index.Item2] = savedCurrentState[currentBlank.Item1, currentBlank.Item2];
                savedCurrentState[currentBlank.Item1, currentBlank.Item2] = temp;
                neighbors.Add(new GameState(savedCurrentState)); 
            }
            return neighbors;
        }

        public (int, int)[] GetMoveAbleIndexes((int, int) curr)
        {
            (int, int)[] values = new (int, int)[3];
            List<(int, int)> list = new List<(int, int)>(); 
            if(curr.Item1 < 2)
            {
                list.Add((curr.Item1 + 1, curr.Item2)); 
            }
            if (curr.Item1 > 0)
            {
                list.Add((curr.Item1 -1, curr.Item2));
            }
            if (curr.Item2 < 2)
            {
                list.Add((curr.Item1, curr.Item2 + 1));
            }
            if (curr.Item2 > 0)
            {
                list.Add((curr.Item1, curr.Item2 -1));
            }
            values = list.ToArray();
            return values; 
        }

        public (int, int) GetBlankIndex(int[,] current)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (current[i, j] ==  null)
                    {
                        return (i, j); 
                    }
                }
            }
            return (-1, -1); 
        }
    }



    public class GameStateWrapper<T> where T : IComparable<T>
    {
        public GameState vertex;
        public GameStateWrapper(GameState vertex, GameStateWrapper<T> prev, double CumulativeDist)
        {
            this.vertex = vertex;
            this.prevWrapper = prev;
            this.CumulativeDistance = CumulativeDist;
        }
        
        public GameStateWrapper<T> prevWrapper;
        public GameState founder;
        public double FinalDistance;
        public double CumulativeDistance;
    }

    public class Puzzle<T> where T : IComparable<T>
    {
        public List<GameState> Vertices { get; private set; }


        public GameState Search(T value)
        {
            for (int i = 0; i < Vertices.Count; i++)
            {
                if (Vertices[i].currentState.Equals(value))
                {
                    return Vertices[i];
                }
            }
            return null;
        }


        public GameStateWrapper<T> DFSSelection(List<GameStateWrapper<T>> vertices)
        {
            GameStateWrapper<T> node = vertices[^1];
            vertices.Remove(node);
            return node;
        }

        public GameStateWrapper<T> BFSSelection(List<GameStateWrapper<T>> vertices)
        {
            GameStateWrapper<T> node = vertices[0];
            vertices.Remove(node);
            return node;
        }

        public GameStateWrapper<T> DjikstraSelection(List<GameStateWrapper<T>> vertices)
        {
            GameStateWrapper<T> node = vertices[0];
            foreach (GameStateWrapper<T> v in vertices)
            {
                for (int i = 0; i < v.vertex.GenerateNextNeighbors().Count; i++)
                {
                    if (node.CumulativeDistance.CompareTo(v.CumulativeDistance) > 0)
                    {
                        node = v;
                    }
                }
            }
            vertices.Remove(node);
            return node;
        }

        public GameStateWrapper<T> AStarSelection(List<GameStateWrapper<T>> vertices, Func<double, double, doubles> heuristic)
        {
            return vertices[0]; 

        }

        public List<GameState> BestFirstSearch(GameState starting, GameState ending, Func<List<GameStateWrapper<T>>, GameStateWrapper<T>> selection)
        {
            HashSet<GameState> visited = new HashSet<GameState>();
            visited.Clear();
            List<GameState> result = new List<GameState>();
            List<GameStateWrapper<T>> Frontier = new List<GameStateWrapper<T>>();
            GameStateWrapper<T> curr = null;
            var temp = new GameStateWrapper<T>(starting, null, 0);
            Frontier.Add(temp);
            while (Frontier.Count >= 0)
            {
                curr = selection(Frontier);
                if (!result.Contains(curr.vertex))
                {
                    result.Add(curr.vertex);
                }
                visited.Add(curr.vertex);
                if (curr.vertex == ending)
                {
                    return result;
                }
                var currNeighbors = curr.vertex.GenerateNextNeighbors(); 
                for (int i = 0; i < currNeighbors.Count; i++)
                {
                    if (!visited.Contains(currNeighbors[i]))
                    {
                        Frontier.Add(new GameStateWrapper<T>(currNeighbors[i], curr, curr.CumulativeDistance + 1));
                    }
                }
                if (Frontier.Count == 0)
                {
                    return result;
                }
            }
            return null;
        }
    }
}
