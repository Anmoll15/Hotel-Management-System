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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HotelManagement
{
    public partial class Booking : Form
    {
        public Booking()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           SqlConnection con = new SqlConnection(@"Data Source=LOQ\SQLEXPRESS;Initial Catalog=HotelDB;Integrated Security=True;TrustServerCertificate=True");

            con.Open();

            SqlCommand cnn = new SqlCommand("insert into bookings Values(@bookingid,@firstname,@lastname,@roomchoice,@checkindate,@checkoutdate)", con);

            cnn.Parameters.AddWithValue ("@bookingid", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@firstname", textBox2.Text);
            cnn.Parameters.AddWithValue("@lastname", textBox3.Text);
            cnn.Parameters.AddWithValue("@roomchoice", textBox4.Text);
            cnn.Parameters.AddWithValue("@checkindate", dateTimePicker1.Value);
            cnn.Parameters.AddWithValue("@checkoutdate", dateTimePicker2.Value);

            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Saved");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LOQ\SQLEXPRESS;Initial Catalog=HotelDB;Integrated Security=True;TrustServerCertificate=True");

            con.Open();

            SqlCommand cnn = new SqlCommand("Select * from bookings", con);

            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);

            dataGridView1.DataSource = table;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LOQ\SQLEXPRESS;Initial Catalog=HotelDB;Integrated Security=True;TrustServerCertificate=True");

            con.Open();

            SqlCommand cnn = new SqlCommand("update bookings set firstname=@firstname,lastname=@lastname,roomchoice=@roomchoice,checkindate=@checkindate,checkoutdate=@checkoutdate where bookingid=@bookingid", con);


            cnn.Parameters.AddWithValue("@bookingid", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@firstname", textBox2.Text);
            cnn.Parameters.AddWithValue("@lastname", textBox3.Text);
            cnn.Parameters.AddWithValue("@roomchoice", textBox4.Text);
            cnn.Parameters.AddWithValue("@checkindate", dateTimePicker1.Value);
            cnn.Parameters.AddWithValue("@checkoutdate", dateTimePicker2.Value);

            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Updated");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LOQ\SQLEXPRESS;Initial Catalog=HotelDB;Integrated Security=True;TrustServerCertificate=True");

            con.Open();

            SqlCommand cnn = new SqlCommand("delete bookings where bookingid=@bookingid", con);

            cnn.Parameters.AddWithValue("@bookingid", int.Parse(textBox1.Text));
           

            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Deleted");
        }

        private void Booking_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LOQ\SQLEXPRESS;Initial Catalog=HotelDB;Integrated Security=True;TrustServerCertificate=True");

            con.Open();

            SqlCommand cnn = new SqlCommand("Select * from bookings", con);

            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);

            dataGridView1.DataSource = table;
        }
    }
}
