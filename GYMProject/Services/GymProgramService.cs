using GYMProject.Contexts;
using GYMProject.Exceptions;
using GYMProject.Models;
using GYMProject.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace GYMProject.Services;

public class GymProgramService
{
    private readonly AppDbContext _context;
    public GymProgramService()
    {
        _context = new AppDbContext();
    }



    #region Create

    public void Create(GymProgramVM gymProgramVM)
    {
        GymProgram gymProgram = new GymProgram();

        gymProgram.Name = gymProgramVM.Name;

        string fileName = Path.GetFileNameWithoutExtension(gymProgramVM.File.FileName);
        string extension = Path.GetExtension(gymProgramVM.File.FileName);
        string fullName = fileName + Guid.NewGuid().ToString() + extension;
        Console.WriteLine(fullName);

        gymProgram.ImgPath = fullName;

        string uploadedPath = "C:\\Users\\ca r221.14\\source\\repos\\GYMProject\\GYMProject\\wwwroot\\assets\\images\\img";

        if (!Directory.Exists(uploadedPath))
        {
            Directory.CreateDirectory(uploadedPath);
        }

        uploadedPath = Path.Combine(uploadedPath, gymProgramVM.Name);

        using FileStream stream = new FileStream(uploadedPath, FileMode.Create);
        gymProgramVM.File.CopyTo(stream);

        _context.gymPrograms.Add(gymProgram);
        _context.SaveChanges();

    }

    #endregion

    #region Read

    public List<GymProgram> GymPrograms()
    {
        return _context.gymPrograms.ToList();
    }

    public GymProgram GetGymProgramById(int id)
    {
        GymProgram? gymProgram = _context.gymPrograms.Find(id);

        if (gymProgram is not null)
        {
            return gymProgram;
        }
        throw new GymProgramException("hemin id-li data yoxdur");
    }
    #endregion

    #region Update

    public void Update(int id, GymProgram updatedProgram)
    {
        if (id != updatedProgram.Id)
        {
            throw new GymProgramException("data yoxdu");
        }

        GymProgram? baseGymProgram = _context.gymPrograms.AsNoTracking().FirstOrDefault(gP => gP.Id == id);
        if (baseGymProgram is not null)
        {
            throw new GymProgramException("data yoxdu");
        }

        _context.gymPrograms.Add(updatedProgram);
        _context.SaveChanges();
    }

    #endregion

    #region Delete

    public void Delete(int id)
    {
        GymProgram? gymProgram = _context.gymPrograms.Find(id);
        if (gymProgram is not null)
        {
            _context.Remove(gymProgram);
            _context.SaveChanges();
        }
    }

    #endregion
}
