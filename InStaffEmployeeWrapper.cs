using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Remabec.Instaff
{
    public class InStaffEmployeeWrapper
    {
        [JsonProperty(PropertyName = "employees_list")]
        public List<ERPEmployee> EmployeeList { get; set; }
    }
}
