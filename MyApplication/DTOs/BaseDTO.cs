using System;
using System.Collections.Generic;
using System.Data.SqlTypes;

namespace MyApplication.DTOs
{
    [Serializable]
    public class BaseDTO
    {
        private int _id = 0;
        private string _createddBy = "";
        private int _createddById = 0;
        private DateTime _createdDate = (DateTime)SqlDateTime.MinValue;
        private string _modifiedBy = "";
        private int _modifiedById = 0;
        private DateTime _modifiedDate = (DateTime)SqlDateTime.MinValue;
        private bool _isDirty = false;

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
            }
        }

        public string CreatedBy
        {
            get { return _createddBy; }
            set
            {
                _createddBy = value;
            }
        }

        public int CreatedById
        {
            get { return _createddById; }
            set
            {
                _createddById = value;
            }
        }

        public DateTime CreatedDate
        {
            get { return _createdDate; }
            set
            {
                _createdDate = value;
            }
        }

        public string ModifiedBy
        {
            get { return _modifiedBy; }
            set
            {
                _modifiedBy = value;
            }
        }

        public int ModifiedById
        {
            get { return _modifiedById; }
            set
            {
                _modifiedById = value;
            }
        }

        public DateTime ModifiedDate
        {
            get { return _modifiedDate; }
            set
            {
                _modifiedDate = value;
            }
        }
        
        public bool IsDirty
        {
            get { return _isDirty; }
            set { _isDirty = value; }
        }
    }
}
