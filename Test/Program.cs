namespace MyLinkedList
{
    public class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public Node<T> Next { get; set; }
    }
    public class LinkedList<T>
    {
        Node<T> head;
        Node<T> tail;

        // добавление элемента
        public void Add(T data)
        {
            Node<T> node = new Node<T>(data);

            if (head == null)
                head = node;
            else
                tail.Next = node;
            tail = node;

        }
        // удаление элемента
        public bool Remove(T data)
        {
            Node<T> current = head;
            Node<T> previous = null;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;
                        if (current.Next == null)
                            tail = previous;
                    }
                    else
                    {
                        head = head.Next;
                        if (head == null)
                            tail = null;
                    }
                    return true;
                }

                previous = current;
                current = current.Next;
            }
            return false;
        }

        // очистка списка
        public void Clear()
        {
            head = null;
            tail = null;
        }
        // содержит ли список элемент
        public bool Contains(T data)
        {
            Node<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }
        // добвление в начало
        public void AppendFirst(T data)
        {
            Node<T> node = new Node<T>(data);
            node.Next = head;
            head = node;
            if (head.Next == null)
                tail = head;
        }
        // разворот
        public void Revert()
        {
            if (head != null && head.Next != null)
            {
                Node<T> temp = head;
                Revert(head.Next, head);
                temp.Next = null;
                head = tail;
            }
        }
        private void Revert(Node<T> currentNode, Node<T> previousNode)
        {
            if (currentNode == null)
                head = currentNode;
            Revert(currentNode, previousNode);
            currentNode.Next = previousNode;
        }
    }
}