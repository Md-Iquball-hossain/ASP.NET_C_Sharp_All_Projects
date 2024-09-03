using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductManagementApp.Models;
using ProductManagementApp.Repositories.Interfaces;
using X.PagedList;

namespace ProductManagementApp.Components
{
    public class ProductListVC : ViewComponent
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IGenericRepo<Product> repo;
        public ProductListVC(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.repo = this.unitOfWork.GetRepo<Product>();
        }
        public async Task<IViewComponentResult> InvokeAsync(int pg = 1)
        {

            var data = await this.repo.GetAllAsync(x => x.Include(p => p.ProductInventories).ThenInclude(pi => pi.Company));




            return View(data.ToPagedList(pg, 5));
        }
    }
}
