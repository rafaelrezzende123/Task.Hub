namespace Task.Hub.Web.Utility
{
    public static class DateValidator
    {
        public static bool BeValidDueDate(DateTime dueDate)
        {
            return dueDate >= DateTime.Today;
        }
    }
}
