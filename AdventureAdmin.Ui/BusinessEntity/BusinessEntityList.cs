using AdventureAdmin.Data.Context;
using AdventureAdmin.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdventureAdmin.Ui.Business_Entity
{
    public partial class BusinessEntityList : Form
    {
        private readonly AdventureWorksContext _context;

        public BusinessEntityList(AdventureWorksContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private async void BusinessEntityList_Load(object sender, EventArgs e)
        {

            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            try
            {
               
                var lista = await _context.BusinessEntities
                    .AsNoTracking() 
                                    .ToListAsync();

                // PASO 3: Asignamos al Grid
                dataGridView1.DataSource = lista;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error de carga: {ex.Message}");
            }
        }

        private async void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
               
                var form = Program.ServiceProvider.GetRequiredService<BusinessEntityForm>();

                if (form.ShowDialog() == DialogResult.OK)
                {
                    await Task.Delay(100);
                    await LoadDataAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar nuevo registro: {ex.Message}");
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}