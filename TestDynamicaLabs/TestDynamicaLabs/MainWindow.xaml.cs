using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestDynamicaLabs.DataClass;

namespace TestDynamicaLabs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnShowPage_Click(object sender, RoutedEventArgs e)
        {
            DeserializationToHtml();
            ShowHtml();
        }

        public void DeserializationToHtml()
        {
            string s = "{responce:{items:" + txtBox.Text + "}}";
            Data data = JsonConvert.DeserializeObject<Data>(s);
            string path = Directory.GetCurrentDirectory();
            using (StreamWriter streamwriter = new StreamWriter(path + "\\Page.html", false, new UTF8Encoding(false)))
            {
                streamwriter.WriteLine("<html>");
                streamwriter.WriteLine("<head>");
                streamwriter.WriteLine("  <title>HTML-Document</title>");
                streamwriter.WriteLine("  <meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />");
                streamwriter.WriteLine("</head>");
                streamwriter.WriteLine("<body>");
                IEnumerable<IGrouping<string, string>> it = data.responce.items.GroupBy(o => o.maker, d => d.model).Reverse();
                foreach (IGrouping<string, string> item in it)
                {
                    streamwriter.WriteLine(@"<p>"+"<font color=\"red\">" + item.Key +"</font>"+"</p>");
                    foreach (string model in item)
                    {
                        streamwriter.WriteLine("<p>" + model + "</p>");
                    }
                }
                streamwriter.WriteLine("</body>");
                streamwriter.WriteLine("</html>");
                streamwriter.Close();
            }
        }

        public void ShowHtml()
        {
            Process prc = new Process();
            string path = Directory.GetCurrentDirectory();
            prc.StartInfo.FileName = path + "\\Page.html";
            prc.StartInfo.UseShellExecute = true;
            prc.Start();
        }
    }
}
