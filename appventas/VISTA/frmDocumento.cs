﻿using appventas.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using appventas.DAO;

namespace appventas.VISTA
{
    public partial class frmDocumento : Form
    {
        public frmDocumento()
        {
            InitializeComponent();
            carga();
            clear();
        }

        private void frmDocumento_Load(object sender, EventArgs e)
        {

        }

        void clear()
        {
            txtIdDocument.Clear();
            txtDocumentName.Clear();

        }

        void carga()
        {

            dgvDocumento.Rows.Clear();
            using (sistema_ventasEntities bd = new sistema_ventasEntities())
            {
                var ListDocum = bd.tb_documento.ToList();

                foreach (var iteracion in ListDocum)
                {
                    dgvDocumento.Rows.Add(iteracion.iDDocumento, iteracion.nombreDocumento);
                }
            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            clsDocumento documento = new clsDocumento();
            tb_documento list = new tb_documento();
            list.nombreDocumento = txtDocumentName.Text;


            documento.guardarDatos(list);

            carga();
            clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            clsDocumento document = new clsDocumento();
            document.eliminarDatos(Convert.ToInt32(txtIdDocument.Text));

            carga();
            clear();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            clsDocumento documento = new clsDocumento();

            tb_documento lista = new tb_documento();
            lista.nombreDocumento = txtDocumentName.Text;
            lista.iDDocumento = Convert.ToInt32(txtIdDocument.Text);

            documento.actualizarDatosr(lista);

            carga();
            clear();
        }

        private void dgvDocumento_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String nombreDocumento = dgvDocumento.CurrentRow.Cells[1].Value.ToString();
            String idDocumento = dgvDocumento.CurrentRow.Cells[0].Value.ToString();
            
            txtDocumentName.Text = nombreDocumento;
            txtIdDocument.Text = idDocumento;
        }
    }
    
}
