using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScriptLinkMaster.CustomEntities
{
    public class CustomFieldObject
    {
        private string _FieldNumber;

        public string FieldNumber
        {
            get { return _FieldNumber; }
            set
            {
                _FieldNumber = value;
                UpdateFieldState();
            }
        }
        private string _FieldValue;

        public string FieldValue
        {
            get { return _FieldValue; }
            set
            {
                _FieldValue = value;
                UpdateFieldState();
            }
        }
        private LockedStatus _LockedStatus;

        public LockedStatus LockedStatus
        {
            get { return _LockedStatus; }
            set
            {
                _LockedStatus = value;
                UpdateFieldState();
            }
        }
        private RequiredStatus _RequiredStatus;

        public RequiredStatus RequiredStatus
        {
            get { return _RequiredStatus; }
            set
            {
                _RequiredStatus = value;
                UpdateFieldState();
            }
        }

        private EnabledStatus _EnabledStatus;

        public EnabledStatus EnabledStatus
        {
            get { return _EnabledStatus; }
            set
            {
                _EnabledStatus = value;
                UpdateFieldState();
            }
        }
        public FieldState FieldState { get; set; }
        public CustomFieldObject()
        {
            LockedStatus = LockedStatus.Unlocked;
            RequiredStatus = RequiredStatus.Unrequired;
            EnabledStatus = EnabledStatus.Enabled;
            FieldState = FieldState.Unchanged;
        }
        protected virtual void UpdateFieldState()
        {
            this.FieldState = FieldState.Modified;
        }
    }
    public enum LockedStatus
    {
        Unlocked = 0,
        Locked = 1
    }
    public enum RequiredStatus
    {
        Unrequired = 0,
        Required = 1
    }
    public enum EnabledStatus
    {
        Disabled = 0,
        Enabled = 1
    }
    public enum FieldState
    {
        Unchanged = 0,
        Modified = 1
    }
}
