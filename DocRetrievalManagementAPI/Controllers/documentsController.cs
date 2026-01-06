using DocRetrievalManagementAPI.Models;
using DocRetrievalManagementAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DocRetrievalManagementAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class documentsController : ControllerBase
    {
        private readonly IDocumentService _docServices;
        private const string MockupUser = "Supervisor";

        public documentsController(IDocumentService docServices) 
        { 
            _docServices = docServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetDocumentAll([FromQuery] string? category)
        {
            var doclist = await _docServices.GetDocumentAll(category);
            return Ok(doclist);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDocumentById(int id)
        {
            var doc = await _docServices.GetDocumentById(id);

            if (doc == null) return NotFound();

            return Ok(doc); 
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DocModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var audit = new AuditLogs {
                UserId = MockupUser,
                TableName = "Documents",
                Action = "Insert",
            };

            var response = await _docServices.CreateAsync(model, audit);
            
            if(response.Result == true)
                return Created($"/documents/{response.Documents.Id}",response.Documents);

            return BadRequest();
        }


        [HttpPut("{id}")]        
        public async Task<IActionResult> Update(int id , DocModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var checkDoc = await _docServices.GetDocumentById(id);

            if (checkDoc == null) return NotFound();

            var audit = new AuditLogs
            {
                UserId = MockupUser,
                TableName = "Documents",
                Action = "Update",
            };

            var response = await _docServices.UpdateAsync(id, model, audit);

            if (response.Result == true)
                return Ok("Updated Successful! : Id: " + response.Documents.Id);

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoc(int id)
        {
            var checkDoc = await _docServices.GetDocumentById(id);

            if (checkDoc == null) return NotFound();

            var audit = new AuditLogs
            {
                UserId = MockupUser,
                TableName = "Documents",
                Action = "Update",
            };

            var response = await _docServices.DeleteAsync(id,audit);

            if (response.Result == true)
                return Ok("Deleted Successful! : Id: " + response.Documents.Id);

            return BadRequest();
        }
    }
}
