using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordsController : ControllerBase
    {
        private readonly IWordService _wordService;

        public WordsController(IWordService wordService)
        {
            _wordService = wordService;
        }

        [HttpGet("getAllWords")]
        public IActionResult GetAll()
        {
            var result = _wordService.GetAll();
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getByWordId")]
        public IActionResult GetById(int exampleId)
        {
            var result = _wordService.GetById(exampleId);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }
        
        [HttpGet("getByName")]
        public IActionResult GetById(string wordName)
        {
            var result = _wordService.GetByName(wordName);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }


        [HttpPost("addWord")]
        public IActionResult Add(Word word)
        {
            var result = _wordService.Add(word);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("deleteWord")]
        public IActionResult Delete(Word word)
        {
            var result = _wordService.Delete(word);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("updateWord")]
        public IActionResult Update(Word word)
        {
            var result = _wordService.Update(word);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }
    }
}