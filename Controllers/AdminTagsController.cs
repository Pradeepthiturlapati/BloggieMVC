using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using WebApplication1.Data;
using WebApplication1.Models.Domain;
using WebApplication1.Models.ViewModels;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminTagsController : Controller
    {
        private readonly ITagRepository tagRepository;
        public AdminTagsController(ITagRepository  tagRepository)
        {
            this.tagRepository = tagRepository;
              
        }

        [Authorize(Roles ="Admin")]
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ActionName("Add")]
        public async Task<IActionResult> Add(AddTagRequest addTagRequest)
        {
            ValidateAddTagRequest(addTagRequest);
            if(ModelState.IsValid==false)
            {
                return View(); 
            }
            //mapping add tag request to tag domain model
            var tag = new Tag
            {
                Name = addTagRequest.Name,
                DisplayName=addTagRequest.DisplayName

            };
            await  tagRepository.AddAsync(tag);
            return RedirectToAction("List");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        [ActionName("List")]
        public  async Task<IActionResult> List(string? searchQuery,
            string? sortBy,string? sortDirection,
            int pageSize = 3,
            int pageNumber=1)
        {
            var totalRecords = await tagRepository.CountAsync();
            var totalPages = Math.Ceiling((decimal)totalRecords / pageSize);
            if(pageNumber > totalPages)
            {
                pageNumber--;
            }
            if(pageNumber < 1)
            {
                pageNumber++;
            }

            ViewBag.TotalPages = totalPages;
            ViewBag.SearchQuery = searchQuery;
            ViewBag.SortBy = sortBy;
            ViewBag.PageSize = pageSize;
            ViewBag.PageNumber = pageNumber;
            ViewBag.SortDirection = sortDirection;
            
            //use dbcontext
            var tags = await tagRepository.GetAllAsync(searchQuery,sortBy,sortDirection,pageNumber,pageSize);

            return View(tags);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid Id)
        {
            // 1st method bloggieDbContext.Tags.Find(Id);
              var tag= await tagRepository.GetAsync(Id);
            if (tag != null)
            {
                var editTagRequest = new EditTagRequest
                {
                    Id = tag.Id,
                    Name = tag.Name,
                    DisplayName = tag.DisplayName
                };
                return View(editTagRequest);
            }
            return View(null);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Edit(EditTagRequest editTagRequest)
        {
            var tag = new Tag
            {
                Id = editTagRequest.Id,
                Name=editTagRequest.Name,
                DisplayName=editTagRequest.DisplayName
            };
           
           var updatedtag= await tagRepository.UpdateAsync(tag);
            if (updatedtag != null)
            { 

            }
            else
            {

            }
            return RedirectToAction("Edit", new { id = editTagRequest.Id });
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Delete(EditTagRequest editTagRequest)
        {
          var deletedTag=await tagRepository.DeleteAsync(editTagRequest.Id);
            if(deletedTag != null)
            {
                return RedirectToAction("List");
            }
            return RedirectToAction("Edit", new { id = editTagRequest.Id });
        }

        private void ValidateAddTagRequest(AddTagRequest addTagRequest)
        {
            if (addTagRequest.Name != null && addTagRequest.DisplayName != null)
            {
                if (addTagRequest.Name == addTagRequest
                    .DisplayName)
                {
                    ModelState.AddModelError("DisplayName", "Name cannot be same as displayname.");
                }
            }
        }
    }
}
