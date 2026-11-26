using Microsoft.EntityFrameworkCore;
using ShelterAdmin.ViewModels;
using ShelterApp.Data;
using ShelterApp.Models;

namespace ShelterAdmin.Services;

public class AnimalService
{
    private readonly ShelterContext _context;

    public AnimalService(ShelterContext context)
    {
        _context = context;
    }

    public List<Animal> GetAllAnimalsForAdmin()
    {
        return _context.Animals
            .OrderByDescending(a => a.ArrivalDate)
            .ToList();
    }

    public void AddAnimal(AnimalEditViewModel vm)
    {
        var animal = new Animal
        {
            Name = vm.Name,
            Species = vm.Species,
            Breed = vm.Breed,
            Gender = vm.Gender,
            Age = vm.Age,
            Size = vm.Size,
            Status = vm.Status,
            ArrivalDate = vm.ArrivalDate,
            Description = vm.Description,
            HealthInfo = vm.HealthInfo
        };
        _context.Animals.Add(animal);
        _context.SaveChanges();
    }

    public void UpdateAnimal(AnimalEditViewModel vm)
    {
        var animal = _context.Animals.Find(vm.Id);
        if (animal != null)
        {
            animal.Name = vm.Name;
            animal.Species = vm.Species;
            animal.Breed = vm.Breed;
            animal.Gender = vm.Gender;
            animal.Age = vm.Age;
            animal.Size = vm.Size;
            animal.Status = vm.Status;
            animal.ArrivalDate = vm.ArrivalDate;
            animal.Description = vm.Description;
            animal.HealthInfo = vm.HealthInfo;

            _context.SaveChanges();
        }
    }

    public void DeleteAnimal(int id)
    {
        var animal = _context.Animals.Find(id);
        if (animal != null)
        {
            _context.Animals.Remove(animal);
            _context.SaveChanges();
        }
    }
}