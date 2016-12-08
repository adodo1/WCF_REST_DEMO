using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace WCFClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseurl = "http://localhost:9553/DemoService.svc";

            WebClient client = new WebClient();
            // GET测试
            string result01 = client.DownloadString(string.Format("{0}/test1?int=1", baseurl));
            Console.WriteLine(result01);
            string result02 = client.DownloadString(string.Format("{0}/test2?double=1.23", baseurl));
            Console.WriteLine(result02);
            string result03 = client.DownloadString(string.Format("{0}/test3?str=abc", baseurl));
            Console.WriteLine(result03);
            string result04 = client.DownloadString(string.Format("{0}/test4", baseurl));
            Console.WriteLine(result04);
            string result05 = client.DownloadString(string.Format("{0}/test5", baseurl));
            Console.WriteLine(result05);
            string result06 = client.DownloadString(string.Format("{0}/test6", baseurl));
            Console.WriteLine(result06);



            string param = "{\"uid\":\"246534824\",\"sid\":\"906508525\",\"choice\":\"yes\",\"a\":\"GenerateQuestionHandler\",\"questfd\":\"0\"}";
            Encoding myEncode = Encoding.GetEncoding("UTF-8");
            byte[] postBytes = Encoding.UTF8.GetBytes(param);
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create("http://localhost:9553/DemoService.svc/test7");
            req.Method = "POST";
            req.ContentType = "application/json;charset=UTF-8";
            req.ContentLength = postBytes.Length;
            try {
                using (Stream reqStream = req.GetRequestStream()) {
                    reqStream.Write(postBytes, 0, postBytes.Length);
                }
                using (WebResponse res = req.GetResponse()) {
                    using (StreamReader sr = new StreamReader(res.GetResponseStream(), myEncode)) {
                        string strResult = sr.ReadToEnd();
                        
                    }
                }
            }
            catch (WebException ex) {
                //return "无法连接到服务器\r\n错误信息：" + ex.Message;
            }
            




            // POST测试
            client.Headers["Content-Type"] = "text/plain";
            string result07 = client.UploadString(string.Format("{0}/test7", baseurl), "POST", param);
            Console.WriteLine(result07);

            


            ////用一个WebClient就可以搞定了 
            //WebClient client = new WebClient();
            ////以PUT方式访问Data/1/100，会映射到服务端的CreateData("1", "100") 
            //client.UploadString("http://localhost:8080/wcf/Data/1/100", "PUT", string.Empty);
            ////以GET方式访问Data/1，会映射到服务端的RetrieveData("1")，应该返回"100" 
            //Console.WriteLine(client.DownloadString("http://localhost:8080/wcf/Data/1"));
            ////以POST方式访问Data/1/200，会映射到服务端的UpdateData("1", "200")             
            //client.UploadString("http://localhost:8080/wcf/Data/1/200", "POST", string.Empty);
            ////再GET一次，应该返回"200" 
            //Console.WriteLine(client.DownloadString("http://localhost:8080/wcf/Data/1"));
            ////以DELETE方式访问Data/1，会映射到服务端的DeleteData("1") 
            //client.UploadString("http://localhost:8080/wcf/Data/1", "DELETE", string.Empty);
            ////再GET一次，应该返回"NOT FOUND" 
            //Console.WriteLine(client.DownloadString("http://localhost:8080/wcf/Data/1")); 


            Console.ReadKey();
        }
    }
}
