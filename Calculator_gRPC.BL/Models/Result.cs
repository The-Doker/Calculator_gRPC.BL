namespace Calculator_gRPC.Models
{
    public class Result
    {
        public int Type { get; set; }
        public string Description { get; set; }
        public decimal CalculateResut { get; set; }
        public Result()
        {
            Description = "";
        }
    }
}
