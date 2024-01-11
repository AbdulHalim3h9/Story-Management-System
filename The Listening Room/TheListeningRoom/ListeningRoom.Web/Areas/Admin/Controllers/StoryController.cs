using Autofac;
using ListeningRoom.Web.Models;
using ListeningRoom.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Formats.Asn1.AsnWriter;
using ListeningRoom.Web.Codes;

namespace ListeningRoom.Web.Areas.Admin.Controllers
{
   [Area("Admin")]
    public class StoryController : Controller
    {
        private readonly ILifetimeScope _scope;
        private readonly ILogger<StoryController> _logger;
        public StoryController(ILogger<StoryController> logger, ILifetimeScope scope)
        {
            _scope = scope;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            AddStoryModel model = _scope.Resolve<AddStoryModel>();
            return View(model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddStoryModel model)
        {
            if (ModelState.IsValid)
            {
                model.ResolveDependency(_scope);
                await model.AddStory();
            }
            return View(model);
        }

        public IActionResult Edit(Guid id)
        {
            var model = _scope.Resolve<EditStoryModel>();
            model.LoadData(id);

            return View(model);
        }

        [ValidateAntiForgeryToken, HttpPost]
        public IActionResult Edit(EditStoryModel model)
        {
            if (ModelState.IsValid)
            {
                model.ResolveDependency(_scope);

                try
                {
                    model.EditCourse();

                    TempData["ResponseMessage"] = "Successfuly updated story.";
                    TempData["ResponseType"] = ResponseTypes.Success;

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                    TempData["ResponseMessage"] = "There was a problem in updating story.";
                    TempData["ResponseType"] = ResponseTypes.Danger;
                }
            }

            return View(model);
        }

        public JsonResult GetStoryData()
        {
            var dataTableModel = new DataTablesAjaxRequestModel(Request);
            var model = _scope.Resolve<StoryListModel>();
            return Json(model.GetPagedStories(dataTableModel));
        }

        [ValidateAntiForgeryToken, HttpPost]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var model = _scope.Resolve<StoryListModel>();
                model.DeleteStory(id);

                TempData["ResponseMessage"] = "Successfuly deleted course.";
                TempData["ResponseType"] = ResponseTypes.Success;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                TempData["ResponseMessage"] = "There was a problem in deleteing course.";
                TempData["ResponseType"] = ResponseTypes.Danger;
            }

            return RedirectToAction("Index");
        }
    }
}
