namespace CSharpContracted.Models
{
  public class Job
  {
    public int Id { get; set; }
    public string Location { get; set; }
    public string Description { get; set; }
    public string ContactInfo { get; set; }
    public string StartDate { get; set; }
  }
  public class JobBidViewModel : Job
  {
    public int JobBidId { get; set; }
  }
}