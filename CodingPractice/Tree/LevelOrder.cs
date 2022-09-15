using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingPractice.Tree
{
    /// <summary>
    /// Tree: Level Order Traversal
    /// https://www.hackerrank.com/challenges/tree-level-order-traversal/problem
    /// </summary>
    public class LevelOrder
    {
        
        private static void PrintLevelOrder(Node root)
        {
            if (root == null)
                return;

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {               
                Node node = queue.Dequeue();
                Console.Write(node.ToString());

                if (node.Left != null)
                    queue.Enqueue(node.Left);

                if (node.Right != null)
                    queue.Enqueue(node.Right);
            }
          
        }

        public static void Test()
        {
            int nodeCount = int.Parse(Console.ReadLine());
            Node root = null;
            var nodesData = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            for (int i = 0; i < nodeCount; i++)
            {
                int data = nodesData[i];
                root = Node.Insert(root, data);
            }
            LevelOrder.PrintLevelOrder(root);            
            Console.ReadLine();
        }

    }
}
