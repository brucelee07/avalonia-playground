using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace Apps.Atlas.Gui.Models;

public class Product
{
    public int ProductId { get; set; }
    
    // [Index(IsUnique = true)] // unique
    [Required] // not null
    public string Name { get; set; } 
}