using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrelloCopyWinForms.Models.TableModels.SubTaskAttribs
{
    public  class DeadLineDate
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string PrintString { get; set; }

        public DeadLineDate()
        {
            StartDate = null;
            EndDate = null;
            PrintString = "";
        }

        public DeadLineDate(DateTime endDate, string print)
        {
            StartDate = null;
            EndDate = endDate;
            PrintString = print;
        }
        public DeadLineDate(DateTime startTime, DateTime endDate, string print)
        {
            StartDate = startTime;
            EndDate = endDate;
            PrintString = print;
        }
    }
}
