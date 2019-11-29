using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteCRUD.Models;

namespace TesteCRUD.Controllers
{
	public class HomeController : Controller
	{
		GenericRepository<Person> pessoaRepository = new GenericRepository<Person>();
		public ActionResult Index()
		{			
			return View();
		}

		[HttpPost]
		public ActionResult CreatePage()
		{			
			return View();
		}

		public JsonResult CreatePeople(Person pessoa)
		{
			Person newPessoa = new Person();
			newPessoa.nome = pessoa.nome;
			newPessoa.telefone = pessoa.telefone;

			try
			{
				pessoaRepository.Save(pessoa);
				return Json(newPessoa.nome, JsonRequestBehavior.AllowGet);
			}
			catch (Exception ex)
			{
				return Json(null, JsonRequestBehavior.AllowGet);
			}
		}

	}
}