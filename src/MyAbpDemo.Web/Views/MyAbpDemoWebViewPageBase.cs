using Abp.Web.Mvc.Views;

namespace MyAbpDemo.Web.Views
{
    public abstract class MyAbpDemoWebViewPageBase : MyAbpDemoWebViewPageBase<dynamic>
    {

    }

    public abstract class MyAbpDemoWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected MyAbpDemoWebViewPageBase()
        {
            LocalizationSourceName = MyAbpDemoConsts.LocalizationSourceName;
        }
    }
}