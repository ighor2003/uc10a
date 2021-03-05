using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;

namespace escolauc10a.Class
{
    public class Professor
    {
        public Professor()
        {

        }
        public Professor(string nome, string cpf, string email, string telefone)
        {
            this.Nome = nome;
            CPF = cpf;
            Email = email;
            Telefone = telefone;
        }
        public int Id { get; set; }

        public string Nome { get; set; }

        public string CPF { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public bool Ativo { get; set; }

        public List<Professor> ObterProfessor()
        {
            List<Professor> lista = new List<Professor>();

            var cmd = Banco.Abrir();

            if (cmd.Connection.State == System.Data.ConnectionState.Open)
            {
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select * from professor";
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new Professor(
                        dr.GetString(1),
                        dr.GetString(2),
                        dr.GetString(3),
                        dr.GetString(4)

                        ));
                }
            }
            return lista;
        }
        public void inserir()
        {
            var cmd = Banco.Abrir();

            if (cmd.Connection.State == System.Data.ConnectionState.Open)
            {
                cmd.CommandText = "insert professor (nome, cpf, email, telefone)" +
                    "values ('" + Nome + "','" + CPF + "','" + Email + "', '" + Telefone + "')";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "select @@identity";
                Id = Convert.ToInt32(cmd.ExecuteScalar());

            }
        }
    }
}
