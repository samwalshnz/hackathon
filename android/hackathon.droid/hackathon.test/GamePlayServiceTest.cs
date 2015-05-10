using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hackathon.droid.Services.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace hackathon.test
{
    [TestClass]
    public class GamePlayServiceTest
    {
        [TestMethod]
        public async Task TestService()
        {
            var service = new GamePlayService();
            var result = await service.GetGamePlay();
            Assert.IsNotNull(result);
        }
    }
}
