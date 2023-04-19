using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfAppContato
{
    /// <summary>
    /// Lógica interna para CadastrarFilme.xaml
    /// </summary>
    public partial class CadastrarFilme : Window
    {
        private MySqlConnection conexao;

        private MySqlCommand comando;
        public CadastrarFilme()
        {
            InitializeComponent();
            Conexao();
            txtNome.Focus();
        }
        private void Conexao()
        {
            string conexaoString = "server=localhost;database=app_filme_bd;user=root;password=root;port=3360";
            conexao = new MySqlConnection(conexaoString);
            comando = conexao.CreateCommand();

            conexao.Open();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool _rdProdutora1 = (bool)rdProdutora1.IsChecked;
                bool _rdProdutora2 = (bool)rdProdutora2.IsChecked;
                bool _rdProdutora3 = (bool)rdProdutora3.IsChecked;
                bool _rdProdutora4 = (bool)rdProdutora4.IsChecked;
                bool _rdProdutora5 = (bool)rdProdutora5.IsChecked;              

                if (!(bool)rdProdutora1.IsChecked && !(bool)rdProdutora2.IsChecked && !(bool)rdProdutora3.IsChecked && !(bool)rdProdutora4.IsChecked && !(bool)rdProdutora5.IsChecked)
                {
                    MessageBox.Show("Marque uma opção");
                }
                else
                {
                    var nome = txtNome.Text;
                    var genero = txtgenero;
                    var produtora = "Ação e Aventura";
                  
                    if (!(bool)rdProdutora2.IsChecked)
                    {
                        produtora = "Drama";
                    }

                    if (!(bool)rdProdutora3.IsChecked)
                    {
                        produtora = "Comédia Romântica";
                    }

                    if (!(bool)rdProdutora4.IsChecked)
                    {
                        produtora = "Ficcão Científica";
                    }

                    if (!(bool)rdProdutora5.IsChecked)
                    {
                        produtora = "Terror";
                    }


                    string query = "INSERT INTO Filme (nome_fil, genero_fil, produtora_fil) VALUES (@_nome,@_genero, @_produtora)";
                    var comando = new MySqlCommand(query, conexao);

                    comando.Parameters.AddWithValue("@_nome", nome);
                    comando.Parameters.AddWithValue("@_genero",genero);
                    comando.Parameters.AddWithValue("@_produtora",produtora);
                    
                    comando.ExecuteNonQuery();

                    txtNome.Clear();
                    rdGroupProdutora.Focus();
                    rdProdutora1.IsChecked = false;
                    rdProdutora2.IsChecked = false;
                    rdProdutora3.IsChecked = false;
                    rdProdutora4.IsChecked = false;
                    rdProdutora5.IsChecked = false;
                    txtgenero.Clear();
                    txtNome.Focus();

                    var opcao = MessageBox.Show("Salvo com sucesso!\n" +
                        "Deseja realizar um novo cadastro?", "Informação",
                        MessageBoxButton.YesNo, MessageBoxImage.Question);


                    if (opcao == MessageBoxResult.Yes)
                    {
                        LimparInputs();
                    }
                    else
                    {
                        this.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show($"Ocorreram erros ao tentar salvar os dados! " +
                // $"Contate o suporte do sistema. (CAD 25)");

                MessageBox.Show(ex.Message);
            }

        }



        private void LimparInputs()
        {

        }

        private void rdProdutora3_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            txtNome.Clear();
            txtgenero.Clear();
            rdGroupProdutora.Focus();
        }
    }
}   
    
    

