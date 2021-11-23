using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShopManager
{
    public partial class fAccountProfile : Form
    {
        public fAccountProfile()
        {
            InitializeComponent();
        }

        /* Method for Account Profile*/
        #region Methods

        #endregion

        #region Events

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
