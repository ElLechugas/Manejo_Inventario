using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Modales;
using CapaPresentacion.Utilidades;
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
    public partial class frmCompras : Form
    {

        private Usuario _Usuario;

        public frmCompras(Usuario oUsuario = null)
        {
            _Usuario = oUsuario;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void frmCompras_Load(object sender, EventArgs e)
        {
            dvgdata.AutoGenerateColumns = false;

            cbtipodocumento.Items.Add(new OpcionCombo() { Valor = "Boleta", Texto = "Boleta" });
            cbtipodocumento.Items.Add(new OpcionCombo() { Valor = "Factura", Texto = "Factura" });
            cbtipodocumento.DisplayMember = "Texto";
            cbtipodocumento.ValueMember = "Valor";
            cbtipodocumento.SelectedIndex = 0;

            txtfecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtidproducto.Text = "0";
            txtidproveedor.Text = "0";

        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            using (var Modal = new mdProveedor()) {
                var result = Modal.ShowDialog();
                if (result == DialogResult.OK)
                {
                    txtidproveedor.Text = Modal._Proveedor.IdProveedor.ToString();
                    txtdocproveedor.Text = Modal._Proveedor.Documento;
                    txtnomproveedor.Text = Modal._Proveedor.RazonSocial;
                }
                else
                {
                    txtdocproveedor.Select();
                }
            }
        }

        private void btnbuscarproducto_Click(object sender, EventArgs e)
        {
            using (var Modal = new mdProducto())
            {
                var result = Modal.ShowDialog();
                if (result == DialogResult.OK)
                {
                    txtidproducto.Text = Modal._Producto.IdProducto.ToString();
                    txtcodproducto.Text = Modal._Producto.Codigo.ToString();
                    txtproducto.Text = Modal._Producto.Nombre.ToString();
                    txtpreciocompra.Text = Modal._Producto.PrecioCompra.ToString();
                    txtprecioventa.Text = Modal._Producto.PrecioVenta.ToString();

                }
                else
                {
                    txtcodproducto.Select();
                }
            }
        }

        private void txtcodproducto_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtcodproducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                Producto oProducto = new CN_Producto().Listar().Where(p => p.Codigo == txtcodproducto.Text && p.Estado == true).FirstOrDefault();
                if (oProducto != null)
                {
                    txtcodproducto.BackColor = Color.Honeydew;
                    txtidproducto.Text = oProducto.IdProducto.ToString();
                    txtproducto.Text = oProducto.Nombre.ToString();
                    txtpreciocompra.Select();
                }
                else
                {
                    txtcodproducto.BackColor = Color.MistyRose;
                    txtidproducto.Text = "0";
                    txtproducto.Text = "";
                }
            }
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {

            decimal precioCompra = 0;
            decimal precioVenta = 0;
            bool producto_existe = false;
            if (int.Parse(txtidproducto.Text) == 0)
            {
                MessageBox.Show("Debe seleccionar un Producto Valido", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            if (!decimal.TryParse(txtpreciocompra.Text, out precioCompra))
            {
                MessageBox.Show("Precio Compra - Formato Ingresado No Valido", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtpreciocompra.Select();
                return;
            }

            if (!decimal.TryParse(txtprecioventa.Text, out precioVenta))
            {
                MessageBox.Show("Precio Venta - Formato Ingresado No Valido", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtprecioventa.Select();
                return;
            }

            foreach (DataGridViewRow fila in dvgdata.Rows)
            {

                if (fila.Cells["IdProducto"].Value.ToString() == txtidproducto.Text)
                {
                    producto_existe = true;
                    MessageBox.Show("EL PRODUCTO SELECCIONADO YA EXISTE", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }

            if (!producto_existe)
            {
                dvgdata.Rows.Add(new object[] {
                       txtidproducto.Text,
                       txtproducto.Text,
                       precioCompra.ToString("0.00"),
                       precioVenta.ToString("0.00"),
                       numcantidad.Value.ToString(),
                       (numcantidad.Value * precioCompra).ToString("0.00")
                });

                limpiarProducto();
                calcularTotal();
                txtidproducto.Select();

            }

        }

        private void limpiarProducto()
        {
            txtidproducto.Text = "0";
            txtcodproducto.Text = "";
            txtcodproducto.BackColor = Color.Black;
            txtproducto.Text = "";
            txtpreciocompra.Text = "";
            txtprecioventa.Text = "";
            numcantidad.Value = 1;
        }

        private void calcularTotal()
        { 
            decimal total = 0;
            if(dvgdata.Rows.Count > 0)
            {
                foreach(DataGridViewRow row in dvgdata.Rows)
                {
                    total += Convert.ToDecimal(row.Cells["SubTotal"].Value.ToString());
                }
                txttotalpagar.Text = total.ToString("0.00");
            }
        }

        private void dvgdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dvgdata.Columns[e.ColumnIndex].Name == "btneliminar")
            {

                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    dvgdata.Rows.RemoveAt(indice);
                    calcularTotal();

                }
            }
        }

        private void dvgdata_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 6)
            {

                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.delete25.Width;
                var h = Properties.Resources.delete25.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.delete25, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void txtpreciocompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtpreciocompra.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
                {
                    e.Handled = false;
                }
                else
                {
                    if(Char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ".")
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void txtprecioventa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtprecioventa.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
                {
                    e.Handled = false;
                }
                else
                {
                    if (Char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ".")
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtidproveedor.Text) == 0)
            {
                MessageBox.Show("Debe Seleccionar un Proveedor", "Mesaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dvgdata.Rows.Count < 1)
            {
                MessageBox.Show("Debe ingresar productos en la compra", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DataTable detalle_compra = new DataTable();

            detalle_compra.Columns.Add("IdProducto", typeof(int));
            detalle_compra.Columns.Add("PrecioCompra", typeof(decimal));
            detalle_compra.Columns.Add("PrecioVenta", typeof(decimal));
            detalle_compra.Columns.Add("Cantidad", typeof(int));
            detalle_compra.Columns.Add("MontoTotal", typeof(decimal));

            foreach (DataGridViewRow row in dvgdata.Rows)
            { 
                detalle_compra.Rows.Add(
                    new object[] {
                        Convert.ToInt32(row.Cells["IdProducto"].Value.ToString()),
                        row.Cells["Precio_Compra"].Value.ToString(),
                        row.Cells["Precio_Venta"].Value.ToString(),
                        row.Cells["Cantidad"].Value.ToString(),
                        row.Cells["SubTotal"].Value.ToString(),
                    }
                );
            }

            int idcorrelativo = new CN_Compra().ObtenerCorrelativo();
            string numerodocumento = string.Format("{0:00000}", idcorrelativo);
            
            Compra oCompra = new Compra()
            { 
                oUsuario = new Usuario() { IdUsuario = _Usuario.IdUsuario},
                oProveedor = new Proveedor() { IdProveedor = Convert.ToInt32(txtidproveedor.Text) },
                TipoDocumento = ((OpcionCombo)cbtipodocumento.SelectedItem).Texto,
                NumeroDocumento = numerodocumento,
                MontoTotal = Convert.ToDecimal(txttotalpagar.Text)

            };

            string mensaje = string.Empty;
            bool respuesta = new CN_Compra().Registrar(oCompra, detalle_compra, out mensaje);

            if (respuesta)
            {
                var result = MessageBox.Show("Numero de Compra Generada:\n" + numerodocumento + "\n\nDesea Copiar al PortaPapeles?", "Mensaje",
                                              MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    Clipboard.SetText(numerodocumento);
                }

                txtidproveedor.Text = "0";
                txtdocproveedor.Text = "";
                txtnomproveedor.Text = "";
                dvgdata.Rows.Clear();
                calcularTotal();

            }
            else 
            {
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        
    }
}
