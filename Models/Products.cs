using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace CodespacesBlank.Models;

public class Products
{
    public int Id {get; set;}
    public string Name {get; set;} = "";
    
    [MaxLength(100)]
    public required string Brand {get; set;}

    [MaxLength(100)]
    public string Category {get; set;} = "";
    [Precision(16, 2)]
    public decimal Price {get; set;}

    [MaxLength(100)]
    public string Description {get; set;} = "";

    [MaxLength(100)]
    public string ImageFileName {get; set;} = "";
    public DateTime CreatedAt {get; set;}
}
