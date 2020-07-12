using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using MyAbpDemo.HttpClientDi;
using MyAbpDemo.TestCache;
using MyAbpDemo.TestHttp.Dto;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MyAbpDemo.TestHttp
{
    public class HttpRequestAppService : IHttpRequestAppService
    {
        //private static readonly HttpClient client = new HttpClient();
        private readonly AbpHttpClient abpHttpClient;
        private readonly IRepository<TestTable> httpRepository;
        private static string apiHost = "https://api.dtuip.com/";
        public HttpRequestAppService(IRepository<TestTable> httpRepository, AbpHttpClient abpHttpClient)
        {
            this.httpRepository = httpRepository;
            this.abpHttpClient = abpHttpClient;
        }
        /// <summary>
        /// 获取实时温度，湿度数据
        /// </summary>
        /// <returns></returns>
        public async Task<string> TestInterface()
        {
            string loginresult = await GetLoginData();
            string dataresult= await GetSensorData(loginresult, "qy/device/queryLastDtByDevNo.html");
            this.abpHttpClient.Dispose();
            return dataresult;
        }
        /// <summary>
        /// 获取一个月的温湿度数据
        /// </summary>
        /// <returns></returns>
        public async Task<string> TestHistoryData(ParameteInput paramete)
        {
            string loginresult = await GetLoginData();
            string singerdata = await GetSensorData(loginresult, "qy/device/queryLastDtByDevNo.html");
            string historydata = await GetHistorySensorData(loginresult, singerdata, "qy/device/querySenHistoryDt.html",paramete.SensorCode,paramete.StartDate,paramete.EndDate);
            this.abpHttpClient.Dispose();
            return historydata;

        }
        public async Task<string> TestHumidityHistoryData(ParameteInput paramete)
        {
            string loginresult = await GetLoginData();
            string singerdata = await GetSensorData(loginresult, "qy/device/queryLastDtByDevNo.html");
            string historydata = await GetHistorySensorData(loginresult, singerdata, "qy/device/querySenHistoryDt.html", paramete.SensorCode, paramete.StartDate, paramete.EndDate);
            this.abpHttpClient.Dispose();
            return historydata;

        }
        private async Task<string> GetLoginData()
        {
            this.abpHttpClient.BaseAddress = new Uri(apiHost);
            this.abpHttpClient.DefaultRequestHeaders.Accept.Clear();
            var requestJson = JsonConvert.SerializeObject(new LoginInfo() { userName = "18978849681", password = "jjck@1234" });
            HttpContent httpContent = new StringContent(requestJson, Encoding.UTF8);
            var loginresponse = await this.abpHttpClient.PostAsync(
                    "qy/user/login.html", httpContent);
            var loginresult = await loginresponse.Content.ReadAsStringAsync();
            //序列化与反序列化
            //JObject jObject = (JObject)JsonConvert.DeserializeObject(loginresult);
            //string requestdataJson = JsonConvert.SerializeObject(new DeviceInfo()
            //{
            //    userApiKey = jObject["userApikey"].ToString(),
            //    flagCode = jObject["flagCode"].ToString(),
            //    deviceNo = "10QMYX581V5VY8UX"
            //}
            //);
            //获取最新一条传感器数据
            //HttpContent datahttpContent = new StringContent(requestdataJson, Encoding.UTF8);
            //var response = await this.abpHttpClient.PostAsync(uriPath, datahttpContent);
            //string result = await response.Content.ReadAsStringAsync();
            //this.abpHttpClient.Dispose();
            return loginresult;
        }
        private async Task<string> GetSensorData(string loginresult,string uriPath)
        {
            //序列化与反序列化
            JObject jObject = (JObject)JsonConvert.DeserializeObject(loginresult);
            string requestdataJson = JsonConvert.SerializeObject(new GetSingerDataDto()
            {
                userApiKey = jObject["userApikey"].ToString(),
                flagCode = jObject["flagCode"].ToString(),
                deviceNo = "10QMYX581V5VY8UX"
            }
            );
            //获取最新一条传感器数据
            HttpContent datahttpContent = new StringContent(requestdataJson, Encoding.UTF8);
            var response = await this.abpHttpClient.PostAsync(uriPath, datahttpContent);
            string sensordataresult = await response.Content.ReadAsStringAsync();
            //this.abpHttpClient.Dispose();
            return sensordataresult;
        }
        /// <summary>
        /// 获取传感器历史数据
        /// </summary>
        /// <param name="loginresult"></param>
        /// <param name="sensordataresult"></param>
        /// <param name="uriPath"></param>
        /// <param name="sensorCode">这个参数一般只传0,1这个参数的代码其实就是jobjectsensor结果的索引码,0是温度，1是湿度</param>
        /// <param name="startDate">输入yyyy-mm-dd格式即可</param>
        /// <param name="endDate">输入yyyy-mm-dd格式即可</param>
        /// <returns></returns>
        private async Task<string> GetHistorySensorData(string loginresult,string sensordataresult,string uriPath,int sensorCode,string startDate,string endDate)
        {
            //序列化与反序列化
            JObject jobjectlogin = (JObject)JsonConvert.DeserializeObject(loginresult);
            JObject jobjectsensor = (JObject)JsonConvert.DeserializeObject(sensordataresult);
            string fullstartdate = String.Format($"{startDate} 00:00:00");
            string fullenddate = String.Format($"{endDate} 23:59:59");
            string historydataJson = JsonConvert.SerializeObject(
                new GetHistoryDataDto()
                {
                    userApiKey = jobjectlogin["userApikey"].ToString(),
                    flagCode = jobjectlogin["flagCode"].ToString(),
                    companyKey = jobjectlogin["companyApiKey"].ToString(),
                    sensorId = jobjectsensor["sensorLastDataList"][sensorCode]["sensorId"].ToString(),
                    //sensorId = "673556",
                    startDate = fullstartdate,
                    endDate = fullenddate,
                    page="1",
                    pageSize="20"                                       
                }
                );
            HttpContent datahttpContent = new StringContent(historydataJson, Encoding.UTF8);
            var response = await this.abpHttpClient.PostAsync(uriPath, datahttpContent);
            string sensorhistorydataresult = await response.Content.ReadAsStringAsync();            
            return sensorhistorydataresult;
        }
        public Task<ResponDto> TestLogin(LoginInput input)
        {
            throw new NotImplementedException();
        }


        //public async Task<ResponDto> TestLogin(LoginInput input)
        //{
        //    client.BaseAddress = new Uri(@"https://api.dtuip.com/");
        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    client.PostAsync("api/Person", new Person() { Age = 10, Id = 1, Name = "test", Sex = "F" })
        //                       //返回请求是否执行成功，即HTTP Code是否为2XX
        //                       .ContinueWith(x => x.Result.IsSuccessStatusCode);
        //}
    }
}
