using System;
using System.Collections.Generic;
using System.Linq;


namespace lab2
{
    class TreeBasedOnArray
    {
        public NodeTreeBasedOnArray Root { get; set; }


        private NodeTreeBasedOnArray[] array = null;

        public int _Root { get; set; } = -1;

        public NodeTreeBasedOnArray Make()
        {
            NodeTreeBasedOnArray prev = null, t;
            bool find;
            int key;
            if (Root == null)
            {
                Console.Write("Введите значение ключа корня дерева: ");
                key = int.Parse(Console.ReadLine());
                Root = List(key);
                array = new NodeTreeBasedOnArray[1];
                array[array.Length - 1] = Root;
                _Root = 0;
            }

            Console.WriteLine("Добавление узлов дерева...");
            while (true)
            {
                Console.Write("Введите ключ нового узла дерева (-1 если достаточно): ");
                key = int.Parse(Console.ReadLine());

                if (key < 0) break;
                t = Root;
                find = false;
                while (t != null && !find)
                {
                    prev = t;
                    if (key == t.Key)
                        find = true;
                    else if (key < t.Key)
                    {
                        if (t.Left == int.MinValue)
                            t = null;
                        else
                            t = array[t.Left];
                    }
                    else
                    {
                        if (t.Right == int.MinValue)
                            t = null;
                        else
                            t = array[t.Right];
                    }
                }

                if (!find)
                {
                    t = List(key);
                    Array.Resize(ref array, array.Length + 1);
                    array[array.Length - 1] = t;

                    if (key < prev.Key)
                        prev.Left = array.Length - 1;
                    else
                        prev.Right = array.Length - 1;
                }
            }

            return Root;
        }

        public NodeTreeBasedOnArray List(int key)
        {
            return new NodeTreeBasedOnArray(key);
        }

        public void Task(NodeTreeBasedOnArray t)
        {
            
        }

        public void Watch(NodeTreeBasedOnArray t, int level = 0)
        {
            if (t != null)
            {
                if (t.Right == int.MinValue)
                    Watch(null, level + 1);
                else
                    Watch(array[t.Right], level + 1);

                for (int i = 0; i < level; i++)
                    Console.Write("    ");
                Console.WriteLine("{0}", t.Key);

                if (t.Left == int.MinValue)
                    Watch(null, level + 1);
                else
                    Watch(array[t.Left], level + 1);
            }
        }

        public NodeTreeBasedOnArray Search(int key)
        {
            NodeTreeBasedOnArray searchTreeNode, prevSearchTreeNode;
            searchTreeNode = Root;
            prevSearchTreeNode = null;

            while (searchTreeNode != null && searchTreeNode.Key != key)
            {
                prevSearchTreeNode = searchTreeNode;
                if (searchTreeNode.Key > key)
                {
                    if (searchTreeNode.Left == int.MinValue)
                        searchTreeNode = null;
                    else
                        searchTreeNode = array[searchTreeNode.Left];
                }
                else
                {
                    if (searchTreeNode.Right == int.MinValue)
                        searchTreeNode = null;
                    else
                        searchTreeNode = array[searchTreeNode.Right];
                }
            }

            if (searchTreeNode == null)
            {
                Console.WriteLine("Узел дерева с таким ключом не найден!");
                return Root;
            }
            else
            {
                Console.WriteLine("Узел дерева с заданным ключом найден");
                return searchTreeNode;
            }
        }

        public NodeTreeBasedOnArray Delete(int key)
        {
            NodeTreeBasedOnArray deletedNodeTree = Root, previousNodeTree = Root;
            while (deletedNodeTree.Key != key && deletedNodeTree != null)
            {
                previousNodeTree = deletedNodeTree;

                if (deletedNodeTree.Key > key)
                    deletedNodeTree = deletedNodeTree.Left == int.MinValue ? null : array[deletedNodeTree.Left];
                else
                    deletedNodeTree = deletedNodeTree.Right == int.MinValue ? null : array[deletedNodeTree.Right];
            }

            if (deletedNodeTree == null)
            {
                Console.WriteLine("Узел с таким ключом не найден, удаление невозможно!");
                return Root;
            }

            if (deletedNodeTree.Right == int.MinValue && deletedNodeTree.Left == int.MinValue)
            {
                if (deletedNodeTree == Root)
                    Root = null;
                else if (array[previousNodeTree.Right] == deletedNodeTree)
                {
                    previousNodeTree.Right = int.MinValue;
                }
                else
                {
                    previousNodeTree.Left = int.MinValue;
                }
            }
            else if (deletedNodeTree.Right == int.MinValue)
            {
                if (deletedNodeTree == Root)
                    Root = array[deletedNodeTree.Left];
                else if (previousNodeTree.Right != int.MinValue && array[previousNodeTree.Right] == deletedNodeTree)
                {
                    previousNodeTree.Right = deletedNodeTree.Left;
                }
                else
                {
                    previousNodeTree.Left = deletedNodeTree.Left;
                }
            }
            else if (deletedNodeTree.Left == int.MinValue)
            {
                if (deletedNodeTree == Root)
                    Root = array[deletedNodeTree.Right];
                else if (previousNodeTree.Right != int.MinValue && array[previousNodeTree.Right] == deletedNodeTree)
                {
                    previousNodeTree.Right = deletedNodeTree.Right;
                }
                else
                {
                    previousNodeTree.Left = deletedNodeTree.Right;
                }
            }
            else
            {
                if (Root == deletedNodeTree)
                    Root = array[deletedNodeTree.Right];
                else if (previousNodeTree.Right != int.MinValue && array[previousNodeTree.Right] == deletedNodeTree)
                {
                    previousNodeTree.Right = deletedNodeTree.Right;
                }
                else
                {
                    previousNodeTree.Left = deletedNodeTree.Right;
                }

                NodeTreeBasedOnArray temp = array[deletedNodeTree.Right], insertedNodeTree = array[deletedNodeTree.Left];
                while (true)
                {
                    if (insertedNodeTree.Key > temp.Key)
                    {
                        if (temp.Right != int.MinValue)
                            temp = array[temp.Right];
                        else
                        {
                            temp.Right = Array.FindIndex(array, x => x == insertedNodeTree);
                            break;
                        }
                    }
                    else
                    {
                        if (temp.Left != int.MinValue)
                            temp = array[temp.Left];
                        else
                        {
                            temp.Left = Array.FindIndex(array, x => x == insertedNodeTree);
                            break;
                        }
                    }
                }
            }

            int deleteIndex = Array.FindIndex(array, x => x == deletedNodeTree);
            foreach (NodeTreeBasedOnArray node in array.Where(x => x.Left > deleteIndex))
                node.Left -= 1;
            foreach (NodeTreeBasedOnArray node in array.Where(x => x.Right > deleteIndex))
                node.Right -= 1;

            for (int i = deleteIndex; i < array.Length - 1; i++)
            {
                array[i] = array[i + 1];
            }

            Array.Resize(ref array, array.Length - 1);

            Console.WriteLine("Узел с заданным ключом удален");
            return Root;
        }
    }
}