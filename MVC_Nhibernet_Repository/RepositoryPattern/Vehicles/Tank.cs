using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryPattern.Abstraction;

namespace RepositoryPattern.Vehicles
{
    public class Tank : IVehicle
    {
        public void Fire()
        {
            Console.WriteLine("Fire From Tank");
        }

        public void Move()
        {
            Console.WriteLine("Tank on the Move");
        }
    }
}
