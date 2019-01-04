using System.IO;
using System.Reflection;
using Framework.Selenium;
using League.Com;
using NUnit.Framework;

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

        [SetUp]
        public virtual void Setup()
        {
            Driver.Init(
                type: TestContext.Parameters["type"],
                browser: TestContext.Parameters["browser"],
                setWait: 30
            );
            
            Esports.Init();
        }

        [TearDown]
        public virtual void Cleanup()
        {
            Driver.Quit();
        }
    }
}