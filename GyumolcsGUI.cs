using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace GyumolcsokGUI
{
    public partial class GyumolcsGUI : Form
    {
        MySqlConnection connection = null;
        MySqlCommand command = null;
        public GyumolcsGUI()
        {
            InitializeComponent();
        }

        private void GyumolcsGUI_Load(object sender, EventArgs e)
        {

            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Password = "";
            builder.Database = "gyumolcsok";
            connection = new MySqlConnection(builder.ConnectionString);
            try
            {
                // terv szerint
                connection.Open();
                command = connection.CreateCommand();

            }
            catch (MySqlException ex)
            {
                // hiba esetén
                MessageBox.Show(ex.Message + Environment.NewLine + "A program leáll!", "Program hiba!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Environment.Exit(0);

            }
            finally
            {
                // terv szerint és hiba esetén is 
                connection.Close();

            }
            Gyumolcsok_ListBox_Update();

        }

        /*
         * Gyumolcsok_ListBox_Update()
         
         * Gyumolcsok Listbox frissítése adatbázisból!
         */

        private void Gyumolcsok_ListBox_Update()
        {

            Gyumolcsok.Items.Clear();
            command.CommandText = "SELECT `id`, `nev`, `egysegar`, `mennyiseg` FROM `gyumolcs` WHERE 1;";
            connection.Open();
            using (MySqlDataReader dr = command.ExecuteReader())
            {
                while (dr.Read()) 
                {

                GyumolcsAdat uj = new GyumolcsAdat(dr.GetInt32("id"), dr.GetString("nev"), dr.GetDouble("egysegar"), dr.GetDouble("mennyiseg"));
                Gyumolcsok.Items.Add(uj);

                }

            }
            connection.Close();

        }

        private void UjGyumolcs_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(NevText.Text))
            {

                MessageBox.Show("Adjon meg egy Gyümölcs Nevet!", "Hiányzó adat!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                NevText.Focus();
                return;

            }
            if (string.IsNullOrEmpty(EgysegArText.Text))
            {

                MessageBox.Show("Adjon meg egy Egység Árat!", "Hiányzó adat!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                EgysegArText.Focus();
                return;

            }
            if (string.IsNullOrEmpty(MennyisegText.Text))
            {

                MessageBox.Show("Adjon meg egy Mennyiséget!", "Hiányzó adat!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MennyisegText.Focus();
                return;

            }
            //-- Kiírjuk Adatbázisba ----
            command.CommandText = "INSERT INTO `gyumolcs` (`id`, `nev`, `egysegar`, `mennyiseg`) VALUES (NULL, @nev, @egysegar, @mennyiseg)";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@nev", NevText.Text);
            command.Parameters.AddWithValue("@egysegar", EgysegArText.Text);
            command.Parameters.AddWithValue("@mennyiseg", MennyisegText.Text);
            connection.Open();
            try
            {

                if (command.ExecuteNonQuery() == 1)
                {

                    MessageBox.Show("Sikeresen rögzítve", "Sikeres!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    IdText.Text = "";
                    NevText.Text = "";
                    EgysegArText.Text = "";
                    MennyisegText.Text = "";

                }
                else
                {

                    MessageBox.Show("Sikertelen rögzítés!", "Sikertelen!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }

            }
            catch (MySqlException ex)
            {

                MessageBox.Show(ex.Message, "Sikertelen!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            connection.Close();
            Gyumolcsok_ListBox_Update();

        }
    }
}
