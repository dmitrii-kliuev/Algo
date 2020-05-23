namespace Queue
{
    public class LinkedListNode<T>
    {
        public LinkedListNode<T> Prev;
        public LinkedListNode<T> Next;

        public T Value { get; internal set; }

        public LinkedListNode(T value)
        {
            Value = value;
        }
    }
}
