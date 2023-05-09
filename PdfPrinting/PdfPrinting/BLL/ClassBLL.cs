using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrintCheck.DAL;

namespace PrintCheck.BLL
{
     class ClassBLL
    {
        public DataTable GetData()
        {
            try
            {
                ClassDAL objdal = new ClassDAL(); //data access layer class object to acess functions
                return objdal.ReadBankInfo();
            }
            catch(Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return null;
            }
           
        }
        public int UpdateCheckPrintingStatus()
        {
            try
            {
                    ClassDAL objdal1 = new ClassDAL();
                     return objdal1.UpdadatePrintInfo();
                
            }
            catch(Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message.ToString());
                return 0;
            }
        }

    }
}
