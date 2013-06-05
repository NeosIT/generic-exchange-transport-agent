using System;
using System.IO;
using System.Net;
using System.Text;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl.Extensions
{
    public static class WebRequestExtensions
    {
        public static void UploadFile(this WebRequest webRequest, Stream stream, string httpMethod, string fileName, string paramName)
        {
            const string linebreak = "\r\n";
            var mime = Utils.Win32.GetMimeFromStream(stream);

            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            byte[] trailer = Encoding.ASCII.GetBytes(linebreak + "--" + boundary + "--" + linebreak);

            StringBuilder sb = new StringBuilder();
            sb.Append("--");
            sb.Append(boundary);
            sb.Append(linebreak);
            sb.Append(string.Format("Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"", paramName,
                                    fileName));
            sb.Append(linebreak);
            sb.Append("Content-Type: " + mime);
            sb.Append(linebreak);
            sb.Append(linebreak);

            byte[] boundarybytes = Encoding.ASCII.GetBytes(sb.ToString());

            webRequest.ContentType = "multipart/form-data; boundary=" + boundary;
            webRequest.ContentLength = stream.Length + boundarybytes.Length + trailer.Length;

            webRequest.Method = httpMethod;
            webRequest.Credentials = CredentialCache.DefaultCredentials;

            Stream requestStream = webRequest.GetRequestStream();

            requestStream.Write(boundarybytes, 0, boundarybytes.Length);

            byte[] buffer = new byte[32768];
            int bytesRead = 0;

            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
            {
                requestStream.Write(buffer, 0, bytesRead);
            }

            requestStream.Write(trailer, 0, trailer.Length);
            requestStream.Close();
        }
    }
}
