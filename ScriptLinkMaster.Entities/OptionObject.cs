using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptLinkMaster.Entities
{
    public class OptionObject
    {
        public string EntityID { get; set; }
        public double EpisodeNumber { get; set; }
        public double ErrorCode { get; set; }
        public string ErrorMesg { get; set; }
        public string Facility { get; set; }
        public List<FormObject> Forms { get; set; }
        public string OptionId { get; set; }
        public string OptionStaffId { get; set; }
        public string OptionUserId { get; set; }
        public string SystemCode { get; set; }

        public OptionObject()
        {
            this.Forms = new List<FormObject>();
        }
    }
}
