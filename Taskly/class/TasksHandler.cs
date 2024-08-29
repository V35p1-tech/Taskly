using System.IO;
using System.Text.Json;

namespace Taskly
{
    public class TasksHandler
    {
        public List<ToDo_Event> toDo_Events = new List<ToDo_Event>();

        public bool AddTask(int ID, string inTaskDescription, bool inTaskHasDate, DateTime inTaskDate)
        {
            bool processComplete = false;
            int tempCount = toDo_Events.Count;
            toDo_Events.Add
            (
                new ToDo_Event
                {
                    Task = inTaskDescription,
                    HasDate = inTaskHasDate,
                    TaskDate = inTaskDate,
                    ID = ID
                }
            );
            ID = ID++;
            if (tempCount < toDo_Events.Count)
            {
                processComplete = true;
            }
            return processComplete;
        }

        public bool RemoveTask(int deleteCount, int[] eventToDelete)
        {
            bool processComplete = false;
            for (int i = deleteCount - 1; i >= 0; i--)
            {
                if (eventToDelete[i] != 9999)
                {
                    toDo_Events.RemoveAt(eventToDelete[i]);
                }
                if (deleteCount == 0)
                {
                    deleteCount = 0;
                    processComplete = true;
                }
            }
            return processComplete;
        }

        public bool SaveToFile(List<ToDo_Event> todoList, string filePath)
        {
            bool processComplete = false;
            var json = JsonSerializer.Serialize(todoList);
            File.WriteAllText(filePath, json);

            processComplete = true;
            return processComplete;
        }

        public List<ToDo_Event> LoadFromFile(string filePath)
        {
            if (!File.Exists(filePath))
                return new List<ToDo_Event>();

            var json = File.ReadAllText(filePath);
            if (json.Length > 0)
                return JsonSerializer.Deserialize<List<ToDo_Event>>(json);
            else
                return new List<ToDo_Event>();
        }
    }
}