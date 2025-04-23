using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagement
{
    public partial class Room : Form
    {
        public Room()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LOQ\SQLEXPRESS;Initial Catalog=HotelDB;Integrated Security=True;TrustServerCertificate=True");

            con.Open();

            SqlCommand cnn = new SqlCommand("insert into rooms Values(@roomid,@roomnumber,@roomtype,@price,@status)", con);

            cnn.Parameters.AddWithValue("@roomid", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@roomnumber", int.Parse(textBox2.Text));
            cnn.Parameters.AddWithValue("@roomtype", textBox3.Text);
            cnn.Parameters.AddWithValue("@price", int.Parse(textBox4.Text));
            cnn.Parameters.AddWithValue("@status", textBox5.Text);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Saved");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LOQ\SQLEXPRESS;Initial Catalog=HotelDB;Integrated Security=True;TrustServerCertificate=True");

            con.Open();

            SqlCommand cnn = new SqlCommand("Select * from rooms", con);

            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);

            dataGridView1.DataSource = table;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LOQ\SQLEXPRESS;Initial Catalog=HotelDB;Integrated Security=True;TrustServerCertificate=True");

            con.Open();

            SqlCommand cnn = new SqlCommand("update rooms set roomnumber=@roomnumber,roomtype=@roomtype,price=@price,status=@status where roomid=@roomid", con);

            cnn.Parameters.AddWithValue("@roomid", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@roomnumber", int.Parse(textBox2.Text));
            cnn.Parameters.AddWithValue("@roomtype", textBox3.Text);
            cnn.Parameters.AddWithValue("@price", int.Parse(textBox4.Text));
            cnn.Parameters.AddWithValue("@status", textBox5.Text);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Updated");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LOQ\SQLEXPRESS;Initial Catalog=HotelDB;Integrated Security=True;TrustServerCertificate=True");

            con.Open();

            SqlCommand cnn = new SqlCommand("delete rooms where roomid=@roomid", con);

            cnn.Parameters.AddWithValue("@roomid", int.Parse(textBox1.Text));
           
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Deleted");
        }

        private void Room_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LOQ\SQLEXPRESS;Initial Catalog=HotelDB;Integrated Security=True;TrustServerCertificate=True");

            con.Open();

            SqlCommand cnn = new SqlCommand("Select * from rooms", con);

            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);

            dataGridView1.DataSource = table;
        }
    }
}    
