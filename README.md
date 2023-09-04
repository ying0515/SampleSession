# SampleSession
*  ASP.NET Core MVC 7
*  Microsoft.AspNetCore.Mvc.NewtonsoftJson 7.0.10
*  Autofac.Extensions.DependencyInjection 8.0.0
*  Mutil Layer

       //(1)Session標準作法
       HttpContext.Session.SetString("code", "1234");
       var data1 = HttpContext.Session.GetString("code");
   
       //(2)Session擴充方法使用myUtility.Extensions
       var currentTime = DateTime.Now;
       HttpContext.Session.Set<DateTime>("code1", currentTime);
       var data2 = HttpContext.Session.Get<DateTime>("code1");

       //(3)使用注入Service方式在Service中使用Session
       var data3 = _testService.GetTest1();
