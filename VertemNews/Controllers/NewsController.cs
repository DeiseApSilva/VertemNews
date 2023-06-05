using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VertemNews.Data;
using VertemNews.Models;


namespace VertemNews.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly VertemNewsContext _context;

        public NewsController(VertemNewsContext context)
        {
            _context = context;
        }
       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<News>>> GetNews()
        {
          if (_context.News == null)
          {
              return NotFound();
          }
            return await _context.News.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<News>> GetNews(int id)
        {
          if (_context.News == null)
          {
              return NotFound();
          }
            var news = await _context.News.FindAsync(id);

            if (news == null)
            {
                return NotFound();
            }

            return news;
        }

        [HttpGet]
        [Route("Search/{text}")]
        public  ActionResult<IEnumerable<News>> GetNews([FromRoute] string text)
        {
            var news =  _context.News.Where(x => x.Title.Contains(text) ||
                                         x.Description.Contains(text) ||
                                         x.Author.Contains(text) ||
                                         x.Content.Contains(text) ||
                                         x.SourceID.Contains(text)).ToList();

            if (news == null)
            {
                return NotFound();
            }

            return news;
        }

        [HttpGet]
        [Route("Source/{text}")]
        public ActionResult<IEnumerable<News>> GetNewsSouce([FromRoute] string text)
        {
            var news = _context.News.Where(x => x.SourceID.Equals(text)).ToList();

            if (news == null)
            {
                return NotFound();
            }

            return news;
        }

        [HttpGet]
        [Route("Category/{text}")]
        public ActionResult<IEnumerable<News>> GetNewsCategory([FromRoute] string text)
        {
            var news = _context.News.Where(x => x.Category.Equals(text)).ToList();

            if (news == null)
            {
                return NotFound();
            }

            return news;
        }

        private bool NewsExists(int id)
        {
            return (_context.News?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
