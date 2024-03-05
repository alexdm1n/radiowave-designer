using System.ComponentModel.DataAnnotations;

namespace RadiowaveDesigner.Models.Models;

public class UserConfiguration
{
    [Key]
    public long Id { get; set; }
    
    public bool ShowExistingBaseStations { get; set; }
}