using NUnit.Framework;
using System;

namespace HomeWorkAl2
{
    class Program
    {
        public class Node
        {
            public int Value { get; set; }
            public Node NextNode { get; set; }
            public Node PrevNode { get; set; }
        }

        //Начальную и конечную ноду нужно хранить в самой реализации интерфейса
        public interface ILinkedList
        {
            int GetCount(); // возвращает количество элементов в списке
            void AddNode(int value);  // добавляет новый элемент списка
            void AddNodeAfter(Node node, int value); // добавляет новый элемент списка после определённого элемента
            void RemoveNode(int index); // удаляет элемент по порядковому номеру
            void RemoveNode(Node node); // удаляет указанный элемент
            Node FindNode(int searchValue); // ищет элемент по его значению
        }
        public class LinkedList : ILinkedList 
        { 
            public Node Head { get; set; }
            public Node Tail { get; set; }
            public int count;

            public int GetCount()
            {
                return count;
            }

            public void AddNode(int value) // добавляет новый элемент списка
            {
                var newNode = new Node { Value = value };
                if (Head == null)
                {
                    Head = newNode;
                }
                else
                {
                    Tail.NextNode = newNode;
                    newNode.PrevNode = Tail;
                }
                Tail = newNode;
                count++;
            }
            public void AddNodeAfter(Node node, int value) // добавляет новый элемент списка после определённого элемента
            {
                var newNode = new Node { Value = value };
                var nextItem = node.NextNode;
                
                node.NextNode = newNode;
                newNode.NextNode = nextItem;
                newNode.PrevNode = node;
                (node.NextNode.NextNode).PrevNode = newNode;
                count++;
            }
            public void RemoveNode(int index) // удаляет элемент по порядковому номеру
            {
                if (index == 0) 
                {
                    var newStartNode = Head.NextNode;
                    newStartNode.PrevNode = null;
                    Head.NextNode = null;
                    return;
                }
                int currentIndex = 0;
                var currentNode = Head;

                while (currentNode != null)
                {
                    if (currentIndex == index - 1)
                    {
                        RemoveNode(currentNode);
                        return;
                    }
                    currentNode = currentNode.NextNode;
                    currentIndex++;
                }

            }
            public void RemoveNode(Node node) // удаляет указанный элемент
            {
                if (node.NextNode == null) return;
                var nextItem = node.NextNode;
                var prevItem = node.PrevNode;
                if (nextItem == null) 
                {
                    node.PrevNode = null;
                }
                if (prevItem == null)
                {
                    node.NextNode = null;
                }
                if (nextItem != null && prevItem != null)
                {
                    node.PrevNode.NextNode = node.NextNode;
                    node.NextNode.PrevNode = node.PrevNode;
                }
                count--;
            }
            public Node FindNode(int searchValue) // ищет элемент по его значению
            {
                var currentNode = Head;
                while (currentNode != null) 
                {
                    if (currentNode.Value == searchValue)
                        return currentNode;
                    currentNode = currentNode.NextNode;
                }
                return null;
            }
        }

        static void Main(string[] args)
        {
            var List = new LinkedList();
            List.AddNode(1); // добавляет элемент 1 списка - 1
            List.AddNode(2); // добавляет элемент 2 списка - 2
            List.AddNode(3); // добавляет элемент 3 списка - 3
            List.AddNode(4); // добавляет элемент 4 списка - 4
            List.AddNode(5); // добавляет элемент 5 списка - 5
            List.AddNode(6); // добавляет элемент 6 списка - 6
            List.AddNode(7); // добавляет элемент 7 списка - 7
            List.AddNode(8); // добавляет элемент 8 списка - 8
            List.AddNode(9); // добавляет элемент 9 списка - 9

            List.RemoveNode(7); // удаляет элемент - 7

            List.AddNodeAfter(List.Head, 10); // после начального (1) элемента, перед (2), добавляет элемент 10   
            List.AddNodeAfter(List.FindNode(8), 11); // после элемента 8, вставляем 11
            List.AddNodeAfter(List.FindNode(3), 15); // после элемента 3, вставляем 15
            List.AddNodeAfter(List.FindNode(8), 82); // после элемента 8, вставляем 82, 

            List.RemoveNode(9); // удаляет элемент - 8

            List.RemoveNode(List.FindNode(2)); // находит и удаляет элемент - 2

            List.FindNode(5); // находит элемент - 5

            Console.WriteLine(List.GetCount()); // вывод количества элементов списка - 12
            // 1 10 3 15 4 5 6 82 11  9 
        }

    }
}
