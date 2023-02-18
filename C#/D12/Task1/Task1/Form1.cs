using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task1
{
    public partial class Form1 : Form
    {
        SqlConnection sqlConn;
        SqlCommand sqlCmd;
        SqlDataAdapter sqlDA;
        DataTable DtPrds;

        public Form1()
        {
            InitializeComponent();
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {
            sqlConn = new SqlConnection(@"Data Source=DESKTOP-RM9R44Q;initial Catalog=Northwind;Integrated Security=true;TrustServerCertificate=true");
            sqlCmd = new SqlCommand("SelectAllProducts", sqlConn);
            sqlCmd.CommandType = CommandType.StoredProcedure;

            sqlDA = new SqlDataAdapter(sqlCmd);
            DtPrds = new DataTable();

            sqlDA.Fill(DtPrds);

            ///Complex Data Binding => dataSource =  DtPrds
            dataGridView1.DataSource = DtPrds;
          
        }

        
    }


}
