using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RecetasSLN.presentación;

namespace RecetasSLN.presentación
{
    public partial class FrmConsultarRecetas : Form
    {
        public FrmConsultarRecetas()
        {
            InitializeComponent();
          
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmNuevaReceta nueva = new FrmNuevaReceta();
            nueva.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea salir?", "CONFIRMACION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }
        private bool validar()
        {
            if(cboTipoReceta.SelectedIndex == - 1)
            {
                return false;
            }
            if(txtNombre.Text == "")
            {
                return false;
            }
            return true;
        }
    }
}
