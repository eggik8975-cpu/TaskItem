using System;
using System.Collections.Generic;

class TaskItem
{
    public string Description { get; set; }
    public bool IsDone { get; set; }

    public TaskItem(string description)
    {
        Description = description;
        IsDone = false;
    }
}

class Program
{
    static void Main()
    {
        List<TaskItem> tasks = new List<TaskItem>();

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("===== Меню =====");
            Console.WriteLine("1. Добавить задачу");
            Console.WriteLine("2. Посмотреть задачи");
            Console.WriteLine("3. Отметить задачу как выполненную");
            Console.WriteLine("4. Выйти");
            Console.Write("Выберите пункт: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddTask(tasks);
                    break;
                case "2":
                    ShowTasks(tasks);
                    break;
                case "3":
                    MarkAsDone(tasks);
                    break;
                case "4":
                    Console.WriteLine("До свидания!");
                    return;
                default:
                    Console.WriteLine("Неверный пункт меню. Попробуйте снова.");
                    break;
            }
        }
    }

    static void AddTask(List<TaskItem> tasks)
    {
        Console.Write("Введите описание задачи: ");
        string description = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(description))
        {
            Console.WriteLine("Описание не может быть пустым.");
            return;
        }

        tasks.Add(new TaskItem(description.Trim()));
        Console.WriteLine($"Задача \"{description.Trim()}\" добавлена!");
    }

    static void ShowTasks(List<TaskItem> tasks)
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("Список задач пуст.");
            return;
        }

        Console.WriteLine("--- Текущие задачи ---");
        for (int i = 0; i < tasks.Count; i++)
        {
            string status = tasks[i].IsDone ? "[X]" : "[ ]";
            Console.WriteLine($"{i + 1}. {status} {tasks[i].Description}");
        }
    }

    static void MarkAsDone(List<TaskItem> tasks)
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("Список задач пуст. Нечего отмечать.");
            return;
        }

        Console.WriteLine("--- Отметить задачу как выполненную ---");
        for (int i = 0; i < tasks.Count; i++)
        {
            string status = tasks[i].IsDone ? "[X]" : "[ ]";
            Console.WriteLine($"{i + 1}. {status} {tasks[i].Description}");
        }

        Console.Write("Введите номер задачи для выполнения: ");
        string input = Console.ReadLine();

        if (!int.TryParse(input, out int number))
        {
            Console.WriteLine("Нужно ввести число.");
            return;
        }

        int index = number - 1;
        if (index < 0 || index >= tasks.Count)
        {
            Console.WriteLine("Задачи с таким номером не существует.");
            return;
        }

        if (tasks[index].IsDone)
        {
            Console.WriteLine($"Задача \"{tasks[index].Description}\" уже выполнена.");
            return;
        }

        tasks[index].IsDone = true;
        Console.WriteLine($"Задача \"{tasks[index].Description}\" отмечена как выполненная!");
    }
}