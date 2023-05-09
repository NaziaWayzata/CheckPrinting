using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace PrintCheck.DAL
{
    class Connection
    {
        //1. address of SQL server and database
     //  static string cString = "Data Source=USNHUSSAIN129;Initial Catalog=myDB;Integrated Security=True";

        //2. establish connection
      //  public SqlConnection con = new SqlConnection(cString);

       public SqlConnection connect = new SqlConnection("Data Source=USNHUSSAIN129;Initial Catalog=myDB;Integrated Security=True");

    }
}
