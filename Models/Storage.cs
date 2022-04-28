using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Storage
    {
        public List<Task> taskList = new List<Task> {
            new Task() { title = "Cleaning", description = "Only my room", isDone = false },
            new Task() { title = "Hang out with friends", description = "Booked tickets to cinema", isDone = false },
            new Task() { title = "Take shower", description = "Do it before meeting", isDone = true }
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
            Task? updateTask = newList.FirstOrDefault(x => title.ToLower() == x.title.ToLower());
            updateTask.isDone = true;
            RemoveTaskFromStorage(title);
            AddTaskToStorage(updateTask);
        }

    }
}
