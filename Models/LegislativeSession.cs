using System.ComponentModel.DataAnnotations;

namespace FreedoniaGovernment.Models;

public class LegislativeSession
{
    public int Id { get; set; }
    public int SessionIndex { get;set; }
    public int StartYear { get;set; }
    public int EndYear { get;set; }
}