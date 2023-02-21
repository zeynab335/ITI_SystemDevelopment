using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
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


        SqlCommand sqlCmd2, sqlCmd3;
        SqlDataAdapter DACategorie;
        DataTable DTCategories;

        SqlDataAdapter DASuppliers;
        DataTable DTSuppliers;


        public Form1()
        {
            InitializeComponent();
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {
            sqlConn = new SqlConnection(@"Data Source=DESKTOP-RM9R44Q;initial Catalog=Northwind;Integrated Security=true;TrustServerCertificate=true");
            sqlCmd = new SqlCommand("select * from Products", sqlConn);
            sqlCmd.CommandType = CommandType.Text;

            sqlDA = new SqlDataAdapter(sqlCmd);
            DtPrds = new DataTable();

            SqlCommandBuilder sqlCmdBuilder = new SqlCommandBuilder(sqlDA);
            sqlDA.InsertCommand = sqlCmdBuilder.GetInsertCommand();
            sqlDA.UpdateCommand = sqlCmdBuilder.GetUpdateCommand();
            sqlDA.DeleteCommand = sqlCmdBuilder.GetDeleteCommand();


        }
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            // load category into compobox
            DataGridViewComboBoxColumn categorCB = new DataGridViewComboBoxColumn();

            sqlDA.Fill(DtPrds);
            ///Complex Data Binding => dataSource =  DtPrds
            dataGridView1.DataSource = DtPrds;


            //* Add Category Name DropDown Box
            sqlCmd2 = new SqlCommand("select CategoryName , CategoryID as catID from Categories", sqlConn);

            DACategorie = new SqlDataAdapter(sqlCmd2);
            DTCategories = new DataTable();
            DACategorie.Fill(DTCategories);

            BindingSource bindingSource1 = new BindingSource(DTCategories, "");

            categorCB.DataSource = bindingSource1;
            categorCB.ValueMember= "catID";
            categorCB.DisplayMember = "CategoryName";
            categorCB.HeaderText = "CategoryName";
            // binding with data grid view
            categorCB.DataPropertyName= "CategoryID";

            dataGridView1.Columns.Add(categorCB);
            dataGridView1.Columns["CategoryID"].Visible= false;
            //dataGridView1.Columns.Add(categorCB);

            //*******************************************************************

            //* Add Supplier Name DropDown Box
            // load category into compobox
            DataGridViewComboBoxColumn supplierDB = new DataGridViewComboBoxColumn();

            SqlCommand sqlCmd3 = new SqlCommand("select ContactName as subName , SupplierID as subID from Suppliers ", sqlConn);

            DASuppliers = new SqlDataAdapter(sqlCmd3);
            DTSuppliers = new DataTable();
            DASuppliers.Fill(DTSuppliers);

            BindingSource bindingSource2 = new BindingSource(DTSuppliers, "");

            supplierDB.DataSource = bindingSource2;
            supplierDB.ValueMember = "subID";
            supplierDB.DisplayMember = "subName";
            supplierDB.HeaderText = "ContactName";
            // binding with data grid view
            supplierDB.DataPropertyName = "SupplierID";

            dataGridView1.Columns.Add(supplierDB);
            dataGridView1.Columns["SupplierID"].Visible = false;





        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
          
            dataGridView1.EndEdit();
            sqlDA.Update(DtPrds);
        }
    }


}
