namespace Calculator_gRPC.BL.Models
{
    public class ReplyWithErrors
    {
        public bool Success { get; set; }
        public string Error { get; set; }
        public ReplyWithErrors()
            => Success = false;
    }
}
