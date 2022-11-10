using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Hotsite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Hotsite.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Cadastrar(Interesse cad)
		{
			try
			{
				DatabaseService dbs = new DatabaseService();
				dbs.CadastraInteresse(cad);
				return Json(new {status = "Ok", mensagem = "Sucesso!"});
			}
			catch (Exception e)
			{
				_logger.LogError("Erro no cadastro" + e.Message);

				return Json(new {status = "ERR", mensagem = "Tente novamente!"});
			}

		}

	}
}
