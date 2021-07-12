
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class SqlServerConnection : IConnectionString
    {
        public string getAddress()
        {
            return "localhost";
        }
        public string getDatabasename()
        {
            return "Test";
        }
        public ConnectionType getConnectionType()
        {
            return ConnectionType.sqlServer;
        }
        public string getUserName()
        {
            return null;
        }
        public string getPassword()
        {
            return null;
        }

        public string getConnectionString()
        {

            if (getUserName() == null) 
                return "Server=" +getAddress() +"; Database="+ getDatabasename()+"; Trusted_Connection=True;";
            else
                return "Data Source=" + getAddress() + "Initial Catalog=" + getDatabasename() + 
                       "User ID=" + getUserName() + "Password=" + getPassword() ;
            
        }

        public bool getPing()
        {
          
            return false;
        }
    
        
    }
}
