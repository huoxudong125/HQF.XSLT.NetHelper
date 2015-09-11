using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace HQF.XSLT.NetHelper.Shell
{
    /// <summary>
    /// http://blogs.msdn.com/b/nareshjoshi/archive/2009/01/15/how-to-force-non-self-closing-tags-for-empty-nodes-when-using-xslcompiledtransform-class.aspx
    /// </summary>
    public class XmlHtmlWriter : XmlTextWriter
    {
        public XmlHtmlWriter(string filePath, Encoding en)
            : base(new FileStream(filePath, FileMode.OpenOrCreate,FileAccess.ReadWrite), en)
        {
        }

        public XmlHtmlWriter(System.IO.Stream stream, Encoding en)
            : base(stream, en)
        {
            //Put all the elemnts for which you want self closing tags in this list.
            //Rest of the tags would be explicitely closed
            fullyClosedElements.AddRange(new string[] { "br", "hr" });
        }

        private string openingElement = "";
        private List<string> fullyClosedElements = new List<string>();

        public override void WriteEndElement()
        {
            if (fullyClosedElements.IndexOf(openingElement) < 0)
                WriteFullEndElement();
            else
                base.WriteEndElement();
        }

        public override void WriteStartElement(string prefix, string localName, string ns)
        {
            base.WriteStartElement(prefix, localName, ns);
            openingElement = localName;
        }
    }
}