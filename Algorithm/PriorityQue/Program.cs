using System;
using System.Diagnostics.CodeAnalysis;

namespace PriorityQue
{
    public enum Sort
    {
        Ascending,
        Descending
    }

    class Knight : IComparable<Knight>
    {
        public Sort sort { get; set; }

        public int Id { get; set; }

        public int CompareTo([AllowNull] Knight other)
        {
            if (Id == other.Id)
                return 0;
            return Id > other.Id ? 1 : -1;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var q = new PriorityQue<Knight>();
            
            q.Push(new Knight() { Id = 20 });
            q.Push(new Knight() { Id = 10 });
            q.Push(new Knight() { Id = 30 });
            q.Push(new Knight() { Id = 90 });
            q.Push(new Knight() { Id = 40 });
            
            while(q.Count() > 0)
            {
                Console.WriteLine(q.Pop().Id);
            }
        }
    }
}
