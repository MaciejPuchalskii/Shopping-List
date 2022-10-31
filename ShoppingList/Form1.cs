using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShoppingList
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

    

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if(progressBar1.Value <100)
            {
                if(textBox1.Text.Length>0)
                {
                    if(listBox1.Items.Contains(textBox1.Text))
                    {
                        DialogResult resault = MessageBox.Show("Element already exists, Do you want to add it?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if(resault == DialogResult.No)
                        {
                            return;
                        }
                    }
                    listBox1.Items.Add(textBox1.Text);
                    textBox1.Clear();
                    AktualizujProgres();
                }
                else
                {
                     MessageBox.Show("Not item found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("List is full. Delete something to add something else!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AktualizujProgres()
        {
            int iloscelementow = listBox1.Items.Count;
            progressBar1.Value = iloscelementow * 10;
        }

        private void btnUsun_Click(object sender, EventArgs e)
        {
            int indexOfElement = listBox1.SelectedIndex;
            if(indexOfElement != -1)
            {
                listBox1.Items.RemoveAt(indexOfElement);
                AktualizujProgres();
            }
            else
            {
                MessageBox.Show("None element have been selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCzysc_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            AktualizujProgres();
        }
    }
}
