using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class Form1 : Form
    {
        CN_Productos objetoCN =new();
        private string idProducto;
        private bool Editar = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LeerProds();
        }
        private void LeerProds()
        {
            CN_Productos objeto = new();
            dataGridView1.DataSource = objeto.LeerProd();
        }
        private void LimpiarForm()
        {
            textProd.Clear();
            textDesc.Clear();
            textPrec.Clear();
            textExis.Clear();
            textProd.Clear();
            textEsta.Clear();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            {
                //Inserta
                if(Editar==false)
                {
                    try
                    {
                        objetoCN.InsProd(textProd.Text, textDesc.Text, textPrec.Text, textExis.Text, textEsta.Text);
                        MessageBox.Show("Registro insertado correctamente");
                        LeerProds();
                        LimpiarForm();

                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("El registro no pudo ser insertado, el motivo es: "+ ex);

                    }
                }
                //Edita
                if(Editar==true)
                {
                    try
                    {
                        objetoCN.ActProd(textProd.Text, textDesc.Text, textPrec.Text, textExis.Text, textEsta.Text, idProducto);
                        MessageBox.Show("Registro actualizado correctamente");
                        LeerProds();
                        LimpiarForm();
                        Editar= false;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("El registro no pudo ser actualizado, el motivo es: " + ex);
                    }
                }
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Editar = true;
                textProd.Text = dataGridView1.CurrentRow.Cells["nomProd"].Value.ToString();
                textDesc.Text = dataGridView1.CurrentRow.Cells["descripcion"].Value.ToString();
                textPrec.Text = dataGridView1.CurrentRow.Cells["precio"].Value.ToString();
                textExis.Text = dataGridView1.CurrentRow.Cells["cantidad"].Value.ToString();
                textEsta.Text = dataGridView1.CurrentRow.Cells["estado"].Value.ToString();
                idProducto = dataGridView1.CurrentRow.Cells["idProducto"].Value.ToString();

                
                
            }
            else
                MessageBox.Show("Por favor seleccione una fila");

        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    idProducto = dataGridView1.CurrentRow.Cells["idProducto"].Value.ToString();
                    objetoCN.EliProd(idProducto);
                    MessageBox.Show("Eliminado correctamente");
                    LeerProds();
                }
                else
                    MessageBox.Show("Seleccione una fila por favor");
            }
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult opc;
            opc = MessageBox.Show("Desea salir? ", "Salir del formulario", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (opc == DialogResult.OK)
            {
                Dispose();
            }


        }
    }
}