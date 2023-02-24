using Microsoft.EntityFrameworkCore;
using UI.Context;

namespace UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormClosed += (sender, e) => context?.Dispose();
        }

        pubsContext context = new();
        

        private void Form1_Load(object sender, EventArgs e)
        {
            context.Titles.Load();
            dataGridView1.DataSource = context.Titles.Local.ToBindingList();
            

            context.Publishers.Load();
            var PublisherList = context.Publishers.Local.ToBindingList(); 
            DataGridViewComboBoxColumn pubCombo = new();
            pubCombo.DataSource = PublisherList;
            pubCombo.HeaderText = "Publisher Name";
            pubCombo.DisplayMember = "PubName";
            pubCombo.ValueMember = "PubId";
            pubCombo.DataPropertyName = "PubId";

            dataGridView1.Columns.Add(pubCombo);

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.EndEdit();
            context.SaveChanges();
            MessageBox.Show(" Changes are Saved Successfully");
        }
    }
}