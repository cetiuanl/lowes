﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lowes
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategoriaProducto form = frmCategoriaProducto.getInstancia;
            form.MdiParent = this;
            form.Show();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
          frmProducto form = frmProducto.getInstancia;
            form.MdiParent = this;
            form.Show();
        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmpleado form = frmEmpleado.getInstancia;
            form.MdiParent = this;
            form.Show();
        }

        private void rolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRol form = frmRol.getInstancia;
            form.MdiParent = this;
            form.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCliente form = frmCliente.getInstancia;
            form.MdiParent = this;
            form.Show();
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVentas form = frmVentas.getInstancia;
            form.MdiParent = this;
            form.Show();
        }



    }
}
