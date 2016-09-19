using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Library.SMS
{
    public class Action
    {
        public static readonly string PostUrl = ConfigurationManager.AppSettings["WebReference.Service.PostUrl"];
        public static readonly string Account = ConfigurationManager.AppSettings["WebReference.Service.Account"];
        public static readonly string Password = ConfigurationManager.AppSettings["WebReference.Service.Password"];
        public static readonly string Content = ConfigurationManager.AppSettings["WebReference.Service.Content"];
        public static readonly string NotCodeContent = ConfigurationManager.AppSettings["WebReference.Service.NotCodeContent"];

        public static string ToContext(string name, string ticket, string code)
        {
            return Content.Replace("{{name}}", name).Replace("{{ticket}}", ticket).Replace("{{code}}", code);
        }

        public static string ToContext(string name, string ticket)
        {
            return NotCodeContent.Replace("{{name}}", name).Replace("{{ticket}}", ticket);
        }

        public static string ToContext(string context)
        {
            return context + "回T退订";
        }

        public static bool Send(string mobile, string content)
        {
            string postStrTpl = "account={0}&pswd={1}&mobile={2}&msg={3}&needstatus=true&product=&extno=";
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] postData = encoding.GetBytes(string.Format(postStrTpl, Account, Password, mobile, content));
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(PostUrl);
            myRequest.Method = "POST";
            myRequest.ContentType = "application/x-www-form-urlencoded";
            myRequest.ContentLength = postData.Length;

            Stream newStream = myRequest.GetRequestStream();
            // Send the data.
            newStream.Write(postData, 0, postData.Length);
            newStream.Flush();
            newStream.Close();

            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            if (myResponse.StatusCode == HttpStatusCode.OK)
            {
                StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
                string stateVal = reader.ReadToEnd();
                string[] stateArr = stateVal.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                if (stateArr.Length <= 0) return false;
                stateArr = stateArr[0].Split(',');
                if (stateArr.Length < 2) return false;
                return stateArr[1] == "0";
            }
            else
            {
                return false;
            }
        }
    }
}
