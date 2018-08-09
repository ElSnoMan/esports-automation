using System;

namespace Tests.Base
{
    public abstract class TestBase
    {
        protected TestBase()
        {
            if (!Environment.CurrentDirectory.ToLower().EndsWith("esports"))
            {
                Environment.CurrentDirectory = "../../../../";
            }
        }
    }
}