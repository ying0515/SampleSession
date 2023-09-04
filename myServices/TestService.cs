using myServices.Interfaces;
using myUtility.Libraries.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myServices
{
    public class TestService : ITestService
    {
        private readonly ISessionLibrary _sessionLibrary;

        public TestService(ISessionLibrary sessionLibrary)
        {
            _sessionLibrary = sessionLibrary;
        }
        public string GetTest1()
        {
            var currentTime = DateTime.Now;
            _sessionLibrary.Set<DateTime>("code2", currentTime);
            var code2Value = _sessionLibrary.Get<DateTime>("code2");
            var code1Value = _sessionLibrary.Get<DateTime>("code1");
            var codeValue = _sessionLibrary.Get<string>("code");

            return "Test1";
        }

        public string GetTest2()
        {
            return "Test2";
        }
    }
}
