using BLL.Entity;
using BLL.EntityList;
using BLL.EntityManager;
using System.Data;

namespace layered
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        TitleList title = new TitleList(); 
        private void loafToolStripMenuItem_Click(object sender, EventArgs e)
        {
            title = TitleManager.selectAllTitles();
            dataGridView1.DataSource = title;

            PublisherList publisher  = PublisherManager.selectAllPublishers();

            DataGridViewComboBoxColumn PubdropDown = new DataGridViewComboBoxColumn();

            PubdropDown.HeaderText = "Publisher Name";
            PubdropDown.DataSource = publisher;
            PubdropDown.ValueMember = "pub_id";
            PubdropDown.DisplayMember = "pub_name";

            PubdropDown.DataPropertyName = "pub_id";


            dataGridView1.Columns.Add(PubdropDown);
            dataGridView1.Height = 400;
            dataGridView1.UserDeletingRow += deleteRow;


        }
   
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.EndEdit();

            foreach ( Title t in title)
            {
                if (t.State == EntityState.Changed)
                {
                    TitleManager.UpdatePropertiesInTitle(t); 
                    
                        MessageBox.Show("Updated Successfully");

                     

                }
                else if (t.State == EntityState.Added)
                {
                    TitleManager.InsertTitle(t);
                    
                        MessageBox.Show("Added Successfully");
                    


                }
            }
        }

        private void deleteRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            string deletedID = title.ElementAt(e.Row.Index).title_id;
            if (TitleManager.DeleteTitle(deletedID))
            {
                MessageBox.Show("Deleted Successfully");
            }

        }

  
    }
}