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
    public partial class frmCategoriaProducto : Form
    {        
        private CategoriaProducto categoriaActual
        {
            get
            {
                int idCategoria = IntegerExtensions.ParseInt(txtIdCategoria.Text);
                string nombre = txtNombre.Text;
                string descripcion = txtDescripcion.Text;
                return new CategoriaProducto(idCategoria,nombre,descripcion);
            }
            set
            {
                txtIdCategoria.Text = value.idCategoria.ToString();
                txtNombre.Text = value.nombre;
                txtDescripcion.Text = value.descripcion;
            }
        }
        

        public frmCategoriaProducto()
        {
            InitializeComponent();
        }

        private void frmCategoriaProducto_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }

        private void cargarDatos()
        {
            dgvCategorias.DataSource = CategoriaProducto.traerTodos(true);
            dgvCategorias.Refresh();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            categoriaActual.guardar();
            cargarDatos();
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            CategoriaProducto.desactivar(categoriaActual.idCategoria);
            cargarDatos();
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            CategoriaProducto limpiar = new CategoriaProducto(0, "", "");
            categoriaActual = limpiar;
        }

        private void dgvCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCategorias.CurrentRow.DataBoundItem.GetType() == typeof(CategoriaProducto))
            {
                categoriaActual = (CategoriaProducto)dgvCategorias.CurrentRow.DataBoundItem;
            }            
        }
    }
}
