﻿using System;
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
    public partial class frmCliente : Form
    {
        private Cliente clienteActual
        {
            get
            {
                int idCliente = IntegerExtensions.ParseInt(txtIdCliente.Text);
                string nombre = txtNombre.Text;
                string direccion = txtDireccion.Text;
                string rfc = txtRfc.Text;
                string correo = txtCorreo.Text;
                return new Cliente(idCliente, nombre, direccion, rfc, correo);
            }
            set
            {
                txtIdCliente.Text = value.idCliente.ToString();
                txtNombre.Text = value.nombreCompleto.ToString();
                txtDireccion.Text = value.direccion.ToString();
                txtRfc.Text = value.RFC.ToString();
                txtCorreo.Text = value.correoElectronico.ToString();
            }
        }

        public frmCliente()
        {
            InitializeComponent();
        }

        private void frmCliente_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }

        private void cargarDatos()
        {
            dgvClientes.DataSource = Cliente.traerTodos(true);
            dgvClientes.Refresh();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            clienteActual.guardar();
            cargarDatos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Cliente.desactivar(clienteActual.idCliente);
            cargarDatos();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Cliente limpiar = new Cliente(0, "", "", "", "");
            clienteActual = limpiar;
           
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvClientes.CurrentRow.DataBoundItem.GetType() == typeof(Cliente))
            {
                this.clienteActual = (Cliente)dgvClientes.CurrentRow.DataBoundItem;
            }
            

        }
    }
}
