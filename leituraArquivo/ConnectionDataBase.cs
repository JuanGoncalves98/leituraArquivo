using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace leituraArquivo
{
    internal class ConnectionDataBase
    {

        SqlConnection conexao;
        public ConnectionDataBase()
        {
            conexao = new SqlConnection();
            conexao.ConnectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=Palavras;Integrated Security=True";
        }

        public SqlConnection Conectar()
        {
            if (conexao.State == System.Data.ConnectionState.Closed)
                conexao.Open();

            return conexao;
        }
        public void Fechar()
        {
            if (conexao.State == System.Data.ConnectionState.Open)
                conexao.Close();
        }
    }
}
