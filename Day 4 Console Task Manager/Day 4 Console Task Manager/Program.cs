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

using System.Text.Json; // For JSON serialization 


class Task
{
    public string Title { get; set; }
    public string Description { get; set; } = "";
    public bool Iscompleted { get; set; } = false;
}

class Program
{
    static List<Task> taskList = new List<Task>();
    static string taskFilePath = "tasks.json";


    static void SaveTasksToFile()
    {
        try
        {
            string json = JsonSerializer.Serialize(taskList, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(taskFilePath, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Error saving tasks: {ex.Message}");
        }
    }

    static void LoadTasksFromFile()
    {
        try
        {
            if (File.Exists(taskFilePath))
            {
                string json = File.ReadAllText(taskFilePath);
                taskList = JsonSerializer.Deserialize<List<Task>>(json) ?? new List<Task>();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Error loading tasks: {ex.Message}");
        }
    }

    public static  void Main(string[] args)
    {
        LoadTasksFromFile();    // Load previous tasks from file when the app starts

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

                    SaveTasksToFile();  // ✅ Save before exiting
                    Console.Write("\nAre you sure you want to exit? (yes/no): ");
                    string confirmExit = Console.ReadLine().Trim().ToLower();

                    if (confirmExit == "yes")
                    {
                        Console.Write("Do you want to clear all saved tasks? (yes/no): ");
                        string clear = Console.ReadLine().Trim().ToLower();

                        if (clear == "yes")
                        {
                            try
                            {
                                File.Delete("tasks.json");
                                Console.WriteLine("All tasks cleared from file.");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error deleting file: {ex.Message}");
                            }
                        }

                        Console.WriteLine("Goodbye!");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Exit cancelled. Press any key to return to menu.");
                        Console.ReadKey();
                    }
                    break;

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
        SaveTasksToFile(); // ✅ Save immediately after adding
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
            SaveTasksToFile(); // ✅ Save immediately after updating
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
            SaveTasksToFile(); // ✅ Save immediately after deletion
            Console.WriteLine("Task deleted.");
        }
        else
        {
            Console.WriteLine("Invalid number.");
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    
    /*
    // Bonus: Save/Load to File
     static void SaveTasksToFile()
    {
        string filePath = "tasks.txt";

        List<string> lines = new List<string>;

        foreach(var task in taskList)
        {
           lines.Add($"{task.Title}||{task.Description}||{task.Iscompleted}");
        }

        try
        {
            File.WriteAllLines(filePath, lines);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving tasks: {ex.Message}");
        }
    }

    //bonus: Load Tasks from File
      static void LoadTasksFromFile()
    {
        string filePath = "tasks.txt";
        if (File.Exists(filePath))
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    var parts = line.Split(new[] { "||" }, StringSplitOptions.None);
                    if (parts.Length == 3)
                    {
                        taskList.Add(new Task
                        {
                            Title = parts[0],
                            Description = parts[1],
                            Iscompleted = bool.Parse(parts[2])
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading tasks: {ex.Message}");
            }
        }
    }
    */

}