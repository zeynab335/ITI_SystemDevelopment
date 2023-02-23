using BLL.Entity;
using BLL.EntityList;
using BLL.EntityManager;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;
using ComboBox = System.Windows.Forms.ComboBox;

namespace layered
{
    public partial class Detailed : Form
    {
        TitleList titleList;
        PublisherList publishers;
        BindingNavigator bindingNavigator;
        public Detailed()
        {
            InitializeComponent();
        }

        [Obsolete]
        private void Form1_Load(object sender, EventArgs e)
        {
            // lists
            titleList  = TitleManager.selectAllTitles();
            publishers = PublisherManager.selectAllPublishers();

            BindingSource bindingSource = new BindingSource(titleList, "");

            //Simple Data Binding
            id_text.DataBindings.Add("Text", bindingSource, "title_id");
            title_text.DataBindings.Add("Text", bindingSource, "title");
            price_text.DataBindings.Add("Text", bindingSource, "price");
            advance_text.DataBindings.Add("Text", bindingSource, "royalty");
            royalty_text.DataBindings.Add("Text", bindingSource, "advance");
            ytd_sales_text.DataBindings.Add("Text", bindingSource, "ytd_sales");
            notes_text.DataBindings.Add("Text", bindingSource, "notes");
            pubdate_text.DataBindings.Add("Text", bindingSource, "pubdate");


          
            BindingSource publishersBindingSource = new BindingSource(publishers, "");

            publisherCom.DataSource  = publishersBindingSource;
            publisherCom.ValueMember = "pub_id";
            publisherCom.DisplayMember = "pub_name";
            publisherCom.DataBindings.Add("SelectedValue", bindingSource, "pub_id");

            bindingNavigator = new(bindingSource);

            this.Controls.Add(bindingNavigator);
            bindingNavigator.DeleteItem.Click += DeleteItem_Click;
            //bindingNavigator.AddNewItem. += AddedItem_Click;
        }

        private void DeleteItem_Click(object? sender, EventArgs e)
        {
            bool exe = TitleManager.DeleteTitle(id_text.Text.ToString());
            if (exe)
            {
                 MessageBox.Show("Title Deleted Successfully ");
            }
            else
            {
                 MessageBox.Show("Title is not Deleted ");

            }
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach(var title in titleList)
            {
                
                if(title.State == EntityState.Changed)
                {

                    bool exe = TitleManager.UpdatePropertiesInTitle(title);
                    if(exe)
                    {
                        MessageBox.Show("Title Upated Successfully ");
                    }
                    else
                    {
                        MessageBox.Show("Title is not updated ");

                    }
                }
            }
        }

        // add new item
        private void button1_Click(object sender, EventArgs e)
        {
            //decimal? price , decimal? advance , int? royalty , int? ytd_sales , string notes)

            int.TryParse(royalty_text.Text.ToString(), out int role);
            int.TryParse(ytd_sales_text.Text.ToString(), out int ytd);

            decimal.TryParse(price_text.Text.ToString(), out decimal price);
            decimal.TryParse(advance_text.Text.ToString(), out decimal advance);

            Title title = new Title();
            title.title_id= id_text.Text.ToString();
            title.pub_id = publisherCom.SelectedValue?.ToString()??"Null";
            title.price = price;
            title.title = title_text?.Text ?? "NA";
            title.notes = notes_text?.Text ?? "NA";
            title.advance = advance;
            title.royalty = role;
            title.ytd_sales = ytd;

            title.State = EntityState.Added;

            bool exe = TitleManager.InsertTitle(title);
            if (exe)
            {
                MessageBox.Show("Title Added Successfully ");

            }
            else
            {
                MessageBox.Show("Title is not Added ");

            }

        }
    }
}

