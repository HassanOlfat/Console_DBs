using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public  interface IConnectionString
    {
        string getAddress();
        string getDatabasename();
        string getUserName();
        string getPassword();
        ConnectionType getConnectionType();
        string getConnectionString();
        bool getPing();
    }
}
