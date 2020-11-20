using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SteadFastAssessment.Shared.Model
{
    //Use DataAnnotations for client-side + server-side validation
    public class TimeSheetModel : ITimeSheet
    {
        [Required(ErrorMessage = "Please enter an Employee Name")]
        public string EmployeeName { get; set; }
        [Required(ErrorMessage = "Please enter a Date")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Please enter the Hours Worked")]
        [Range(0, 24, ErrorMessage = "Hours Worked must be between 0 and 24")]
        public double HoursWorked { get; set; }
    }
}
