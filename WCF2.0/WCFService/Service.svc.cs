using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“Service”。
    public class Service : IService
    {
        public string Say()
        {
            // 获取客户端传过来的Header
            WebHeaderCollection headerCollection = WebOperationContext.Current.IncomingRequest.Headers;
            foreach (string item in headerCollection) {
                string value = headerCollection.Get(item);
            }
            // 设置返回的Header
            WebOperationContext.Current.OutgoingResponse.Headers["DODO"] = "hello";
            return "HelloWorld";
        }

        public string SayHello(string value, string a)
        {
            return "Hello：" + value + "," + a;
        }

        public string Speak(Stream stream)
        {
            StreamReader reader = new StreamReader(stream);
            string value = reader.ReadToEnd();
            return "Hello：Android " + value;
        }

        public string SpeakHello(string a, string uid)
        {
            return "Hello：Android +Listen:" + a + "_" + uid;
        }
    }
}
