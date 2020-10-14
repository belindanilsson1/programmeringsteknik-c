namespace TimeSheet.Common.Models
{
    public class TimeSheetEntryModel
    {
        //Har normalt egenskaper eller metoder. 
        public string WorkDone { get; set; }
        public int HoursWorked { get; set; }

        //Fält, brukar inte ha publika fält. Fel sätt att skriva.
        // public string WorkDone;
        // public int HoursWorked;
    }
}
