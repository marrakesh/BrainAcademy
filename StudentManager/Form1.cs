using System;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace StudentManager
{   
    public partial class StudentManager : Form
    {
        private readonly StudentContext db;

        public StudentManager()
        {
            InitializeComponent();
            db = new StudentContext();
            db.Students.Load();
            StudenList.DataSource = db.Students.ToList();
            StudenList.DisplayMember = "Name";
            comboBox1.DataSource = db.Groups.ToList();
            comboBox1.DisplayMember = "GroupName";
            StudenList.ValueMember = "Id";
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label7.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {

        }

        //Student list
        private void listBox1_Click(object sender, EventArgs e)
        {

            var listName = StudenList.Text;
            var idNameTable = db.Students.Select(x => new { x.Id, x.Name, x.Group, x.GroupId, x.Number, x.AverageGrade, x.Scholarship });
            var id = idNameTable.Where(v => v.Name == listName).Select(v => v.Id).ToList()[0];
            var name = idNameTable.Where(v => v.Name == listName).Select(n => n.Name).ToList()[0];
            var group = idNameTable.Where(v => v.Name == listName).Select(s => s.Group).ToList()[0];
            var number = idNameTable.Where(v => v.Name == listName).Select(n => n.Number).ToList()[0];
            var ag = idNameTable.Where(v => v.Name == listName).Select(v => v.AverageGrade).ToList()[0];
            var scholar = idNameTable.Where(v => v.Name == listName).Select(n => n.Scholarship).ToList()[0];

            textBox1.Text = id.ToString();
            textBox2.Text = name;
            textBox3.Text = number.ToString();
            textBox4.Text = ag.ToString(CultureInfo.CurrentCulture);
            checkBox1.Checked = scholar;
            comboBox1.Text = group.GroupName;

        }

        //Update student
        private void button2_Click(object sender, EventArgs e)
        {
            var listName = StudenList.Text;
            var idNameTable = db.Students.Select(x => new { x.Id, x.Name });
            var id = idNameTable.Where(v => v.Name == listName).Select(v => v.Id).ToList()[0];
            var student = db.Students.Find(id);
            var grid0 = (Group)comboBox1.SelectedItem;

            student.Name = textBox2.Text;
            student.GroupId = grid0.Id;
            student.Number = int.Parse(textBox3.Text);
            student.AverageGrade = double.Parse(textBox4.Text);
            student.Scholarship = checkBox1.Checked;

            db.SaveChanges();
            StudenList.Refresh();
            MessageBox.Show("Succesfully updated");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        //Delete student
        private void button4_Click(object sender, EventArgs e)
        {
            var listName = StudenList.Text;
            var idNameTable = db.Students.Select(x => new { x.Id, x.Name });
            var id = idNameTable.Where(v => v.Name == listName).Select(v => v.Id).ToList()[0];
            var student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();
            StudenList.Refresh();
            MessageBox.Show("Succesfully deleted");
        }
        //Create student
        private void button1_Click(object sender, EventArgs e)
        {
            var createStudForm = new CreateStudent();
            var result = createStudForm.ShowDialog(this);
            var grid0 = (Group)createStudForm.comboBox1.SelectedItem;
            
            if (result == DialogResult.Cancel)
            {
                return;
            }
            var student = new Student
            {
                Name = createStudForm.textBox1.Text,
                GroupId = grid0.Id,
                Number = int.Parse(createStudForm.textBox2.Text),
                AverageGrade = double.Parse(createStudForm.textBox3.Text),
                Scholarship = createStudForm.checkBox1.Checked
            };


            db.Students.Add(student);
            db.SaveChanges();
            StudenList.Refresh();
            MessageBox.Show("New student succesfully added");
        }

        //Group managment
        private void button3_Click(object sender, EventArgs e)
        {
            var groupManagmentForm = new GroupManagment();
            var result = groupManagmentForm.ShowDialog(this);

            if (result == DialogResult.Cancel)
            {
                return;
            }

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text.Contains('.') || textBox4.Text.Contains(' '))
            {
                label7.Text = "Invalid symbol";
            }
            else
            {
                label7.Text = "";
            }
        }
    }
}
