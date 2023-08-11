using System;

namespace ConsoleApp1_1 // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task1 task1 = new Task1();
            Task2 task2 = new Task2();
            Task3 task3 = new Task3();

            task3.doSomething("note2.txt");

            //task1.print();

            //task2.doSomething("PUG", 4);
        }
    }
}