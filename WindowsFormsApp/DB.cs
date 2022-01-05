using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp
{
    internal class DB
    {
        private MySqlConnection connection;
        public DB ( string host, int port, string database, string username, string password )
        {
            // Connection String.
            String connString = "Server=" + host + ";Database=" + database + ";port=" + port + ";User Id=" + username + ";password=" + password;

            this.connection = new MySqlConnection( connString );
        }

        public void openConnection ()
        {
            if ( this.connection.State == System.Data.ConnectionState.Closed )
            {
                this.connection.Open();
            }
        }

        public void closeConnection()
        {
            if ( this.connection.State == System.Data.ConnectionState.Open )
            {
                this.connection.Close();
            }
        }

        public MySqlConnection getConnection ()
        {
            return this.connection;
        }
    }
}
