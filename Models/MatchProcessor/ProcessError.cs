using System;

namespace LoLPA.Database.Models.MatchProcessor
{
    public class ProcessError
    {
        public int Id { get; set; }
        public string Source { get; set; }
        public string ErrorMessage { get; set; }
        public string StackTrace { get; set; }
        public string InnerException { get; set; }
        public DateTime ErrorDate { get; set; }

        public static ProcessError FromException(Exception e)
        {
            return new ProcessError()
            {
                Source = e.Source,
                ErrorMessage = e.Message,
                StackTrace = e.StackTrace,
                InnerException = e.InnerException?.Message,
                ErrorDate = DateTime.Now
            };
        }
    }
}