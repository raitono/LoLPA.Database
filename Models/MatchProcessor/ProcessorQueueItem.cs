namespace LoLPA.Database.Models.MatchProcessor
{
    public class ProcessorQueueItem
    {
        public int Id { get; set; }
        public string MatchId { get; set; }
        public bool IsPriority { get; set; }
        public ProcessError ProcessError { get; set; }
    }
}