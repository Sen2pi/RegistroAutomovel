namespace RegistroAutomovel_V1.EstruturasDeDados;

public class Node
{
    public int data;
    public Node next;

    public Node(int data) {
        this.data = data;
        this.next = null;
    }
}