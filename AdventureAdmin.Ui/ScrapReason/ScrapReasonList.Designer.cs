namespace AdventureAdmin.Ui.ScrapReason;

partial class ScrapReasonList
{
    private System.ComponentModel.IContainer components = null;

    private DataGridView scrapReasonsDataGridView;
    private Button nuevoButton;
    private Button modificarButton;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        scrapReasonsDataGridView = new DataGridView();
        nuevoButton = new Button();
        modificarButton = new Button();
        ((System.ComponentModel.ISupportInitialize)scrapReasonsDataGridView).BeginInit();
        SuspendLayout();
        // 
        // scrapReasonsDataGridView
        // 
        scrapReasonsDataGridView.AllowUserToAddRows = false;
        scrapReasonsDataGridView.AllowUserToDeleteRows = false;
        scrapReasonsDataGridView.AllowUserToOrderColumns = true;
        scrapReasonsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        scrapReasonsDataGridView.Location = new Point(15, 48);
        scrapReasonsDataGridView.Margin = new Padding(4, 4, 4, 4);
        scrapReasonsDataGridView.Name = "scrapReasonsDataGridView";
        scrapReasonsDataGridView.ReadOnly = true;
        scrapReasonsDataGridView.RowHeadersWidth = 51;
        scrapReasonsDataGridView.Size = new Size(970, 500);
        scrapReasonsDataGridView.TabIndex = 0;
        // 
        // nuevoButton
        // 
        nuevoButton.Location = new Point(15, 4);
        nuevoButton.Margin = new Padding(4, 4, 4, 4);
        nuevoButton.Name = "nuevoButton";
        nuevoButton.Size = new Size(118, 36);
        nuevoButton.TabIndex = 1;
        nuevoButton.Text = "✅ Nuevo";
        nuevoButton.UseVisualStyleBackColor = true;
        nuevoButton.Click += nuevoButton_Click;
        // 
        // modificarButton
        // 
        modificarButton.Location = new Point(141, 4);
        modificarButton.Margin = new Padding(4, 4, 4, 4);
        modificarButton.Name = "modificarButton";
        modificarButton.Size = new Size(140, 36);
        modificarButton.TabIndex = 2;
        modificarButton.Text = "✏️ Modificar";
        modificarButton.UseVisualStyleBackColor = true;
        modificarButton.Click += modificarButton_Click;
        // 
        // ScrapReasonList
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1005, 562);
        Controls.Add(modificarButton);
        Controls.Add(nuevoButton);
        Controls.Add(scrapReasonsDataGridView);
        Margin = new Padding(4, 4, 4, 4);
        Name = "ScrapReasonList";
        Text = "ScrapReasonList";
        Load += ScrapReasonList_Load;
        ((System.ComponentModel.ISupportInitialize)scrapReasonsDataGridView).EndInit();
        ResumeLayout(false);
    }
}
