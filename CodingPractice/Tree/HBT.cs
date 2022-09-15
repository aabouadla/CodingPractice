using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingPractice.Tree
{
    /// <summary>
    /// Tree: Height of a Binary Tree
    /// </summary>
    public static class HBT
    {
        public static int GetHeight(Node root)
        {
            if (root == null)
                return -1;

            int leftHight = GetHeight(root.Left);
            int rightHight = GetHeight(root.Right);
            
            if (leftHight > rightHight)
            { return leftHight + 1; }
            else { return rightHight + 1; }
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
            int height = HBT.GetHeight(root);
            Console.WriteLine(height);
            Console.ReadLine();
        }
    }
}
