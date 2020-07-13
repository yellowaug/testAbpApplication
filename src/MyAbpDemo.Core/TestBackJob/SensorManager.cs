using Abp.BackgroundJobs;
using Abp.Dependency;
using Abp.Domain.Services;
using JetBrains.Annotations;
using MyAbpDemo.HttpClientDi;
using MyAbpDemo.TestBackJob.Ent;
using MyAbpDemo.TestCache;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyAbpDemo.TestBackJob
{
    public class SensorManager: BackgroundJob<Account>, ITransientDependency
    {
        private readonly AbpHttpClient abpHttpClient;
        private static string apiHost = "https://api.dtuip.com/";
        private AbpRedis abpRedis;
        public SensorManager(AbpHttpClient abpHttpClient, AbpRedis abpRedis)
        {
            this.abpHttpClient = abpHttpClient;
            this.abpRedis = abpRedis;
        }

        public override void Execute(Account args)
        {
            _ = this.GetLoginData(args);//这个语法糖够牛逼的，要记住

        }
        private async Task GetLoginData(Account account)
        {
            this.abpHttpClient.BaseAddress = new Uri(apiHost);
            this.abpHttpClient.DefaultRequestHeaders.Accept.Clear();
            var requestJson = JsonConvert.SerializeObject(account);
            HttpContent httpContent = new StringContent(requestJson, Encoding.UTF8);
            var loginresponse = await this.abpHttpClient.PostAsync(
                    "qy/user/login.html", httpContent);
            var loginresult = await loginresponse.Content.ReadAsStringAsync();
            var redisdb = this.abpRedis.ConnectReidsDb("10.12.2.61");
            redisdb.StringSet("test1", loginresult);
                
            //return loginresult;
            #region 一些旧的代码
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
            #endregion

        }
    }
}
