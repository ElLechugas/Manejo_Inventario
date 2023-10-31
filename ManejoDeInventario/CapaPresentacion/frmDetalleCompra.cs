using CapaEntidad;
using CapaNegocio;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using iTextSharp.tool.xml.pipeline.end;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmDetalleCompra : Form
    {
        public frmDetalleCompra()
        {
            InitializeComponent();
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            Compra oCompra = new CN_Compra().ObtenerCompra(txtbusqueda.Text);
            if (oCompra.IdCompra != 0) {
                txtnumerodocumento.Text = oCompra.NumeroDocumento;
                txtfecha.Text = oCompra.FechaRegistro;
                txttipodocumento.Text = oCompra.TipoDocumento;
                txtusuario.Text = oCompra.oUsuario.NombreCompleto;
                txtdocproveedor.Text = oCompra.oProveedor.Documento;
                txtnomproveedor.Text = oCompra.oProveedor.RazonSocial;

                dvgdata.Rows.Clear();
                foreach (Detalle_Compra dc in oCompra.oDetalleCompra)
                {
                    dvgdata.Rows.Add(new object[] { dc.oProducto.Nombre, dc.PrecioCompra, dc.cantidad, dc.MontoTotal});
                }
                txtmontototal.Text = oCompra.MontoTotal.ToString("0.00");
            }
        
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            txtfecha.Text = "";
            txttipodocumento.Text = "";
            txtusuario.Text = "";
            txtdocproveedor.Text = "";
            txtnomproveedor.Text = "";

            dvgdata.Rows.Clear();
            txtmontototal.Text = "0.00";
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            if (txttipodocumento.Text == "") {
                MessageBox.Show("No se Encontraron Resultados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            
            }

            string Texto_HTML = Properties.Resources.PlantillaCompra.ToString();

            Negocio odatos = new CN_Negocio().ObtenerDatos();

            Texto_HTML = Texto_HTML.Replace("@nombrenegocio", odatos.Nombre.ToUpper());
            Texto_HTML = Texto_HTML.Replace("@docnegocio", odatos.RUC);
            Texto_HTML = Texto_HTML.Replace("@direcnegocio", odatos.Direccion);

            Texto_HTML = Texto_HTML.Replace("@tipodocumento", txttipodocumento.Text.ToUpper());
            Texto_HTML = Texto_HTML.Replace("@numerodocumento", txtnumerodocumento.Text);

            Texto_HTML = Texto_HTML.Replace("@docproveedor", txtdocproveedor.Text);
            Texto_HTML = Texto_HTML.Replace("@nombreproveedor", txtnomproveedor.Text);
            Texto_HTML = Texto_HTML.Replace("@fecharegistro", txtfecha.Text);
            Texto_HTML = Texto_HTML.Replace("@usuarioregistro", txtusuario.Text);

            string filas = string.Empty;
            foreach (DataGridViewRow row in dvgdata.Rows)
            {
                filas += "<tr>";
                filas += "<td>" + row.Cells["Producto"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Precio_Compra"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Cantidad"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["SubTotal"].Value.ToString() + "</td>";
                filas += "</tr>";
            }

            Texto_HTML = Texto_HTML.Replace("@filas", filas);
            Texto_HTML = Texto_HTML.Replace("@montototal", txtmontototal.Text);

            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = string.Format("Compra_{0}.pdf", txtnumerodocumento.Text);
            savefile.Filter = "Pdf Files |*,pdf";
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(savefile.FileName, FileMode.Create))
                { 
                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                    bool obtenido = true;
                    byte[] byteimage = new CN_Negocio().ObtenerLogo(out obtenido);
                    
                    if (obtenido) {
                        iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(byteimage);
                        img.ScaleToFit(60, 60);
                        img.Alignment = iTextSharp.text.Image.UNDERLYING;
                        img.SetAbsolutePosition(pdfDoc.Left, pdfDoc.GetTop(51));
                        pdfDoc.Add(img);
                    }

                    using (StringReader sr = new StringReader(Texto_HTML))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    }

                    pdfDoc.Close();
                    stream.Close();
                    MessageBox.Show("DOCUMENTO GENERADO", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

       
    }
}
