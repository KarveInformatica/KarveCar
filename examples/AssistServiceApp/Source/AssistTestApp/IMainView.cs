using Microsoft.Practices.Unity;

namespace AssistTestApp
{
    public  interface IMainView
    {
      IUnityContainer Container { set; get; }
    }
}