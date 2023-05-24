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

    public Node AddValueToTree(Node finishedTree, int numberToAdd)
    {
        //Falls die Node null ist wird der Wert direkt eingefügt
        if (finishedTree == null)
        {
            return new Node(numberToAdd);
        }

        //Falls der wert größer ist wird er zur rechten Node hinzugefügt.
        if (finishedTree.Id < numberToAdd)
        {
            finishedTree.RightNode = AddValueToTree(finishedTree.RightNode, numberToAdd);
        }
        //Falls der wert kleiner ist wird er zur linken Node hinzugefügt.
        else if (finishedTree.Id > numberToAdd)
        {
            finishedTree.LeftNode = AddValueToTree(finishedTree.LeftNode, numberToAdd);
        }

        return finishedTree;
    }

    public Node GetMinValueFromTree(Node finishedTree)
    {
        //Hier wird überprüft ob die Id der Haupt-Node größer ist als die Id des linken Baumes.
        if (finishedTree.LeftNode != null && finishedTree.Id > finishedTree.LeftNode.Id)
            //Hier findet wieder der Selbstaufruf statt.
            return GetMinValueFromTree(finishedTree.LeftNode);

        return finishedTree;
    }

    public Node GetMaxValueFromTree(Node finishedTree)
    {
        //Hier wird überprüft ob die Id der Haupt-Node kleiner ist als die Id des linken Baumes.
        if (finishedTree.RightNode != null && finishedTree.Id < finishedTree.RightNode.Id)
            //Hier findet wieder der Selbstaufruf statt.
            return GetMaxValueFromTree(finishedTree.RightNode);

        return finishedTree;
    }

    public List<int> GetNodesSortedDescending(Node finishedTree)
    {
        var list = new List<int>();

        if (finishedTree != null)
        {
            //Da eine absteigende Liste gewünscht ist, fangen wir mit den größten Wert(finishedTree.RightNode) an.
            list.AddRange(GetNodesSortedDescending(finishedTree.RightNode));
            list.Add(finishedTree.Id);
            list.AddRange(GetNodesSortedDescending(finishedTree.LeftNode));
        }

        return list;
    }

    public List<int> GetNodesSortedAscending(Node finishedTree)
    {
        var list = new List<int>();

        if (finishedTree != null)
        {
            //Da eine aufsteigende Liste gewünscht ist, fangen wir mit den kleinsten Wert(finishedTree.LeftNode) an.
            list.AddRange(GetNodesSortedAscending(finishedTree.LeftNode));
            list.Add(finishedTree.Id);
            list.AddRange(GetNodesSortedAscending(finishedTree.RightNode));
        }

        return list;
    }

    public void DisplaySortedNumbers(int[] numbers, List<int> nodes, string sortingName)
    {
        Console.WriteLine("Sortierung-" + sortingName + ": " + string.Join(", ", nodes.Select(x => x)));
    }

    public void DisplayValuesFromTree(string nodeId, string valueType)
    {
        Console.WriteLine(valueType + ": " + nodeId);
    }
}