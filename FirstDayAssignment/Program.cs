namespace FirstDayAssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Graph<int> graph1 = new Graph<int>();
            Random rand = new Random(45); 

            for (int i = 0; i < 12; i++)
            {
                graph1.AddVertex(i + 1);
            }
            for (int i = 0;i < 12; i++)
            {
                if (i + 1 % 4 != 0)
                {
                    graph1.AddEdge(i + 1, i + 2, rand.Next(0, 10));
                }
                if(i + 1 < 8)
                {
                    graph1.AddEdge(i + 1, i + 5, rand.Next(0, 10));
                }
            }

            List<Vertex<int>> values = graph1.DFS(1, 12);
            List<Vertex<int>> values2 = graph1.BFS(1, 12);
            List<Vertex<int>> values3 = graph1.BestFirstSearch(1, 12, graph1.DjikstraSelection);
            int a = 0; 
        }
    }
}
