using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace hotelTesting
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string strConexao = $@"Data Source={Application.StartupPath}\cnxSQLite.db;";

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                CriarBancoDeDados();
                using (SQLiteConnection conexao = new SQLiteConnection(strConexao))
                {
                    if (conexao.State == ConnectionState.Closed)
                    {
                        conexao.Open();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao conectar: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void CriarBancoDeDados()
        {

            string caminhoBanco = Application.StartupPath + @"\cnxSQLite.db";
            MessageBox.Show($"Caminho do banco de dados: {caminhoBanco}", "Caminho do Banco de Dados");

            SQLiteConnection.CreateFile(caminhoBanco);

            if (!File.Exists(caminhoBanco))
            {
                Console.WriteLine("entrou no criar banco");
                SQLiteConnection.CreateFile(caminhoBanco);

                using (SQLiteConnection conexao = new SQLiteConnection(strConexao))
                {
                    conexao.Open();

                    string query = @"
                    CREATE TABLE IF NOT EXISTS Hotels (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Nome TEXT NOT NULL,
                        Preco REAL NOT NULL,
                        Disponivel BOOLEAN NOT NULL,
                          
                    );";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conexao))
                    {
                        cmd.ExecuteNonQuery();
                    }
                   Hotel hotel = new Hotel();

                }
            }
        }
    }
}