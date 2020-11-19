using System;
using System.Collections.Generic;
using System.Text;

namespace SteadFastAssessment.Shared.Model
{
    public class TimeSheetModel : ITimeSheet
    {
        public string EmployeeName { get; set; }
        public DateTime Date { get; set; }
        public double HoursWorked { get; set; }
    }
    public interface ITimeSheet
    {
        public string EmployeeName { get; set; }
        public DateTime Date { get; set; }
        public double HoursWorked { get; set; }
    }
}
