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
    public partial class LiteratureSearchForm : Form
    {
        private Point lastpoint;
        private string userName;
        public LiteratureSearchForm( string userName )
        {
            InitializeComponent();

            this.userName = userName;

            DataGridViewTextBoxColumn id = new DataGridViewTextBoxColumn();
            id.HeaderText = "ID";

            DataGridViewTextBoxColumn name = new DataGridViewTextBoxColumn();
            name.HeaderText = "Название";

            DataGridViewTextBoxColumn autor = new DataGridViewTextBoxColumn();
            autor.HeaderText = "Автор";

            DataGridViewTextBoxColumn year = new DataGridViewTextBoxColumn();
            year.HeaderText = "Год издания";

            DataGridViewTextBoxColumn file = new DataGridViewTextBoxColumn();
            file.HeaderText = "Файл";

            DataGridViewCheckBoxColumn run = new DataGridViewCheckBoxColumn();
            run.HeaderText = " ";

            this.literatureTable.Columns.Add( id );
            this.literatureTable.Columns.Add( name );
            this.literatureTable.Columns.Add( autor );
            this.literatureTable.Columns.Add( year );
            this.literatureTable.Columns.Add( file );
            this.literatureTable.Columns.Add( run );

            this.loadTable();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loadTable ()
        {
            String  query                       = "SELECT * FROM `literature`";
            String  queryPart                   = " WHERE ";
            Boolean isFilterNotEmpty            = false;
            Boolean isAuthorSurnameNotEmpty     = false;
            Boolean isFirstWordOfNameNotEmpty   = false;
            Boolean isYearOfPublishingNotEmpty  = false;

            if ( this.authorSurname.Text != "" )
            {
                isFilterNotEmpty        = true;
                isAuthorSurnameNotEmpty = true;

                queryPart += "`surname_autor` = @authorSurname ";
            }

            if ( this.firstWordOfName.Text != "" )
            {
                isFilterNotEmpty            = true;
                isFirstWordOfNameNotEmpty   = true;

                queryPart += isAuthorSurnameNotEmpty ? "AND `first_word_name` = @firstWordOfName " : "`first_word_name` = @firstWordOfName ";
            }

            if ( this.yearOfPublishing.Text != "" )
            {
                isFilterNotEmpty            = true;
                isYearOfPublishingNotEmpty  = true;

                queryPart += isAuthorSurnameNotEmpty || isFirstWordOfNameNotEmpty ? "AND `year` = @yearOfPublishing" : "`year` = @yearOfPublishing";
            }

            if ( isFilterNotEmpty)
            {
                query += queryPart;
            }

            Debug.WriteLine( query );

            DB db = new DB("localhost", 3306, "scharp_db", "root", "root");
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand(query, db.getConnection());

            if ( isAuthorSurnameNotEmpty )
            {
                command.Parameters.Add("@authorSurname", MySqlDbType.VarChar ).Value = this.authorSurname.Text;
            }

            if ( isFirstWordOfNameNotEmpty )
            {
                command.Parameters.Add("@firstWordOfName", MySqlDbType.VarChar).Value = this.firstWordOfName.Text;
            }

            if ( isYearOfPublishingNotEmpty )
            {
                command.Parameters.Add("@yearOfPublishing", MySqlDbType.VarChar ).Value = Convert.ToInt32( this.yearOfPublishing.Text );
            }

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                Debug.WriteLine("es gibt Users");

                this.literatureTable.Rows.Clear();

                foreach (DataRow row in table.Rows)
                {
                    this.literatureTable.Rows.Add( row["id"], row["name"], row["autor"], row["year"], row["path"], false );
                }
            }
            else
            {
                this.literatureTable.Rows.Clear();

                Debug.WriteLine("es gibt keine Users");
            }

            this.literatureTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.literatureTable.AllowUserToAddRows = false;
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            this.loadTable();
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            this.authorSurname.Text    = "";
            this.firstWordOfName.Text  = "";
            this.yearOfPublishing.Text = "";

            this.loadTable();
        }

        private void openBtn_Click(object sender, EventArgs e)
        {
            for ( int i = 0; i < this.literatureTable.Rows.Count; i++ )
            {
                bool toExec = ( bool ) this.literatureTable.Rows[ i ].Cells[ 5 ].Value;

                if ( toExec )
                {
                    String file = this.literatureTable.Rows[ i ].Cells[ 4 ].Value.ToString();

                    ProcessStartInfo ps = new ProcessStartInfo();

                    ps.FileName = "cmd.exe";
                    ps.WindowStyle = ProcessWindowStyle.Hidden;
                    ps.Arguments = @"/c cd .. && cd .. && cd literature && " + file;
                    Process.Start(ps);
                }
            }
        }

        private void goBackBtn_Click(object sender, EventArgs e)
        {
            this.Hide();

            MainMenuForm mainMenu = new MainMenuForm( this.userName );

            mainMenu.Show();
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
