namespace Task.Hub.Core.Entities.Query.Tasks
{
    public class SqlTaskConstants
    {
        public const string GetTask = @"select Uid, Title, Description, DueDate, IsCompleted from Tasks WHERE Uid = @Uid and Active = @Active";
    }
}
