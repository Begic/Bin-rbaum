using Binärbaum.Enums;
using ValueType = Binärbaum.Enums.ValueType;

namespace Binärbaum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = new[] { 4, 9, 24, 27, 30, 35, 39, 46, 47, 51, 64, 68, 75, 82, 90 };
            Console.WriteLine("Input: " + string.Join(", ", numbers.Select(x=> x)));

            //Dies ist die Logik zum Binärbaum erstellen.
            var tree = new BinaryTree();
            Node finishedTree = tree.Create(numbers);


            //GetMinValueFromTree gibt den kleinsten Wert vom fertigen Binärbaum(finishedTree) zurück.
            var minNode = tree.GetMinValueFromTree(finishedTree);
            tree.DisplayValuesFromTree(minNode.Id.ToString(), nameof(ValueType.Min));

            //GetMaxValueFromTree gibt den größten Wert vom fertigen Binärbaum(finishedTree) zurück.
            var maxNode = tree.GetMaxValueFromTree(finishedTree);
            tree.DisplayValuesFromTree(maxNode.Id.ToString(), nameof(ValueType.Max));



            //GetNodesSortedDescending gibt vom fertigen Binärbaum eine absteigend sortierte List<int> zurück.
            var nodeDescending = tree.GetNodesSortedDescending(finishedTree);
            tree.DisplaySortedNumbers(numbers, nodeDescending, nameof(SortingType.Descending));

            //GetNodesSortedAscendig gibt vom fertigen Binärbaum eine aufsteigend sortierte List<int> zurück.
            var nodeAscending = tree.GetNodesSortedAscending(finishedTree);
            tree.DisplaySortedNumbers(numbers, nodeAscending, nameof(SortingType.Ascending));





            //In dieser Methode wird ein weiterer Wert hinzugefügt
            var treeWithAddedValue = tree.AddValueToTree(finishedTree, 49);

            //GetNodesSortedDescending gibt vom fertigen Binärbaum eine absteigend sortierte List<int> zurück.
            var nodeDescendingWithAddedValue = tree.GetNodesSortedDescending(treeWithAddedValue);
            tree.DisplaySortedNumbers(numbers, nodeDescendingWithAddedValue, nameof(SortingType.Descending));

            //GetNodesSortedAscendig gibt vom fertigen Binärbaum eine aufsteigend sortierte List<int> zurück.
            var nodeAscendingWithAddedValu = tree.GetNodesSortedAscending(treeWithAddedValue);
            tree.DisplaySortedNumbers(numbers, nodeAscendingWithAddedValu, nameof(SortingType.Ascending));

        }
    }
}