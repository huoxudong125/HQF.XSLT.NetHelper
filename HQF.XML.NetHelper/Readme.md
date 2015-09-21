##XmlDocument VS. XDocument VS. XMLReader

It all depends on a number of different factors. The easiest would be XMLDocument or XDocument (depending on your tasks, also, I would doubt that XDocument without LINQ to XML would pay off, so consider using LINQ with that), but XmlReader/XmlWriter can get you top performance. Please see my short review of those approaches:

Use System.Xml.XmlDocument class. It implements DOM interface; this way is the easiest and good enough if the size if the document is not too big.
See [XmlDocument in MSDN](http://msdn.microsoft.com/en-us/library/system.xml.xmldocument.aspx).

Use the classes System.Xml.XmlTextWriter and System.Xml.XmlTextReader; this is the fastest way of reading, especially is you need to skip some data.
See [xmlwriter in MSDN](http://msdn.microsoft.com/en-us/library/system.xml.xmlwriter.aspx), [xmlreader](http://msdn.microsoft.com/en-us/library/system.xml.xmlreader.aspx).

Use the class System.Xml.Linq.XDocument; this is the most adequate way similar to that of XmlDocument, supporting LINQ to XML Programming.
See [xmldocument](http://msdn.microsoft.com/en-us/library/system.xml.xmldocument.aspx), [XDocument Class Overview](http://msdn.microsoft.com/en-us/library/bb387063.aspx). 


##Other Related Article & QA
[XDocument or XmlDocument](https://stackoverflow.com/questions/1542073/xdocument-or-xmldocument)   
 
