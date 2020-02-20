using System;
using System.IO;
using System.Net;

namespace WOOCOMMERCE_SPECFLOW.Api
{
    public class HttpRequestBuilder
    {
        private static string ApiHost = "http://34.205.174.166/";
        private static string Authorization = "Basic c2hvcG1hbmFnZXI6YXhZMiByaW1jIFN6TzkgY29iZiBBWkJ3IE5Mblg=";
        /// <summary>
        /// Enum of possible HTTP methods supported by this builder
        /// </summary>
        public enum HttpWebRequestMethod
        {
            /// <summary>The GET http request</summary>
            GET,
            /// <summary>The POST http request</summary>
            POST,
            /// <summary>The DELETE http request</summary>
            DELETE
        }

        public HttpResponse SendRequest(HttpWebRequestMethod method, string endpoint, string payload = "", string contentType = "application/json; charset=utf-8")
        {            
            string targetURL = ApiHost + endpoint;
            HttpWebResponse response;
            HttpResponse result = new HttpResponse();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(targetURL);

            // Set up the request with objects from the builder method
            request.Method = method.ToString();            
            WebHeaderCollection headers = new WebHeaderCollection {                                        
                                        {"Authorization", Authorization }};
            request.Headers = headers;
            request.ContentType = contentType;

            // Attempt to send the request and get a response
            try
            {
                if (RequestAcceptsPayload(method) && !string.IsNullOrEmpty(payload))
                {
                    using (StreamWriter streamWriter = new StreamWriter(request.GetRequestStream()))
                    {
                        streamWriter.Write(payload);
                    }
                }
                using (response = (HttpWebResponse)request.GetResponse())
                {
                    using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
                    {
                        result.StatusCode = response.StatusCode;
                        result.Headers = response.Headers;
                        result.Cookies = response.Cookies;
                        result.ResponseBody = streamReader.ReadToEnd();
                    }
                }
            }            
            catch (WebException ex)
            {
                throw new WebException(ex.Message);
            }


            return result;
        }
        private bool RequestAcceptsPayload(HttpWebRequestMethod method)
        {
            switch (method)
            {               
                case HttpWebRequestMethod.POST:                
                    return true;
                case HttpWebRequestMethod.GET:
                case HttpWebRequestMethod.DELETE:
                    return false;
                default:
                    throw new ArgumentException("HTTP web request method " + method.ToString() + " is not known if it supports a payload or not.");
            }
        }

    }
    /// <summary>
    /// This struct stores the response to a request for easy access
    /// </summary>
    public struct HttpResponse
    {
        /// <summary>The status code</summary>
        public HttpStatusCode StatusCode;
        /// <summary>The cookies</summary>
        public CookieCollection Cookies;
        /// <summary>The headers</summary>
        public WebHeaderCollection Headers;
        /// <summary>The response body</summary>
        public string ResponseBody;
    }
}
