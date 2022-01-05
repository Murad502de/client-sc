using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class RegisterForm : Form
    {
        private Point lastpoint;
        public RegisterForm()
        {
            InitializeComponent();

            this.userNameField.Text      = "Имя";
            this.userNameField.ForeColor = Color.Gray;

            this.loginField.Text      = "Логин";
            this.loginField.ForeColor = Color.Gray;

            this.passField.Text      = "Пароль";
            this.passField.ForeColor = Color.Gray;
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
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - this.lastpoint.X;
                this.Top += e.Y - this.lastpoint.Y;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            this.lastpoint = new Point(e.X, e.Y);
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            this.panel1_MouseMove(sender, e);
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            this.panel1_MouseDown(sender, e);
        }

        private void userNameField_Enter(object sender, EventArgs e)
        {
            if (this.userNameField.Text == "Имя")
            {
                this.userNameField.Text = "";
                this.userNameField.ForeColor = Color.Black;
            }
        }

        private void userNameField_Leave(object sender, EventArgs e)
        {
            if (this.userNameField.Text == "")
            {
                this.userNameField.Text = "Имя";
                this.userNameField.ForeColor = Color.Gray;
            }
        }

        private void loginField_Enter(object sender, EventArgs e)
        {
            if (this.loginField.Text == "Логин")
            {
                this.loginField.Text      = "";
                this.loginField.ForeColor = Color.Black;
            }
        }

        private void loginField_Leave(object sender, EventArgs e)
        {
            if (this.loginField.Text == "")
            {
                this.loginField.Text      = "Логин";
                this.loginField.ForeColor = Color.Gray;
            }
        }

        private void passField_Enter(object sender, EventArgs e)
        {
            if (this.passField.Text == "Пароль")
            {
                this.passField.Text      = "";
                this.passField.ForeColor = Color.Black;
            }
        }

        private void passField_Leave(object sender, EventArgs e)
        {
            if (this.passField.Text == "")
            {
                this.passField.Text      = "Пароль";
                this.passField.ForeColor = Color.Gray;
            }
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            if (
                ( this.userNameField.Text == "Имя" )
                  ||
                ( this.loginField.Text == "Логин" )
                  ||
                ( this.passField.Text == "Пароль" )
            )
            {
                MessageBox.Show( "Поля заполнены некорректно" );

                return;
            }

            if ( this.isUserExist() )
            {
                MessageBox.Show( "Пользователь с таким логином уже существует" );

                return;
            }

            DB db = new DB( "localhost", 3306, "scharp_db", "root", "root" );

            MySqlCommand command = new MySqlCommand( "INSERT INTO `users` (`login`, `pass`, `name`) VALUES (@login, @pass, @name);", db.getConnection() );

            command.Parameters.Add( "@login", MySqlDbType.VarChar ).Value = this.loginField.Text;
            command.Parameters.Add( "@pass", MySqlDbType.VarChar ).Value  = this.passField.Text;
            command.Parameters.Add( "@name", MySqlDbType.VarChar ).Value  = this.userNameField.Text;

            db.openConnection();

            if ( command.ExecuteNonQuery() == 1 )
            {
                MessageBox.Show( "Пользователь успешно добавлен" );

                this.toAuthLabel_Click( sender, e );
            }
            else
            {
                MessageBox.Show( "Произошла ошибка при добавлении пользователя" );
            }

            db.closeConnection();
        }

        private Boolean isUserExist ()
        {
            DB db = new DB( "localhost", 3306, "scharp_db", "root", "root" );
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand( "SELECT * FROM `users` WHERE `login` = @uL", db.getConnection() );

            command.Parameters.Add( "@uL", MySqlDbType.VarChar ).Value = this.loginField.Text;

            adapter.SelectCommand = command;
            adapter.Fill( table );

            if ( table.Rows.Count > 0 ) return true;

            return false;
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }

        private void toAuthLabel_Click(object sender, EventArgs e)
        {
            this.Hide();

            LoginForm loginForm = new LoginForm();

            loginForm.Show();
        }

        private void toAuthLabel_MouseHover(object sender, EventArgs e)
        {

        }

        private void toAuthLabel_MouseLeave(object sender, EventArgs e)
        {

        }
    }
}
