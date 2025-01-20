using Azure;
using Azure.Data.Tables;

public class Car : ITableEntity
{
    public string PartitionKey { get; set; }
    public string RowKey { get; set; }
    public DateTimeOffset? Timestamp { get; set; }
    public ETag ETag { get; set; }

    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
}