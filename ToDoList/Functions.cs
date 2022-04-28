using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    internal class Functions
    {
        static List<Task> list = new List<Task>();
        static Storage informations = new Storage();
        public static void Start()
        {
            list = informations.GetTaskList();
            Console.WriteLine("=== TO DO LIST ===");
            list.ForEach(task => {
                if (task.isDone)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.WriteLine($"{task.title,-25}{task.description,-25}");
            });
            Console.ResetColor();
            Console.WriteLine();
        }
        public static void ChooseOption()
        {
            Console.WriteLine("What you wanna do? \n\t Add Task (insert 1) " +
                "\n\t Remove Task (insert 2) " +
                "\n\t Done Task (insert 3)" +
                "\n\t End (insert 4)");

            Console.Write("Choose option: ");
            int option;

            while (true)
                try
                {
                    option = int.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.Write("Please, insert correct number: ");
                }
            if (option == 1)
            {
                Task newTask = new Task();
                Console.Write("Insert title of task: ");
                newTask.title = Console.ReadLine();
                Console.Write("Insert description of task: ");
                newTask.description = Console.ReadLine();
                newTask.isDone = false;
                informations.AddTaskToStorage(newTask);
                Refresh();
            }
            else if (option == 2)
            {
                Console.Write("Insert title of task you want to remove: ");
                string removeByTitle = Console.ReadLine();
                informations.RemoveTaskFromStorage(removeByTitle);
                Refresh();
            }
            else if (option == 3)
            {
                Console.Write("Insert title of task you have done: ");
                string doneByTitle = Console.ReadLine();
                informations.DoneTask(doneByTitle);
                Refresh();
            }
            else if (option == 4)
            {
                Console.Write("Thank you!");
            }
        }
        static void Refresh()
        {
            Console.Clear();
            Start();
            ChooseOption();
        }
    }
}
