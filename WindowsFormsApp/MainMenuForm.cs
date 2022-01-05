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
    public partial class MainMenuForm : Form
    {
        private string userName;
        public MainMenuForm( String userName = "Default Name" )
        {
            InitializeComponent();

            this.userName = userName;
            this.userNameField.Text = this.userName;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void quitBtn_Click(object sender, EventArgs e)
        {
            this.Hide();

            LoginForm loginForm = new LoginForm();

            loginForm.Show();
        }

        private void userListBtn_Click(object sender, EventArgs e)
        {
            this.Hide();

            UserListForm userListForm = new UserListForm( this.userName );

            userListForm.Show();
        }

        private void literatureBtn_Click(object sender, EventArgs e)
        {
            this.Hide();

            LiteratureSearchForm literatureSearch = new LiteratureSearchForm( this.userName );

            literatureSearch.Show();
        }

        private void closeBtn_MouseHover(object sender, EventArgs e)
        {
            this.closeBtn.ForeColor = System.Drawing.Color.FromArgb(230, 125, 34);
        }

        private void closeBtn_MouseLeave(object sender, EventArgs e)
        {
            this.closeBtn.ForeColor = System.Drawing.Color.FromArgb(239, 239, 239);
        }
    }
}
