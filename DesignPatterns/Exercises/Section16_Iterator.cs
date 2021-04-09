using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.Exercises.Section16_Iterator
{
    public class Node<T>
    {
        public T Value;
        public Node<T> Left, Right;
        public Node<T> Parent;

        public Node(T value)
        {
            Value = value;
        }

        public Node(T value, Node<T> left, Node<T> right)
        {
            Value = value;
            Left = left;
            Right = right;

            left.Parent = right.Parent = this;
        }

        public IEnumerable<T> PreOrder
        {
            get
            {
                static IEnumerable<Node<T>> Traverse(Node<T> node)
                {
                    yield return node;
                    if(node.Left != null)
                        foreach (var left in Traverse(node.Left))
                            yield return left;
                    if (node.Right != null)
                        foreach (var right in Traverse(node.Right))
                            yield return right;
                }
                return Traverse(this).Select(n => n.Value);
            }
        }
    }
}
