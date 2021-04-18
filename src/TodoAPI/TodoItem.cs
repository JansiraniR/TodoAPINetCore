using Amazon.DynamoDBv2.DataModel;

namespace TodoAPI
{
     [DynamoDBTable("TodoItems")]
  public class TodoItem
  {
     [DynamoDBProperty("Id")]
      public long Id { get; set; }
 [DynamoDBProperty("Notes")]
      public string Notes { get; set;}
 [DynamoDBProperty("Status")]
      public string Status { get; set;}
 [DynamoDBProperty("Tasks")]
      public string Tasks { get; set;}
       [DynamoDBProperty("Done")]
      public bool Done { get; set;}
 [DynamoDBProperty("DateTime")]
      public string DateTime { get; set;}
  }
}