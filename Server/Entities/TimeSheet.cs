using SteadFastAssessment.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SteadFastAssessment.Server.Entities
{
    public class TimeSheet : ITimeSheet
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public DateTime Date { get; set; }
        public double HoursWorked { get; set; }
    }
}
