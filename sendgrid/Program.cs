using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Xml;
using System.Web;
using Newtonsoft.Json;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace sendgrid
{
    class Program
    {
        static void Main(string[] args)
        {
            //AddUnsubscribeEmailAddress("swu@yorkvilleu.ca");
            //DeleteUnsubscribeEmailAddress("swu@yorkvilleu.ca");
            GetAllUnsubscribesEmailAddress("swu@yorkvilleu.ca");
            
            Console.ReadLine();
        }
        public static string AddUnsubscribeEmailAddress(string email)
        {
            string api_user = "noreply_ysis@yorkvilleu.ca";
            string api_key = "4MjVY?]E+z6qTX:";
            string Email = "swu@yorkvilleu.ca";
            string url = "https://api.sendgrid.com/api/unsubscribes.add.json";
            string result=string.Empty;

            // Create a form encoded string for the request body
            string parameters = "api_user=" + HttpUtility.UrlEncode(api_user) + "&api_key=" + HttpUtility.UrlEncode(api_key) + "&email=" + HttpUtility.UrlEncode(Email);

            try
            {
                //Create Request
                HttpWebRequest myHttpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
                myHttpWebRequest.Method = "POST";
                myHttpWebRequest.ContentType = "application/x-www-form-urlencoded";

                // Create a new write stream for the POST body
                StreamWriter streamWriter = new StreamWriter(myHttpWebRequest.GetRequestStream());

                // Write the parameters to the stream
                streamWriter.Write(parameters);
                streamWriter.Flush();
                streamWriter.Close();

                // Get the response
                HttpWebResponse httpResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();

                // Create a new read stream for the response body and read it
                StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream());
                result = streamReader.ReadToEnd();

                // Write the results to the console
                Console.WriteLine(result);
            }
            catch (WebException ex)
            {
                // Catch any execptions and gather the response
                HttpWebResponse response = (HttpWebResponse)ex.Response;

                // Create a new read stream for the exception body and read it
                StreamReader streamReader = new StreamReader(response.GetResponseStream());
                 result = streamReader.ReadToEnd();

                // Write the results to the console
                Console.WriteLine(result);
            }
            return result;
        }

        public static IList<EmailInfo> GetAllUnsubscribesEmailAddress(string email)
        {
 
            string api_user = "noreply_ysis@yorkvilleu.ca";
            string api_key = "4MjVY?]E+z6qTX:";
            string api_date = "1";
            string url = "https://sendgrid.com/api/unsubscribes.get.json";
            IList<EmailInfo> allUnsubscribeInfo=null;

            // Create a form encoded string for the request body
            string parameters = "api_user=" + HttpUtility.UrlEncode(api_user) + "&api_key=" + HttpUtility.UrlEncode(api_key) + "&date=" + api_date;
            url=url+"?"+parameters;
            try
            {
                //Create Request
                HttpWebRequest myHttpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
                myHttpWebRequest.Method = "GET";
                //myHttpWebRequest.ContentType = "application/x-www-form-urlencoded";

                // Get the response
                HttpWebResponse httpResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();

                // Create a new read stream for the response body and read it
                StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream());
                string result = streamReader.ReadToEnd();
                // Write the results to the console
                Console.WriteLine(result);
                String resultJson = @"{'allInfo':" + result + "}";
                JObject o = JObject.Parse(resultJson);
                JArray a = (JArray)o["allInfo"];
                allUnsubscribeInfo = a.ToObject<IList<EmailInfo>>();

            }
            catch (WebException ex)
            {
                // Catch any execptions and gather the response
                HttpWebResponse response = (HttpWebResponse)ex.Response;

                // Create a new read stream for the exception body and read it
                StreamReader streamReader = new StreamReader(response.GetResponseStream());
                string result = streamReader.ReadToEnd();

                // Write the results to the console
                Console.WriteLine(result);
            }
            return allUnsubscribeInfo;
        }

        public static string DeleteUnsubscribeEmailAddress(string email)
        {
            string api_user = "noreply_ysis@yorkvilleu.ca";
            string api_key = "4MjVY?]E+z6qTX:";
            string Email = "swu@yorkvilleu.ca";
            string url = "https://api.sendgrid.com/api/unsubscribes.delete.json";
            string result=string.Empty;

            // Create a form encoded string for the request body
            string parameters = "api_user=" + HttpUtility.UrlEncode(api_user) + "&api_key=" + HttpUtility.UrlEncode(api_key) + "&email=" + HttpUtility.UrlEncode(Email);

            try
            {
                //Create Request
                HttpWebRequest myHttpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
                myHttpWebRequest.Method = "POST";
                myHttpWebRequest.ContentType = "application/x-www-form-urlencoded";

                // Create a new write stream for the POST body
                StreamWriter streamWriter = new StreamWriter(myHttpWebRequest.GetRequestStream());

                // Write the parameters to the stream
                streamWriter.Write(parameters);
                streamWriter.Flush();
                streamWriter.Close();

                // Get the response
                HttpWebResponse httpResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();

                // Create a new read stream for the response body and read it
                StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream());
                result = streamReader.ReadToEnd();

                // Write the results to the console
                Console.WriteLine(result);
            }
            catch (WebException ex)
            {
                // Catch any execptions and gather the response
                HttpWebResponse response = (HttpWebResponse)ex.Response;

                // Create a new read stream for the exception body and read it
                StreamReader streamReader = new StreamReader(response.GetResponseStream());
                 result = streamReader.ReadToEnd();

                // Write the results to the console
                Console.WriteLine(result);
            }
            return result;
        }
    }
    class EmailInfo
    {
        private string email;
        private DateTime created;
        public string Email { get; set;}
        public DateTime Created { get; set; }
    }
}
