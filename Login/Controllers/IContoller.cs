using System.Web;
using System.Web.Mvc;
public interface IController : Controller
{
    public ActionResult controlar();
    public ActionResulr controlar(Lugar a);
}