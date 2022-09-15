using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingPractice.Tree
{
    /// <summary>
    /// Binary Tree Node
    /// </summary>
    public class Node
    {
        public int Data { get; private set; }
        public Node Left { get; set; }
        public Node Right { get; set; }        

        public Node(int data)
        {
            this.Data = data;
        }

        public Node(int data, Node left, Node right)
        {
            this.Data = data;
            this.Left = left;
            this.Right = right;
        }

        public static Node Insert(Node root, int data)
        {
            if (root == null)
            {
                return new Node(data);
            }
            else
            {
                Node cur;
                if (data <= root.Data)
                {
                    cur = Insert(root.Left, data);
                    root.Left = cur;
                }
                else
                {
                    cur = Insert(root.Right, data);
                    root.Right = cur;
                }
                return root;
            }
        }

        public override string ToString()
        {
            return Data.ToString() + " ";
        }
    }
}
