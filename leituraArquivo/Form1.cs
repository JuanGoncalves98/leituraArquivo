using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace leituraArquivo
{
    public partial class Form1 : Form
    {
        Controller controle;
        DataSet dataSet;

        public Form1()
        {
            InitializeComponent();
            controle = new Controller();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            carregarDataSet();
        }

        private void carregarDataSet()
        {
            dataSet = controle.carregarDadosArquivo(textBox1.Text);
            dataGridView1.DataMember = dataSet.Tables[0].TableName;
            dataGridView1.DataSource = dataSet;
        }
    }
}