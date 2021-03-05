using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using escolauc10a.Class;

namespace escolauc10a.Forms
{
    public partial class FrmProfessor : Form
    {
        public FrmProfessor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Professor professor = new Professor();
            var lista = professor.ObterProfessor();
            foreach (var docente in lista)
            {
                listBox1.Items.Add(docente.Nome + " - " + docente.CPF + " - " + docente.Email + " - " + docente.Telefone);
            }
        }

        private void FrmProfessor_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            Professor professor = new Professor(
                txtNome.Text,
                txtCpf.Text,
                txtEmail.Text,
                txtTelefone.Text
                );
            professor.inserir();
            txtId.Text = professor.Id.ToString();
        }
    }
}
