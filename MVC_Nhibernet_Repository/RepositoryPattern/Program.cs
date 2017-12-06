using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryPattern.Abstraction;
using RepositoryPattern.DAL;
using RepositoryPattern.DAL.Scientist;

namespace RepositoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Dependency Injection
            //IVehicle vehicle = new Submarine();
            //VehicleController vehicleController = new VehicleController(vehicle);
            //vehicleController.Fire();
            //vehicleController.Move();
            //Console.WriteLine("---------------\n");
            //IVehicle vehicle1 = new Tank();
            //vehicleController = new VehicleController(vehicle1);
            //vehicleController.Fire();
            //vehicleController.Move();
            //Console.WriteLine("---------------\n");
            //IVehicle vehicle2 = new Plane();
            //vehicleController = new VehicleController(vehicle2);
            //vehicleController.Fire();
            //vehicleController.Move();
            //Console.WriteLine("---------------\n");
            //Console.WriteLine("---------------\n");
            //Console.ReadLine();
            #endregion

            #region Ioc Castle
            using (var c1 = new Castle_Abstraction())
            {
                c1.PlaneFactory();
                c1.ResolveCastle<IVehicle>().Fire();
                c1.ResolveCastle<IVehicle>().Move();
                Console.WriteLine("-----------------\n");
            }
            using (var c2 = new Castle_Abstraction())
            {
                c2.TankFactory();
                c2.ResolveCastle<IVehicle>().Fire();
                c2.ResolveCastle<IVehicle>().Move();
                Console.WriteLine("-----------------\n");

            }
            using (var c3 = new Castle_Abstraction())
            {
                c3.SubmarineFactory();
                c3.ResolveCastle<IVehicle>().Fire();
                c3.ResolveCastle<IVehicle>().Move();
                Console.WriteLine("-----------------\n");

            }
            #endregion

            #region Repository Pattern
            //using (ShopUnitOfWork worker = new ShopUnitOfWork())
            //{
            //    Category computerBook = new Category { Title = "Computer Books" };
            //    worker.CategoryRepository.Insert(computerBook);
            //    computerBook.Products = new List<Product> {
            //        new Product { Title = "Advanced NoSQL", Quantity = 1, UnitPrice = 34.59M },
            //        new Product { Title = "NHibernate in Action", Quantity = 5, UnitPrice = 29.99M },
            //        new Product { Title = "Unleashed Delphi 2.0", Quantity = 3, UnitPrice = 9.99M }
            //    };
            //    Category cookBook = new Category { Title = "Cook Books" };
            //    worker.CategoryRepository.Insert(cookBook);
            //    cookBook.Products = new List<Product> {
            //    new Product()
            //        {
            //            Title = "Italian Kitchen", Quantity = 20, UnitPrice = 12 }
            //        };
            //    worker.CategoryRepository.Insert(cookBook);
            //    var books = worker.ProductRepository.Select(p => p.CategoryID == computerBook.CategoryID);

            //    List<Invioce> _invoiceList = new List<Invioce>() {
            //    new Invioce{  InvioceID=1, Description="First Data", Price="500tl" },
            //    new Invioce{InvioceID=2, Description="last DAta", Price="250tl" } };
            //    for (int i = 0; i < _invoiceList.Count; i++)
            //    {
            //        worker.InvioceRepository.Insert(_invoiceList[i]);
            //    }
            //    worker.Save();

            //    List<Payment> _paymentList = new List<Payment>() {
            //    new Payment{  PaymentID=1, Description="First Data", Price="500tl" },
            //    new Payment{PaymentID=2, Description="last DAta", Price="250tl" } };
            //    for (int i = 0; i < _invoiceList.Count; i++)
            //    {
            //        worker.PaymentRepository.Insert(_paymentList[i]);
            //        worker.Save();

            //    }

            //    foreach (var book in books)
            //    {
            //        Console.WriteLine("{0} {1} {2}", book.Title, book.UnitPrice, book.Quantity);
            //    }
            //}
            #endregion

            #region Repository Pattern Scientist
            //using (ScientistUnitOfWork workerScientist = new ScientistUnitOfWork())
            //{
            //    ScientistEntity tesla = new ScientistEntity { ID = 1, FirstName = "Nikola", LastName = "Tesla", Title = "Electiric Engineer" };
            //    ScientistEntity Newton = new ScientistEntity { ID = 2, FirstName = "Isac", LastName = "Newton", Title = "Engineer" };
            //    ScientistEntity Galili = new ScientistEntity { ID = 3, FirstName = "Galili", LastName = "Galilio", Title = "Space" };
            //    ScientistEntity Albert = new ScientistEntity { ID = 4, FirstName = "Albert", LastName = "Einstian", Title = "Emc2" };

            //    workerScientist.ScientistRepository.Insert(tesla); //Insert
            //    workerScientist.ScientistRepository.Insert(Newton); //Insert
            //    workerScientist.ScientistRepository.Insert(Galili); // Insert
            //    workerScientist.ScientistRepository.Insert(Albert); // Insert

            //    Invention invention = new Invention { InventionID = 1, Description = "Electric Power", ScientistID = 1 };
            //    Invention invention2 = new Invention { InventionID = 2, Description = "WireLess", ScientistID = 1 };
            //    Invention invention3 = new Invention { InventionID = 3, Description = "Warden Cliff", ScientistID = 1 };

            //    Invention invention4 = new Invention { InventionID = 4, Description = "Grivity", ScientistID = 2 };
            //    Invention invention5 = new Invention { InventionID = 5, Description = "Binoculers", ScientistID = 3 };
            //    Invention invention6 = new Invention { InventionID = 6, Description = "Planets", ScientistID = 4 };

            //    workerScientist.ScientistRepositoryInvention.Insert(invention);
            //    workerScientist.ScientistRepositoryInvention.Insert(invention2);
            //    workerScientist.ScientistRepositoryInvention.Insert(invention3);
            //    workerScientist.ScientistRepositoryInvention.Insert(invention4);
            //    workerScientist.ScientistRepositoryInvention.Insert(invention5);
            //    workerScientist.ScientistRepositoryInvention.Insert(invention6);


            //    workerScientist.Save(); // Transaction Complate

            //    var scientistsResult = workerScientist.ScientistRepository.Select().ToList(); // All Scientist
            //    var inventionResult = workerScientist.ScientistRepositoryInvention.Select().ToList(); // All Invention

            //    var JoinResult = (from t1 in scientistsResult
            //                      join t2 in inventionResult
            //                      on t1.ID equals t2.ScientistID
            //                      group t1 by t1.ID into G
            //                      select new { Sciencetist_ID = G.Key, Invention_Count = G.Count() }).ToList();

            //    JoinResult.RemoveAll(a => a.Sciencetist_ID == 3);
            //    var redundancy = JoinResult.Select(b => b.Invention_Count < 3).FirstOrDefault();

            //    var maxId = scientistsResult.OrderByDescending(a => a.ID).FirstOrDefault(); //Select Max userID or Last added data.
            //    var maxUser = scientistsResult.Max(a => a.ID);
            //    int? minUser = scientistsResult.Min(a => (int?)a.ID); //Null Check
            //    var idk = scientistsResult.OrderBy(a => a.FirstName);

            //    IEnumerable<ScientistEntity> scientists = workerScientist.ScientistRepository.Select(p => p.ID == 2); // Get Scientist with "Where" case

            //    //workerScientist.ScientistRepository.Delete(4); // Delete

            //    ScientistEntity scientistForUpdate = workerScientist.ScientistRepository.FindById(2); //Choose the entity to Delete
            //    scientistForUpdate.Title = "Space, Apple, Sky";

            //    workerScientist.ScientistRepository.Update(scientistForUpdate); // Update

            //    workerScientist.Save(); // Transaction Complate
            //}
            #endregion

            Console.Read();
        }
    }
}
