using Microsoft.EntityFrameworkCore;
using Villa_MVC_Project.BL.Exceptions;
using Villa_MVC_Project.BL.ViewModels;
using Villa_MVC_Project.DAL.Contexts;
using Villa_MVC_Project.DAL.Models;

namespace Villa_MVC_Project.BL.Services;

public class VillaService
{
    private readonly AppDbContext _context;
    public VillaService(AppDbContext context)
    {
        _context = context;
    }




    #region Create

    public void Create(VillaVM villaVM)
    {
        Villa villa = new Villa();
        villa.CategoryName = villaVM.CategoryName;
        villa.Price = villaVM.Price;
        villa.Location = villaVM.Location;

        string fileName = Path.GetFileNameWithoutExtension(villaVM.File.FileName);
        string extension = Path.GetExtension(villaVM.File.FileName);
        string fullName = fileName + Guid.NewGuid().ToString() + extension;
        Console.WriteLine(fullName);

        villa.ImgPath = fullName;

        string uploadedPath = "C:\\Users\\HP\\Desktop\\MVC\\VillaMVC\\Villa_MVC_Project.MVC\\wwwroot\\assets\\images\\img";


        if (!Directory.Exists(uploadedPath))
       {
           Directory.CreateDirectory(uploadedPath);
       }

        uploadedPath = Path.Combine(uploadedPath, fullName);
        using FileStream fileStream = new FileStream(uploadedPath, FileMode.Create);

        villaVM.File.CopyTo(fileStream);

        _context.Villas.Add(villa);
        _context.SaveChanges();


    }


    #endregion

    #region Read

    public List<Villa> Villas()
    {
        return _context.Villas.ToList();
    }

    public Villa GetVillaById(int id)
    {
        Villa villa = _context.Villas.Find(id);
        if (villa is not null)
        {
            return villa;
        }
        throw new VillaException("Data Yoxdur!");
    }

    #endregion

    #region Update
    public void Update(int id, Villa updatedvilla)
    {
        if (id != updatedvilla.Id)
        {
            throw new VillaException("Id-ler eyni deyil");
        }

        Villa? baseVilla = _context.Villas.AsNoTracking().SingleOrDefault(v => v.Id == id);
        if (baseVilla is null)
        {
            throw new VillaException("Data Yoxdur!");
        }

        _context.Villas.Update(updatedvilla);
        _context.SaveChanges();
    }


    #endregion

    #region Delete

    public void Delete(int id)
    {
        Villa? villa = _context.Villas.Find(id);
        if (villa is not null)
        {
            _context.Villas.Remove(villa);
            _context.SaveChanges();
        }
        else
        {
            throw new VillaException("Data Yoxdur!");
        }




    }
    #endregion
}
