using Business.Concrate;
using DataAccess.Concrate.EntityFramework;
using Entity.Concrate;


namespace ConsoleUI
{

    class Program
    {
        static void Main(string[] args)
        {
           // CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            UserManager userManager = new UserManager(new EfUserDal());

        




            
            //Brand brand1 = new Brand {BrandName="FORD FOCUS" };
            //Color color1 = new Color { ColorName = "GRİ" };
            
            //Rental rental1 = new Rental
            //{ 
            //    CarId = 1,
            //    CustomerId = 1,
            //    RentDate = new DateTime(10/04/2022),
            //    ReturnDate = new DateTime(11/04/2022)
            //};

            
               // rentalManager.Add(rental1);
            

                //CarDTO(carManager);
                //CarTumData(carManager);

            //User user = new User { 
            //    UserId = 1, 
            //    FirstName = "Hüseyin",
            //    LastName = "Palamar",
            //    Email = "huseyinpalamar@gmail.com",
            //    Password = "123456SD"

            //};
            //User user2 = new User
            //{
            //    UserId = 2,
            //    FirstName = "İlkay",
            //    LastName = "Kurtuldu",
            //    Email = "ilkaykurtuldu39@gmail.com",
            //    Password = "123456"

            //};

            //userManager.Add(user2);

            


            //Car car2 = new Car
            //{
            //    Id = 2,
            //    BrandId = 2,
            //    ColorId = 1,
            //    Description = "AUIDI  Full paket",
            //    DailyPrice = 800,
            //    ModelYear = 2022

            //};

            //carManager.Add(car2);

            //Customer customer = new Customer
            //{
            //    CustomerId = 2,
            //    CompanyName = "SOLID TEAM",
            //    UserId = 2

            //};
            //customerManager.Add(customer);

           
            

        }

        private static void CarDTO(CarManager carManager)
        {
            var result = carManager.GetCarDetailDtos();
            foreach (var d in result.Data)
            {
                Console.WriteLine(d.CarId + "**" + d.BrandName + "**" + d.ModelYear + "**" + d.ColorName + "--" + d.Dectription);
            }
        }

        private static void CarTumData(CarManager carManager)
        {
            var result = carManager.GetAll();
            foreach (var c in result.Data)
            {
                Console.WriteLine(c.Id+"******"+c.Description);
            }
        }



    }
}