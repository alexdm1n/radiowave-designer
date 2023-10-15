using System.ComponentModel.DataAnnotations;

namespace RadiowaveDesigner.Models.Models;

public class Coordinate
{
    [Key]
    public long Id { get; set; }
    
    public string Coordinates { get; set; }

    public int Position { get; set; }
}