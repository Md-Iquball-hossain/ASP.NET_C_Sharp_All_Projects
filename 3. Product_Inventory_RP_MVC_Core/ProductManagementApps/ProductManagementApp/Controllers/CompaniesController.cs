using Microsoft.AspNetCore.Mvc;
using ProductManagementApp.Models;
using ProductManagementApp.Repositories.Interfaces;
using X.PagedList;

namespace ProductManagementApp.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IGenericRepo<Company> repo;
        public CompaniesController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.repo = this.unitOfWork.GetRepo<Company>();
        }
        public async Task<IActionResult> Index(int pg = 1)
        {
            var data = await repo.GetAllAsync();

            var pagedData = await data.OrderBy(x => x.CompanyId).ToPagedListAsync(pg, 5);


            return View(pagedData);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Company company)
        {
            await this.repo.InsertAsync(company);
            bool saved = await this.unitOfWork.SaveAsync();
            if (saved)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Failed to saved data");
            }
            return View(company);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var data = await repo.GetByIdAsync(x => x.CompanyId == id);
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Company company)
        {
            await this.repo.UpdateAsync(company);
            bool saved = await this.unitOfWork.SaveAsync();
            if (saved)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Failed to saved data");
            }
            return View(company);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Company company, int? id)
        {
            await this.repo.DeleteAsync(x => x.CompanyId == id);
            bool saved = await this.unitOfWork.SaveAsync();
            if (saved)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Failed to Delete data");
            }
            return View(company);
        }
    }
}
