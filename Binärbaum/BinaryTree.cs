using Binärbaum.Enums;

namespace Binärbaum;

public class BinaryTree
{
    public Node Create(int[] numbers)
    {
        if (numbers.Any())
        {
            //Hier wird die Mitte rausgesucht.
            var wurzelKnoten = numbers.Length / 2;

            //Unsere Liste mit den Nummern wird nun genau in der Mitte geteilt.
            //Somit bekommen wir von der linken Seite eine liste und von der Rechten Seite.
            var treeLeft = numbers.Take(wurzelKnoten).ToList();
            var treeRight = numbers.TakeLast(wurzelKnoten).ToList();

            //Nun wird ein Selbstaufruf ausgeführt mit jeweils der linken und der rechten Liste.
            //Beim Selbstaufruf werden dann zur richtigen Zeit die Werte gesetzt.
            var node = new Node(numbers[wurzelKnoten])
            {
                LeftNode = Create(treeLeft.ToArray()),
                RightNode = Create(treeRight.ToArray())
            };

            return node;
        }

        return null;
    }

    public Node GetMinValueFromTree(Node finishedTree)
    {
        //Hier wird überprüft ob die Id der Haupt-Node größer ist als die Id des linken Baumes.
        if (finishedTree.LeftNode != null && finishedTree.Id > finishedTree.LeftNode.Id)
        {
            //Hier findet wieder der Selbstaufruf statt.
            return GetMinValueFromTree(finishedTree.LeftNode);
        }

        return finishedTree;
    }

    public Node GetMaxValueFromTree(Node finishedTree)
    {
        //Hier wird überprüft ob die Id der Haupt-Node kleiner ist als die Id des linken Baumes.
        if (finishedTree.RightNode != null && finishedTree.Id < finishedTree.RightNode.Id)
        {
            //Hier findet wieder der Selbstaufruf statt.
            return GetMaxValueFromTree(finishedTree.RightNode);
        }

        return finishedTree;
    }

    public List<int> GetNodesSorted(Node finishedTree, SortingType sortingType)
    {
        var numbers = new List<int>();

        //Hier füge ich die NodeIds zur liste, dabei verwende ich erneut einen Selbstaufruf.
        if (finishedTree.LeftNode != null)
        {
            numbers.AddRange(GetNodesSorted(finishedTree.LeftNode, sortingType));
        }
        if (finishedTree.RightNode != null)
        {
            numbers.AddRange(GetNodesSorted(finishedTree.RightNode, sortingType));
        }

        //Meine eigene Id von der Node muss ich ebenfalls abspeichern.
        numbers.Add(finishedTree.Id);

        //Hier habe ich mittels einem enum's die Sortierung gelöst.
        if (sortingType == SortingType.Ascending)
        {
            return numbers.Distinct().OrderBy(x => x).ToList();
        }
        return numbers.Distinct().OrderByDescending(x => x).ToList();
    }

    public void DisplaySortedNumbers(int[] numbers, List<int> nodeAscending, string sortingName)
    {
        Console.WriteLine("Sortierung-" + sortingName +": "+ string.Join(", ", nodeAscending.Select(x => x)));
    }

    public void DisplayValuesFromTree(string nodeId, string valueType)
    {
        Console.WriteLine(valueType + ": " + nodeId);
    }
}