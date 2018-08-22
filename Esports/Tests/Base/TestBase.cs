using System.IO;
using System.Reflection;

namespace Tests.Base
{
    public abstract class TestBase
    {
        protected TestBase()
        {
            var assembly = Assembly.GetExecutingAssembly().FullName;
            var path = Path.Combine(assembly, "../../../../../");
            Directory.SetCurrentDirectory(path);
        }
    }
}