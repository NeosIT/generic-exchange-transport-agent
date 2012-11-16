using System;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.DisclaimerHandler.Impl
{
    public class RtfDocument
    {
        public string Content { get; internal set; }

        public RtfDocument(string rtfContent)
        {
            Content = rtfContent;
        }

        public bool Merge(RtfDocument mergeDoc)
        {
            try
            {
                var mergeFirst = mergeDoc.Content.IndexOf(@"\par", StringComparison.Ordinal);
                var mergeLast = mergeDoc.Content.LastIndexOf(@"\par", StringComparison.Ordinal) - 1;

                if ((mergeFirst < 0) || (mergeLast < 0))
                {
                    return false;
                }

                var docFirst = Content.LastIndexOf(@"}", StringComparison.Ordinal);

                if (docFirst < 0)
                {
                    return false;
                }

                string migCont = mergeDoc.Content.Substring(mergeFirst, mergeLast - mergeFirst + 1);

                if (migCont.StartsWith(@"\pard", StringComparison.Ordinal))
                {
                    migCont = @"\par\par" + migCont.Remove(0, 5);
                }

                Content = Content.Insert(docFirst, migCont);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
