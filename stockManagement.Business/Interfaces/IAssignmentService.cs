using stockManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace stockManagement.Business.Interfaces
{
    public interface IAssignmentService
    {
        List<Assignment> ListAssignment();
        Assignment AddAssignment(Assignment Assignment);
        Assignment UpdateAssignment(Assignment Assignment);
        bool DeleteAssignment(int id);
       
        
    }
}
