using Abp.Domain.Services;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAbpDemo.TestCache
{
    public class AbpRedisManager: DomainService
    {                                  
        public IDatabase redisDb(string redisHost)
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(redisHost);
            return redis.GetDatabase();
        }
    }
}
