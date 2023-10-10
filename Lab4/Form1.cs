using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private Task1 task1 = new Task1();
        private VectorPaint VectorPaint = new VectorPaint();
        public Form1()
        {
            InitializeComponent();
            AddOwnedForm(task1);
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
           task1.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
