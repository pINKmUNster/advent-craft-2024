namespace ElfWorkshop;

public class ElfWorkshop
{
    public List<string> TaskList { get; } = [];

    public void AddTask(string task)
    {
        if (task != null && task != "")
        {
            TaskList.Add(task);
        }
    }

    // Ici le nom de la méhtode est incorrect on complete la premiere task de la liste.
    
    public string CompleteTask()
    {
        if (TaskList.Count > 0)
        {
            var task = TaskList[0];
            TaskList.RemoveAt(0);
            return task;
        }

        return null;
    }
}