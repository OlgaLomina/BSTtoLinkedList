using System;
using System.Collections.Generic;
using System.Linq;
// Given a BST, create a linkedlist of all the nodes at each depth
namespace Tree1_1
{
    public class Node
    {
        public int data;
        public Node left, right, nextRight;

        public Node()
        {
            data = 0;
            left = right = nextRight = null;
        }
        public Node(int val)
        {
            data = val;
            left = right = nextRight = null;
        }
    }

    public class MyLL
    {
        Node head;

        public MyLL()
        {
            head = null;
        }
        public Node AddTail(int val)
        {
            Node node = new Node(val);
            if (head == null)
            {
                head = node;
            }
            else
            {
                Node curr = head;
                while (curr.nextRight != null)
                {
                    curr = curr.nextRight;
                }
                curr.nextRight = node;
            }
            return node;
        }

        public void PrintNodes()
        {
            Node curr = head;
            while (curr != null)
            {
                Console.WriteLine(curr.data);
                curr = curr.nextRight;
            }
        }
    }

    public class Tree
    {
        public Node root;

        public Tree()
        {
            root = null;
        }

        // Sets nextRight of all nodes of a tree 
        public MyLL BSTtoLinkedList(MyLL list, Node root)
        {
            if (root == null) return null;
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);
            while (q.Count() > 0)
            {
                root = q.Dequeue();
                list.AddTail(root.data);
                if (root.left != null)
                {
                    q.Enqueue(root.left);
                }
                if (root.right != null)
                {
                    q.Enqueue(root.right);
                }
            }
            return list;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Node root = new Node(50);
            root.left = new Node(25);
            root.right = new Node(70);
            root.left.left = new Node(10);
            root.left.right = new Node(40);
            root.right.left = new Node(60);
            root.right.right = new Node(80);

            Tree bst = new Tree();
            MyLL mylist = new MyLL();

            mylist = bst.BSTtoLinkedList(mylist, root);

            mylist.PrintNodes();
        }
    }
}
