using System;
using System.IO;
using System.Runtime.InteropServices;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Impl.Utils
{
    public class Win32
    {
        [DllImport(@"urlmon.dll", CharSet = CharSet.Auto)]
        private static extern UInt32 FindMimeFromData(UInt32 pBC, [MarshalAs(UnmanagedType.LPStr)] String pwzUrl,
                                                      [MarshalAs(UnmanagedType.LPArray)] byte[] pBuffer, UInt32 cbSize,
                                                      [MarshalAs(UnmanagedType.LPStr)] String pwzMimeProposed,
                                                      UInt32 dwMimeFlags, out UInt32 ppwzMimeOut, UInt32 dwReserved);

        public static string GetMimeFromStream(Stream stream)
        {
            if (null == stream)
            {
                throw new ArgumentNullException("stream");
            }

            long originalPosition = 0;

            if (stream.CanSeek)
            {
                originalPosition = stream.Position;
                stream.Position = 0;
            }

            try
            {
                byte[] buffer = new byte[256];

                if (stream.Length >= 256)
                {
                    stream.Read(buffer, 0, 256);
                }
                else
                {
                    stream.Read(buffer, 0, (int) stream.Length);
                }

                UInt32 mimetype;
                FindMimeFromData(0, null, buffer, 256, null, 0, out mimetype, 0);
                IntPtr mimeTypePtr = new IntPtr(mimetype);
                string mime = Marshal.PtrToStringUni(mimeTypePtr);
                Marshal.FreeCoTaskMem(mimeTypePtr);
                return mime;
            }
            catch (Exception)
            {
                return "unknown/unknown";
            }
            finally
            {
                if (stream.CanSeek)
                {
                    stream.Position = originalPosition;
                }
            }
        }
    }
}
