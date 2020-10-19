using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Remabec.Instaff
{
    public class ERPEmployee
    {
        [JsonProperty(PropertyName = "employee_id")]
        public string EmployeeId { get; set; }

        [JsonProperty(PropertyName = "first_name")]
        public string Firstname { get; set; }

        [JsonProperty(PropertyName = "middle_name")]
        public string Middlename { get; set; }

        [JsonProperty(PropertyName = "last_name")]
        public string Lastname { get; set; }

        [JsonProperty(PropertyName = "employee_name")]
        public string Fullname { get; set; }

        [JsonProperty(PropertyName = "ssn")]
        public string SSN { get; set; }

        [JsonProperty(PropertyName = "employee_email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "address1")]
        public string Address1 { get; set; }

        [JsonProperty(PropertyName = "address2")]
        public string Address2 { get; set; }

        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }

        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }

        [JsonProperty(PropertyName = "zip")]
        public string Zip { get; set; }

        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }

        [JsonProperty(PropertyName = "homephone")]
        public string HomePhone { get; set; }

        [JsonProperty(PropertyName = "workphone")]
        public string WorkPhone { get; set; }

        [JsonProperty(PropertyName = "mobilephone")]
        public string MobilePhone { get; set; }

        [JsonProperty(PropertyName = "birthdate")]
        public string BirthDate { get; set; }

        [JsonProperty(PropertyName = "hiredate")]
        public string HireDate { get; set; }

        [JsonProperty(PropertyName = "firedate")]
        public string FireDate { get; set; }

        [JsonProperty(PropertyName = "employee_department_name")]
        public string DepartmentName { get; set; }

        [JsonProperty(PropertyName = "employee_access_code")]
        public string AccessCode { get; set; }
    }
}
