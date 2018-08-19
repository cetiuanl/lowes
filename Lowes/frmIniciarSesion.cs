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
    public partial class frmIniciarSesion : Form
    {
        public frmIniciarSesion()
        {
            InitializeComponent();
        }

        private void btnSesion_Click(object sender, EventArgs e)
        {
            try { 
                string usuario = textBox1.Text;
                string contrasena = textBox2.Text;
                Empleado oEmpleado = Empleado.validar(usuario, contrasena);
                Rol oRol = Rol.traerPorId(oEmpleado.idRol);

                Sesion.getInstancia.empleadoActual = oEmpleado;
                Sesion.getInstancia.rolActual = oRol;
                Sesion.getInstancia.fechaSesion = DateTime.Today;

                if (oEmpleado == null || oRol == null)
                {
                    this.DialogResult = DialogResult.Retry;                    
                }
                else
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                
            }
            catch (Exception)
            {
                this.DialogResult = DialogResult.Retry;
            }
        }

        private void frmIniciarSesion_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Sesion.getInstancia.empleadoActual == null) { 
                this.DialogResult = DialogResult.Abort;
            }
        }
    }
}
