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

       private Producto productoActual
        {
            get
            {
                int idProducto = IntegerExtensions.ParseInt(txtIdProducto.Text);
                string nombre = txtNombre.Text;
                decimal precioCompra = DecimalExtensions.ParseDecimal( txtPrecioCompra.Text);
                decimal precioVenta = DecimalExtensions.ParseDecimal(txtPrecioVenta.Text);
                decimal inventario = DecimalExtensions.ParseDecimal(txtInventario.Text);
                int idCategoriaProducto = IntegerExtensions.ParseInt(txtIdCategoria.Text);
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
                txtIdCategoria.Text = value.idCategoria.ToString();
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
            productoActual.guardar();
            cargarDatos();
        }

        private void btnEliminate_Click(object sender, EventArgs e)
        {
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
