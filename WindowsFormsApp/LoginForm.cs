using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class LoginForm : Form
    {
        private Point lastpoint;
        public LoginForm()
        {
            InitializeComponent();

            this.passField.AutoSize = false;
            this.passField.Size     = new Size( this.passField.Size.Width, 50 );
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void closeBtn_MouseHover(object sender, EventArgs e)
        {
            this.closeBtn.ForeColor = System.Drawing.Color.FromArgb( 230, 125, 34 );
        }

        private void closeBtn_MouseLeave(object sender, EventArgs e)
        {
            this.closeBtn.ForeColor = System.Drawing.Color.FromArgb( 239, 239, 239 );
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if ( e.Button == MouseButtons.Left )
            {
                this.Left += e.X - this.lastpoint.X;
                this.Top  += e.Y - this.lastpoint.Y;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            this.lastpoint = new Point( e.X, e.Y );
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            this.panel1_MouseMove( sender, e );
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            this.panel1_MouseDown( sender, e );
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            String loginUser = this.loginField.Text;
            String passUser  = this.passField.Text;

            DB db                    = new DB( "localhost", 3306, "scharp_db", "root", "root");
            DataTable table          = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand( "SELECT * FROM `users` WHERE `login` = @uL AND `pass` = @uP", db.getConnection() );
            
            command.Parameters.Add( "@uL", MySqlDbType.VarChar ).Value = loginUser;
            command.Parameters.Add( "@uP", MySqlDbType.VarChar ).Value = passUser;

            adapter.SelectCommand = command;
            adapter.Fill( table );

            if ( table.Rows.Count > 0 )
            {
                string userName = ( string ) table.Rows[ 0 ][ "name" ];
                this.Hide();

                MainMenuForm mainMenu = new MainMenuForm( userName );

                mainMenu.Show();
            }
            else
            {
                MessageBox.Show( "Ошибка авторизации" );
            }
        }

        private void passField_TextChanged(object sender, EventArgs e)
        {

        }

        private void loginField_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void addUserBtn_Click(object sender, EventArgs e)
        {
            this.Hide();

            RegisterForm Register = new RegisterForm();

            Register.Show();
        }
    }
}
