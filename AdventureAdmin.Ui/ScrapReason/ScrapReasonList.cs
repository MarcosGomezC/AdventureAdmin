using Microsoft.Extensions.DependencyInjection;
using AdventureAdmin.Ui.Services;
using ScrapReasonModel = AdventureAdmin.Data.Models.ScrapReason;

namespace AdventureAdmin.Ui.ScrapReason;

public partial class ScrapReasonList : Form
{
    private readonly ScrapReasonService _service;

    public ScrapReasonList(ScrapReasonService service)
    {
        InitializeComponent();
        _service = service;
    }

    private void ScrapReasonList_Load(object sender, EventArgs e)
    {
        _ = LoadDataAsync();
    }

    private async Task LoadDataAsync()
    {
        try
        {
            var scrapReasons = await _service.GetList(s => true);
            scrapReasonsDataGridView.DataSource = scrapReasons;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al cargar datos: {ex.Message}");
        }
    }

    private void nuevoButton_Click(object sender, EventArgs e)
    {
        var form = Program.ServiceProvider.GetRequiredService<ScrapReasonForm>();
        if (form.ShowDialog(this) == DialogResult.OK)
            _ = LoadDataAsync();
    }

    private void modificarButton_Click(object sender, EventArgs e)
    {
        if (scrapReasonsDataGridView.CurrentRow?.DataBoundItem is not ScrapReasonModel entidad)
        {
            MessageBox.Show("Seleccione un registro para modificar.");
            return;
        }

        var form = ActivatorUtilities.CreateInstance<ScrapReasonForm>(
            Program.ServiceProvider, entidad);

        if (form.ShowDialog(this) == DialogResult.OK)
            _ = LoadDataAsync();
    }
}
