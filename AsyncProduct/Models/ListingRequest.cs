namespace AsyncProduct.Models;

public class ListingRequest
{
    public int Id { get; set; }
    
    public string RequestBody { get; set; } = string.Empty;
    public string EstimatedCompetionTime { get; set; } = string.Empty;
    public string RequestStatus { get; set; } = string.Empty;
    public string RquestId { get; set; } = Guid.NewGuid().ToString(); 
}