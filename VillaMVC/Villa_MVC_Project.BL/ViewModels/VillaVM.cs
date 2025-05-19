using Microsoft.AspNetCore.Http;

namespace Villa_MVC_Project.BL.ViewModels;

public class VillaVM
{
    public string CategoryName { get; set; }
    public double Price { get; set; }
    public string Location { get; set; }
    public IFormFile File { get; set; }

}
