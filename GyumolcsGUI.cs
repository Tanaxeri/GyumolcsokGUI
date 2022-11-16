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

            if (nincsenadat())
            {

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
        private bool nincsenadat()
        {

            //-- Szükséges adatok ellenőrzése
            if (string.IsNullOrEmpty(NevText.Text))
            {

                MessageBox.Show("Adjon meg egy Gyümölcs Nevet!", "Hiányzó adat!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                NevText.Focus();
                return true;

            }
            if (string.IsNullOrEmpty(EgysegArText.Text))
            {

                MessageBox.Show("Adjon meg egy Egység Árat!", "Hiányzó adat!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                EgysegArText.Focus();
                return true;

            }
            if (string.IsNullOrEmpty(MennyisegText.Text))
            {

                MessageBox.Show("Adjon meg egy Mennyiséget!", "Hiányzó adat!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MennyisegText.Focus();
                return true;

            }
            return false;

        }

        private void Modositbutton_Click(object sender, EventArgs e)
        {

            if (Gyumolcsok.SelectedIndex < 0)
            {

                MessageBox.Show("Nincsen kijelölve gyümölcs!", "Hiányzó jelölés!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }
            GyumolcsAdat kivalasztottgyumolcs = (GyumolcsAdat)Gyumolcsok.SelectedItem;
            command.CommandText = "UPDATE `gyumolcs` SET `nev` = @nev, `egysegar` = @egysegar, `mennyiseg`= @mennyiseg WHERE `id` = @id";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@id", IdText.Text.ToString());
            command.Parameters.AddWithValue("@nev", NevText.Text);
            command.Parameters.AddWithValue("@egysegar", EgysegArText.Text);
            command.Parameters.AddWithValue("@mennyiseg", MennyisegText.Text);
            connection.Open();
            if (command.ExecuteNonQuery() == 1)
            {

                MessageBox.Show("Módosítás sikeres volt!", "Sikeres!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                connection.Close();
                IdText.Text = "";
                NevText.Text = "";
                EgysegArText.Text = "";
                MennyisegText.Text = "";
                Gyumolcsok_ListBox_Update();

            }
            else
            {

                MessageBox.Show("Az adatok módosítása sikertelen volt!", "Sikertelen!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            if (connection.State == ConnectionState.Open)
            {

                connection.Close();

            }

        }

        private void Torolbutton_Click(object sender, EventArgs e)
        {

            if (Gyumolcsok.SelectedIndex < 0)
            {

                return;

            }
            command.CommandText = "DELETE FROM `gyumolcs` WHERE `id` = @id;";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@id", IdText.Text);
            connection.Open();
            if (command.ExecuteNonQuery() == 1)
            {

                MessageBox.Show("Törlés sikeres volt!", "Sikeres!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                connection.Close();
                IdText.Text = "";
                NevText.Text = "";
                EgysegArText.Text = "";
                MennyisegText.Text = "";
                Gyumolcsok_ListBox_Update();

            }
            else
            {

                MessageBox.Show("Az adatok törlése sikertelen volt!", "Sikertelen!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            if (connection.State == ConnectionState.Open)
            {

                connection.Close();

            }


        }

        private void Gyumolcsok_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (Gyumolcsok.SelectedIndex < 0)
            {

                return;

            };
            // --A felhasználó kijelöl egy elemet a listában.
            GyumolcsAdat kivalasztottgyumolcs = (GyumolcsAdat)Gyumolcsok.SelectedItem;
            IdText.Text = kivalasztottgyumolcs.Id.ToString();
            NevText.Text = kivalasztottgyumolcs.Nev;
            EgysegArText.Text = kivalasztottgyumolcs.Egysegar.ToString();
            MennyisegText.Text = kivalasztottgyumolcs.Mennyiseg.ToString();


        }
    }
}
