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

        private static frmVentas instancia;

        public static frmVentas getInstancia
        {
            get
            {
                if (instancia == null || instancia.IsDisposed)
                    {
                    instancia = new frmVentas();
                    }
                return instancia;
            }
        }


        private Ventas VentaActual
        {
            get
            {
                int idVenta = IntegerExtensions.ParseInt(txtIdVenta.Text);
                int idEmpleado = Sesion.getInstancia.empleadoActual.idEmpleado; //IntegerExtensions.ParseInt(txtidEmpleado.Text);
                DateTime fecha = dtpFechaVenta.Value;
                int estatus = IntegerExtensions.ParseInt(cboEstatusFacturacion.SelectedValue.ToString());

                string idClienteValue = cboidCliente.SelectedValue.ToString();
                int idCliente = IntegerExtensions.ParseInt(idClienteValue);

                string tipoPago = cboFormaPago.SelectedText.ToString();

                return new Ventas(idVenta, idEmpleado, fecha, estatus, idCliente,tipoPago);
            }
            set
            {
                txtIdVenta.Text = value.idVenta.ToString();
                txtidEmpleado.Text = value.idCliente.ToString();
                dtpFechaVenta.Value = value.fechaVenta;

                cboEstatusFacturacion.SelectedValue = value.estatus;
                cboidCliente.SelectedValue = value.idCliente;

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

            cboidCliente.DataSource = Cliente.traerTodos(true);
            cboidCliente.DisplayMember = Cliente.DisplayMember;
            cboidCliente.ValueMember = Cliente.ValueMember;
            cboidCliente.Refresh();

            List<ModoPago> listadoTiposPago = new List<ModoPago>();

            listadoTiposPago.Add(new ModoPago(1,"Tarjeta de Credito"));
            listadoTiposPago.Add(new ModoPago(2, "Efectivo"));
            listadoTiposPago.Add(new ModoPago(3, "Cheque"));

            cboFormaPago.DataSource = listadoTiposPago;
            cboFormaPago.DisplayMember = ModoPago.DisplayMember;
            cboFormaPago.ValueMember = ModoPago.ValueMember;
            cboFormaPago.Refresh();

            List<EstatusVenta> listadoEstatusVenta = new List<EstatusVenta>();

            listadoEstatusVenta.Add(new EstatusVenta(1, "Pendiente"));
            listadoEstatusVenta.Add(new EstatusVenta(2, "Facturado"));
            listadoEstatusVenta.Add(new EstatusVenta(3, "Cancelado"));

            cboEstatusFacturacion.DataSource = listadoEstatusVenta;
            cboEstatusFacturacion.DisplayMember = EstatusVenta.DisplayMember;
            cboEstatusFacturacion.ValueMember = EstatusVenta.ValueMember;
            cboEstatusFacturacion.Refresh();
        }

       


        private void dgvVenta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.VentaActual = (Ventas)dgvVenta.CurrentRow.DataBoundItem;


        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                VentaActual.guardar();
                cargarDatos();
            }
            catch (Exception ex)
            {

                string mensaje = $"{ex.Message}";
                MessageBox.Show(mensaje, "Ha ocurrido un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
            }
            VentaActual.guardar();
            cargarDatos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Ventas limpiar = new Ventas(0, 0, DateTime.Today, 0, 0, "");
            VentaActual = limpiar;
        }
    }
}
