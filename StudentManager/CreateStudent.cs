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
    public partial class CreateStudent : Form
    {
        private readonly StudentContext db;
        public CreateStudent()
        {
            InitializeComponent();
            db = new StudentContext();
            comboBox1.DataSource = db.Groups.ToList();
            comboBox1.DisplayMember = "GroupName";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
