using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“DemoService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 DemoService.svc 或 DemoService.svc.cs，然后开始调试。
    public class DemoService : IDemoService
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string Test1(int value)
        {
            return "hello " + value.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string Test2(double value)
        {
            return "hello " + value.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string Test3(string value)
        {
            return "hello " + value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int Test4()
        {
            return 8;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public double Test5()
        {
            return 3.14;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Test6()
        {
            return "hello test6";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public CompositeType Test7(Stream stream)
        {
            StreamReader reader = new StreamReader(stream);
            string value = reader.ReadToEnd();
            //return "hello " + value;
            return new CompositeType();
        }
    }
}
