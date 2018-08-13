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
    public partial class frmEmpleado : Form
    {
        private Empleado empleadoActual
        {
            get
            {
                int idEmpleado = IntegerExtensions.ParseInt(txtIdEmpleado.Text);
                string nombre = txtNombre.Text;
                DateTime fecha = dtpFechaNacimiento.Value;
                string usuario = txtUsuario.Text;
                string contrasena = txtContrasena.Text;
                int idRol = IntegerExtensions.ParseInt(txtIdRol.Text);

                return new Empleado(idEmpleado, nombre, fecha, usuario, contrasena, idRol);
            }
            set
            {
                txtIdEmpleado.Text = value.idEmpleado.ToString();
                txtNombre.Text = value.nombreCompleto;
                dtpFechaNacimiento.Value = value.fechaNacimiento;
                txtUsuario.Text = value.usuario;
                txtContrasena.Text = value.contrasena;
                txtIdRol.Text = value.idRol.ToString();
            }
        }
        public frmEmpleado()
        {
            InitializeComponent();
        }

        private void frmEmpleado_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }

        private void cargarDatos()
        {
            dgvEmpleados.DataSource = Empleado.traerTodos(true);
            dgvEmpleados.Refresh();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            empleadoActual.guardar();
            cargarDatos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Empleado.desactivar(empleadoActual.idEmpleado);
            cargarDatos();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Empleado limpiar = new Empleado(0, "",DateTime.Today, "", "", 0);
            empleadoActual = limpiar;
        }

        private void dgvEmpleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            this.empleadoActual = (Empleado)dgvEmpleados.CurrentRow.DataBoundItem;
        }
    }
}
