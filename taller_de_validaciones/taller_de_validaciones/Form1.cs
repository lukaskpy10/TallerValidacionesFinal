using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using taller_de_validaciones.Elementos;

namespace taller_de_validaciones
{
    public partial class Form1 : Form
    {
      

        public Form1()

        {
            InitializeComponent();

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            // validar nombre

            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                erpMensaje.SetError(txtNombre, "Debe ingresar un nombre");
                return;
            }
            else
            {
                erpMensaje.SetError(txtNombre, "");

            }

            // no permitir  numero de documento vacio
            if (string.IsNullOrEmpty(txtNumDocumento.Text))
            {
                erpMensaje.SetError(txtNumDocumento, "Debe ingresar un numero de documento");
                return;
            }
            // SOLO PERMITIR NUMERO DE DOCUMENTO MAYOR A 0
            if(Convert.ToInt64( txtNumDocumento.Text) <= 0)
            {
                erpMensaje.SetError(txtNumDocumento, "El numero ingresado debe ser mayor a 0");
                return;
            }

           
            // NUIP ENTRE  1.000.000.000y 9.999.999.999.

            if (((TipoDocumento)cbTipoDocumento.SelectedItem).Id == 3)


            { if (Convert.ToInt64( txtNumDocumento.Text) <= 1000000000)
                {
                    MessageBox.Show("debe ingresar un numero mayor a 1.000.000.000");

                }
                    
               if (Convert.ToInt64(txtNumDocumento.Text) >= 9999999999)
                {
                    MessageBox.Show("debe ingresar un numero menor  a 9.999.999.999");
                }
                return;
            }

          
            // no permitir costo del servicio vacio
            if (string.IsNullOrEmpty(txtCosto .Text))
            {
                erpMensaje.SetError(txtCosto, "Debe ingresar un  costo del servicio");
                return;
            }
            // SOLO PERMITIR COSTO DEL SERVICIO MAYOR  A 0
            if (Convert.ToInt64(txtCosto.Text) <= 0)
            {
                erpMensaje.SetError(txtCosto, "El numero ingresado debe ser mayor a 0");
                return;
            }

          


            // mostrar mensaje de  registro ingresado exitosamente
            Elementos.RPS Registro = new Elementos.RPS();
            Registro.Nombre = txtNombre.Text;
            Registro.NumeroDocumento = Convert.ToInt64(txtNumDocumento.Text);
            Registro.CostoServicio = Convert.ToInt64(txtCosto.Text);

            MessageBox.Show("Registro Ingresado Exitosamente");
            


        }

        private void Form1_Load(object sender, EventArgs e)
        {// DEFINIR TIPOS DE DOCUMENTO
            System.Collections.Generic.List<Elementos.TipoDocumento>
                tiposDocumento = new List<Elementos.TipoDocumento>();

            tiposDocumento.Add(new Elementos.TipoDocumento() { Id = 1, Nombre = "Cedula Ciudania" });
            tiposDocumento.Add(new Elementos.TipoDocumento() { Id = 2, Nombre = "Tarjeta de  extranjeria" });
            tiposDocumento.Add(new Elementos.TipoDocumento() { Id = 3, Nombre = "NUIP" });
            tiposDocumento.Add(new Elementos.TipoDocumento() { Id = 4, Nombre = "Tarjeta de identidad" });
            cbTipoDocumento.DataSource = tiposDocumento;
            cbTipoDocumento.DisplayMember = "Nombre";
          
            
            
            // DEFINIR LOS RANGOS

          

            System.Collections.Generic.List<Elementos.Rango>
            rangos = new List<Elementos.Rango>();

            rangos.Add(new Elementos.Rango() { Id = 1, Nombre = "Rango A" });
            rangos.Add(new Elementos.Rango() { Id = 2, Nombre = "Rango B" });
            rangos.Add(new Elementos.Rango() { Id = 3, Nombre = "Rango C" });

            cbRango.DataSource = rangos;
            cbRango.DisplayMember = "Nombre";


        }

        private void btnCalcular_Click(object sender, EventArgs e)
        { double ValorApagar= 0 ;

            if (((Rango)cbRango.SelectedItem).Id == 1)

             {
                 ValorApagar = (Convert.ToInt64(txtCosto.Text) - ((Convert.ToInt64(txtCosto.Text) * 0.30)));

             }
            if (((Rango)cbRango.SelectedItem).Id == 2)
            {
                 ValorApagar = (Convert.ToInt64(txtCosto.Text) - ((Convert.ToInt64(txtCosto.Text) * 0.20)));

             }
            if (((Rango)cbRango.SelectedItem).Id == 3)
            {
                 ValorApagar = (Convert.ToInt64(txtCosto.Text) - ((Convert.ToInt64(txtCosto.Text) * 0.10)));
             }

             MessageBox.Show("el valor a pagar es de " + ValorApagar);


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtCosto_TextChanged(object sender, EventArgs e)
        {

        }
        //NO PERMITIR EL INGRESO DE LETRAS EN EL COSTO  
        private void txtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((int)e.KeyChar == 8 ||
              (int)e.KeyChar >= 48 && (int)e.KeyChar <= 59))
            {
                e.Handled = true;
            }
        }
    }
}
