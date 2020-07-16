using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NWIND_PROY
{
    public partial class frmPerfiles : Form
    {
        EntityNWIND entity = new EntityNWIND ();
        bool editar = false;
        long idperfil = 0;
        public frmPerfiles()
        {
            InitializeComponent();
        }

        private void frmPerfiles_Load(object sender, EventArgs e)
        {
            var tperfiles = from p in entity.Perfiles
                            select new {
                                     p.PKPerfilId ,
                                     p.PerfilDescripcion ,
                                     p.PerfilEstado };

            dgperfiles.DataSource = tperfiles.CopyAnonymusToDataTable();
            dgperfiles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

           




        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            if (txtperfilnombre.Text.Equals(""))
            {
                MessageBox.Show("Porfavor Ingrese la descripcion del perfil");
                return;
            }

            try
            {
                if (editar)
                {
                    var tperfil = entity.Perfiles.FirstOrDefault(x => x.PKPerfilId == idperfil);

                    tperfil.PerfilDescripcion = txtperfilnombre.Text;
                    tperfil.PerfilEstado = chkestado.Checked;
                    
                }
                else
                {
                    Perfiles tbperfiles = new Perfiles();
                    tbperfiles.PerfilDescripcion = txtperfilnombre.Text;
                    tbperfiles.PerfilEstado = chkestado.Checked;

                    entity.Perfiles.Add(tbperfiles);
                    entity.SaveChanges();

                   
                }
                txtperfilnombre.Text = "";
                editar = false;
                idperfil = 0;

                var tperfiles = from p in entity.Perfiles
                                select new
                                {
                                    p.PKPerfilId,
                                    p.PerfilDescripcion,
                                    p.PerfilEstado
                                };
                dgperfiles.DataSource = tperfiles.CopyAnonymusToDataTable();
                MessageBox.Show("Datos Guardados");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            } 
        }
        

     



        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            editar = false;
            txtperfilnombre.Text = "";
            idperfil = 0;
        }

        private void dgperfiles_SelectionChanged(object sender, EventArgs e)
        {

            try
            {
                idperfil = Convert.ToInt64(dgperfiles.SelectedCells[0].Value);
                editar = true;
                var tperfil = entity.Perfiles.FirstOrDefault(x => x.PKPerfilId == idperfil);
                txtperfilnombre.Text = tperfil.PerfilDescripcion;
                chkestado.Checked = tperfil.PerfilEstado;
            }
            catch (Exception)
            {

                
            }
        }
    }
}
