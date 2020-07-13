using Abp.BackgroundJobs;
using MyAbpDemo.TestBackJob;
using MyAbpDemo.TestBackJob.Ent;
using MyAbpDemo.TestCache;
using MyAbpDemo.TestHttp.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAbpDemo.TestBackGroupJob
{
    public class BackJobAppService : IBackJobAppService
    {
        private readonly IBackgroundJobManager backgroundJobManager;

        //private readonly SensorManager sensorManager;
        public BackJobAppService(IBackgroundJobManager backgroundJobManager)
        {
            this.backgroundJobManager = backgroundJobManager;
        }
        public async Task GetToken(LoginInput loginInput)
        {
            await this.backgroundJobManager.EnqueueAsync<SensorManager, Account>(
                new Account { userName = "18978849681", password = "jjck@1234" });

        }
    }
}
