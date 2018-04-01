using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutoHome
{
    public partial class FrmLog : Form
    {
        List<string> ListLogFrontend;

        public FrmLog(List<String> LogList)
        {
            InitializeComponent();
            ListLogFrontend = new List<string>(LogList);
            /*BindingSource BS = new BindingSource();
            BS.DataSource = ListLogFrontend;
            dataGridView_log.DataSource = BS;
            */

            
            foreach (string s in ListLogFrontend)
                richTextBox_log.AppendText(s + Environment.NewLine);
                
            //richTextBox_log.BindingContext = LogList;
        }
    }
}
