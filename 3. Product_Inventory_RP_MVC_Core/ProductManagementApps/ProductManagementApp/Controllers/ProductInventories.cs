using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductManagementApp.Models;
using ProductManagementApp.Repositories.Interfaces;
using ProductManagementApp.ViewModels.Input;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProductManagementApp.Controllers
{
    public class ProductInventories : Controller
    {
        private readonly IWebHostEnvironment env;
        private readonly IUnitOfWork unitOfWork;
        private readonly IGenericRepo<ProductInventory> repo;
        public ProductInventories(IUnitOfWork unitOfWork, IWebHostEnvironment env)
        {
            this.unitOfWork = unitOfWork;
            this.repo = this.unitOfWork.GetRepo<ProductInventory>();
            this.env = env;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Edit(int id)
        {
            var data = await this.repo.GetByIdAsync(x => x.ProductInventoryId == id);
            //ViewBag.Companies = await this.repo.ExecuteSqlCollection<ProductInventoryEditModel>($"SELECT * FROM ProductInventories where ProductInventoryId = {id} ");
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ProductInventory model)
        {
            await this.repo.UpdateAsync(model);
            await this.unitOfWork.SaveAsync();
            return RedirectToAction("Index");
        }
    }
}
