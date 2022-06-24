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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace LAX_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadGrid();
        }

        SqlConnection con = new SqlConnection("Data Source = 10.0.4.116,1433; Initial Catalog = LAX_Opgave; User ID = subarna; Password=DryOrc5166; Encrypt=False");

        //SqlConnection con = new SqlConnection("Data Source=192.168.192.129,49170;Initial Catalog=Film;User ID=subarna;Password=ZeroTwo5166;Encrypt=False");

        public void LoadGrid()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Categories", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            datagrid.ItemsSource = dt.DefaultView;
           
        }


        public void ClearData()
        {
            id_txt.Clear();
            film_txt.Clear();
            instruktør_txt.Clear();
            årstal_txt.Clear();
            detaljer_txt.Clear();

        }
        private void clear_btn_Click(object sender, RoutedEventArgs e)
        {
            ClearData();
  
        }

        public bool isValid()
        {
            if(film_txt.Text == string.Empty)
            {
                MessageBox.Show("Indtast Film Titel","Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (instruktør_txt.Text == string.Empty)
            {
                MessageBox.Show("Indtast Instruktør","Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (årstal_txt.Text == string.Empty)
            {
                MessageBox.Show("Indtast Årstal","Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (detaljer_txt.Text == string.Empty)
            {
                MessageBox.Show("Indtast Detaljer", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }
        private void opret_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (isValid())
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Categories VALUES (@Film_Titel, @Instruktør, @Årstal, @Detaljer)", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Film_Titel", film_txt.Text);
                    cmd.Parameters.AddWithValue("@Instruktør", instruktør_txt.Text);
                    cmd.Parameters.AddWithValue("@Årstal", årstal_txt.Text);
                    cmd.Parameters.AddWithValue("@Detaljer", detaljer_txt.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    LoadGrid();

                    MessageBox.Show("Film data oprettet", "Gemt", MessageBoxButton.OK, MessageBoxImage.Information);
                    ClearData();

                }

            }
            catch (SqlException)
            {

                MessageBox.Show("Venligst indtast kun nummer i Årstal", "Fejl", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void slet_btn_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Categories WHERE Id = " + id_txt.Text + " ", con);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Film data slettet", "Slettet", MessageBoxButton.OK, MessageBoxImage.Information);
                con.Close();
                ClearData();
                LoadGrid();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Film data bliver ikke slettet.");
            }
            finally
            {
                con.Close();
            }
        }

        private void rediger_btn_Click(object sender, RoutedEventArgs e)
        {
            
         
            SqlCommand cmd = new SqlCommand("UPDATE Categories set Film_Titel = '" + film_txt.Text + "',Instruktør = '" + instruktør_txt.Text + "', Årstal = '" + årstal_txt.Text + "', Detaljer = '" + detaljer_txt.Text + "' WHERE Id = '" + id_txt.Text + "' ", con);
                
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Film data er opdateret", "Opdateret", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
                ClearData();
                LoadGrid();

            }
           






        }


     
    }
}
