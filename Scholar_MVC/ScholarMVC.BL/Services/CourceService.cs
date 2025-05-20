
using Microsoft.EntityFrameworkCore;
using ScholarMVC.BL.Exceptions;
using ScholarMVC.BL.ViewModels;
using ScholarMVC.DAL.Contexts;
using ScholarMVC.DAL.Models;

namespace ScholarMVC.BL.Services;

public class CourceService
{
    private readonly AppDbContext _context;
    public CourceService(AppDbContext appDbContext)
    {
        _context = appDbContext;
    }


    #region Create

    public void Create(CourceVM courceVM)
    {
        Cource cource = new Cource();
        cource.Category = courceVM.Category;
        cource.Teacher = courceVM.Teacher;
        cource.Price = courceVM.Price;

        string fileName = Path.GetFileNameWithoutExtension(courceVM.File.FileName);
        string extension = Path.GetExtension(courceVM.File.FileName);
        string fullName = fileName + Guid.NewGuid().ToString() + extension;

        Console.WriteLine(fullName);

        cource.ImgPath = fullName;

        string updatedPath = "C:\\Users\\ca r221.14\\source\\repos\\ScholarMVC\\ScholarMVC.MVC\\wwwroot\\assets\\images\\img";

        if (!Directory.Exists(updatedPath))
        {
            Directory.CreateDirectory(updatedPath);
        }
        updatedPath = Path.Combine(updatedPath, fullName);

        using FileStream stream = new FileStream(updatedPath, FileMode.Create);

        courceVM.File.CopyTo(stream);

        _context.Cources.Add(cource);
        _context.SaveChanges();

    }

    #endregion

    #region Read
    public List<Cource> Cources()
    {
        return _context.Cources.ToList();
    }

    public Cource GetAllCourcesById(int id)
    {
        Cource cource = _context.Cources.Find(id);
        if (cource is null)
        {
            return cource;
        }
        throw new CourceException("Data yoxdur");
    }

    #endregion

    #region Update

    public void Update(int id, Cource updatedcource)
    {
        if (id != updatedcource.Id)
        {
            throw new CourceException("Data yoxdur");

        }
        Cource baseCource = _context.Cources.AsNoTracking().SingleOrDefault(c => c.Id == id);
        if (baseCource is not null)
        {
            throw new CourceException("Data yoxdur");
        }

        _context.Cources.Update(updatedcource);
        _context.SaveChanges();
    }
    #endregion

    #region Delete

    public void Delete(int id)
    {
        Cource cource = _context.Cources.Find(id);
        if (cource is null)
        {
            _context.Cources.Remove(cource);
            _context.SaveChanges();
        }
    }

    #endregion



}
