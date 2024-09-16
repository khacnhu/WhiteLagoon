using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using WhiteLagoon.Common.Interfaces;
using WhiteLagoon.Domain.Entities;
using WhiteLagoon.Infrastructure.Data;

namespace WhiteLagoon.Controllers
{
    public class VillaController : Controller
    {

        private readonly IVillaRepository _villaRepository;

        public VillaController(IVillaRepository villaRepository)
        {
            this._villaRepository = villaRepository;
        }

        public IActionResult Index()
        {
            var villas = _villaRepository.GetAll();
            return View(villas);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Villa obj)
        {
            if (obj.Name == obj.Description)
            {
                ModelState.AddModelError("name", "The Description cannot exactly match the Name");
            }

            if(ModelState.IsValid)
            {
                _villaRepository.Add(obj);
                _villaRepository.Save();
                TempData["success"] = "The Villa has been created successfully";
                return RedirectToAction("Index");
            }

            return View();

            
        }


        public IActionResult Update(int villaId) 
        {
            Villa? obj = _villaRepository.Get(x => x.Id == villaId);
            if (obj == null) 
            {
                return RedirectToAction("Error", "Home");
            }
                
            return View(obj);
    
        }

        [HttpPost]
        public IActionResult Update(Villa obj)
        {
            if (ModelState.IsValid && obj.Id > 0 )
            {
                _villaRepository.Update(obj);
                _villaRepository.Save();
                TempData["success"] = "The Villa has been updated successfully";
                return RedirectToAction("Index");
            }

            return View();

        }

        
        public IActionResult Delete(int villaId)
        {
            Villa? obj = _villaRepository.Get(x => x.Id == villaId);
            if (obj == null)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(obj);

        }

        [HttpPost]
        public IActionResult Delete(Villa obj)
        {
            Villa? villa = _villaRepository.Get(x => x.Id == obj.Id);
            Console.WriteLine("CHECK ", villa);

            if (villa != null)
            {
                _villaRepository.Remove(villa);
                _villaRepository.Save();
                TempData["success"] = "The Villa has been delete successfully";
                return RedirectToAction("Index");
            }
            TempData["error"] = "The villa could not be deleted";
            return View();

        }


    }
}
