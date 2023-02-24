using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Context;
using UI.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace UI
{
    public partial class DetailedView : Form
    {
        BindingNavigator bindingNavigator;  
        public DetailedView()
        {
            InitializeComponent();
            // to dispose context obj
            this.FormClosed += (sender, e) => context?.Dispose();

        }

        pubsContext context = new();
        private void DetailedView_Load(object sender, EventArgs e)
        {

            context.Titles.Load();
            context.Publishers.Load();

            var TitlesList = context.Titles.Local.ToBindingList();
            var PublisherList = context.Publishers.Local.ToBindingList();
            BindingSource bindingSource = new BindingSource(TitlesList, "");
            bindingNavigator = new(bindingSource);


            //Simple Data Binding
            id_text.DataBindings.Add("Text", bindingSource, "TitleId");
            title_text.DataBindings.Add("Text", bindingSource, "Title1");
            price_text.DataBindings.Add("Text", bindingSource, "Price" , true);
            advance_text.DataBindings.Add("Text", bindingSource, "Royalty",true);
            royalty_text.DataBindings.Add("Text", bindingSource, "Advance", true);
            ytd_sales_text.DataBindings.Add("Text", bindingSource, "YtdSales", true);
            notes_text.DataBindings.Add("Text", bindingSource, "Notes");
            pubdate_text.DataBindings.Add("Text", bindingSource, "Pubdate");


            // publisher compobox
            publisherCom.DataSource = PublisherList;
            publisherCom.ValueMember = "PubId";
            publisherCom.DisplayMember = "PubName";
            publisherCom.DataBindings.Add("SelectedValue", TitlesList, "PubId");



            this.Controls.Add(bindingNavigator);
        
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Title current = (Title)bindingNavigator.BindingSource.Current;
            EntityState CurrentState = context.Entry(current).State;

            //if(CurrentState.Equals(EntityState.Modified))
            //{
            //    MessageBox.Show("Modified");
            //}

            try
            {
                context.SaveChanges();
                MessageBox.Show("Changes are saved successfully");

            }
            catch
            {
                MessageBox.Show("Can't Save Changes");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            Title newTitle = new Title()
            {
                TitleId = id_text.Text.ToString(),
                Title1 = title_text.Text.ToString(),
                PubId = publisherCom.SelectedValue?.ToString(),
                Price = Convert.ToDecimal(price_text.Text.ToString()),
                Advance = Convert.ToDecimal(advance_text.Text.ToString()),
                Royalty = Convert.ToInt32(royalty_text.Text.ToString()),
                Notes = notes_text.Text.ToString(),

            };
            
            context.Add(newTitle);
            try
            {
                context.SaveChanges();
                MessageBox.Show("Added New Title successfully");

            }
            catch
            {
                MessageBox.Show("Title can't be added ");
            }
        }
    }
}
