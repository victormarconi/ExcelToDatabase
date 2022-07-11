using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelBancoDeDados
{
    public static class Excel
    {
        public static DataTable GetItens()
        {
            var arquivo = @"C:\Users\NOTE-TI2-MKTPLACE\Downloads\produtosecologica.xlsx";
            var planilha = "SELECT  * FROM [Itens$]";

            var strCon = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + arquivo +
                "; Extended Properties=\"Excel 12.0; HDR=Yes; IMEX=0\"";

            var dt = new DataTable();

            using (OleDbConnection con = new OleDbConnection(strCon))
            {
                using (OleDbDataAdapter da = new OleDbDataAdapter(planilha, con))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }
    }
}
