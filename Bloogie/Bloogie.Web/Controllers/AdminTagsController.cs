using Microsoft.AspNetCore.Mvc;
using Bloogie.Web.Models.ViewModel;
using Bloogie.Web.Models.Domain;
using Bloogie.Web.Data;
namespace Bloogie.Web.Controllers
{
    public class AdminTagsController : Controller
    {
        private readonly BloogieDbContext bloogieDbContext;

        //Making Constructor Injection for communicating with Database
        //private BloogieDbContext _bloogieDbContext;
        public AdminTagsController(BloogieDbContext bloogieDbContext)
        {
            this.bloogieDbContext = bloogieDbContext;
            //_bloogieDbContext = bloogieDbContext;
        }

        

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        //[ActionName("Add")]

        public IActionResult Add(AddTagRequest addTagRequest)
        {
            //Easy Approach-Not recommended
            //var name = Request.Form["name"];
            //var displayName = Request.Form["displayName"];

            //More Better Approach-MODEL BINDING
            //var name = addTagRequest.Name;
            //var displayName = addTagRequest.DisplayName;

            //saving to DB
            //Mapping The Add Tag Request to Tag Domain Model
            var tag = new Tag
            {
                Name = addTagRequest.Name,
                DisplayName = addTagRequest.DisplayName
            };
            bloogieDbContext.Tags.Add(tag);
            //This Line is Crucial to save changes in Databases
            bloogieDbContext.SaveChanges();
            return View("Add");                                                 
        }
    }
}
