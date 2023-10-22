using System.ComponentModel.DataAnnotations;

namespace RadiowaveDesigner.Models.Models;

public class AreaConfiguration
{
    [Key]
    public long Id { get; set; }

    public IEnumerable<Coordinate> Coordinates { get; set; }
}