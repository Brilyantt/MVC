using Microsoft.AspNetCore.Http;

namespace CarMVC.ViewModels;

public class FeaturedCarVM
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Model { get; set; }
    public double Price { get; set; }
    public IFormFile File { get; set; }
}
