using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteCRUD.Models
{
	public class Person
	{
		public virtual long id { get; set; }
		public virtual string nome { get; set; }
		public virtual string telefone { get; set; }
	}
}