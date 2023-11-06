using System.ComponentModel.DataAnnotations;

namespace RadiowaveDesigner.Models.Models;

public class Places
{
    [Key]
    public string Coordinates { get; set; }

    public string Name { get; set; }
    
    public string Address { get; set; }

    public string BoundedByJson { get; set; }

    public Category Category { get; set; }

    public string Region { get; set; }

    public double Priority { get; set; }
}