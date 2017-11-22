using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Mapping;
using NHibernate;
using System.Configuration;

namespace MVC_Nhibernet_Repository.DAL
{
    public class DatabaseModule
    {
        private static ISessionFactory _sessionFactory;
        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                    InitializeSessionFactory();

                return _sessionFactory;
            }
        }
        private static void InitializeSessionFactory()
        {
            string conn =ConfigurationManager.ConnectionStrings["db"].ConnectionString; // Get connection string from web.config

            _sessionFactory = Fluently.Configure().Database(MsSqlConfiguration.MsSql2008
               .ConnectionString(conn).ShowSql())
               .Mappings(m => m.FluentMappings.AddFromAssembly(typeof(DatabaseModule).Assembly))
               .BuildSessionFactory();
        }
        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
        public static IStatelessSession OpenStatelessSession()
        {
            return SessionFactory.OpenStatelessSession();
        }
    }

    public class Scientists
    {
        public virtual int ID { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Title { get; set; }
    }
    public class Inventions
    {
        public virtual int InventionID { get; set; }
        public virtual string Description { get; set; }
        public virtual Scientists ScientistID { get; set; }
    }

    public class ScientistsMap : ClassMap<Scientists>
    {
        public ScientistsMap()
        {
            Table("Scientists");
            Id(x => x.ID);
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.Title).Not.LazyLoad();
        }
    }
    public class InventionsMap : ClassMap<Inventions>
    {
        public InventionsMap()
        {
            Table("Inventions");
            Id(x => x.InventionID);
            Map(x => x.Description);
            //References(x => x.ScientistID).Column("ScientistID");
            References(x => x.ScientistID).Column("ScientistID").Not.LazyLoad(); //It causes to problem when you eager to call 2 get event from angular
        }
    }
  }