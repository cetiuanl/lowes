using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LowesCN;

namespace Lowes
{
    public partial class frmRol : Form
    {
        private Rol RolActual
        {
            get
            {
                int idrol = IntegerExtensions.ParseInt(txtIdRol.Text);
                string nombre = txtnombre.Text;
                string descripcion = txtdescripcion.Text;
                return new Rol(idrol,nombre,descripcion);
            }
            set
            {
                txtIdRol.Text = value.idRol.ToString();
                txtnombre.Text = value.nombre;
                txtdescripcion.Text = value.descripcion;
            }
        }
        


        public frmRol()
        {
            InitializeComponent();
        }

        private void frmRol_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }
        private void cargarDatos()
        { 
            dgvRol.DataSource = Rol.traerTodos(true);
            dgvRol.Refresh();


        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            RolActual.guardar();
            cargarDatos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Rol.desactivar(RolActual.idRol);
            cargarDatos();

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Rol limpiar = new Rol(0, "", "");
            RolActual = limpiar;
        }

        private void dgvRol_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvRol.CurrentRow.DataBoundItem.GetType() == typeof(Rol))
            {
                RolActual = (Rol)dgvRol.CurrentRow.DataBoundItem;
            }
                
        }
    }
}
