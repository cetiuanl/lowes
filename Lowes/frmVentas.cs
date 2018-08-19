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
    public partial class frmVentas : Form
    {

        private Ventas VentaActual
        {
            get
            {
                int idVenta = IntegerExtensions.ParseInt(txtIdVenta.Text);
                int idEmpleado = IntegerExtensions.ParseInt(txtidEmpleado.Text);
                DateTime fecha = dtpFechaVenta.Value;
                int estatus = IntegerExtensions.ParseInt(cboEstatusFacturacion.Text);
                int idCliente = IntegerExtensions.ParseInt(cboidCliente.Text);
                string tipoPago = cboFormaPago.SelectedText.ToString();
                return new Ventas(idVenta, idEmpleado, fecha, estatus, idCliente,tipoPago);
            }
            set
            {
                txtIdVenta.Text = value.idVenta.ToString();
                txtidEmpleado.Text = value.idCliente.ToString();
                dtpFechaVenta.Value = value.fechaVenta;
                cboEstatusFacturacion.Text = value.estatus.ToString();
                cboidCliente.SelectedText = value.idCliente.ToString();
                cboFormaPago.SelectedText = value.tipoPago;
            }
        }

        public frmVentas()
        {
            InitializeComponent();
        }

        private void frmVentas_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }

        private void cargarDatos()
        {
            dgvVenta.DataSource = Ventas.traerTodos(true);
            dgvVenta.Refresh();
        }

       


        private void dgvVenta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.VentaActual = (Ventas)dgvVenta.CurrentRow.DataBoundItem;


        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            VentaActual.guardar();
            cargarDatos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ///
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Ventas limpiar = new Ventas(0, 0, DateTime.Today, 0, 0, "");
            VentaActual = limpiar;
        }
    }
}
