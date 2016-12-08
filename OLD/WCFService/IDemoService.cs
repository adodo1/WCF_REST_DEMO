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
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IService1”。
    [ServiceContract]
    public interface IDemoService
    {
        /// <summary>
        /// 测试1 整形输入
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(UriTemplate = "/test1?int={value}",
            Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        string Test1(int value);
        /// <summary>
        /// 测试2 浮点输入
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(UriTemplate = "/test2?double={value}",
            Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        string Test2(double value);
        /// <summary>
        /// 测试3 字符输入
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(UriTemplate = "/test3?str={value}",
            Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        string Test3(string value);

        //---------------------------------------------------------------------------
        /// <summary>
        /// 测试4 整形输出
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(UriTemplate = "/test4",
            Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        int Test4();
        /// <summary>
        /// 测试5 浮点输出
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(UriTemplate = "/test5",
            Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        double Test5();
        /// <summary>
        /// 测试6 字符输出
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(UriTemplate = "/test6",
            Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        string Test6();

        //---------------------------------------------------------------------------
        /// <summary>
        /// 测试7 POST
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(UriTemplate = "/test7",
            Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        CompositeType Test7(Stream value);



        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: 在此添加您的服务操作
    }


    // 使用下面示例中说明的数据约定将复合类型添加到服务操作。
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
