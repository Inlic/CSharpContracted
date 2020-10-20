namespace CSharpContracted.Models
{
  public class Contractor
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string ContactType { get; set; }
    public string ContactInfo { get; set; }
  }
  public class ContractorBidViewModel : Contractor
  {
    public int ContractorBidId { get; set; }
    public double ContractorBidRate { get; set; }
  }
}