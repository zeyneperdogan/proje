using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proje1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int number;
            if (int.TryParse(textBox1.Text, out number))
            {
                Thread thread = new Thread(() => FindPrimes(number, listBox1));
                thread.Start();
            }
            else
            {
                MessageBox.Show("Please enter a valid number");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int number;
            if (int.TryParse(textBox2.Text, out number))
            {
                Thread thread = new Thread(() => FindPrimes(number, listBox2));
                thread.Start();
            }
            else
            {
                MessageBox.Show("Please enter a valid number");
            }
        }
        private void FindPrimes(int number, ListBox listBox)
        {
            List<int> primes = new List<int>();
            for (int i = 2; i <= number; i++)
            {
                if (IsPrime(i))
                {
                    primes.Add(i);
                }
            }

            this.Invoke((MethodInvoker)delegate {
                listBox.Items.Clear();
                foreach (int prime in primes)
                {
                    listBox.Items.Add(prime);
                }
            });
        }

        private bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;

            for (int i = 2; i < number; i++)
            {
                if (number % i == 0) return false;
            }

            return true;
        }
    }
}
