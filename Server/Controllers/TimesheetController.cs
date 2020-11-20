using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SteadFastAssessment.Server.Entities;
using SteadFastAssessment.Shared;
using SteadFastAssessment.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SteadFastAssessment.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TimeSheetController : ControllerBase
    {
        private readonly ILogger<TimeSheetController> _logger;
        private readonly TimeSheetContext _context;

        public TimeSheetController(ILogger<TimeSheetController> logger, TimeSheetContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IEnumerable<TimeSheetModel> Get()
        {
            //EntityFramework - retrieve TimeSheets here
            return _context.TimeSheets
                .Select(ts => new TimeSheetModel { 
                    EmployeeName = ts.EmployeeName,
                    Date = ts.Date,
                    HoursWorked = ts.HoursWorked
                }).ToArray();
        }

        [HttpPost]
        public void Post([FromBody] TimeSheetModel timesheet)
        {
            //Server-side validation
            if (ModelState.IsValid)
            {
                //Create Entity from validated data
                var toAdd = new TimeSheet
                {
                    EmployeeName = timesheet.EmployeeName,
                    Date = timesheet.Date,
                    HoursWorked = timesheet.HoursWorked
                };
                //Add to EntityFramework here
                _context.TimeSheets.Add(toAdd);
                _context.SaveChanges();
            }
        }
    }
}
