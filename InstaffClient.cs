using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Remabec.Instaff
{


    public class InstaffClient //: IDisposable
    {
        private readonly HttpClient httpClient;        
        //private readonly string jsonMediaType = "application/json";
        private JsonSerializerSettings jsonSettings { get; set; }
        public bool IsDisposed { get; private set; }

        public InstaffClient(string apiBase, string user, string pw)
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress =new Uri(apiBase);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            var byteArrayAuth = new UTF8Encoding().GetBytes($"{user}:{pw}");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArrayAuth));
            
            
            jsonSettings = new JsonSerializerSettings();
            jsonSettings.NullValueHandling = NullValueHandling.Ignore;
            jsonSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

        }                    


        public async Task<string> PostAsync(string resource, byte[] postData)
        {
            ByteArrayContent strContent = new ByteArrayContent(postData);
            HttpResponseMessage responseMessage = await httpClient.PostAsync(resource, strContent).ConfigureAwait(false);
            responseMessage.EnsureSuccessStatusCode();

            var responseJson = JObject.Parse(responseMessage.Content.ReadAsStringAsync().Result);
            
            Console.WriteLine($"Status Code: { responseMessage.StatusCode}");
            Console.WriteLine($"Message: {responseJson["message"]}\r\nStatus: {responseJson["status"]}");

            if (responseMessage.StatusCode != HttpStatusCode.Created && responseMessage.StatusCode != HttpStatusCode.OK)
                throw new Exception(string.Format("Server Error (HTTP{0}: {1}).", (object)responseMessage.StatusCode, (object)responseJson["message"]));

            return $"{responseJson["message"].ToString()} Statut : {responseJson["status"]}";
        }


        public string PushEmployees(ERPEmployee[] employees)
        {
            InStaffEmployeeWrapper wrapper = new InStaffEmployeeWrapper();            
            wrapper.EmployeeList = employees.ToList();

            var employeeEndpoint = "/api/v3/employees";

            byte[] bytes = new UTF8Encoding().GetBytes(JsonConvert.SerializeObject((object)wrapper, jsonSettings));
            return PostAsync(employeeEndpoint, bytes).ConfigureAwait(false).GetAwaiter().GetResult().ToString();

        }

        public void PushEmployeesByChunks(ERPEmployee[] employees, int chunkSize)
        {
            int num = 0;
            List<ERPEmployee> employees1 = new List<ERPEmployee>();
            foreach (ERPEmployee employee in employees)
            {
                ++num;                
                employees1.Add(employee);
                if (num % chunkSize == 0)
                {
                    PushEmployees(employees1.ToArray());  
                    employees1.Clear();
                }
            }
            if (employees1.Count > 0)
            {
                PushEmployees(employees1.ToArray());
            }
        }

        //protected virtual void Dispose(bool isDisposing)
        //{
        //    if (IsDisposed)
        //    {
        //        return;
        //    }
        //    if (isDisposing)
        //    {
        //        httpClient.Dispose();
        //    }
        //    IsDisposed = true;
        //}

        //public virtual void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}

        //~InstaffClient()
        //{
        //    Dispose(false);
        //}
    }



   
   

}
