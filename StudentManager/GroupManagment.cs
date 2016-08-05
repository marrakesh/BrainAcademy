using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManager
{
    public partial class GroupManagment : Form
    {
        private readonly StudentContext db;
        public GroupManagment()
        {
            InitializeComponent();
            db = new StudentContext();
            GroupList.DataSource = db.Groups.ToList();
            GroupList.DisplayMember = "GroupName";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var listName = GroupList.Text;
            var idNameTable = db.Groups.Select(x => new { x.GroupName, x.Id });
            var id = idNameTable.Where(v => v.GroupName == listName).Select(v => v.Id).ToList()[0];
            var group = db.Groups.Find(id);
            db.Groups.Remove(group);
            db.SaveChanges();
            GroupList.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           var group = new Group
            {
                GroupName = textBox1.Text,
            };


            db.Groups.Add(group);
            db.SaveChanges();
            GroupList.Refresh();
            MessageBox.Show("New group succesfully added");
        }
    }
}
