using System;
using System.Collections.Generic;

namespace Graph
{
    
    class Program
    {
        #region TreeNode Data

        static TreeNode<string> MakeTree()
        {
            TreeNode<string> root = new TreeNode<string>() { Data = "R1 개발실" };
            {
                {
                    TreeNode<string> node = new TreeNode<string>() { Data = "디자인팀" };
                    node.Children.Add(new TreeNode<string>() { Data = "전투" });
                    node.Children.Add(new TreeNode<string>() { Data = "경제" });
                    node.Children.Add(new TreeNode<string>() { Data = "스토리" });
                    root.Children.Add(node);
                }

                {
                    TreeNode<string> node = new TreeNode<string>() { Data = "프로그래밍팀" };
                    node.Children.Add(new TreeNode<string>() { Data = "서버" });
                    node.Children.Add(new TreeNode<string>() { Data = "클라" });
                    node.Children.Add(new TreeNode<string>() { Data = "엔진" });
                    root.Children.Add(node);
                }

                {
                    TreeNode<string> node = new TreeNode<string>() { Data = "아트팀" };
                    node.Children.Add(new TreeNode<string>() { Data = "배경" });
                    node.Children.Add(new TreeNode<string>() { Data = "캐릭터" });
                    root.Children.Add(node);
                }

            }
            return root;
        }

        //재귀 함수를 이용한 트리 구조 출력
        static void PrintTree(TreeNode<string> root)
        {
            //접근
            Console.WriteLine(root.Data);

            foreach (TreeNode<string> child in root.Children)
                PrintTree(child);
        }
        
        //트리 노드 높이 구하기(재귀활용)
        static int GetHeight(TreeNode<string> root)
        {
            int height = 0;

            foreach(TreeNode<string> child in root.Children)
            {
                int newHeight = GetHeight(child) + 1;
                /*if (height < newHeight)
                    height = newHeight;*/
                // or
                //height = height < newHeight ? newHeight : height;
                // or 
                height = Math.Max(height, newHeight); 
            }

            return height;
        }



        #endregion
       
        static void Main(string[] args)
        {
            // DFS (Depth First Search 깊이 우선 탐색)
            // BFS (Breadth First Search 너비 우선 탐색)
            #region Graph
            /*{
                Graph graph = new Graph();
                var adj1 = new int[6, 6]
                {
                {0, 1, 0, 1, 0, 0 },
                {1, 0, 1, 1, 0, 0 },
                {0, 1, 0, 0, 0, 0 },
                {1, 1, 0, 0, 1, 0 },
                {0, 0, 0, 1, 0, 1 },
                {0, 0, 0, 0, 1, 0 }
                };
                var adj2 = new List<int>[]
                {
                new List<int>() {1,3},
                new List<int>() {0,2,3},
                new List<int>() {1},
                new List<int>() {0,1,4},
                new List<int>() {3,5},
                new List<int>() {4}
                };

                var adj3 = new int[6, 6]
                {
                {-1, 15, -1, 35, -1, -1 },
                {15, -1, 05, 10, -1, -1 },
                {-1, 05, -1, -1, -1, -1 },
                {35, 10, -1, -1, 05, -1 },
                {-1, -1, -1, 05, -1, 05 },
                {-1, -1, -1, -1, 05, -1 }
                };


                graph.SetAdj(adj3);

                graph.Dijikstra(0);

            }*/
            #endregion

            #region TreeNode

            TreeNode<string> root = MakeTree();
            /*PrintTree(root);*/

            Console.WriteLine(GetHeight(root));
            ;

            #endregion

        }
    }
}
