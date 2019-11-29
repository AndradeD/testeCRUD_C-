
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;

namespace TesteCRUD
{
	public static class Database<TEntity>
	{
		private static ISessionFactory _sessionFactory;
		private static ISessionFactory SessionFactory
		{
			get
			{
				if (_sessionFactory == null)
				{
					_sessionFactory = Fluently.Configure().Database(MySQLConfiguration.Standard.ConnectionString(
						c => c.FromConnectionStringWithKey("ConnectionString")
					)).Mappings(m => m.FluentMappings.AddFromAssemblyOf<TEntity>()).BuildSessionFactory();
				}
				return _sessionFactory;
			}
		}
		public static ISession OpenSession()
		{
			return SessionFactory.OpenSession();
		}
	}
}