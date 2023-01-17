using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace leituraArquivo
{
    internal class Controller
    {
        ConnectionDataBase conexao;
        SqlCommand comandoSQL;
        SqlDataAdapter adapter;
        DataSet dataSet;

        public Controller()
        {
            conexao = new ConnectionDataBase();
            adapter = new SqlDataAdapter();
            dataSet = new DataSet();
            comandoSQL = new SqlCommand();
            comandoSQL.Connection = conexao.Conectar();
        }

        public DataSet carregarDadosArquivo(String path)
        {
            inserirPalavras(lerArquivo(path));
            return consultarContagemDePalavras();
        }

        private String[] lerArquivo(String path)
        {
            return File.ReadAllLines(path);
        }

        private DataSet consultarContagemDePalavras()
        {
            comandoSQL.CommandText = "SELECT PALAVRA AS Palavra, COUNT(*) AS Incidência"
                                   + "  FROM PALAVRASLIDAS"
                                   + " GROUP BY PALAVRA"
                                   + " ORDER BY COUNT(*) DESC";

            adapter.SelectCommand = comandoSQL;
            adapter.Fill(dataSet);

            return dataSet;
        }

        private void inserirPalavras(String[] palavras)
        {
            try
            {
                foreach (String palavra in palavras)
                {
                    comandoSQL.CommandText = "INSERT INTO PALAVRASLIDAS (PALAVRA) VALUES ('" + palavra + "')";
                    comandoSQL.ExecuteNonQuery();
                }
            }
            catch
            {
            }
         }
    }
}
