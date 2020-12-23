using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    class TreeNode<T>
    {
        public T Data { get; set; }
        public List<TreeNode<T>> Children { get; set; } = new List<TreeNode<T>>();

    }
}
