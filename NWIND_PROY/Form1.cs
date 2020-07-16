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
    
    public partial class Form1 : Form
    {
        EntityNWIND  entityWIND = new EntityNWIND();
        
        public Form1()
        {
            InitializeComponent();

            var comp = from c in entityWIND.Compañías_de_envíos
                       select c;
            DataTable dtcomp = new DataTable();
            dtcomp.Columns.Add("IdCompañíaEnvíos", typeof(int));
            dtcomp.Columns.Add("NombreCompañía", typeof(string ));
            dtcomp.Columns.Add("Teléfono", typeof(string));

            foreach (var c in comp)
            {
                DataRow dtrow = dtcomp.NewRow();
                dtrow[0] = c.IdCompañíaEnvíos;
                dtrow[1] = c.NombreCompañía;
                dtrow[2] = c.Teléfono;

                dtcomp.Rows.Add(dtrow);
            }
            dataGridView1.DataSource = dtcomp;
            dataGridView1.Refresh();
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            if (txtNombrecompania .Text.Equals(""))
            {
                MessageBox.Show("Por favor ingrese el nombre");
                return;
            }
            if (txtTelefono .Text.Equals(""))
            {
                MessageBox.Show("Por favor ingrese el telefono");
                return;
            }



            try
            {
                Compañías_de_envíos comp = new Compañías_de_envíos();
                comp.NombreCompañía = txtNombrecompania.Text;
                comp.Teléfono = txtTelefono.Text;

                entityWIND.Compañías_de_envíos.Add(comp);
                entityWIND.SaveChanges();

                txtNombrecompania.Clear();
                txtTelefono.Clear();
                MessageBox.Show("Datos Guardados");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
    }
}
