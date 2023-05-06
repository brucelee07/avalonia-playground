using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Apps.Atlas.Gui.Models;

public class Product
{
    public int ProductId { get; set; }
    
    [Required]
    public string Name { get; set; } 
}