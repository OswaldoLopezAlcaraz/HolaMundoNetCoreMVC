using HolaMundoNetCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace HolaMundoNetCoreMVC.Controllers
{
    public class HomeController : Controller
    {
        #region Propiedades
        private readonly ILogger<HomeController> _logger;
        #endregion Propiedades

        #region Constructor
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        #endregion Constructor

        #region Views
        public IActionResult Index()
        {
            return View();

        }


        public IActionResult Privacy()
        {
            return View();
        }


        #endregion Views

        #region Metodos
        /// <summary>
        /// Oswaldo Lopez 22ABR23
        /// Método de validación de contraseña
        /// Al menos una letra mayúscula
        /// Al menos una letra minúscula
        /// Al menos un símbolo
        /// Al menos un número
        /// </summary>
        /// <param name="Contrasena">String que se obtiene de la vista index</param>
        /// <returns>IActionResult que regresa el view Index</returns>
        public IActionResult ValidarTexto(string Contrasena, string RepiteContrasena)
        {
            Regex regex = new Regex("^(?=.*[A-Z])(?=.*[a-z])(?=.*\\d)(?=.*\\W).+$");

            if (regex.IsMatch(Contrasena))
            {
                if (RepiteContrasena.Equals(Contrasena))
                {
                    ViewBag.Message = "La contrasena ha sido validada";
                }
                else
                {
                    ViewBag.Message = "Lo que ingresaste en los campos no es igual";
                }
            }
            else
            {
                ViewBag.Message = "La contrasena NO ha sido validada";
            }

            return View("Index");
        }
        #endregion Metodos



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}