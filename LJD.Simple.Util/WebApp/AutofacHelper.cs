using Autofac;

namespace LJD.Simple.Util
{
    public class AutofacHelper
    {
        public static IContainer Container { get; set; }

        public static T GetService<T>()
        {
            return (T)Container?.Resolve(typeof(T));
        }
    }
}