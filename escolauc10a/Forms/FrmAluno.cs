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
    public partial class FrmAluno : Form
    {
        public FrmAluno()
        {
            InitializeComponent();
        }

        private void FrmAluno_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Aluno aluno = new Aluno();
            var lista = aluno.ObterAlunos();
            foreach (var item in lista)
            {
                if (item.Ativo)
                {
                    listBox1.Items.Add(item.Id + " - " + item.Nome + " - " + item.Email);
                }
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            Aluno aluno = new Aluno(
                txtNome.Text,
                txtEmail.Text,
                txtSenha.Text
                );
            aluno.inserir();
            txtId.Text = aluno.Id.ToString();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.Text == "...")
            {
                txtId.ReadOnly = false;
                txtId.Focus();
                button5.Text = "Buscar";
                btnInserir.Enabled = false;
            }
            else if (button5.Text == "Buscar")
            {
                txtId.ReadOnly = true;
                button5.Text = "...";
                button4.Enabled = true;
                // consultar por id
                Aluno aluno = new Aluno();
                aluno.BuscarPorId(int.Parse(txtId.Text));
                txtNome.Text = aluno.Nome;
                txtEmail.Text = aluno.Email;
                txtEmail.Enabled = false;
                checkBox1.Checked = aluno.Ativo;
                checkBox1.Enabled = true;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Aluno aluno = new Aluno();
            aluno.Nome = txtNome.Text;
            aluno.Senha = txtSenha.Text;
            aluno.Ativo = checkBox1.Checked;

            if (aluno.Atualizar())
            {
                MessageBox.Show("Aluno editado com sucesso!");
            }
            
        }
    }
}
