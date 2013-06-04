using System;
using System.IO;
using System.Net;
using System.Text;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl.Extensions
{
    public static class WebRequestExtensions
    {
        public static void UploadFile(this WebRequest webRequest, Stream stream, string httpMethod, string fileName, string contentType, string paramName)
        {
            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundarybytes = Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

            webRequest.ContentType = "multipart/form-data; boundary=" + boundary;
            webRequest.Method = httpMethod;
            webRequest.Credentials = CredentialCache.DefaultCredentials;

            Stream requestStream = webRequest.GetRequestStream();

            requestStream.Write(boundarybytes, 0, boundarybytes.Length);

            const string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
            string header = string.Format(headerTemplate, paramName, fileName, contentType);

            byte[] headerbytes = Encoding.UTF8.GetBytes(header);
            requestStream.Write(headerbytes, 0, headerbytes.Length);

            byte[] buffer = new byte[4096];
            int bytesRead = 0;

            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
            {
                requestStream.Write(buffer, 0, bytesRead);
            }

            byte[] trailer = Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
            requestStream.Write(trailer, 0, trailer.Length);
            requestStream.Close();
        }
    }
}
