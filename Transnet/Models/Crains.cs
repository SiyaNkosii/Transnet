using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transnet.Models
{
    public class Crains
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CrainId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Start Date")]
        public DateTime strtDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName(" End date")]
        public DateTime endDate { get; set; }
        public int Days { get; set;}



        [DisplayName("No. of shift per day and No. of public holidays (PH) During Period")]
        public int noShiftonHd { get; set; }
        [DisplayName("No. of Hours per shift and No. of public holidays (PH) During Period")]
        public int noShiftphrHD { get; set; }
        [DisplayName("No. of Days and No. of public holidays (PH) During Period")]
        public int noDaysPD { get; set; }
        [DisplayName("No. of Hours and No. of public holidays (PH) During Period")]
        public int noHoursPD { get; set; }



        [DisplayName("Weekdays exclude PH : No. of shift per day")]
        public int noShiftonEx { get; set; }
        [DisplayName("Weekdays exclude PH : No. of Hours per shift.")]
        public int noShifpHrEx { get; set; }
        [DisplayName("Weekdays exclude PH : No. of days")]
        public int noDaysEx { get; set; }
        [DisplayName("Weekdays exclude PH : No. of Hours")]
        public int noHoursEx { get; set; }



        [DisplayName("On weekends : No. of shift per day")]
        public int noShiftonWk { get; set; }
        [DisplayName("On weekends : No. of shift per Hour")]
        public int noShiftpHrWk { get; set; }
        [DisplayName("On weekends : No. of Days")]
        public int noDaysonWk { get; set; }
        [DisplayName("On weekends : No. of Hours")]
        public int noHoursonWk { get; set; }


        [DisplayName("No. Of Cranes")]
        public int NoCrains { get; set; }
        [DisplayName("Total time per crane")]
        public int totTimepC { get; set; }
        [DisplayName("Total time")]
        public int totTime { get; set; }


        public int HoursPH()
        {
            int tot = 0;
            tot = noShiftonHd * noShiftphrHD * noDaysPD;
            return tot;
        }
        public int HoursExPH()
        {
            int tot = 0;
            tot = noShiftonEx * noShifpHrEx * noDaysEx;
            return tot;
        }
        public int HoursWnd()
        {
            int tot = 0;
            tot = noShiftonWk * noShiftpHrWk * noDaysonWk;
            return tot;
        }
        public int TotCr()
        {
            int tot = 0;
            tot = HoursPH() + HoursExPH() + HoursWnd();
            return tot;
        }
        public int TotTime()
        {
            int tot = 0;
            tot = TotCr() * NoCrains;
            return tot;
        }



    }
}