using System.Linq;
using Microsoft.EntityFrameworkCore;
using Northwind.Context;
using Northwind.Entities;
using Northwind.Services.Interfaces;

namespace Northwind.Services
{
    public class ProductService: BaseService<Product>, IProductService
    {
        public ProductService(IRepository<Product> repo, IUnitOfWork uow)
            : base(repo, uow) {}

        public IQueryable<Product> GetAll() {
            return this._repo.Query()
                .Include(x => x.Supplier)
                .Include(x => x.Category);
        }
    }
}