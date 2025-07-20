/*Console Task Manager – Plan (Day 4 Project)
  Features:
    Add Task (Title + Optional Description)

    View All Tasks

    Mark Task as Completed

    Delete a Task

    Exit Program

    (Bonus: Save/Load to File)


 */

using System;
using System.Collections.Generic; // For List<T>

using System.IO; // For File I/O


class Task
{
    public string Title { get; set; }
    public string Description { get; set; } = "";
    public bool Iscompleted { get; set; } = false;
}

class Program
{
    static List<Task> taskList = new List<Task>();

    public static  void Main(string[] args)
    {
       while (true)
        {
            Console.Clear();
            Console.WriteLine("==== Task Manager ====");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. View All Tasks");
            Console.WriteLine("3. Mark Task as Completed");
            Console.WriteLine("4. Delete a Task");
            Console.WriteLine("5. Exit");
            Console.Write("\nChoose an option (1-5): ");

            string choice = Console.ReadLine().Trim();

            switch (choice)
            {
                case "1":
                    AddTask();
                    break;
                case "2":
                    ViewTasks();
                    break;
                case "3":
                    MarkCompleted();
                    break;
                case "4":
                    DeleteTask();
                    break;
                case "5":
                    Console.WriteLine("Exiting program...");
                    return;
                default:
                    Console.WriteLine("Invalid option. Press any key to try again.");
                    Console.ReadKey();
                    break;

            }

        }
         
    }

    static void AddTask()
    {
        Console.Clear();
        Console.Write("\nEnter task title: ");
        string title = Console.ReadLine().Trim();
        Console.Write("Enter description (optional): ");
        string desc = Console.ReadLine().Trim();

        taskList.Add(new Task { Title = title, Description = desc });
        Console.WriteLine("Task added successfully!");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    static void ViewTasks()
    {
        Console.Clear();
        if (taskList.Count == 0)
        {
            Console.WriteLine("=== Task List ===");
            Console.WriteLine("No tasks available.");
        }
        else
        {
            Console.WriteLine("=== Task List ===");
            int index = 1;

            foreach(var task in taskList)
            {    
                
                Console.WriteLine($"{index}.{task.Title}\n{task.Description}\n{ (task.Iscompleted ? "Completed" : "Pending ")}");
                Console.WriteLine("-------------------");
                index++;
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }

    static void MarkCompleted()
    {
        Console.Clear();
        ViewTasks();
        Console.Write("\nEnter the task number to mark as completed: ");
        if (int.TryParse(Console.ReadLine(), out int TaskNum) && TaskNum > 0 && TaskNum <= taskList.Count()){

            taskList[TaskNum - 1].Iscompleted = true;
            Console.WriteLine("Task marked as completed!");
        }
        else
        {
            Console.WriteLine("Invalid number.");
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }


    static void DeleteTask()
    {
        ViewTasks();
        Console.Write("\nEnter task number to delete: ");
        if (int.TryParse(Console.ReadLine(), out int num) && num > 0 && num <= taskList.Count)
        {
            taskList.RemoveAt(num - 1);
            Console.WriteLine("Task deleted.");
        }
        else
        {
            Console.WriteLine("Invalid number.");
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

}