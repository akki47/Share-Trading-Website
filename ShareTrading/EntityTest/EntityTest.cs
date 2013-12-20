using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using ShareTradingModel;
using TestingFramework;

namespace Entities.Test
{
    public class EntityTest<T>:TestBase
    {
        private ShareTradingEntities context;
        //Write all common test for entity
        public override void OnTestStartup()
        {
            context = new ShareTradingEntities();
        }

        public override void OnTestComplete()
        {
            //need to dispose every thing
        }
    }
}
