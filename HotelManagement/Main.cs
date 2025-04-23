using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagement
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Guest gt = new Guest();
            gt.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Room rm = new Room();
            rm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Booking bk = new Booking();
            bk.Show(); 
        }
    }
}
