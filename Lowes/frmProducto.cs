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
    public partial class frmProducto : Form
    {
        private static frmProducto instancia;
        public static frmProducto getInstancia {
            get
            {
                if (instancia == null || instancia.IsDisposed)
                {
                    instancia = new frmProducto
                }
                return instancia;
            }

        }
       
       private Producto productoActual
        {
            get
            {
                int idProducto = IntegerExtensions.ParseInt(txtIdProducto.Text);
                string nombre = txtNombre.Text;
                decimal precioCompra = DecimalExtensions.ParseDecimal( txtPrecioCompra.Text);
                decimal precioVenta = DecimalExtensions.ParseDecimal(txtPrecioVenta.Text);
                decimal inventario = DecimalExtensions.ParseDecimal(txtInventario.Text);
                int idCategoriaProducto = IntegerExtensions.ParseInt( cbxIdCategoria.SelectedValue.ToString());
                string unidad = (txtUnidad.Text);

                return new Producto(idProducto, nombre, precioCompra, precioVenta, inventario, idCategoriaProducto, unidad);
            }
            set
            {
                txtIdProducto.Text = value.idProducto.ToString();
                txtNombre.Text = value.nombre;
                txtPrecioCompra.Text = value.precioCompra.ToString();
                txtPrecioVenta.Text = value.precioVenta.ToString();
                txtInventario.Text = value.inventario.ToString();
                cbxIdCategoria.SelectedValue = value.idCategoria.ToString();
                txtUnidad.Text = value.unidad.ToString();

            }

        }
        public frmProducto()
        {
            InitializeComponent();
        }

        private void frmProducto_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }

        private void cargarDatos()
        {
            
            dgbProductos.DataSource = Producto.traerTodos(true);
            dgbProductos.Refresh();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                productoActual.guardar();
                cargarDatos();
            }
            catch (Exception ex)
            {
                string mensaje = $"Mensaje de error: {ex.Message} Fin";
                MessageBox.Show(mensaje, "Ha ocurrido un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
              
            }
            
        }

        private void btnEliminate_Click(object sender, EventArgs e)
        {
            try
            {
                Producto.desactivar(productoActual.idProducto);
                cargarDatos();
            }
            catch (Exception ex)
            {
                string mensaje = $"Mensaje de error: {ex.Message} Fin";
                MessageBox.Show(mensaje, "Ha ocurrido un error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            Producto.desactivar(productoActual.idProducto);
            cargarDatos();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Producto limpiar = new Producto(0, "", 0, 0, 0, 0, "");
                productoActual = limpiar;
                  }  


        private void dgbProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.productoActual = (Producto)dgbProductos.CurrentRow.DataBoundItem;
        }
    }
}
