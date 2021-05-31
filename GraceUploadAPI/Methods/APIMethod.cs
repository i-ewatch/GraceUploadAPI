using GraceUploadAPI.APIModules;
using GraceUploadAPI.Configuration;
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

        public APISetting APISetting { get; set; }
        public void Send_State_Multiple(List<StateModule> stateModules)
        {
            foreach (var item in APISetting.APIAddress)
            {
                var client = new RestClient($"{item}/api/State/Multiple");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", JsonConvert.SerializeObject(stateModules), ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                if (response.StatusDescription != "OK")
                {
                    Log.Error("多AI64上傳失敗" + response.Content);
                }
                //Console.WriteLine(response.Content);
            }
        }
        public void Send_State(StateModule stateModules)
        {
            foreach (var item in APISetting.APIAddress)
            {
                var client = new RestClient($"{item}/api/State");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", JsonConvert.SerializeObject(stateModules), ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                if (response.StatusDescription != "OK")
                {
                    Log.Error("AI64上傳失敗" + response.Content);
                }
                //Console.WriteLine(response.Content);
            }
        }
        public void Send_State_Web_Multiple(List<StateModule> stateModules)
        {
            foreach (var item in APISetting.APIAddress)
            {
                var client = new RestClient($"{item}/api/StateWeb/Multiple");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", JsonConvert.SerializeObject(stateModules), ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                if (response.StatusDescription != "OK")
                {
                    Log.Error("多狀態上傳失敗" + response.Content);
                }
                //Console.WriteLine(response.Content);
            }
        }
        public void Send_State_Web(StateModule stateModules)
        {
            foreach (var item in APISetting.APIAddress)
            {
                var client = new RestClient($"{item}/api/StateWeb");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", JsonConvert.SerializeObject(stateModules), ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                if (response.StatusDescription != "OK")
                {
                    Log.Error("狀態網頁上傳失敗" + $"{JsonConvert.SerializeObject(stateModules)}" + response.Content);
                }
                //Console.WriteLine(response.Content);
            }
        }
        public void Send_AI(AI64Module aI64Module)
        {
            foreach (var item in APISetting.APIAddress)
            {
                var client = new RestClient($"{item}/api/AI64");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", JsonConvert.SerializeObject(aI64Module), ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                if (response.StatusDescription != "OK")
                {
                    Log.Error("狀態上傳失敗" + response.Content);
                }
                //Console.WriteLine(response.Content);
            }
        }
    }
}
