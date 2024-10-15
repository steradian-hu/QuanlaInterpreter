namespace QuanlaInterpreter.Helpers
{
    public class ConfigHint
    {
        public bool ShowComments {  get; set; }
        public bool ShowEmptyLines { get; set; }

        public string CommentReplacement { get; set; } = "#";
    }
}
