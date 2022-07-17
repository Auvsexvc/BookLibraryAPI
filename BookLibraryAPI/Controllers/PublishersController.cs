using BookLibraryAPI.Exceptions;
using BookLibraryAPI.Interfaces;
using BookLibraryAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookLibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly IPublishersService _publishersService;

        public PublishersController(IPublishersService publishersService)
        {
            _publishersService = publishersService;
        }

        [HttpGet("get-all")]
        public IActionResult GetAll(string sortBy = "asc", string searchString = "null")
        {
            try
            {
                return Ok(_publishersService.GetAll(sortBy, searchString));
            }
            catch (Exception)
            {
                return BadRequest("Publishers couldnt be loaded.");
            }
        }

        [HttpPost("add-publisher")]
        public IActionResult AddPublisher([FromBody] PublisherVM publisherVM)
        {
            try
            {
                var newPublisher = _publishersService.AddPublisher(publisherVM);

                return Created(nameof(AddPublisher), newPublisher);
            }
            catch (PublisherNameException e)
            {
                return BadRequest($"{e.Message}, Publisher name: {e.PublisherName}");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("get-publisher-by-id/{id}")]
        public IActionResult GetPublisherById(int id)
        {
            var data = _publishersService.GetPublisherById(id);

            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpGet("get-publisher-books-with-author/{id}")]
        public IActionResult GetPublisherData(int id)
        {
            var data = _publishersService.GetPublisherData(id);

            return Ok(data);
        }

        [HttpDelete("delete-publisher-by-id/{id}")]
        public IActionResult DeletePublisherById(int id)
        {
            try
            {
                _publishersService.DeletePublisherById(id);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}