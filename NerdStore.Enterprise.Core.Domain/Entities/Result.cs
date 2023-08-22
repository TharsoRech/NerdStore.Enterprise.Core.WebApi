namespace NerdStore.Enterprise.Core.Domain.Entities
{
    public class Result
    {
        public dynamic? Value { get; set; }

        public string? ErrorMessage { get; set; }

        public int ErrorCode { get; set; }
    }
}
