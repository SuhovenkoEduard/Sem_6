using System;

namespace lab2
{
    class Tree
    {
        private NodeTree Root { get; set; }

        public static int k = 0;

        public NodeTree Make()
        {
            NodeTree prev = null, t;
            bool find;
            int key;
            if (Root == null)
            {
                Console.Write("Введите значение ключа корня дерева: ");
                key = int.Parse(Console.ReadLine());
                Root = List(key);
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
                        t = t.Left;
                    else
                        t = t.Right;
                }

                if (!find)
                {
                    t = List(key);
                    if (key < prev.Key)
                        prev.Left = t;
                    else
                        prev.Right = t;
                }
            }

            return Root;
        }

        public NodeTree List(int key)
        {
            return new NodeTree(key);
        }

        public void Watch(NodeTree t, int level = 0)
        {
            if(t != null)
            {
                Watch(t.Right, level + 1);
                for (int i = 0; i < level; i++) Console.Write("    ");
                Console.WriteLine("{0}", t.Key);
                Watch(t.Left, level + 1);
            }
        }

        public NodeTree Search(int key)
        {
            NodeTree searchTreeNode, prevSearchTreeNode;
            searchTreeNode = Root;
            prevSearchTreeNode = null;

            while(searchTreeNode != null && searchTreeNode.Key != key)
            {
                prevSearchTreeNode = searchTreeNode;
                if (searchTreeNode.Key > key)
                    searchTreeNode = searchTreeNode.Left;
                else
                    searchTreeNode = searchTreeNode.Right;
            }

            if(searchTreeNode == null)
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

        public NodeTree Delete(int key)
        {
            NodeTree deletedNodeTree = Root, previousNodeTree = Root;
            while(deletedNodeTree.Key != key && deletedNodeTree != null)
            {
                previousNodeTree = deletedNodeTree;

                if (deletedNodeTree.Key > key)
                    deletedNodeTree = deletedNodeTree.Left;
                else
                    deletedNodeTree = deletedNodeTree.Right;
            }

            if(deletedNodeTree == null)
            {
                Console.WriteLine("Узел с таким ключом не найден, удаление невозможно!");
                return Root;
            }

            if(deletedNodeTree.Right == null && deletedNodeTree.Left == null)
            {
                if (deletedNodeTree == Root)
                    Root = null;
                else if (previousNodeTree.Right == deletedNodeTree)
                {
                    previousNodeTree.Right = null;
                }
                else
                {
                    previousNodeTree.Left = null;
                }
            }
            else if (deletedNodeTree.Right == null)
            {
                if (deletedNodeTree == Root)
                    Root = deletedNodeTree.Left;
                else if (previousNodeTree.Right == deletedNodeTree)
                {
                    previousNodeTree.Right = deletedNodeTree.Left;
                }
                else
                {
                    previousNodeTree.Left = deletedNodeTree.Left;
                }
            }
            else if (deletedNodeTree.Left == null)
            {
                if (deletedNodeTree == Root)
                    Root = deletedNodeTree.Right;
                else if (previousNodeTree.Right == deletedNodeTree)
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
                    Root = deletedNodeTree.Right;
                else if (previousNodeTree.Right == deletedNodeTree)
                {
                    previousNodeTree.Right = deletedNodeTree.Right;
                }
                else
                {
                    previousNodeTree.Left = deletedNodeTree.Right;
                }

                NodeTree temp = deletedNodeTree.Right, insertedNodeTree = deletedNodeTree.Left;
                while (true)
                {
                    if (insertedNodeTree.Key > temp.Key)
                    {
                        if (temp.Right != null)
                            temp = temp.Right;
                        else
                        {
                            temp.Right = insertedNodeTree;
                            break;
                        }
                    }
                    else
                    {
                        if (temp.Left != null)
                            temp = temp.Left;
                        else
                        {
                            temp.Left = insertedNodeTree;
                            break;
                        }
                    }
                }
            }


            Console.WriteLine("Узел с заданным ключом удален");
            return Root;
        }

        public bool isLeaf(NodeTree node)
        {
            if (node.Left == null && node.Right == null)
            {
                return true;
            }
            return false;
        }

        public int SumValues(NodeTree node)
        {
            if (node == null) return 0;
            return SumValues(node.Left) + SumValues(node.Right) + node.Key;
        }

        public int GetSize(NodeTree node)
        {
            if (node == null) return 0;
            return GetSize(node.Left) + GetSize(node.Right) + 1;
        }

        public double CalcAverageValue(NodeTree root) => (double) SumValues(root) / GetSize(root);

        public int height(NodeTree node)
        {
            if (node == null)
            {
                return 0;
            }
            else
            {
                int lheight = height(node.Left);
                int rheight = height(node.Right);
                if (lheight > rheight)
                {
                    return (lheight + 1);
                }
                else
                {
                    return (rheight + 1);
                }
            }
        }
    }
}
