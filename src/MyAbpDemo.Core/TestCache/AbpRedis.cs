using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Dependency;
using StackExchange.Redis;

namespace MyAbpDemo.TestCache
{
    public class AbpRedis: ITransientDependency
    {                
        public IDatabase ConnectReidsDb(string redisHost)
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(redisHost);
            return redis.GetDatabase();
        }
    }
}
