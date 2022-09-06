using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Carreras_SP
{
    public partial class frmConsultarCarreras : Form
    {
        public frmConsultarCarreras()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != 1)
            {
                int id = (int)comboBox1.SelectedValue;
                if (MessageBox.Show("Desea eliminar la carrera?", "CONFIRMACION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    new AccesoBD()ElimincarCarrera(id);
                }
            }

        }

        private void ElimincarCarrera(int id)
        {
            throw new NotImplementedException();
        }
    }
}
