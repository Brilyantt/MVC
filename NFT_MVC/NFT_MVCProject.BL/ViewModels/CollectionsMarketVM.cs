using Microsoft.AspNetCore.Http;

namespace NFT_MVCProject.MVC.ViewModels;

public class CollectionsMarketVM
{
    public string Name { get; set; }

    public string CategoryName { get; set; }

    public int CountOfItem { get; set; }

    public IFormFile File { get; set; }
}
