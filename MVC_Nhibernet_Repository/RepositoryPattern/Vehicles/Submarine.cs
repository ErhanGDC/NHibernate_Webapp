using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryPattern.Abstraction;

namespace RepositoryPattern.Vehicles
{
    public class Submarine : IVehicle
    {
        public void Fire()
        {
            Console.WriteLine("Fire From Submarine");
        }

        public void Move()
        {
            Console.WriteLine("Submarine on the Move");
        }
    }
}
