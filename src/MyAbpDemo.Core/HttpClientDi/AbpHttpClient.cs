using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Abp.Dependency;

namespace MyAbpDemo.HttpClientDi
{
    public class AbpHttpClient:HttpClient,IAbpHttpClient, ITransientDependency
    {
    }
}
