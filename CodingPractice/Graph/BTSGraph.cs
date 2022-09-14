using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingPractice.Graph
{
    public class BTSGraph 
    {
        private int NodesCount;
        private static int EDGE_DISTANCE = 6;
        Dictionary<int, List<int>> Nodes = new Dictionary<int, List<int>>();
         
        public BTSGraph(int n)
        {
            NodesCount = n;
            Nodes = new Dictionary<int, List<int>>(NodesCount);
        }

        public void AddEdge(int u, int v)
        {
            Nodes.Add(Nodes.Count, new List<int>() { u, v });
        }

        public List<int> GetNeighbors(int node)
        {
            List<int> neighbors = new List<int>();

            for (int i = 0; i < Nodes.Count; i++)
            {
                if (Nodes[i][0] == node)
                {
                    if(!neighbors.Contains(Nodes[i][1]))
                        neighbors.Add(Nodes[i][1]);
                }
                else if (Nodes[i][1] == node)
                {
                    if (!neighbors.Contains(Nodes[i][0]))
                        neighbors.Add(Nodes[i][0]);
                }

            }
          return neighbors;
        }

        public List<int> ShortestReach(int start)
        {
            List<int> distances = Enumerable.Repeat(-1, NodesCount).ToList();
            distances[start] = 0;
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                int node = queue.Dequeue();
                foreach (var neighbor in GetNeighbors(node))                
                {
                    if (distances[neighbor] == -1)
                    {
                        distances[neighbor] = distances[node] + EDGE_DISTANCE;
                        queue.Enqueue(neighbor);
                    }
                }
            }
            return distances;

        }

        public static void Test()
        {
            int queries = int.Parse(Console.ReadLine());

            for (int t = 0; t < queries; t++)
            {
                // Create a graph of size n where each edge weight is 6:
                List<string> enteredLine = Console.ReadLine().Split(' ').ToList();
                // number of node
                int graphSize = 0;
                int.TryParse(enteredLine[0], out graphSize);
                BTSGraph graph = new BTSGraph(graphSize);

                // number of node
                int m = 0;
                int.TryParse(enteredLine[1], out m);

                for (int i = 0; i < m; i++)
                {
                    enteredLine = Console.ReadLine().Split(' ').ToList();
                    int u = int.Parse(enteredLine[0]) - 1;
                    int v = int.Parse(enteredLine[1]) - 1;

                    // add each edge to the graph
                    graph.AddEdge(u, v);
                }

                // Find shortest reach from node s
                enteredLine = Console.ReadLine().Split(' ').ToList();
                int startNode = int.Parse(enteredLine[0]) - 1;
                List<int> distances = graph.ShortestReach(startNode);

                for (int i = 0; i < distances.Count; i++)
                {
                    if (i != startNode)
                    {
                        Console.Write(distances[i]);
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }

}
