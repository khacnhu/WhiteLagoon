using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;
using WhiteLagoon.Domain.Entities;
using WhiteLagoon.Infrastructure.Data;
using WhiteLagoon.ViewModels;
using static System.Net.Mime.MediaTypeNames;

namespace WhiteLagoon.Controllers
{
    public class VillaNumberController : Controller
    {

        private readonly ApplicationDbContext _db;

        public VillaNumberController(ApplicationDbContext db)
        {
            this._db = db;
        }

        public IActionResult Index()
        {
            var villaNumbers = _db.villaNumbers.Include(u => u.Villa).ToList();
            return View(villaNumbers);
        }


        public IActionResult Create()
        {
            VillaNumberVM villaNumberVM = new VillaNumberVM()
            {
                VillaList = _db.Villas.ToList().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }
            )};

            return View(villaNumberVM);
        }

        [HttpPost]
        public IActionResult Create(VillaNumberVM obj)
        {

            //ModelState.Remove("Villa");

            bool roomNumberExists = _db.villaNumbers.Any(u => u.Villa_Number == obj.VillaNumber.Villa_Number);

            if (ModelState.IsValid && !roomNumberExists )
            {
                _db.villaNumbers.Add(obj.VillaNumber);
                _db.SaveChanges();
                TempData["success"] = "The Villa Number has been created successfully";
                return RedirectToAction("Index");
            
            }

            if (roomNumberExists)
            {
                TempData["error"] = "The Villa Number has been existed";

            }

            TempData["error"] = "The Villa Number or Villa Id is not correct , you should change value";

            obj.VillaList = _db.Villas.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });

            return View(obj);


        }



        public IActionResult Update(int villaNumberId)
        {
            VillaNumberVM villaNumberVM = new VillaNumberVM()
            {
                VillaList = _db.Villas.ToList().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                VillaNumber = _db.villaNumbers.FirstOrDefault(u => u.Villa_Number == villaNumberId)
            };

            if (villaNumberVM.VillaNumber == null) { 
                return RedirectToAction("Error", "Home");
            }

            return View(villaNumberVM);

        }

        [HttpPost]
        public IActionResult Update(VillaNumberVM villaNumberVM)
        {
            if (ModelState.IsValid)
            {
                _db.villaNumbers.Update(villaNumberVM.VillaNumber);
                _db.SaveChanges();
                TempData["success"] = "The Villa Number has been updated successfully";
                return RedirectToAction("Index");
            }

            villaNumberVM.VillaList = _db.Villas.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });

            return View();

        }


        public IActionResult Delete(int villaNumberId)
        {
            VillaNumberVM villaNumberVM = new VillaNumberVM()
            {
                VillaList = _db.Villas.ToList().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                VillaNumber = _db.villaNumbers.FirstOrDefault(u => u.Villa_Number == villaNumberId)
            };

            if (villaNumberVM.VillaNumber == null)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(villaNumberVM);
        }



        [HttpPost]
        public IActionResult Delete(VillaNumberVM villaNumberVM)
        {
            VillaNumber? objFromDb = _db.villaNumbers.FirstOrDefault(u => u.Villa_Number == villaNumberVM.VillaNumber.Villa_Number);
            if (objFromDb is not null)
            {
                _db.villaNumbers.Remove(objFromDb);
                _db.SaveChanges();
                TempData["success"] = "The Villa Number has been delete successfully";
                return RedirectToAction("Index");
            }

            TempData["error"] = "The Villa Number could not ";


            return View();

        }

    }
}
