using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ScholarMVC.BL.ViewModels;

public class CourceVM
{
    [Required(ErrorMessage = "Category bos ola bilmez" )]
    public string Category { get; set; }
    [Required(ErrorMessage = "Muelllim adini qeyd et!")]
    public string Teacher { get; set; }

    [Required(ErrorMessage = "Qiymeti de daxil et")]
    public double Price { get; set; }

    [Required(ErrorMessage = "Sekil bos gonderile bilmez")]
    public IFormFile File { get; set; }
}
