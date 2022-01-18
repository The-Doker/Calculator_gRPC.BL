namespace Calculator_gRPC.Models
{
    public class Reply
    {
        public bool Success { get; set; }
        public string Error { get; set; }
        public Result[] Results { get; set; }
        public Reply(int sizeOfResultsArray)
        {
            Results = new Result[sizeOfResultsArray];
            Error = "";
            Success = false;
        }
    }
}
