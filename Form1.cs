using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MaterialSkin;
using MaterialSkin.Controls;

namespace App30
{
    public partial class Form1 : MaterialForm
    {
        public Form1()
        {
            InitializeComponent();
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue800, Primary.Blue900,
                Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            string nome = txtNomeProduto.Text;
            string valor = txtValorProduto.Text;

            listBoxNomes.AddItem(nome);
            listBoxValor.AddItem(valor);

            double valorTotal;
            double v = double.Parse(valor);
            if (lblValor.Text == "")
            {
                valorTotal = 0;
            }
            else
            {
                valorTotal = double.Parse(lblValor.Text);
            }

            valorTotal += v;
                

            txtNomeProduto.Clear();
            txtValorProduto.Clear();
            lblNome.Text = "Total: ";
            lblValor.Text = $"{valorTotal}";

        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            string s = listBoxNomes.SelectedItem.Text;
            
            for(int i = 0; i < listBoxNomes.Items.Count; i++)
            {
                if (listBoxNomes.Items[i].Text == s)
                {
                    listBoxNomes.RemoveItemAt(i);
                    double v = double.Parse(listBoxValor.Items[i].Text);
                    listBoxValor.RemoveItemAt(i);

                    double valor = double.Parse(lblValor.Text);
                    valor -= v;
                    lblValor.Text = $"{valor}";
                }
            }
        }
    }
}
