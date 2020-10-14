using System.Collections.Generic;
using TimeSheet.Common.Models;
using System;
using System.Linq;

namespace TimeSheet.Common
{
    public class TimeSheetProcessor
    {
        public static int CalculateTimeForCustomer(List<TimeSheetEntryModel> entries, string customerName)
        {
            int sum = 0;

            foreach (var entry in entries)
            {
                int customerIndex = entry.WorkDone.IndexOf(customerName, StringComparison.OrdinalIgnoreCase);
                if (customerIndex >= 0)
                {
                    sum += entry.HoursWorked;
                }

                /* if (entry.WorkDone.ToLower().Contains(customerName.ToLower()))
                 {
                     sum += entry.HoursWorked;
                 }           */
            }

            return sum;
        }

        public static int CalculateTimeWorked(List<TimeSheetEntryModel> entries)
        {
            int sum = 0;

            foreach (var entry in entries)
            {
                sum += entry.HoursWorked;
            }
            return sum;
        }


    }
}
