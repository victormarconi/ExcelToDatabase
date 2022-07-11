using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelBancoDeDados
{
    public class Itens
    {
        public string IdItem { get; set; }
        public string NomeItem { get; set; }
        public string Gtins { get; set; }
        public decimal AlturaCM { get; set; }
        public decimal LarguraCM { get; set; }
        public decimal ProfundidadeCM { get; set; }
        public decimal PesoG { get; set; }
        public string Descricao { get; set; }
        public int QtdEstoque { get; set; }
        public decimal PrecoDe { get; set; }
        public decimal PrecoPor { get; set; }
        public string Marca { get; set; }
        public string Status { get; set; }
        public string AprovarItem { get; set; }
        public string RevogarItem { get; set; }
        public string ExcluirItem { get; set; }
        public string Foto1 { get; set; }

        public Itens() { }

        public Itens(string idItem, string nomeItem, string gtins, decimal alturaCM, decimal larguraCM, decimal profundidadeCM, decimal pesoG, string descricao, int qtdEstoque, decimal precoDe, decimal precoPor, string marca, string status, string aprovarItem, string revogarItem, string excluirItem, string foto1)
        {
            IdItem = idItem;
            NomeItem = nomeItem;
            Gtins = gtins;
            AlturaCM = alturaCM;
            LarguraCM = larguraCM;
            ProfundidadeCM = profundidadeCM;
            PesoG = pesoG;
            Descricao = descricao;
            QtdEstoque = qtdEstoque;
            PrecoDe = precoDe;
            PrecoPor = precoPor;
            Marca = marca;
            Status = status;
            AprovarItem = aprovarItem;
            RevogarItem = revogarItem;
            ExcluirItem = excluirItem;
            Foto1 = foto1;
        }

        public List<Itens> GetItens()
        {
            var listaItens = new List<Itens>();
            var dt = Excel.GetItens();

            foreach (DataRow item in dt.Rows)
                listaItens.Add(new Itens(item["Id Item"].ToString(),
                    item["Nome Item"].ToString(), item["Gtins"].ToString(), Convert.ToDecimal(item["Altura (cm)"]),
                    Convert.ToDecimal(item["Largura (cm)"]), Convert.ToDecimal(item["Profundidade (cm)"]),
                    Convert.ToDecimal(item["Peso (g)"]), item["Descrição"].ToString(),
                    Convert.ToInt32(item["Qtd Estoque"]), Convert.ToDecimal(item["Preço de"]), 
                    Convert.ToDecimal(item["Preço por"]), item["Marca"].ToString(), item["Status"].ToString(),
                    item["Aprovar Item"].ToString(), item["Revogar Item"].ToString(),
                    item["Excluir Item"].ToString(), item["Foto 1"].ToString()));

            return listaItens;
        }
        
        public bool AdiconarItens()
        {
            return DataBase.AdicionarItens(this);
        }      
    }
}
