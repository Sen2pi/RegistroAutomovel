namespace RegistroAutomovel_V1.EstruturasDeDados;

public class OrderedLinkedList
{
    public Node head;

    public class Node {
        public int data;
        public Node next;

        public Node(int data) {
            this.data = data;
            this.next = null;
        }
    }

    public void Insert(int data) {
        Node newNode = new Node(data);

        if (head == null || data < head.data) {
            newNode.next = head;
            head = newNode;
            return;
        }

        Node current = head;
        while (current.next != null && current.next.data < data) {
            current = current.next;
        }
        newNode.next = current.next;
        current.next = newNode;
    }

    public bool search(int data) {
        Node current = head;
        while (current != null && current.data < data) {
            current = current.next;
        }
        if (current == null || current.data > data) {
            return false;
        }
        return true;
    }

    public void Delete(int data) {
        if (head == null) {
            return;
        }
        if (head.data == data) {
            head = head.next;
            return;
        }
        Node current = head;
        while (current.next != null && current.next.data < data) {
            current = current.next;
        }
        if (current.next == null || current.next.data > data) {
            return;
        }
        current.next = current.next.next;
    }
}