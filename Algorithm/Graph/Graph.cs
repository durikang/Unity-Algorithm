using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    class Graph
    {
        public int[,] Adj1 { get; private set; }
        public List<int>[] Adj2 { get; private set; }

        public void SetAdj(int[,] _arr1)
        {
            this.Adj1 = _arr1;
        }
        public void SetAdj(List<int>[] _adj2)
        {
            this.Adj2 = _adj2;
        }

        bool[] visited = new bool[6];
        // 1) 우선 now부터 방문하고,
        // 2) now와 연결된 정점들을 하나씩 확인해서, [ 아직 미발변(미방문) 상태라면 ] 방문한다.
        public void DFS(int now)
        {
            Console.WriteLine(now);
            visited[now] = true; // 1) 우선 now부터 방문하고.

            if(Adj1 !=null)
            {
                for (int next = 0; next < 6; next++)
                {
                    if (Adj1[now, next] == 0) // 연결되어 있지 않으면 스킵,
                        continue;
                    if (visited[next]) //이미 방문 했으면 스킵
                        continue;
                    DFS(next);
                }
            }
            else if(Adj2 != null)
            {
                foreach (int next in Adj2[now])
                {
                    if (visited[next]) //이미 방문 했으면 스킵
                        continue;
                    DFS(next);
                }
            }
        }


        internal void Dijikstra(int start)
        {
            bool[] visited = new bool[6];
            int[] distance = new int[6];
            int[] parent = new int[6];
            Array.Fill(distance, Int32.MaxValue);

            distance[start] = 0;
            parent[start] = start;

            while (true)
            {
                // 제일 좋은 후보를 찾는다 (가장 가까이에 있는)

                // 가장 유력한 후보의 거리와 번호를 저장한다.
                int closet = Int32.MaxValue;
                int now = -1;
                for (var i = 0; i < 6; i++)
                {
                    // 이미 방문한 정점은 스킵
                    if (visited[i])
                        continue;
                    //아직 발견(예약)된 적이 없거나, 기존 후보보다 멀리 있으면 스킵
                    if (distance[i] == Int32.MaxValue || distance[i] >= closet)
                        continue;
                    // 여태껏 발견한 가장 유력한 후보라는 의미. 정보를 갱신
                    closet = distance[i];
                    now = i;
                }
                //다음 후보가 하나도 없다. -> 종료
                if (now == -1)
                    break;
                // 제일 좋은 후보를 찾았으니까 방문한다.
                visited[now] = true;

                //방문한 정점과 인접한 정점들을 조사해서, 상황에 따라 발견한 최단 거리를 갱신.
                for(var next = 0; next < 6; next++)
                {
                    //연결되지 않은 정점 스킵
                    if (Adj1[now, next] == -1)
                        continue;
                    //이미 방문한 정점은 스킵
                    if (visited[next])
                        continue;

                    //새로 조사된 정점의 최단 거리를 계산
                    int nextDist = distance[now] + Adj1[now,next];
                    //만약에 기존에 발견한 최단거리가 새로 조사된 최단거리보다 크면, 정보를 갱신
                    if(nextDist < distance[next])
                    {
                        distance[next] = nextDist;
                        parent[start] = now;
                    }
                    

                }
            }
        }

        public void BFS(int start)
        {
            bool[] found = new bool[6];
            int[] parent = new int[6];
            int[] distance = new int[6];

            var q = new Queue<int>();
            q.Enqueue(start);
            found[start] = true;
            parent[start] = start;
            distance[start] = 0;

            while (q.Count > 0)
            {
                int now = q.Dequeue();
                Console.WriteLine($"이동 경로 : {now}");

                if (Adj1 != null)
                {
                    for(int next = 0; next < 6; next++)
                    {
                        // 인접하지 않음(인접하는 노드가 없을 경우)
                        if (Adj1[now, next] == 0)
                            continue;//스킵
                        if (found[next]) //이미 발견했으면(true)
                            continue;//스킵
                        q.Enqueue(next);
                        found[next] = true;
                        parent[next] = now;
                        distance[next] = distance[now] + 1;
                    }
                }
            }
            Console.WriteLine("부모노드");
            for(var i =0;i<parent.Length;i++)
            {
                Console.WriteLine($"parent[{i}] : {parent[i]}");
            }
            Console.WriteLine("거리");
            for(var i =0; i<distance.Length;i++)
            {
                Console.WriteLine($"distance[{i}] : {distance[i]}");
            }

        }

        public void SearchAll()
        {
            visited = new bool[6];
            for (var now = 0; now < 6; now++)
            {
                if (visited[now] == false)
                    DFS(now);
            }
        }
    }
}
