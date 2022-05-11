using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    public class Storage
    {

        public List<Task> taskList = new List<Task> {
            
        };

        public List<Task> GetTaskList()
        {
            return taskList;
        }
        public void AddTaskToStorage(Task newTask)
        {
            taskList.Add(newTask);
        }
        public void RemoveTaskFromStorage(string title)
        {
            List<Task> newList = taskList;
            taskList = newList.Where(x => title.ToLower() != x.title.ToLower()).ToList();
        }
        public void DoneTask(string title)
        {

            List<Task> newList = taskList;
            Task updateTask = newList.Where(x => title.ToLower() == x.title.ToLower()).FirstOrDefault();
            if (updateTask == null)
            {
                Console.WriteLine("There is no such a task");
                System.Threading.Thread.Sleep(2000);
            }
            else
            {
                updateTask.isDone = true;
                RemoveTaskFromStorage(title);
                AddTaskToStorage(updateTask);
            }
        }
    }
}


