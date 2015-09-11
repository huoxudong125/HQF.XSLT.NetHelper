using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace HQF.XSLT.NetHelper.Shell.ViewModel
{
    /// <summary>
    ///     This class contains properties that the main View can data bind to.
    ///     <para>
    ///         Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    ///     </para>
    ///     <para>
    ///         You can also use Blend to data bind with the tool's support.
    ///     </para>
    ///     <para>
    ///         See http://www.galasoft.ch/mvvm
    ///     </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private string _outputFolder;
        private string _xmlContent;
        private string _xmlPath;
        private string _xslContent;
        private string _xslPath;

        /// <summary>
        ///     Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}

            BrowseXmlFileCommand = new RelayCommand(OnBrowseXmlFile);
            BrowseXslFileCommand = new RelayCommand(OnBrowseXslFile);
            BrowseOutPutFolderCommand = new GalaSoft.MvvmLight.CommandWpf.RelayCommand(OnBrowseOutputFolder);
            ConvertCommand = new RelayCommand(ConvertCommandMethod);
        }

        public ICommand BrowseXmlFileCommand { get; private set; }
        public ICommand BrowseXslFileCommand { get; private set; }

        public ICommand BrowseOutPutFolderCommand { get; private set; }
        public ICommand ConvertCommand { get; private set; }

        public string XmlPath
        {
            get { return _xmlPath; }
            set { Set(() => XmlPath, ref _xmlPath, value); }
        }

        public string XslPath
        {
            get { return _xslPath; }
            set { Set(() => XslPath, ref _xslPath, value); }
        }

        public string OutputPath
        {
            get { return _outputFolder; }
            set { Set(() => OutputPath, ref _outputFolder, value); }
        }

        public string XmlContent
        {
            get { return _xmlContent; }

            set { Set(() => XmlContent, ref _xmlContent, value); }
        }

        public string XslContent
        {
            get { return _xslContent; }
            set { Set(() => XslContent, ref _xslContent, value); }
        }

        private void OnBrowseOutputFolder()
        {
            var saveFolder = new SaveFileDialog();
            saveFolder.Filter = "html File(*.html) | *.html|All File(*.*)|*.*";
            var openResult = saveFolder.ShowDialog();
            if (openResult.HasValue && openResult.Value)
            {
                OutputPath = saveFolder.FileName;
            }
        }

        private void ConvertCommandMethod()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            string xmlfile = XmlPath;
            string xslfile = XslPath;
            string outfile = OutputPath;

            XPathDocument doc = null;
            try
            {
                doc = new XPathDocument(xmlfile);
            }
            catch (XmlException e)
            {
                Console.WriteLine(Path.GetFullPath(xmlfile));
                MessageBox.Show(e.Message);
                Environment.Exit(1);
            }

            try
            {
                XslCompiledTransform transform = new XslCompiledTransform(true);
                transform.Load(xslfile);

                //XmlTextWriter writer = new XmlTextWriter(outfile, Encoding.UTF8);
                var writer = new XmlHtmlWriter(outfile, Encoding.UTF8);

                transform.Transform(doc, null, writer);

                MessageBox.Show(String.Format("{0} in {1}ms", Path.GetFullPath(outfile), stopwatch.ElapsedMilliseconds));

                System.Diagnostics.Process.Start(Path.GetFullPath(outfile));
            }
            catch (XsltException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(String.Format("{0}({1},{2})", e.SourceUri, e.LineNumber, e.LinePosition));
                Console.WriteLine(e.InnerException.Message);
                Environment.Exit(1);
            }
            catch (XmlException e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(1);
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(1);
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
                Environment.Exit(1);
            }
        }

        private void OnBrowseXmlFile()
        {
            var openDialog = new OpenFileDialog();
            openDialog.Filter = "xml File(*.xml) | *.xml|iCore Project File(*.icore) | *.iCore";
            var openResult = openDialog.ShowDialog();
            if (openResult.HasValue && openResult.Value)
            {
                XmlPath = openDialog.FileName;
                var doc= XDocument.Load(XmlPath);
                XmlContent = doc.Root.ToString();
            }
        }

        private void OnBrowseXslFile()
        {
            var openDialog = new OpenFileDialog();
            openDialog.Filter = @"xsl File (*.xsl) |*.xsl";
            var openResult = openDialog.ShowDialog();
            if (openResult.HasValue && openResult.Value)
            {
                XslPath = openDialog.FileName;
                var doc = XDocument.Load(XslPath);
                XslContent = doc.Root.ToString();
            }
        }
    }
}