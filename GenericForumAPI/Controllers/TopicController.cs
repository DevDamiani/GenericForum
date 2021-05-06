using GenericForum.Model.Interfaces.Services;
using GenericForum.Model.Request;
using GenericForum.Model.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GenericForumAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {

        private ITopicService _topicService { get; }

        public TopicController(ITopicService topicService)
        {
            _topicService = topicService;
        }

        // GET: api/Topic/1
        [HttpGet("{id}")]
        public IActionResult GetTopicByID(int id)
        {

            var topicResponse = _topicService.GetTopicByID(id);

            return Ok(topicResponse);

        }

        // GET: api/Topic/?pag=1&count=20
        [HttpGet]
        public IActionResult GetPaginationTopicsByOrderDateDecrescent([FromQuery] int pag = 1, [FromQuery] int count = 20)
        {

            if (pag <= 0 || count <= 0)
                return BadRequest();


            var topicBriefListResponse = _topicService.GetTopicsInRangeByOrderDateDecrescent(pag, count);

            var total = _topicService.TotalData();
            int totalPaginas = (int)Math.Ceiling((double)total / count);
            var tamanhoPagina = topicBriefListResponse.Count();

            string previousPage = pag > 1 && pag > 0 ? $"https://localhost:5001/api/topic/?pag={ pag - 1 }&count={ count }" : "";
            string nextPage = pag < totalPaginas && pag > 0 ? $"https://localhost:5001/api/topic/?pag={ pag + 1 }&count={ count }" : "";

            var paginationTopicBriefResponse = new PaginationGenericResponse<TopicBriefResponse>(
                total, totalPaginas, tamanhoPagina, pag, topicBriefListResponse, previousPage, nextPage);

            return Ok(paginationTopicBriefResponse);

        }

        // GET: api/Topic/?filter=bacana
        [HttpGet("filtertopic")]
        public IActionResult GetPaginationTopicsByFilterWordsinTitle([FromQuery] string filter)
        {

            var topics = _topicService.GetinRangeTopicsByFilterWordsinTitle(10, filter);

            return Ok(topics);

        }

        // POST api/Topic/createtopic
        [Authorize]
        [HttpPost("createtopic")]
        public IActionResult CreateTopic([FromBody] TopicRequest topicDataModel)
        {

            var token = Request.Headers["Authorization"];

            var isCreated = _topicService.CreateTopic(topicDataModel, token);

            if(isCreated)
                return Ok();

            return Unauthorized();
        }

        // POST api/Topic/createcomment
        [Authorize]
        [HttpPost("createcomment")]
        public IActionResult CreateCommentForTopic([FromBody] CommentRequest commentDataModel)
        {

            var token = Request.Headers["Authorization"];

            var isCreated = _topicService.CreateCommentForTopic(commentDataModel, token);

            if (!isCreated)
                return Unauthorized();

            return Ok();
        }

    }
}
