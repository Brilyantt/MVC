using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Villa_MVC_Project.BL.ViewModels;

public class VillaVM
{
    [Required(ErrorMessage = " Category Adı boş ola bilməz")]

    public string CategoryName { get; set; }

    [Required(ErrorMessage = " Qiymət boş ola bilməz")]

    public double Price { get; set; }

    [Required(ErrorMessage = " Location boş ola bilməz")]

    public string Location { get; set; }

    [Required(ErrorMessage = " Şəkil seçilməlidir")]

    public IFormFile File { get; set; }

}
