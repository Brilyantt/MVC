using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace NFT_MVCProject.MVC.ViewModels;

public class CollectionsMarketVM
{
    [Required(ErrorMessage = "Ad boş ola bilməz")]

    public string Name { get; set; }

    [Required(ErrorMessage = "Kateqoriya adı boş ola bilməz")]

    public string CategoryName { get; set; }

    [Required(ErrorMessage = "Item sayı boş ola bilməz")]

    public int CountOfItem { get; set; }

    [Required(ErrorMessage = "Şəkil seçilməlidir")]

    public IFormFile File { get; set; }
}
