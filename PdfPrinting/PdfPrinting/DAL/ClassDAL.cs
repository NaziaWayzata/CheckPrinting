
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PrintCheck.DAL
{
     class ClassDAL
    {
        public DataTable ReadBankInfo()
        {
           Connection con = new Connection();
            if (ConnectionState.Closed == con.connect.State)
            {
                //3. open connection
                con.connect.Open();
            }
                //4. prepare query
                string Query = "SELECT * FROM WellsTrans where Ready_to_Print = 'y'";
                SqlCommand cmd = new SqlCommand(Query, con.connect);
                try
                {
                    using (SqlDataAdapter sqlDa = new SqlDataAdapter(cmd))
                    {

                        DataTable dt = new DataTable();
                        sqlDa.Fill(dt);
                        return dt;
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
        }


        public int UpdadatePrintInfo()
        {
            Connection con = new Connection();
            if (ConnectionState.Closed == con.connect.State)
            {
                //3. open connection
                con.connect.Open();
            }
            //4. prepare query
            string Query = "UPDATE myDB.dbo.WellsTrans SET  Ready_to_Print = 'N' Where Ready_to_Print='Y' ";
           
            try
            {
                using (SqlCommand cmd = new SqlCommand(Query, con.connect))
                {
                    return cmd.ExecuteNonQuery();
                  //  {
                    //    MessageBox.Show("Updated ");
                    //}
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}
