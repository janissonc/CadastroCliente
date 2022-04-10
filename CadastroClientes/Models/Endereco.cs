using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace CadastroClientes.Models
{
    public class Endereco
    {
        public int Id { get; set; }
        public int Id_Cliente { get; set; }
        public int Id_Tipo { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Cep { get; set; }

        public Endereco(int id, int id_Cliente, int id_Tipo, string logradouro, string numero, string complemento, string cidade, string uf, string cep)
        {
            Id = id;
            Id_Cliente = id_Cliente;
            Id_Tipo = id_Tipo;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Cidade = cidade;
            Uf = uf;
            Cep = cep;
        }

        public Endereco()
        {

        }
        public static void InserirEndereco(Endereco endereco)
        {
            SqlConnection connection = new SqlConnection("Server=DESKTOP-SM0KMME\\SQLEXPRESS;Database=Cliente;User ID = sa; Password=janisson123; Trusted_Connection=False; MultipleActiveResultSets=true");
            if (connection.State == ConnectionState.Closed)  //System.Data.ConnectionState.Closed
            {
                connection.Open();
            }

            SqlCommand cmd = new SqlCommand("dbo.SP_EnderecoInserir", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@idCliente", endereco.Id_Cliente);
            cmd.Parameters.AddWithValue("@idTipo", endereco.Id_Tipo);
            cmd.Parameters.AddWithValue("@logradouro", endereco.Logradouro);
            cmd.Parameters.AddWithValue("@numero", endereco.Numero);
            cmd.Parameters.AddWithValue("@complemento", endereco.Complemento);
            cmd.Parameters.AddWithValue("@cidade", endereco.Cidade);
            cmd.Parameters.AddWithValue("@uf", endereco.Uf);
            cmd.Parameters.AddWithValue("@cep", endereco.Cep);
            cmd.ExecuteNonQuery();
           

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
        public static List<Endereco> Selecionar()
        {
            SqlConnection connection = new SqlConnection("Server=DESKTOP-SM0KMME\\SQLEXPRESS;Database=Cliente;User ID = sa; Password=janisson123; Trusted_Connection=False; MultipleActiveResultSets=true");
            if (connection.State == ConnectionState.Closed)  //System.Data.ConnectionState.Closed
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand("dbo.SP_EnderecoSelecionar", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            List<Endereco> lista = new List<Endereco>();
            while (dr.Read())
            {
                Endereco endereco = new Endereco();

                endereco.Id_Cliente = int.Parse(dr["ID_Cliente"].ToString());
                endereco.Id_Tipo = int.Parse(dr["ID_Tipo"].ToString());
                endereco.Logradouro = dr["Logradouro"].ToString();
                endereco.Numero = dr["Numero"].ToString();
                endereco.Complemento = dr["Complemento"].ToString();
                endereco.Cidade = dr["Cidade"].ToString();
                endereco.Uf = dr["Uf"].ToString();
                endereco.Cep = dr["Cep"].ToString();

                lista.Add(endereco);
            }

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
            return lista;
        }

        public static Endereco SelecionarId(int id)
        {
            SqlConnection connection = new SqlConnection("Server=DESKTOP-SM0KMME\\SQLEXPRESS;Database=Cliente;User ID = sa; Password=janisson123; Trusted_Connection=False; MultipleActiveResultSets=true");
            if (connection.State == ConnectionState.Closed)  //System.Data.ConnectionState.Closed
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand("dbo.SP_EnderecoSelecionarId", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
            SqlDataReader dr = cmd.ExecuteReader();

            Endereco endereco = new Endereco();

            while (dr.Read())
            {
                endereco.Id_Cliente = int.Parse(dr["ID_Cliente"].ToString());
                endereco.Id_Tipo = int.Parse(dr["ID_Tipo"].ToString());
                endereco.Logradouro = dr["Logradouro"].ToString();
                endereco.Numero = dr["Numero"].ToString();
                endereco.Complemento = dr["Complemento"].ToString();
                endereco.Cidade = dr["Cidade"].ToString();
                endereco.Uf = dr["Uf"].ToString();
                endereco.Cep = dr["Cep"].ToString();

            }

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }

            return endereco;
        }

        public static void AtualizarEndereco(Endereco endereco)
        {
            SqlConnection connection = new SqlConnection("Server=DESKTOP-SM0KMME\\SQLEXPRESS;Database=Cliente;User ID = sa; Password=janisson123; Trusted_Connection=False; MultipleActiveResultSets=true");
            if (connection.State == ConnectionState.Closed)  //System.Data.ConnectionState.Closed
            {
                connection.Open();
            }

            SqlCommand cmd = new SqlCommand("dbo.SP_EnderecoAlterar", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ID_Endereco", endereco.Id);

            cmd.Parameters.AddWithValue("@idCliente", endereco.Id_Cliente);
            cmd.Parameters.AddWithValue("@idTipo", endereco.Id_Tipo);
            cmd.Parameters.AddWithValue("@logradouro", endereco.Logradouro);
            cmd.Parameters.AddWithValue("@numero", endereco.Numero);
            cmd.Parameters.AddWithValue("@complemento", endereco.Complemento);
            cmd.Parameters.AddWithValue("@cidade", endereco.Cidade);
            cmd.Parameters.AddWithValue("@uf", endereco.Uf);
            cmd.Parameters.AddWithValue("@cep", endereco.Cep);
            cmd.ExecuteNonQuery();

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
        public static void ExcluirEndereco(int id)
        {
            SqlConnection connection = new SqlConnection("Server=DESKTOP-SM0KMME\\SQLEXPRESS;Database=Cliente;User ID = sa; Password=janisson123; Trusted_Connection=False; MultipleActiveResultSets=true");
            if (connection.State == ConnectionState.Closed)  //System.Data.ConnectionState.Closed
            {
                connection.Open();
            }

            SqlCommand cmd = new SqlCommand("dbo.SP_EnderecoExcluir", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ID_Endereco", id);

            cmd.ExecuteNonQuery();

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }

        }
    }
}
