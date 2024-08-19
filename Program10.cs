using System;
using System.Collections.Generic;

namespace TaskManager
{
    class Program
    {
        static List<Task> tasks = new List<Task>();

        static void Main(string[] args)
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Task Manager");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. Remove Task");
                Console.WriteLine("3. List Tasks");
                Console.WriteLine("4. Mark Task as Complete");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddTask();
                        break;
                    case "2":
                        RemoveTask();
                        break;
                    case "3":
                        ListTasks();
                        break;
                    case "4":
                        MarkTaskAsComplete();
                        break;
                    case "5":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void AddTask()
        {
            Console.Write("Enter task description: ");
            string description = Console.ReadLine();
            tasks.Add(new Task { Description = description, IsComplete = false });
            Console.WriteLine("Task added successfully.");
        }

        static void RemoveTask()
        {
            Console.Write("Enter the index of the task to remove: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index >= 0 && index < tasks.Count)
            {
                tasks.RemoveAt(index);
                Console.WriteLine("Task removed successfully.");
            }
            else
            {
                Console.WriteLine("Invalid index. Please try again.");
            }
        }

        static void ListTasks()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks to display.");
                return;
            }

            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i}. {tasks[i].Description} - {(tasks[i].IsComplete ? "Complete" : "Incomplete")}");
            }
        }

        static void MarkTaskAsComplete()
        {
            Console.Write("Enter the index of the task to mark as complete: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index >= 0 && index < tasks.Count)
            {
                tasks[index].IsComplete = true;
                Console.WriteLine("Task marked as complete.");
            }
            else
            {
                Console.WriteLine("Invalid index. Please try again.");
            }
        }
    }

    class Task
    {
        public string Description { get; set; }
        public bool IsComplete { get; set; }
    }
}
