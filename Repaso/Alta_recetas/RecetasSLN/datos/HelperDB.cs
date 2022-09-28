using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using RecetasSLN.dominio;
using System.Windows.Forms;

namespace RecetasSLN.datos
{
    internal class HelperDB
    {
        SqlConnection cnn = new SqlConnection(RecetasSLN.Properties.Resources.CadenaConexion);
        SqlCommand cmd = new SqlCommand();
        private void ConfigurarSp(string nombre)
        {
            cmd.Connection = cnn;
            cmd.CommandText = nombre;
            cmd.CommandType = CommandType.StoredProcedure;
        }
        public DataTable ConsultarSP(string consulta)
        {
            DataTable tabla = new DataTable();
            cnn.Open();
            ConfigurarSp(consulta);
            tabla.Load(cmd.ExecuteReader());
            cnn.Close();
            return tabla;
        }
        public bool altaReceta(Recetas receta)
        {
            bool respuesta = true;
            SqlTransaction transaccion = null;  
            try
            {
                cnn.Open();
                transaccion = cnn.BeginTransaction();
                SqlCommand cmdMaestro = new SqlCommand("[SP_INSERTAR_RECETA]", cnn, transaccion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", receta.Nombre);
                cmd.Parameters.AddWithValue("@cheff", receta.Cheff);
                cmd.Parameters.AddWithValue("@tipo_receta", receta.TipoReceta);
                SqlParameter param = new SqlParameter("id_receta", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmdMaestro.Parameters.Add(param);
                cmdMaestro.ExecuteNonQuery();

                int id_receta = Convert.ToInt32(param.Value);
                SqlCommand cmdDetalle = new SqlCommand("SP_INSERTAR_DETALLE", cnn, transaccion);
                cmd.CommandType = CommandType.StoredProcedure;
                for(int i = 0; i < receta.detallesReceta.Count; i++)
                {
                    cmdDetalle.Parameters.Clear();
                    cmdDetalle.Parameters.AddWithValue("@cantidad",receta.detallesReceta[i].Cantidad);
                    cmdDetalle.Parameters.AddWithValue("id_receta", id_receta);
                    cmdDetalle.Parameters.AddWithValue("id_ingrediente", receta.detallesReceta[i].Ingrediente.IngredienteId);
                    cmd.ExecuteNonQuery();
                }
                transaccion.Commit();
            }
            catch (Exception ex)
            {
                transaccion.Rollback();
                MessageBox.Show("Error:"+ex.Message,"Error", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                respuesta = false;

            }
            finally
            {
                if(cnn != null && cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
            return respuesta;
        }
        public bool registrarBaja()
        {

        }
    }
}
