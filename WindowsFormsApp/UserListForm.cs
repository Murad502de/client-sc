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
    public partial class UserListForm : Form
    {
        private Point lastpoint;
        private string userName;
        public UserListForm( string userName)
        {
            InitializeComponent();

            this.userName = userName;

            this.loadUserListTable();
        }

        private void loadUserListTable ()
        {
            DataGridViewTextBoxColumn id = new DataGridViewTextBoxColumn();
            id.HeaderText = "ID";

            DataGridViewTextBoxColumn name = new DataGridViewTextBoxColumn();
            name.HeaderText = "Name";

            DataGridViewCheckBoxColumn delete = new DataGridViewCheckBoxColumn();
            delete.HeaderText = "Delete";

            this.userListTable.Columns.Add( id );
            this.userListTable.Columns.Add( name );
            this.userListTable.Columns.Add( delete );

            DataTable table = this.getUserList();

            if (table.Rows.Count > 0)
            {
                Debug.WriteLine("es gibt Users");

                foreach (DataRow row in table.Rows)
                {
                    this.userListTable.Rows.Add( row[ "id" ], row[ "name" ], false );
                }
            }
            else
            {
                Debug.WriteLine("es gibt keine Users");
            }

            this.userListTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.userListTable.AllowUserToAddRows = false;
        }

        private DataTable getUserList ()
        {
            DB db = new DB( "localhost", 3306, "scharp_db", "root", "root" );
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand( "SELECT * FROM `users`", db.getConnection() );

            adapter.SelectCommand = command;
            adapter.Fill( table );

            return table;
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            List<int> rowsToRemoveId                = new List<int>();
            List<DataGridViewRow> rowsToRemoveItem  = new List<DataGridViewRow>();

            for ( int i = 0; i < this.userListTable.Rows.Count; i++ )
            {
                bool delete = ( bool ) this.userListTable.Rows[ i ].Cells[ 2 ].Value;

                if ( delete )
                {
                    string id = this.userListTable.Rows[ i ].Cells[ 0 ].Value.ToString();

                    rowsToRemoveId.Add( Convert.ToInt32( id ) );
                    rowsToRemoveItem.Add( this.userListTable.Rows[ i ] );
                }
            }

            if ( rowsToRemoveId.Count > 0 )
            {
                this.deleteUserById( rowsToRemoveId, rowsToRemoveItem );
            }
        }
        private void deleteUserById ( List<int> usersId, List<DataGridViewRow> rowsToRemoveItem )
        {
            DB db = new DB( "localhost", 3306, "scharp_db", "root", "root" );

            db.openConnection();

            for ( int i = 0; i < usersId.Count; i++ )
            {
                MySqlCommand command = new MySqlCommand( "DELETE FROM `users` WHERE `users`.`id` = @id", db.getConnection() );

                command.Parameters.Add( "@id", MySqlDbType.VarChar).Value = usersId[ i ];

                if ( !( command.ExecuteNonQuery() == 1 ) )
                {
                    MessageBox.Show( "Произошла ошибка при удалении пользователя: " + usersId[ i ] );
                }
                else
                {
                    this.userListTable.Rows.Remove( rowsToRemoveItem[ i ] );
                }
            }

            db.closeConnection();
        }

        private void goBackBtn_Click(object sender, EventArgs e)
        {
            this.Hide();

            MainMenuForm mainMenu = new MainMenuForm( this.userName );

            mainMenu.Show();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void closeBtn_MouseHover(object sender, EventArgs e)
        {
            this.closeBtn.ForeColor = System.Drawing.Color.FromArgb(230, 125, 34);
        }

        private void closeBtn_MouseLeave(object sender, EventArgs e)
        {
            this.closeBtn.ForeColor = System.Drawing.Color.FromArgb(239, 239, 239);
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
    }
}
