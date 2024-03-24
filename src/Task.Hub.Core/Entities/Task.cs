
namespace Task.Hub.Core.Entities;

public class Task : BaseEntity
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public DateTime DueDate { get; private set; }
    public bool IsCompleted { get; private set; }


    private Task(string title, string description, DateTime dueDate)
    {
        Title = title;
        Description = description;
        DueDate = dueDate;
        IsCompleted = false;
    }

    public static Task Create(string title, string description, DateTime dueDate)
    {
        return new Task(title, description, dueDate);
    }


    public void Update(string title, string description, DateTime dueDate, bool isCompleted)
    {
        Title = title;
        Description = description;
        DueDate = dueDate;
        if (IsCompleted != isCompleted)
        {
            SetCompleted();
        }
    }


    private void SetCompleted()
    {
        IsCompleted = true;
    }


}

