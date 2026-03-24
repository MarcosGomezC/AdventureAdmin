using AdventureAdmin.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AdventureAdmin.Ui.ShipMethod
{
    public partial class ShipMethodList : Form
    {
        private readonly AdventureWorksContext _context;
        public ShipMethodList(AdventureWorksContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private async Task ShipMethodList_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            try
            {
                var shipMethods = await _context.ShipMethods.ToListAsync();
                ShipMethodDataView.DataSource = shipMethods;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private async Task nuevoButton_Click(object sender, EventArgs e)
        {
            var shipMethodForm = Program.ServiceProvider.GetRequiredService<ShipMethodForm>();
            shipMethodForm.ShowDialog();
            await LoadDataAsync();
        }
    }
}
