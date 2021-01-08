using GraceUploadAPI.APIModules;
using Newtonsoft.Json;
using RestSharp;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraceUploadAPI.Methods
{
    public class APIMethod
    {
        public void Send_State_Multiple(List<StateModule> stateModules)
        {
            var client = new RestClient("http://ewatchapi.ai64.igrand.com.tw/api/State/Multiple");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", JsonConvert.SerializeObject(stateModules), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if (response.StatusDescription != "OK")
            {
                Log.Error(response.Content);
            }
            //Console.WriteLine(response.Content);
        }
        public void Send_State_Web_Multiple(List<StateModule> stateModules)
        {
            var client = new RestClient("http://ewatchapi.ai64.igrand.com.tw/api/StateWeb/Multiple");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", JsonConvert.SerializeObject(stateModules), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if (response.StatusDescription != "OK")
            {
                Log.Error(response.Content);
            }
            //Console.WriteLine(response.Content);
        }
        public void Send_AI(AI64Module aI64Module)
        {
            var client = new RestClient("http://ewatchapi.ai64.igrand.com.tw/api/AI64");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", JsonConvert.SerializeObject(aI64Module), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if (response.StatusDescription !="OK")
            {
                Log.Error(response.Content);
            }
            //Console.WriteLine(response.Content);
        }
    }
}
