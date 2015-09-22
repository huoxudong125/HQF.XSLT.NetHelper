


#Three models for processing XML Data
The Microsoft .NET Framework includes three models for processing XML data: the `XmlDocument` class, the `XPathDocument` class, and LINQ to XML.


1. The `XmlDocument` class implements the W3C document object model (DOM) level 1 core and the core DOM level 2 recommendations. The DOM is an in-memory (cache) tree representation of an XML document. With the XmlDocument and its related classes, you can construct XML documents, load and access data, modify data, and save changes.

2. The `XPathDocument` class is a **read-only, in-memory** data store that is based on the `XPath` data model. The `XPathNavigator` class offers several editing options and navigation capabilities using a cursor model over XML documents contained in the read-only `XPathDocument` class as well as the `XmlDocument` class.

3. **LINQ to XML** is the new model in the .NET Framework version 3.5 for processing XML data. It is an in-memory model that leverages LINQ (Language-Integrated Query). LINQ extends the language syntax of C# and Visual Basic to provide new query capabilities.

[Process XML Data Using the DOM Model](https://msdn.microsoft.com/library/t058x2df(v=vs.110).aspx)
>Discusses using the XmlDocument, and its related classes to process XML data.

[Process XML Data Using the XPath Data Model](https://msdn.microsoft.com/library/87274khy(v=vs.110).aspx)
>Discusses using the XPathDocument, XmlDocument, and XPathNavigator classes to process XML data.

[Process XML Data Using LINQ to XML](https://msdn.microsoft.com/zh-cn/library/bb669128(v=vs.110).aspx)
>Provides a brief overview of LINQ to XML and provides links to the LINQ to XML documentation.



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

  
 
