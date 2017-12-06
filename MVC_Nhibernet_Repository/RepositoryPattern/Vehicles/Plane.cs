using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryPattern.Abstraction;

namespace RepositoryPattern.Vehicles
{
    public class Plane : IVehicle
    {
        public void Fire()
        {
            Console.WriteLine("Fire From Plane");
        }

        public void Move()
        {
            Console.WriteLine("Plane on the Move");
        }
    }
    }
