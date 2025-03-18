using CommonDataStructs.Structs;


namespace CommonDataStructs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Tree tree = new Tree();
            tree.Insert(5);
            tree.Insert(2);
            tree.Insert(8);
            tree.Insert(1);
            tree.Insert(3);
            Tree newTree = tree.Copy();

            newTree.Delete(3);
            newTree.Print();
            tree.Print();
           
        }
    }
}
