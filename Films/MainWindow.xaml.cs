using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using System.Reflection;
using Microsoft.Win32;
using System.Configuration;
using System.Data.Objects;

namespace Films
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //string selectConnection = ConfigurationManager.ConnectionStrings["MaConnection"].ConnectionString;
        string imagePath;
        FilmsDataContext db = new FilmsDataContext();
        public MainWindow()
        {
            InitializeComponent();
            

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            InitialiseListeFilms();
        }

        public void InitialiseListeFilms()
        {
            Film film1 = new Film("Gladiateur");
            Film film2 = new Film("Inception");
            Film film3 = new Film("Godfther 1");
            Film film4 = new Film("Harry Potter 3");

            List<Film> listeFilms = new List<Film>();
            listeFilms.Add(film1);
            listeFilms.Add(film2);
            listeFilms.Add(film3);
            listeFilms.Add(film4);

            foreach (Film film in listeFilms)
            {
                listBox1.Items.Add(film);
            }



            //dataGrid1.Items.Add = listeFilms;
            //dataGrid1.Columns.Add(
            //dataGrid1.ItemsSource = listeFilms;
        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            InitialiseListeFilmsDataGrid();
        }

        public void InitialiseListeFilmsDataGrid()
        {

            Film film1 = new Film("Gladiateur", 4.5, Genre.drame);
            Film film2 = new Film("Inception", 4, Genre.science_fiction);
            Film film3 = new Film("Godfther 1", 4.5, Genre.drame);
            Film film4 = new Film("Harry Potter 3", 3, Genre.fantastique);

            List<Film> listeFilms = new List<Film>();
            listeFilms.Add(film1);
            listeFilms.Add(film2);
            listeFilms.Add(film3);
            listeFilms.Add(film4);

            DataTable table = CreateDataTable<Film>(listeFilms);

            int a = 0;
           // string s= table.Rows[1].

            foreach (Film film in listeFilms)
            {

                dataGrid2.Items.Add(film);

            }
            // object test = dataGrid1.Items[1];


        }

        private void button2_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void button2_Click_2(object sender, RoutedEventArgs e)
        {
            InitialiseListeFilmsDataGrid();
        }


        public static DataTable CreateDataTable<T>(IEnumerable<T> list)
        {
            Type type = typeof(T);
            var properties = type.GetProperties();

            DataTable dataTable = new DataTable();
            foreach (PropertyInfo info in properties)
            {
                dataTable.Columns.Add(new DataColumn(info.Name, Nullable.GetUnderlyingType(info.PropertyType) ?? info.PropertyType));
            }

            foreach (T entity in list)
            {
                object[] values = new object[properties.Length];
                for (int i = 0; i < properties.Length; i++)
                {
                   // values[i] = properties[i].GetValue(entity);
                }

                dataTable.Rows.Add(values);
            }

            return dataTable;
        }

