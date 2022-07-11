using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelBancoDeDados
{
    public class DataBase
    {
        
        private static string server = @"(localdb)\MSSQLLocalDB";
        private static string database = "TesteEcologica";

        public static string MsgErro { get; private set; }
        public static string StrCon
        {
            get { return $"Data Source = {server};Initial Catalog = {database}; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"; }
        }

        public static bool AdicionarItens(Itens item)
        {
            try
            {
                using(SqlConnection cn = new SqlConnection(StrCon))
                {
                    cn.Open();

                    var sql = "INSERT INTO produtos (Id_Item, Nome_Item, Gtins, AlturaCM, LarguraCM," +
                        "ProfundidadeCM, PesoG, Descrição, Qtd_Estoque, Preço_de, Preço_por, Marca," +
                        "Status, Aprovar_Item, Revogar_Item, Excluir_Item, Foto_1) " +
                        "VALUES (@Id_Item, @Nome_Item, @Gtins, @AlturaCM, @LarguraCM, @ProfundidadeCM, " +
                        "@PesoG, @Descrição, @Qtd_Estoque, @Preço_de, @Preço_por, @Marca, @Status," +
                        "@Aprovar_Item, @Revogar_Item, @Excluir_Item, @Foto_1)";

                    using(SqlCommand cmd = new SqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@Id_Item", item.IdItem);
                        cmd.Parameters.AddWithValue("@Nome_Item", item.NomeItem);
                        cmd.Parameters.AddWithValue("@Gtins", item.Gtins);
                        cmd.Parameters.AddWithValue("@AlturaCM", item.AlturaCM);
                        cmd.Parameters.AddWithValue("@LarguraCM", item.LarguraCM);
                        cmd.Parameters.AddWithValue("@ProfundidadeCM", item.ProfundidadeCM);
                        cmd.Parameters.AddWithValue("@PesoG", item.PesoG);
                        cmd.Parameters.AddWithValue("@Descrição", item.Descricao);
                        cmd.Parameters.AddWithValue("@Qtd_Estoque", item.QtdEstoque);
                        cmd.Parameters.AddWithValue("@Preço_de", item.PrecoDe.ToString().Replace(",", "."));
                        cmd.Parameters.AddWithValue("@Preço_por", item.PrecoPor.ToString().Replace(",","."));
                        cmd.Parameters.AddWithValue("@Marca", item.Marca);
                        cmd.Parameters.AddWithValue("@Status", item.Status);
                        cmd.Parameters.AddWithValue("@Aprovar_Item", item.AprovarItem);
                        cmd.Parameters.AddWithValue("@Revogar_Item", item.RevogarItem);
                        cmd.Parameters.AddWithValue("@Excluir_Item", item.ExcluirItem);
                        cmd.Parameters.AddWithValue("@Foto_1", item.Foto1);
                        cmd.ExecuteNonQuery();
                    }
                }
                MsgErro = "";
                return true;
            }
            catch (Exception ex)
            { 
                MsgErro = ex.Message;
                return false;
            }
        }
    }
}
