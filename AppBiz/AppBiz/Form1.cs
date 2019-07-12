using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
namespace AppBiz
{
    public partial class Form1 : Form
    {
       
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "zR1XLA7t6MqYvc2QZLBP0uFcmqVY9jWnwvkhOsbn",
            BasePath= "https://database-98ed4.firebaseio.com/"
        };
        IFirebaseClient client;
        public Form1()
        {
            InitializeComponent();

          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);
          


        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                panel1.Width += 11;
                if (panel1.Width >= 475)
                {
                    timer1.Stop();
                    Form2 m = new Form2();
                    m.Show();
                    this.Hide();

                }
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
