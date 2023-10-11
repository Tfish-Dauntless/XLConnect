using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XLConnect.Forms
{
    public partial class PopUpForm : Form
    {
        public string DBNAME { get; set; }
        public PopUpForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets value for Form Text box to be returned.Closed Form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OK_Button_Click(object sender, EventArgs e)
        {
            if (Name_TextBox.Text.Length < 0)
            {
                //MessageBox.Show("Please add a value for name.");
                return;
            }
            else
            {
                DBNAME = Name_TextBox.Text;
            }
            this.Close();
        }

        /// <summary>
        /// Closes Form without Saving.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
