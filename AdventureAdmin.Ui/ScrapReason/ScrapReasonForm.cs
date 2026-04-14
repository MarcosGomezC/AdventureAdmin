using AdventureAdmin.Ui.Services;
using ScrapReasonModel = AdventureAdmin.Data.Models.ScrapReason;

namespace AdventureAdmin.Ui.ScrapReason;

public partial class ScrapReasonForm : Form
{
    private readonly ScrapReasonService _service;
    private readonly ScrapReasonModel? _entidad;

    public ScrapReasonForm(ScrapReasonService service) : this(service, null) { }

    public ScrapReasonForm(ScrapReasonService service, ScrapReasonModel? entidad)
    {
        InitializeComponent();
        _service = service;
        _entidad = entidad;

        if (_entidad != null)
            CargarDatos(_entidad);
    }

    private void CargarDatos(ScrapReasonModel e)
    {
        txtNombre.Text = e.Name;
    }

    private async void btnGuardar_Click(object sender, EventArgs e)
    {
        var nombre = txtNombre.Text.Trim();
        if (string.IsNullOrWhiteSpace(nombre))
        {
            MessageBox.Show("El nombre es obligatorio.");
            txtNombre.Focus();
            return;
        }

        bool ok;
        if (_entidad == null)
            ok = await Insertar(nombre);
        else
            ok = await Actualizar(nombre);

        if (!ok)
        {
            MessageBox.Show("No se pudo guardar el registro.");
            return;
        }

        DialogResult = DialogResult.OK;
        Close();
    }

    private async Task<bool> Insertar(string nombre)
    {
        var scrapReason = new ScrapReasonModel { Name = nombre };
        return await _service.Insertar(scrapReason);
    }

    private async Task<bool> Actualizar(string nombre)
    {
        var db = await _service.Buscar((int)_entidad!.ScrapReasonId);
        if (db == null)
            return false;

        db.Name = nombre;
        return await _service.Actualizar(db);
    }

    private void btnCancelar_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }
}
