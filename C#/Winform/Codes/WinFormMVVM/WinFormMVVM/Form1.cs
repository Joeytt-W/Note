using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace WinFormMVVM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Peoples = new BindingList<People>();
        }

        public BindingList<People> Peoples { get; set; }

        private void Form1_Load(object sender, EventArgs e)
        {
            Peoples.Add(new People
            {
                Name = "张三",
                Age = 20,
                Address = "北京"
            });

            Peoples.Add(new People
            {
                Name = "李四",
                Age = 25,
                Address = "上海"
            });

            Peoples.Add(new People
            {
                Name = "王五",
                Age = 29,
                Address = "南京"
            });

            dgvPeoples.DataBindings.Add("DataSource", this, "Peoples", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void btnAddPeople_Click(object sender, EventArgs e)
        {
            Peoples.Add(new People());
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            string str = string.Empty;
            foreach (var people in Peoples)
            {
                str += people.Name + "," + people.Age + "," + people.Address + "\r\n";
            }
            MessageBox.Show(str);
        }

        private void btnDeletePeople_Click(object sender, EventArgs e)
        {
            People people = dgvPeoples.CurrentRow.DataBoundItem as People;
            Peoples.Remove(people);
        }
    }
}
