using DataAccess.Abstract;
using Entity.Concrate;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrate.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _car;

        public InMemoryCarDal()
        {
            _car = new List<Car>
            {
                new Car{Id=1,BrandId=2,ColorId=1,DailyPrice=200,Description="2012 model Fiat Egea",ModelYear=2012},
                new Car{Id=2,BrandId=1,ColorId=3,DailyPrice=500,Description="2016 model BMW ",ModelYear=2016},
                new Car{Id=3,BrandId=1,ColorId=1,DailyPrice=800,Description="2019 model BMW 1.5",ModelYear=2019},
                new Car{Id=4,BrandId=3,ColorId=4,DailyPrice=600,Description="2014 model Ford Mondeo",ModelYear=2012}
            };
        }

        public void add(Car car)
        {
            _car.Add(car);
        }

        public void Add(Car entity)
        {
            throw new NotImplementedException();
        }

        public void delete(Car car)
        {
            Car deleteCar=_car.SingleOrDefault(c=>c.Id==car.Id);

            _car.Remove(deleteCar);

            
        }

        public void Delete(Car entity)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> getAll()
        {
            return _car;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car getById(int id)
        {
            return _car.SingleOrDefault(c=>c.Id==id);
        }

        public List<CarDetailDto> GetCarDetail()
        {
            throw new NotImplementedException();
        }

        public void update(Car car)
        {
            Car updateCar = _car.SingleOrDefault(c => c.Id == car.Id);

             updateCar.BrandId = car.BrandId;
             updateCar.ModelYear = car.ModelYear;
             updateCar.Description = car.Description;
             updateCar.DailyPrice = car.DailyPrice;
             updateCar.ColorId = car.ColorId;
           
        }

        public void Update(Car entity)
        {
            throw new NotImplementedException();
        }
    }
}
