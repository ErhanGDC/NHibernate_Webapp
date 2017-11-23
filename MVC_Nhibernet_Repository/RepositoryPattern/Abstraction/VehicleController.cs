using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Abstraction
{
    public class VehicleController
    {
        IVehicle _vehicle;
        public VehicleController(IVehicle vehicle)
        {
            _vehicle = vehicle;
        }

        public void Fire()
        {
            _vehicle.Fire();
        }
        public void Move()
        {
            _vehicle.Move();
        }
    }
}
