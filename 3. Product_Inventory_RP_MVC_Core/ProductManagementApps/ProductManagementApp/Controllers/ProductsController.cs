using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductManagementApp.Models;
using ProductManagementApp.Repositories.Interfaces;
using ProductManagementApp.ViewModels.Input;

namespace ProductManagementApp.Controllers
{
    public class ProductsController : Controller
    {
        //private readonly ProductDbContext db= new ProductDbContext();
        private readonly IWebHostEnvironment env;
        private readonly IUnitOfWork unitOfWork;
        private readonly IGenericRepo<Product> repo;
        public ProductsController(IUnitOfWork unitOfWork, IWebHostEnvironment env)
        {
            this.unitOfWork = unitOfWork;
            this.repo = this.unitOfWork.GetRepo<Product>();
            this.env = env;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ProductList(int pg = 1)
        {
            Thread.Sleep(1000);
            return ViewComponent("ProductListVC", new { pg = pg });
        }
        public async Task<IActionResult> Create()
        {
            var data = new ProductInputModel { UnitPrice = null };
            data.ProductInventories.Add(new ProductInventory { Date = null, Quantity = null });
            ViewBag.Companies = await this.repo.ExecuteSqlCollection<Company>("SELECT * FROM Companies");
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductInputModel model, string act = "")
        {
            if (act == "add")
            {
                model.ProductInventories.Add(new ProductInventory { Date = null, Quantity = null });
                foreach (var v in ModelState.Values)
                {
                    v.Errors.Clear();
                }

            }
            if (act.StartsWith("remove"))
            {
                int index = int.Parse(act.Substring(act.IndexOf("_") + 1));
                model.ProductInventories.RemoveAt(index);

                foreach (var v in ModelState.Values)
                {

                    v.RawValue = null;
                    v.Errors.Clear();
                }

            }
            if (act == "insert")
            {
                if (ModelState.IsValid)
                {
                    var data = new Product
                    {
                        Name = model.Name,
                        UnitPrice = model.UnitPrice ?? 0,
                        SellUnit = model.SellUnit

                    };
                    string ext = Path.GetExtension(model.Picture.FileName);
                    string fileName = $"{Path.GetFileNameWithoutExtension(Path.GetRandomFileName())}{ext}";
                    string savePath = Path.Combine(this.env.WebRootPath, "Images", fileName);
                    FileStream fs = new FileStream(savePath, FileMode.Create);
                    await model.Picture.CopyToAsync(fs);
                    fs.Close();
                    //
                    data.Picture = fileName;
                    foreach (var pi in model.ProductInventories)
                    {
                        data.ProductInventories.Add(pi);
                    }
                    await this.repo.InsertAsync(data);
                    await this.unitOfWork.SaveAsync();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.Companies = await this.repo.ExecuteSqlCollection<Company>("SELECT * FROM Companies");
            return View(model);
        }
 
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DoDelete(int id)
        {
            var data = await this.repo.GetByIdAsync(x => x.ProductId == id);
            if (data == null) return NotFound();
            await this.repo.DeleteAsync(x => x.ProductId == id);
            await this.unitOfWork.SaveAsync();

            return Json(new { success = true, id });
        }
        public async Task<IActionResult> Edit(int id)
        {
            var data = await this.repo.GetByIdAsync(x => x.ProductId == id, x => x.Include(p => p.ProductInventories).ThenInclude(pi => pi.Company));
            if (data == null) return NotFound();
            var modelData = new ProductEditModel
            {
                ProductId = id,
                Name = data.Name,
                UnitPrice = data.UnitPrice,
                SellUnit = data.SellUnit,

            };
            foreach (var pi in data.ProductInventories)
            {
                modelData.ProductInventories.Add(pi);
            }
            ViewBag.CurrentPic = data.Picture;
            ViewBag.Companies = await this.repo.ExecuteSqlCollection<Company>("SELECT * FROM Companies");
            return View(modelData);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ProductEditModel model, string act = "")
        {
            var data = await this.repo.GetByIdAsync(x => x.ProductId == model.ProductId, x => x.Include(p => p.ProductInventories)
                                .ThenInclude(pi => pi.Company));
            if (data == null) return NotFound();
            if (act == "add")
            {
                model.ProductInventories.Add(new ProductInventory { Date = null, Quantity = null });
                foreach (var v in ModelState.Values)
                {
                    v.Errors.Clear();
                }
            }
            if (act.StartsWith("remove"))
            {
                int index = int.Parse(act.Substring(act.IndexOf("_") + 1));
                model.ProductInventories.RemoveAt(index);

                foreach (var v in ModelState.Values)
                {

                    v.RawValue = null;
                    v.Errors.Clear();
                }

            }
            if (act == "update")
            {
                if (ModelState.IsValid)
                {

                    data.Name = model.Name;
                    data.UnitPrice = model.UnitPrice;
                    data.SellUnit = model.SellUnit;

                };
                if (model.Picture != null)
                {
                    string ext = Path.GetExtension(model.Picture.FileName);
                    string fileName = $"{Path.GetFileNameWithoutExtension(Path.GetRandomFileName())}{ext}";
                    string savePath = Path.Combine(this.env.WebRootPath, "Images", fileName);
                    FileStream fs = new FileStream(savePath, FileMode.Create);
                    model.Picture?.CopyTo(fs);
                    fs.Close();
                    //
                    data.Picture = fileName;
                }
                else
                {
                    //nothing

                }
                data.ProductInventories.Clear();
                foreach (var pi in model.ProductInventories)
                {
                    await this.repo.ExecuteCommand($"INSERT INTO ProductInventories ([Date], CompanyId, Quantity, ProductId) VALUES ('{pi.Date}', {pi.CompanyId}, {pi.Quantity},{data.ProductId})");
                }
                await this.repo.UpdateAsync(data);
                await this.unitOfWork.SaveAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CurrentPic = data.Picture;
            ViewBag.Companies = await this.repo.ExecuteSqlCollection<Company>("SELECT * FROM Companies");
            return View(model);
        }


    }


}
