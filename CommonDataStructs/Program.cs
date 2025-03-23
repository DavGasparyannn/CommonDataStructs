using CommonDataStructs.Structs;
using CommonDataStructs.Structs.Lists;


namespace CommonDataStructs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyList<int> list = new MyList<int>();
            List<int> list2 = new List<int>();
            LinkedList<int> ints = new LinkedList<int>();
            DoublyLinkedList<int> doublyLinkedList = new DoublyLinkedList<int>();
            doublyLinkedList.AddStart(1);
            doublyLinkedList.AddStart(2);
            doublyLinkedList.AddStart(3);
            doublyLinkedList.AddStart(4);
            doublyLinkedList.AddStart(5);
            foreach (var item in doublyLinkedList)
            {
                Console.WriteLine(item);
            }
            /*list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            list.Add(6);
            list.Add(7);
            list.Add(8);
            list.Remove(0);

            list.Add(9);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }*/
        }
    }
}