#region code supprimé
		

        //private void RequeteDataBaseFillDataGrid3(string selectCommandText)
        //{


        //    try
        //    {
        //        dataGrid3.AutoGenerateColumns = true;
        //        dataGrid3.CanUserAddRows = false;
        //        // Change the connection string
        //        // to match with your system.
        //        //string selectConnection =
        //           // @"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\OneDrive\Documents\memo\c sharp\Projects 2017\Films\Films\Database1.mdf;Integrated Security=True;User Instance=True";
                
        //        SqlDataAdapter dataAdapter =
        //        new SqlDataAdapter(
        //        selectCommandText, selectConnection);
        //        DataTable table = new DataTable();
        //        dataAdapter.Fill(table);
        //        dataGrid3.ItemsSource = table.DefaultView;

        //        dataGrid3.AutoGenerateColumns = true;
        //        dataGrid3.CanUserAddRows = false;

        //        //dataGrid3.ite
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        //private void button3_Click(object sender, RoutedEventArgs e)
        //{
            
            
        //    string titre = textBoxTitre.Text;
        //    string note = textBoxNote.Text;
        //    string genre = comboBoxGenre.Text; //comboBoxGenre.SelectedValue.ToString();
        //    string image = imagePath;
        //    string annee = textBoxAnnee.Text;

        //    if (titre != "" && note != "" && genre != "" && image != null)
        //    {
        //        string requete = @"INSERT INTO Films  VALUES('" + titre + "','" + genre + "','" + annee + "','" + image + "')";

        //        SelectData(requete);//(@"INSERT INTO Films  VALUES('zzz','zzsz','qsza','xsdqs')");
        //    }
        //    else MessageBox.Show("Mercir de remplir tous les champs");

        //    //ParlerAvecDataBase(@"INSERT INTO Films VALUES ('valeur 1', 'valeur 2', 'valeur3')");


        //    //System.Data.SqlClient.SqlConnection sqlConnection1 =
        //    //   new System.Data.SqlClient.SqlConnection(@"Data Source=E:\OneDrive\Documents\memo\c sharp\Projects 2017\Films\Films\Database1.sdf");

        //    //System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
        //    //cmd.CommandType = System.Data.CommandType.Text;
        //    //cmd.CommandText = "INSERT Region (RegionID, RegionDescription) VALUES (5, 'NorthWestern')";
        //    //cmd.Connection = sqlConnection1;

        //    //sqlConnection1.Open();
        //    //cmd.ExecuteNonQuery();
        //    //sqlConnection1.Close();

        //}
 
	#endregion

        private Film ajouterFilm()
        {
            Film film= new Film("zeb1");
            return film;
            //film = new Film(textBoxTitre.Text,int.Parse(textBoxNote),comboBoxGenre.SelectedItem
            //throw new NotImplementedException();
        }

        #region code supprmé acces base de donnée avec MySQL
		//private void SelectData(string selectCommandText)
        //{
        //    try
        //    {
        //        // Change the connection string
        //        // to match with your system.
                

        //        SqlDataAdapter dataAdapter =
        //        new SqlDataAdapter(
        //        selectCommandText, selectConnection);
        //        DataTable table = new DataTable();
        //        dataAdapter.Fill(table);

                
                
        //        //dataGridView1.DataSource = table;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}


        //private void button4_Click(object sender, RoutedEventArgs e)
        //{
        //    RequeteDataBaseFillDataGrid3("SELECT * FROM Films");

        //} 
	#endregion

        private void dataGrid3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //image1.Source.value = dataGrid3.SelectedCells[3].ToString();
            //image1.Source = 
/*
            Image myImage3 = new Image();
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri( Uri("smiley_stackpanel.PNG", UriKind.Relative);
            bi3.EndInit();
            image1.Stretch = Stretch.Fill;
            image1.Source = bi3;
 * */
            //bi3.ur

        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true) 
               imagePath= openFileDialog.FileName ;
               

        }

        

        private void textBoxNote_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void comboBoxGenre_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dataGrid3_AutoGeneratedColumns(object sender, EventArgs e)
        {

        }

        private void buttonLinq_Click(object sender, RoutedEventArgs e)
        {
            var filmsTable = from films in db.Films
                             select films;
            dataGrid3.ItemsSource = filmsTable;

            dataGrid3.AutoGenerateColumns = true;
            dataGrid3.CanUserAddRows = false;
            //dataGridFilmsComplete.data
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {

            string titre = textBoxTitre.Text;
            string note = textBoxNote.Text;
            string genre = comboBoxGenre.Text; //comboBoxGenre.SelectedValue.ToString();
            string image = imagePath;
            string annee = textBoxAnnee.Text;

            if (titre != "" && note != "" && genre != "" && image != null)
            {
                Films film = new Films();
                film.Titre = titre;
                film.Anee = annee;
                film.Genre = genre;
                film.Image = image;
                try
                {
                    
                    //db.Films.Attach(film);
                    db.Films.InsertOnSubmit(film);
                    db.SubmitChanges();
                }
                catch (Exception ex)
                {
                    
                    MessageBox.Show(ex.Message);
                }
            }

            else MessageBox.Show("Mercir de remplir tous les champs");
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            FilmsDataContext ctx = db;
            if (dataGrid3.SelectedIndex != -1)
            {
                var x = (from y in ctx.Films
                         where y.Titre == (string)dataGrid3.SelectedValue
                         select y).FirstOrDefault();
                
                    ctx.Films.DeleteOnSubmit(x);

            }
        }

    }
}

