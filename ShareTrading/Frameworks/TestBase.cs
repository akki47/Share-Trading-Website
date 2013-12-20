using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestingFramework
{
    [TestClass]
    public abstract class TestBase
    {
        [TestInitialize]
        public virtual void OnTestStartup()
        {
        }

        [TestCleanup]
        public virtual void OnTestComplete()
        {
        }
    }
}
