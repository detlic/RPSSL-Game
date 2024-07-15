namespace PlayAPI.Model
{
    public class ChoiceRule
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int[] Beats { get; set; }
    }
}
