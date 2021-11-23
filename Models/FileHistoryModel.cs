namespace project.asp.net.core.Models
{
    public class FileHistoryModel
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public int UserModelId { get; set; }
        public int ModelId { get; set; }
    }
}
