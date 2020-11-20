using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteadFastAssessment.Shared.Model
{
    public interface ITimeSheet
    {
        public string EmployeeName { get; set; }
        public DateTime Date { get; set; }
        public double HoursWorked { get; set; }
    }
}
