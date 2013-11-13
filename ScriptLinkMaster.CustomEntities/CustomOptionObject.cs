using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptLinkMaster.CustomEntities
{
    public class CustomOptionObject : IEquatable<CustomOptionObject>
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

        public void RemoveEmptyForms()
        {
            Forms.RemoveAll(f => !f.Rows.Any());
        }

        public bool Equals(CustomOptionObject other)
        {
            if (other == null)
                return false;
            return this.EntityID == other.EntityID &&
                this.EpisodeNumber == other.EpisodeNumber &&
                this.ErrorCode == other.ErrorCode &&
                this.ErrorMesg == other.ErrorMesg &&
                this.Facility == other.Facility &&
                this.OptionId == other.OptionId &&
                this.OptionStaffId == other.OptionStaffId &&
                this.OptionUserId == other.OptionUserId &&
                this.SystemCode == other.SystemCode &&
                AreFormsEqual(this.Forms, other.Forms);

        }
        public override bool Equals(object obj)
        {
            CustomOptionObject customOptionObject = obj as CustomOptionObject;
            if (customOptionObject == null)
                return false;
            return this.Equals(customOptionObject);
        }
        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + EntityID.GetHashCode();
            hash = hash * 23 + EpisodeNumber.GetHashCode();
            hash = hash * 23 + ErrorCode.GetHashCode();
            hash = hash * 23 + ErrorMesg.GetHashCode();
            hash = hash * 23 + Facility.GetHashCode();
            hash = hash * 23 + OptionId.GetHashCode();
            hash = hash * 23 + OptionStaffId.GetHashCode();
            hash = hash * 23 + OptionUserId.GetHashCode();
            hash = hash * 23 + SystemCode.GetHashCode();
            foreach (var form in this.Forms)
            {
                hash = hash * 23 + form.GetHashCode();
            }
            return hash;
        }

        private bool AreFormsEqual(List<CustomFormObject> list1, List<CustomFormObject> list2)
        {
            if (!AreBothNull(list1, list2) && AreBothEmpty(list1, list2))
                return true;

            if (list1.Count != list2.Count)
                return false;

            for (int i = 0; i < list1.Count; i++)
            {
                if (!list1[i].Equals(list2[i]))
                {
                    return false;
                }
            }
            return true;
        }

        private bool AreBothEmpty(List<CustomFormObject> list1, List<CustomFormObject> list2)
        {
            return (!list1.Any() && !list2.Any());
        }

        private bool AreBothNull(List<CustomFormObject> list1, List<CustomFormObject> list2)
        {
            return (list1 == null && list2 == null);
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
