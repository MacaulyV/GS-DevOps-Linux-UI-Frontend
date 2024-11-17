using Microsoft.AspNetCore.Mvc;

namespace ElectriXDriveUI.Controllers
{
    public class HomeController : Controller
    {
        // Este m�todo 'Index' retorna a view principal da p�gina inicial.
        // Basicamente, ele � respons�vel por carregar o conte�do da p�gina "Home".
        public IActionResult Index()
        {
            return View();
        }
    }
}
