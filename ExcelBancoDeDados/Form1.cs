using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelBancoDeDados
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            var item = new Itens();
            var listaItens = item.GetItens();

            foreach(var produtoItem in listaItens)
            {
                item = produtoItem;
                if (!item.AdiconarItens())
                    MessageBox.Show(DataBase.MsgErro);

            }

            MessageBox.Show("Processo encerrado");

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
