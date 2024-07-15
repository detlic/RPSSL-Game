namespace TestUI.Utilities
{
    public class ApiBasic
    {
        public static string ChoiceAPIBase { get; set; } = string.Empty;
        public static string PlayAPIBase { get; set; } = string.Empty;
        public enum ApiType
        {
            GET,
            POST
        }
    }
}
