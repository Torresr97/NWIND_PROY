using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Security.Cryptography;


namespace NWIND_PROY
{
    public partial class frmUsuarios : Form
    {
        bool editar = false;
        Int64 pkUsuarioId = 0;
        EntityNWIND entity = new EntityNWIND();
        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            var tusuario = from us in entity.Usuarios
                           select new
                           {
                               us
                           };
            dgusuarios.DataSource = tusuario.CopyAnonymusToDataTable();
            dgusuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            var tperfiles = from p in entity.Perfiles
                            select p;

            DataTable dtperfiles = tperfiles.CopyAnonymusToDataTable();
            cmbperfil.DataSource = dtperfiles;
            cmbperfil.ValueMember = dtperfiles.Columns[0].ColumnName;
            cmbperfil.DisplayMember = dtperfiles.Columns[1].ColumnName;


        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            editar = false;
            pkUsuarioId = 0;
            limpiarcontroles();

        }

        public void limpiarcontroles()
        {
            txtnombre.Text = txtcontrasena.Text = txtusuario.Text = "";
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            if (editar)
            {

            }
            else
            {
                Usuarios tusuarios = new NWIND_PROY.Usuarios();
                    tusuarios.UsuarioNombre = txtusuario.Text;
                tusuarios.Usuario = txtusuario.Text;
                tusuarios.FKPerfilId = Convert.ToInt64(cmbperfil.SelectedValue);

                
                using (SHA512 sha = new SHA512Managed()){
                    byte[] info = Encoding.UTF8. GetBytes(txtcontrasena.Text);
                      byte[] clave = sha.ComputeHash(info);

                    tusuarios.Contrasenia = cadenaHash(clave);
                }
             

                entity.Usuarios.Add(tusuarios);
                entity.SaveChanges();
                limpiarcontroles();

                MessageBox.Show("Datos Guardados");





            }
        }

        static string cadenaHash(byte[] hash) {
            StringBuilder resultado = new StringBuilder();
            for(int i=0; i< hash.Length; i++)
            {
                resultado.Append(hash[i].ToString("x2"));

            }
            return resultado.ToString();
        }

        private void dgusuarios_SelectionChanged(object sender, EventArgs e)
        {
            if(dgusuarios .Rows.Count > 0)
            {
                pkUsuarioId = Convert.ToInt64(dgusuarios.SelectedCells[0].Value);
                editar = true;

                var tusuario = entity.Usuarios.FirstOrDefault(x => x.PKUsuarioId == pkUsuarioId);

                txtusuario.Text = tusuario.Usuario;
                txtnombre.Text = tusuario.UsuarioNombre;

                var tperfil = entity.Perfiles.FirstOrDefault(x => x.PKPerfilId == tusuario.FKPerfilId);

                cmbperfil.SelectedItem = tperfil.PKPerfilId;
            }
        }
    }
}
