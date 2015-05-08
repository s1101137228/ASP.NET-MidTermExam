using AopAlliance.Intercept;
using System;
using System.Diagnostics;

namespace KuasCore.Interceptors 
{
    class DebogLogInterceptor : IMethodInterceptor
    {
        DateTime time_start = DateTime.Now;//計時開始 取得目前時間
        public object Invoke(IMethodInvocation invocation)
        {
            DateTime time_end = DateTime.Now;//計時結束 取得目前時間
            string result2 = ((TimeSpan)(time_end - time_start)).TotalMilliseconds.ToString();
            Console.WriteLine("DebogLogInterceptor 攔截到一個方法呼叫 = [{0}],時間為[{1}]", invocation, result2);
            Debug.Print("DebogLogInterceptor 攔截到一個方法呼叫 = [{0}]", invocation);

            object result = invocation.Proceed();

            Console.WriteLine("回傳的資料已取得 [{0}]", result);
            Debug.Print("回傳的資料已取得 [{0}]", result);

            return result;
        }
    }
}
