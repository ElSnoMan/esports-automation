using Framework;
using Framework.Selenium;
using League.Com;
using NUnit.Framework;

namespace Tests.Base
{
    public abstract class TestBase
    {
        protected TestBase()
        {
            FW.Init();
        }

        [SetUp]
        public virtual void Setup()
        {
            Driver.Init(
                type: FW.Config.Driver.Type,
                browser: FW.Config.Driver.Browser,
                setWait: FW.Config.Driver.Wait
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
