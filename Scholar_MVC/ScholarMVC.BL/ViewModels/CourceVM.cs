using Microsoft.AspNetCore.Http;

namespace ScholarMVC.BL.ViewModels;

public class CourceVM
{
    public string Category { get; set; }
    public string Teacher { get; set; }
    public double Price { get; set; }

    public IFormFile File { get; set; }
}
