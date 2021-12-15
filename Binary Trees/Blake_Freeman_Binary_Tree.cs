using System;

namespace Binary_Trees
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree(1);

            for (int i = 0; i < 10000; i++)
            {
                tree.AddNode(i);
            }

            tree.DisplayAllChildren(tree.rootNode);
            Console.ReadLine();
        }

        public class BinaryTree
        {
            public Node rootNode { get; set; }
            Node currentNode { get; set; }
            int totalDepth = 0;

            public BinaryTree(int rootData)
            {
                rootNode = new Node(rootData);
                currentNode = rootNode;
            }

            public void AddNode(int data)
            {
                Node nodeToInsert = new Node(data);
                if(currentNode.left == null)
                {
                    currentNode.left = nodeToInsert;
                }
                else
                {
                    if(currentNode.right == null)
                    {
                        currentNode.right = nodeToInsert;
                    }
                }

                if(currentNode.right != null && currentNode.left != null)
                {
                    currentNode = currentNode.left;
                }
            }

            public int GetSumOfDepths()
            {
                int nodeDepth = 0;
                currentNode = rootNode;

                while (currentNode.left != null && currentNode.right != null)
                {
                    if (currentNode.left != null)
                    {
                        nodeDepth++;
                    }
                    if (currentNode.right != null)
                    {
                        nodeDepth++;
                        GetNodeDepth(currentNode.right);
                    }

                    currentNode = currentNode.left;
                }

                totalDepth += nodeDepth;

                return totalDepth;
            }

            private int GetNodeDepth(Node node)
            {
                int nodeDepth = 0;
                while(node.left != null && node.right != null)
                {
                    if(node.left != null)
                    {
                        nodeDepth++;
                        node = node.left;
                    }
                }

                return nodeDepth;
            }

            public void DisplayAllChildren(Node node)
            {
                Node nodeToDisplay = node;
                Console.WriteLine(nodeToDisplay.data);

                while (nodeToDisplay.left != null && nodeToDisplay.right != null)
                {
                    if (nodeToDisplay.left != null)
                    {
                        Console.WriteLine(nodeToDisplay.left.data);
                    }
                    if (nodeToDisplay.right != null)
                    {
                        DisplayAllChildren(nodeToDisplay.right);
                    }
                    nodeToDisplay = nodeToDisplay.left;
                }
            }
        }

        public class Node
        {
            public int data;
            public Node left { get; set; }
            public Node right { get; set; }

            public Node(int Data)
            {
                data = Data;
            }
            public void SetData(int Data)
            {
                data = Data;
            }
            public int GetData()
            {
                return data;
            }
        }
    }
}
