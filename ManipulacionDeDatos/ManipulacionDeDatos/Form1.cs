using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ManipulacionDeDatos
{
    public partial class InventariosBaseDeDatos : Form
    {
        public InventariosBaseDeDatos()
        {
            InitializeComponent();
        }
        //Estableciendo la conexión
        SqlConnection conexion = new SqlConnection("Data Source=RBOY;Initial Catalog=Games;Integrated Security=True");

        //Método para limpiar los textbox
        void limpiar()
        {
            tbxID.Text = "";
            tbxNombre.Text = "";
            tbxEmpresa.Text = "";
            tbxConsola.Text = "";
            tbxScore.Text = "";

        }

        public void llenar_grid()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from Juegos", conexion);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }

            catch (Exception ex)
            {
                MessageBox.Show("No se puede llenar el DGV" + ex.ToString());
            }
        }

        //Metodo que actualiza al nuevo ID
        public void validacion(object sender, EventArgs e)
        {
            SqlCommand validacion = new SqlCommand("update Juegos set ID=@ID, Nombre=@Nombre, Empresa=@Empresa, Consola=@Consola, Score=@Score where ID=@ID", conexion);

            validacion.Parameters.AddWithValue("ID",(tbxID.Text));
            validacion.Parameters.AddWithValue("Nombre", (tbxNombre.Text));
            validacion.Parameters.AddWithValue("Empresa", (tbxEmpresa.Text));
            validacion.Parameters.AddWithValue("Consola", (tbxConsola.Text));
            validacion.Parameters.AddWithValue("Score", (tbxScore.Text));

            conexion.Open();

            //Confirmacion de validacion
            try
            {
                validacion.ExecuteNonQuery();
                MessageBox.Show("Registro actualizado correctamente");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conexion.Close();

                llenar_grid();

                limpiar();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'gamesDataSet.Juegos' table. You can move, or remove it, as needed.
            this.juegosTableAdapter.Fill(this.gamesDataSet.Juegos);

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Instancia para la alta
            SqlCommand altas = new SqlCommand("insert into Juegos (ID, Nombre, Empresa, Consola, Score) values (@ID, @Nombre, @Empresa, @Consola, @Score)", conexion);

            //Añadiendo
            altas.Parameters.AddWithValue("@ID", tbxID.Text);
            altas.Parameters.AddWithValue("@Nombre", tbxNombre.Text);
            altas.Parameters.AddWithValue("@Empresa", tbxEmpresa.Text);
            altas.Parameters.AddWithValue("@Consola", tbxConsola.Text);
            altas.Parameters.AddWithValue("@Score", tbxScore.Text);

            //Abiendo la conexión
            conexion.Open();

            //Try Catch para reconocer cuando se agregue un ID repetido
            try
            {
                //Ejecuta ia instrucción SQL
                altas.ExecuteNonQuery();
            }
            catch(SqlException)
            {
                //MessageBox para confirmar el cambio
                conexion.Close();
                DialogResult respuesta = MessageBox.Show("Desea reescribir el registro", "ERROR DE REPETICION", MessageBoxButtons.YesNo);
                if (respuesta == DialogResult.Yes)
                    validacion(null, null);

            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                    conexion.Close();
            }
           
            llenar_grid();

            //Limpiando los textbox
            limpiar();

            //Confirmación
            MessageBox.Show("Metodo de agregar finalizado");
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Abriendo conexión
            conexion.Open();

            //Creando la cadena para dar de baja a usuarios
            string baja = "Delete from Juegos Where ID=@ID";

            //Creando comandos
            SqlCommand delt = new SqlCommand(baja, conexion);

            //Valor de lo obtenido en el textbox
            delt.Parameters.AddWithValue("@ID", tbxID.Text);

            //Ejecuta la instrucción SQL
            delt.ExecuteNonQuery();

            //Liberamos recursos
            delt.Dispose();
            delt = null;


            //Limpiando textbox
            limpiar();

            llenar_grid();

            //Cerrando conexión
            conexion.Close();

            //Confirmación
            MessageBox.Show("Registro eliminado");
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Abiendo conexión
            conexion.Open();

            //Instancia para actalizar la información
            SqlCommand comando = new SqlCommand("update Juegos set ID=@ID,Nombre=@Nombre, Empresa=@Empresa, Consola=@Consola, Score=@Score where ID=@ID", conexion);

            //Añadiendo la nueva información
            comando.Parameters.AddWithValue("@ID", tbxID.Text);
            comando.Parameters.AddWithValue("@Nombre", tbxNombre.Text);
            comando.Parameters.AddWithValue("@Empresa", tbxEmpresa.Text);
            comando.Parameters.AddWithValue("@Consola", tbxConsola.Text);
            comando.Parameters.AddWithValue("@Score", tbxScore.Text);

            //Ejecuta la instrucción SQL
            comando.ExecuteNonQuery();



            //Confirmación
            MessageBox.Show("Registro actualizando con exito");

            //Cerrando conexión
            conexion.Close();

            //Limpiando los textbox
            limpiar();

            llenar_grid();
        }

        //Consulta
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            //Instancia para la consulta
            SqlCommand consulta = new SqlCommand("select * from Juegos where ID=@ID", conexion);

            //Abiendo la conexión
            conexion.Open();

            //Consulta en base al ID
            consulta.Parameters.AddWithValue("@ID", tbxID.Text);

            //Lee la info
            SqlDataReader reader = consulta.ExecuteReader();

            //Leyendo la información y colocándola en los textbox
            while (reader.Read())
            {
                tbxID.Text = reader[0].ToString();
                tbxNombre.Text = reader[1].ToString();
                tbxEmpresa.Text = reader[2].ToString();
                tbxConsola.Text = reader[3].ToString();
                tbxScore.Text = reader[4].ToString();
            }

            //Confirmación
            MessageBox.Show("Consulta completada");

            //Cerrando conexión
            conexion.Close();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                tbxID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                tbxNombre.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                tbxEmpresa.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                tbxConsola.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                tbxScore.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            }

            catch (Exception ex)
            {
                MessageBox.Show("No se pudo visualizar" + ex.ToString());

            }
        }


    }
}
