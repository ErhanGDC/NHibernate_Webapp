using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using RepositoryPattern.Vehicles;

namespace RepositoryPattern.Abstraction
{
    public class Castle_Abstraction : IDisposable
    {
        private IWindsorContainer windsorContainer=new WindsorContainer();

        public void TankFactory()
        {
            windsorContainer.Register(Component.For<IVehicle>().ImplementedBy<Tank>());
        }

        public void SubmarineFactory()
        {
            windsorContainer.Register(Component.For<IVehicle>().ImplementedBy<Submarine>());
        }

        public void PlaneFactory()
        {
            windsorContainer.Register(Component.For<IVehicle>().ImplementedBy<Plane>());
        }

        public T ResolveCastle<T>()
        {
            return windsorContainer.Resolve<T>();
        }

        public void Dispose()
        {
            windsorContainer.Dispose();
        }
    }
}
