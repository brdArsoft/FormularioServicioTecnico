using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace WindowsFormsApp7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textSe.Enabled = false;
            //textMostrar.Enabled = false;
            

        }

        private void cbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Carga de items en ComboBox
            //celular

            DataTable celular = new DataTable();
            celular.Columns.Add("MARCA");
            DataRow dr = celular.NewRow();
            dr["MARCA"] = "SAMSUNG";
            celular.Rows.Add(dr);
            DataRow dr2 = celular.NewRow();
            dr2["MARCA"] = "ALCATEL";
            celular.Rows.Add(dr2);
            DataRow dr3 = celular.NewRow();
            dr3["MARCA"] = "LG";
            celular.Rows.Add(dr3);
            DataRow dr4 = celular.NewRow();
            dr4["MARCA"] = "IPHONE";
            celular.Rows.Add(dr4);
            DataRow dr5 = celular.NewRow();
            dr5["MARCA"] = "OTRO";
            celular.Rows.Add(dr5);

            //laptop

            DataTable laptop = new DataTable();
            laptop.Columns.Add("MARCA");
            DataRow dr6 = laptop.NewRow();
            dr6["MARCA"] = "LENOVO";
            laptop.Rows.Add(dr6);
            DataRow dr7 = laptop.NewRow();
            dr7["MARCA"] = "HP";
            laptop.Rows.Add(dr7);
            DataRow dr8 = laptop.NewRow();
            dr8["MARCA"] = "SAMSUNG";
            laptop.Rows.Add(dr8);
            DataRow dr9 = laptop.NewRow();
            dr9["MARCA"] = "MAC";
            laptop.Rows.Add(dr9);
            DataRow dr10 = laptop.NewRow();
            dr10["MARCA"] = "OTRO";
            laptop.Rows.Add(dr10);

            //tv

            DataTable tv = new DataTable();
            tv.Columns.Add("MARCA");
            DataRow dr11 = tv.NewRow();
            dr11["MARCA"] = "HITACHI";
            tv.Rows.Add(dr11);
            DataRow dr12 = tv.NewRow();
            dr12["MARCA"] = "KANJI";
            tv.Rows.Add(dr12);
            DataRow dr13 = tv.NewRow();
            dr13["MARCA"] = "SAMSUNG";
            tv.Rows.Add(dr13);
            DataRow dr14 = tv.NewRow();
            dr14["MARCA"] = "KEN BROWN";
            tv.Rows.Add(dr14);
            DataRow dr15 = tv.NewRow();
            dr15["MARCA"] = "OTRO";
            tv.Rows.Add(dr15);

            //Autocompletar combo box
            if (cbTipo.SelectedIndex == 0)
            {
                cbMarca.DataSource = celular;
                cbMarca.DisplayMember = "MARCA";
            }
            else if (cbTipo.SelectedIndex == 1)
            {
                cbMarca.DataSource = laptop;
                cbMarca.DisplayMember = "MARCA";
            }
            else if (cbTipo.SelectedIndex == 2)
            {
                cbMarca.DataSource = tv;
                cbMarca.DisplayMember = "MARCA";
            }

        }
        private void rbSi_CheckedChanged(object sender, EventArgs e)
        //Evento seña
        {
            if (rbSi.Checked)
            {
                textSe.Enabled = false;
            }
            else
            {
                textSe.Enabled = true;
            }

        }

        private void rbNo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNo.Checked)
            {
                textSe.Enabled = false;
            }
            else
            {
                textSe.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Mostrar Datos cargados

            string lista = "";

            //Datos del cliente
            lista += "Nombre: " + textNom.Text + "\r\n";
            lista += "Direccion: " + textDir.Text + "\r\n";
            lista += "Telefono: " + textTel.Text + "\r\n";
            lista += "Dni: " + textdni.Text + "\r\n";
            //Datos del equipo
            lista += "Tipo: " + cbTipo.Text + "\r\n";
            lista += "Marca: " + cbMarca.Text + "\r\n";
            lista += "Modelo: " + textModelo.Text + "\r\n";
            lista += "Imei: " + textImei.Text + "\r\n";
            //Falla
            lista += "Falla: " + textFalla.Text + "\r\n";
            lista += "Observaciones: " + textObs.Text + "\r\n";


            //Cotización

            if (rbSi.Checked == true)

            {
                int a = Convert.ToInt16(textArreglo.Text);
                int b = Convert.ToInt16(textSe.Text);

                lista += "Valor del Arreglo: $" + a.ToString() + "\r\n";
                textMostrar.Text = lista;
                textOr.Enabled=false;
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                groupBox3.Enabled = false;

                int r = a - b;

                lista += "Seña de : $" + b.ToString() + "\r\n";
                lista += "Restan abonar: $" + r.ToString();
                textMostrar.Text = lista;
            }
            else if (rbSi.Checked == false)
            {
                lista += "Valor del Arreglo: $" + textArreglo.Text + "\r\n";
                textMostrar.Text = lista;
                textOr.Enabled = false;
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                groupBox3.Enabled = false;
            }
          
        }
        //validación Orden
        private void textOr_Validated(object sender, EventArgs e)
        {
            if (textOr.Text.Trim() == "")
            {
                //MessageBox.Show("Debe ingresar numero de orden");
                errorProvider1.SetError(textOr, "Introduce Numero de Orden");
                textOr.Focus();




            }
            else
            {
                errorProvider1.Clear();
                
            }

        }

        //validación Nombre

        private void textNom_Validated(object sender, EventArgs e)
        {
            if (textNom.Text.Trim() == "")
            {
                errorProvider1.SetError(textNom, "Introduce Nombre");
                textNom.Focus();
                MessageBox.Show("Debe ingresar Nombre");

            }
            else
            {
                errorProvider1.Clear();
            }
        }
        //Validación Dirección

        private void textDir_Validated(object sender, EventArgs e)
        {
            if (textDir.Text.Trim() == "")
            {
                errorProvider1.SetError(textDir, "introduce Dirección");
                textDir.Focus();
                MessageBox.Show("Debe ingresar Dirección");
                
            }
            else
            {
                errorProvider1.Clear();
            }



        }
        //validación telefono
        private void textTel_Validated(object sender, EventArgs e)
        {
            if (textTel.Text.Trim() == "")
            {
                errorProvider1.SetError(textTel, "introduce telefono");
                textDir.Focus();

            }
            else
            {
                errorProvider1.Clear();
            }

        }
        //validacion DNI
        private void textdni_Validated(object sender, EventArgs e)
        {
            if (textdni.Text.Trim() == "")
            {
                errorProvider1.SetError(textdni, "introduce DNI");
                textDir.Focus();

            }
            else
            {
                errorProvider1.Clear();
            }

        }
        

        //validación solos numeros:orden, dni,telefono
        private void textTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.soloNumeros(e);

        }

        private void textdni_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.soloNumeros(e);
        }

        private void textArreglo_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.soloNumeros(e);
        }

        private void textSe_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.soloNumeros(e);
        }
        private void textOr_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.soloNumeros(e);
        }


        //Boton Guardar
        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = @"c:\";
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.FileName = "*.txt";
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                
                Stream fileStream = saveFileDialog1.OpenFile();
                StreamWriter sw = new StreamWriter(fileStream);
                sw.WriteLine("BIENVENIDOS A GESTION TALLER                        N° de Orden:" + textOr.Text);
                sw.WriteLine(dateTimePicker1.Text);
                sw.WriteLine(textMostrar.Text);
                sw.Close();
            }



        }
        private void button3_Click(object sender, EventArgs e)
        {
            //Boton Nueva Orden
            textOr.Clear();

            foreach (Control c in this.groupBox1.Controls)
            {
                if (c is TextBox)
                {
                    TextBox texto = c as TextBox;
                    texto.Text = "";
                }
                else if (c is ComboBox)
                {
                    ComboBox combo = c as ComboBox;
                    combo.SelectedIndex = -1;
                }


            }
            foreach (Control c in this.groupBox2.Controls)
            {
                if (c is TextBox)
                {
                    TextBox texto = c as TextBox;
                    texto.Text = "";
                }
                else if (c is ComboBox)
                {
                    ComboBox combo = c as ComboBox;
                    combo.SelectedIndex = -1;
                }


            }
            foreach (Control c in this.groupBox3.Controls)
            {
                if (c is TextBox)
                {
                    TextBox texto = c as TextBox;
                    texto.Text = "";
                }
                else if (c is ComboBox)
                {
                    ComboBox combo = c as ComboBox;
                    combo.SelectedIndex = -1;
                }


            }
            textMostrar.Clear();
           
            textOr.Enabled = true;
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;
            groupBox3.Enabled = true;
        }
        //Boton cerrar
        private void button4_Click(object sender, EventArgs e)
        {
          Close();

            
        }

    
        
    }
}
