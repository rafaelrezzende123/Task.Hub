namespace Task.Hub.Web.Utility
{
    public static class GuidValidator
    {
        public static bool BeValidGuid(Guid guidString)
        {
            return Guid.TryParse(guidString.ToString(), out _);
        }
    }
}
