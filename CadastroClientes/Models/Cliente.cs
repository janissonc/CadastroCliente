using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace CadastroClientes.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
        public string EstadoCivil { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public List<Endereco> ListaEndereco { get; set; } = new List<Endereco>();

        public Cliente(string nome, string sexo, DateTime dataNascimento, string estadoCivil, string cpf, string rg, List<Endereco> listaEndereco)
        {
            Nome = nome;
            Sexo = sexo;
            DataNascimento = dataNascimento;
            EstadoCivil = estadoCivil;
            Cpf = cpf;
            Rg = rg;
            ListaEndereco = listaEndereco;
        }
        public Cliente()
        {

        }

        public static void InserirCliente(Cliente cliente)
        {
            SqlConnection connection = new SqlConnection("Server=Guilherme\\SQLEXPRESS02;Database=Cliente;User ID = sa; Password=Gui156061;" +
    "Trusted_Connection=False; MultipleActiveResultSets=true");
            if (connection.State == ConnectionState.Closed)  //System.Data.ConnectionState.Closed
            {
                connection.Open();

            }

            SqlCommand cmd = new SqlCommand("dbo.SP_ClienteInserir", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@nome", cliente.Nome);
            cmd.Parameters.AddWithValue("@sexo", cliente.Sexo);
            cmd.Parameters.AddWithValue("@dataNascimento", cliente.DataNascimento);
            cmd.Parameters.AddWithValue("@estadoCivil", cliente.EstadoCivil);
            cmd.Parameters.AddWithValue("@cpf", cliente.Cpf);
            cmd.Parameters.AddWithValue("@rg", cliente.Rg);
            cmd.ExecuteNonQuery();

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }

        }
        public static List<Cliente> Selecionar()
        {
            SqlConnection connection = new SqlConnection("Server=Guilherme\\SQLEXPRESS02;Database=Cliente;User ID = sa; Password=Gui156061;" +
    "Trusted_Connection=False; MultipleActiveResultSets=true");
            if (connection.State == ConnectionState.Closed)  //System.Data.ConnectionState.Closed
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand("dbo.SP_ClienteSelecionar", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            List<Cliente> lista = new List<Cliente>();
            while (dr.Read())
            {
                Cliente cliente = new Cliente();
                cliente.Id = int.Parse(dr["ID_Cliente"].ToString());
                cliente.Nome = dr["Nome"].ToString();
                cliente.Sexo = dr["Sexo"].ToString();
                cliente.DataNascimento = Convert.ToDateTime(dr["DataNascimento"].ToString());
                cliente.EstadoCivil = dr["EstadoCivil"].ToString();
                cliente.Cpf = dr["CPF"].ToString();
                cliente.Rg = dr["RG"].ToString();

                lista.Add(cliente);

            }

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }

            return lista;

        }

        public static Cliente SelecionarId(int id)
        {
            SqlConnection connection = new SqlConnection("Server=Guilherme\\SQLEXPRESS02;Database=Cliente;User ID = sa; Password=Gui156061;" +
    "Trusted_Connection=False; MultipleActiveResultSets=true");
            if (connection.State == ConnectionState.Closed)  //System.Data.ConnectionState.Closed
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand("dbo.SP_ClienteSelecionarId", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Id", id);
            SqlDataReader dr = cmd.ExecuteReader();

            Cliente cliente = new Cliente();

            while (dr.Read())
            {
                cliente.Id = int.Parse(dr["ID_Cliente"].ToString());
                cliente.Nome = dr["Nome"].ToString();
                cliente.Sexo = dr["Sexo"].ToString();
                cliente.DataNascimento = Convert.ToDateTime(dr["DataNascimento"].ToString());
                cliente.EstadoCivil = dr["EstadoCivil"].ToString();
                cliente.Cpf = dr["CPF"].ToString();
                cliente.Rg = dr["RG"].ToString();
            }

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }

            return cliente;
        }

        public static void AtualizarCliente(Cliente cliente)
        {
            SqlConnection connection = new SqlConnection("Server=Guilherme\\SQLEXPRESS02;Database=Cliente;User ID = sa; Password=Gui156061;" +
    "Trusted_Connection=False; MultipleActiveResultSets=true");
            if (connection.State == ConnectionState.Closed)  //System.Data.ConnectionState.Closed
            {
                connection.Open();
            }

            SqlCommand cmd = new SqlCommand("dbo.SP_ClienteAlterar", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ID_Cliente", cliente.Id);

            cmd.Parameters.AddWithValue("@nome", cliente.Nome);
            cmd.Parameters.AddWithValue("@sexo", cliente.Sexo);
            cmd.Parameters.AddWithValue("@dataNascimento", cliente.DataNascimento);
            cmd.Parameters.AddWithValue("@estadoCivil", cliente.EstadoCivil);
            cmd.Parameters.AddWithValue("@cpf", cliente.Cpf);
            cmd.Parameters.AddWithValue("@rg", cliente.Rg);
            cmd.ExecuteNonQuery();

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }

        }

        public static void ExcluirCliente(int id)
        {
            SqlConnection connection = new SqlConnection("Server=Guilherme\\SQLEXPRESS02;Database=Cliente;User ID = sa; Password=Gui156061;" +
    "Trusted_Connection=False; MultipleActiveResultSets=true");
            if (connection.State == ConnectionState.Closed)  //System.Data.ConnectionState.Closed
            {
                connection.Open();
            }

            SqlCommand cmd = new SqlCommand("dbo.SP_ClienteExcluir", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ID_Cliente", id);

            cmd.ExecuteNonQuery();

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }

        }

    }
}
