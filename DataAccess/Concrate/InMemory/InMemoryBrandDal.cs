using DataAccess.Abstract;
using Entity.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrate.InMemory
{
    public class InMemoryBrandDal : IBrandDal
    {
        List<Brand> _brand;

        public InMemoryBrandDal()
        {
            _brand = new List<Brand>
            {
                new Brand{BrandId=1,BrandName="BMW"},
                new Brand{BrandId=2,BrandName="TOFAŞ"},
                new Brand{BrandId=3,BrandName="RENO"}
            };
        }

        public void Add(Brand brand)
        {
            _brand.Add(brand);
        }

        public void delete(Brand brand)
        {
            Brand deleteBrand=_brand.SingleOrDefault(b=>b.BrandId==brand.BrandId);
            _brand.Remove(deleteBrand); 
        }

        public void Delete(Brand entity)
        {
            throw new NotImplementedException();
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Brand> getAll()
        {
            return _brand;
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Brand getById(int id)
        {
            return _brand.SingleOrDefault(b=>b.BrandId == id);

        }

        public void update(Brand brand)
        {
            Brand updateBrand = _brand.SingleOrDefault(b => b.BrandId == brand.BrandId);
             
            updateBrand.BrandId = brand.BrandId;
            updateBrand.BrandName = brand.BrandName;
            

        }

        public void Update(Brand entity)
        {
            throw new NotImplementedException();
        }
    }
}
