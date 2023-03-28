using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;

namespace MyApplication.DTOs
{
    [Serializable]
    public class Service:BaseDTO
    {
        private string _serviceName = string.Empty;
        
        public string ServiceName
        {
            get { return _serviceName; }
            set
            {
                _serviceName = value;
                IsDirty = true;
            }
        }
        
        private string _productNumber = string.Empty;
        
        public string ProductNumber
        {
            get { return _productNumber; }
            set
            {
                _productNumber = value;
                IsDirty = true;
            }
        }
        
        private string _description = string.Empty;
        
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                IsDirty = true;
            }
        }
        
        private string _scopeOfWork = string.Empty;
        
        public string ScopeOfWork
        {
            get { return _scopeOfWork; }
            set
            {
                _scopeOfWork = value;
                IsDirty = true;
            }
        }
        
        private decimal _unitPrice = 0;
        
        public decimal UnitPrice
        {
            get { return _unitPrice; }
            set
            {
                _unitPrice = value;
                IsDirty = true;
            }
        }
        
        private int _modifiedById = 0;
        
        public int ModifiedById
        {
            get { return _modifiedById; }
            set
            {
                _modifiedById = value;
                IsDirty = true;
            }
        }
        
    }
}
