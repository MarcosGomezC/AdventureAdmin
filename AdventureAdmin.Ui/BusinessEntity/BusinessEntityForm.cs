using AdventureAdmin.Data.Context;
using AdventureAdmin.Data.Models;
using System;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace AdventureAdmin.Ui.Business_Entity
{
    public partial class BusinessEntityForm : Form
    {
        private readonly AdventureWorksContext _context;

        public BusinessEntityForm(AdventureWorksContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private async void Guardar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtGuid.Text))
            {
                MessageBox.Show("El nombre es obligatorio", "Validación");
                return;
            }

            try
            {
                Guardar.Enabled = false;




                MessageBox.Show("¡Guardado con éxito!", "Éxito");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                string mensajeError = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                MessageBox.Show($"Error en la base de datos: {mensajeError}");
            }
            finally
            {
                Guardar.Enabled = true;
            }
        }

        private void txtGuid_TextChanged(object sender, EventArgs e)
        {

        }
    }
}