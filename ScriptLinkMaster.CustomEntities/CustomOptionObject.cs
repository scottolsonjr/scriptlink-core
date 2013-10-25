using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptLinkMaster.CustomEntities
{
    public class CustomOptionObject
    {
        public string EntityID { get; set; }
        public double EpisodeNumber { get; set; }
        public ErrorCode ErrorCode { get; set; }
        public string ErrorMesg { get; set; }
        public string Facility { get; set; }
        public List<CustomFormObject> Forms { get; set; }
        public string OptionId { get; set; }
        public string OptionStaffId { get; set; }
        public string OptionUserId { get; set; }
        public string SystemCode { get; set; }

        public CustomOptionObject()
        {
            this.ErrorCode = ErrorCode.None;
            this.Forms = new List<CustomFormObject>();
        }
    }

    public enum ErrorCode
    {
        None = 0,
        Blank = 1,
        OKCancel = 2,
        OK = 3,
        YesNo = 4,
        URL = 5
    }

}
