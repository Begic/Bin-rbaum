namespace Binärbaum;

public class Node
{
    public Node(int id)
    {
        this.Id = id;
    }

    public int Id { get; set; }
    public Node? LeftNode { get; set; }
    public Node? RightNode { get; set; }
}