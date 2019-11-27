using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using TesteCRUD.Models;

namespace TesteCRUD
{
	public class PersonMap : ClassMap<Person>
	{
		public PersonMap()
		{
			Id(x => x.id).GeneratedBy.Increment();
			Map(x => x.nome);
			Table("person");
		}
	}
}