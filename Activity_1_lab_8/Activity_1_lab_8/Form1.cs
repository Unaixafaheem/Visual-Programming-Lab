using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Activity_1_lab_8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Status_Enter(object sender, EventArgs e)
        {

        }

        private void Married_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Unmarried_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Preview_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Gender, Hobby, Status;
            if (radioButton1.Checked) Gender = "Male";
            else
                Gender = "Female";
            if (radioButton2.Checked) Hobby = "Book Reading";
            else
                Hobby = "Gardening";
            if (radioButton3.Checked) Status = "Married";
            else
                Status = "Unmarried";
            MessageBox.Show("Customer Name : " + textBox1 + "\n" +
                "Country: " + comboBox1 + "\n" +
                "Gender: " + Gender + "\n" +
                "Hobby: " + Hobby + "\n" +
                "Status: " + Status);
        }

        private void loadCustomer()
        {
            string strConnection = "Data source=AUMC-LAB3-40\\SQLEXPRESS;Initial Catalog=CustomerDB; Integrated Security=True";
            SqlConnection objConnection = new SqlConnection(strConnection);
            objConnection.Open();
            string strCommand = "Select* from CustomerTable";
            SqlCommand objCommand = new SqlCommand(strCommand, objConnection);

            DataSet objDataSet = new DataSet();
            SqlDataAdapter objAdapter = new SqlDataAdapter(objCommand);
            objAdapter.Fill(objDataSet);
            dataGridView1.DataSource = objDataSet.Tables[0];
            objConnection.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            loadCustomer();
        }
    }
}
