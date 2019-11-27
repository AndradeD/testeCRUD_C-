using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Data;

namespace TesteCRUD
{
	public interface IRepository<TEntity>
	{
		void Save(TEntity obj);
		void Delete(TEntity obj);
		object GetById(long id);
		List<TEntity> GetAll();
	}
}
