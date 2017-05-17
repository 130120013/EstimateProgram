using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estimate
{
    public partial class WebBrowserForm : Form
    {
        private Uri uri;
        public WebBrowserForm()
        {
            InitializeComponent();
        }

        public WebBrowserForm(string link)
        {
            InitializeComponent();
            uri = new Uri(link);
            webBrowser1.Navigate(uri);
        }
        public void ChangeWebBrowserSource(string newlink)
        {

            uri = new Uri(newlink);
            webBrowser1.Navigate(uri);

        }

    }
}
