using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using stockManagement.Business.Interfaces;
using stockManagement.Data.Models;
using System.Collections.Generic;

namespace stockManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private readonly IAssignmentService _assignmentService;
        public AssignmentController(IAssignmentService assignmentService)
        {
            _assignmentService = assignmentService;
        }


        [HttpGet("getListAssignment")]
        public List<Assignment> GetListAssignment()
        {
            List<Assignment> assignment = new List<Assignment>();
            assignment = _assignmentService.ListAssignment();
            return (assignment);
        }

        [HttpPost("addAssignment")]
        public Assignment AddAssignment([FromBody] Assignment assignment)
        {
            Assignment assignmentToAdd = new Assignment();
            assignmentToAdd = _assignmentService.AddAssignment(assignment);
            return (assignmentToAdd);
        }

        [HttpDelete("deleteAssignment/{id}")]
        public IActionResult DeleteAssignment(int id)
        {
            bool result = this._assignmentService.DeleteAssignment(id);
            return Ok(result);
        }

        [HttpPut("updateAssignment")]
        public Assignment UpdateAssignment([FromBody] Assignment assignment)
        {
            assignment = _assignmentService.UpdateAssignment(assignment);
            return (assignment);
        }

        

       
    }
}
