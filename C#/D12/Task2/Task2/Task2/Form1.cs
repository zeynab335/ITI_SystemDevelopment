using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace Task2
{
    public partial class Form1 : Form
    {
        SqlConnection sqlCon;
        SqlCommand sqlCmd;
        SqlCommand sqlCmd2;
        BindingSource bindingSource;

        SqlDataReader supplierData;
        SqlDataAdapter sqlDA;
        DataTable Dtable;



        SqlDataAdapter DACategorie;
        DataTable DTCategories;

        SqlDataAdapter DASuppliers;
        DataTable DTSuppliers;

        public Form1()
        {
            InitializeComponent();
        }

        [Obsolete]
        private void Form1_Load(object sender, EventArgs e)
        {
            // estublish sql connenction
            sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["connectDB"].ConnectionString);
            sqlCon.Open();

          
            // start adding details of product into controls 
            sqlDA = new SqlDataAdapter(new SqlCommand("select * from Products", sqlCon));
            Dtable = new DataTable();
            sqlDA.Fill(Dtable);

            SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(sqlDA);
            sqlDA.InsertCommand = cmdBuilder.GetInsertCommand();
            sqlDA.UpdateCommand= cmdBuilder.GetUpdateCommand();
            sqlDA.DeleteCommand = cmdBuilder.GetDeleteCommand();


            bindingSource = new BindingSource(Dtable, "");

            //Simple Data Binding
            id.DataBindings.Add("Text", bindingSource, "ProductID");
            productName.DataBindings.Add("Text", bindingSource, "ProductName");
           
            // get category name
            sqlCmd2 = new SqlCommand("select CategoryName , CategoryID from Categories", sqlCon);

            DACategorie = new SqlDataAdapter(sqlCmd2);
            DTCategories = new DataTable();
            DACategorie.Fill(DTCategories);

            BindingSource bindingSource1 = new BindingSource(DTCategories, "");

            catNameCompo.DataSource = DTCategories;
            catNameCompo.ValueMember = "CategoryID";
            catNameCompo.DisplayMember = "CategoryName";
            catNameCompo.DataBindings.Add("SelectedValue", bindingSource, "CategoryID");


            // get Sublier name
            SqlCommand sqlCmd3 = new SqlCommand("select ContactName as subName , SupplierID as subID from Suppliers ", sqlCon);
            
            DASuppliers = new SqlDataAdapter(sqlCmd3);
            DTSuppliers = new DataTable();
            DASuppliers.Fill(DTSuppliers);

            comboBox1.DataSource = DTSuppliers;
            comboBox1.ValueMember = "subID";
            comboBox1.DisplayMember = "subName";
            comboBox1.DataBindings.Add("SelectedValue" , bindingSource, "SupplierID");
            
            bindingNavigator1.BindingSource   = bindingSource;
            //this.Controls.Add(bindingNavigator);

        }

        private void save_Click(object sender, EventArgs e)
        {
            this.Validate();
            bindingSource.EndEdit();
            sqlDA.Update(Dtable);

        }

    }
}

