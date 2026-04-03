namespace AdventureAdmin.Ui
{
    partial class DepartmentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            label1 = new Label();
            label2 = new Label();
            txtName = new TextBox();
            txtGroupName = new TextBox();
            btnGuardar = new Button();
            errorProvider1 = new ErrorProvider(components);
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(5, 13);
            label1.Name = "label1";
            label1.Size = new Size(158, 15);
            label1.TabIndex = 0;
            label1.Text = "Nombre del Departamento";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(5, 42);
            label2.Name = "label2";
            label2.Size = new Size(111, 15);
            label2.TabIndex = 1;
            label2.Text = "Nombre del Grupo";
            label2.Click += label2_Click;
            // 
            // txtName
            // 
            txtName.Location = new Point(167, 10);
            txtName.Name = "txtName";
            txtName.Size = new Size(227, 23);
            txtName.TabIndex = 2;
            // 
            // txtGroupName
            // 
            txtGroupName.Location = new Point(120, 39);
            txtGroupName.Name = "txtGroupName";
            txtGroupName.Size = new Size(274, 23);
            txtGroupName.TabIndex = 3;
            txtGroupName.TextChanged += txtGroupName_TextChanged;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = SystemColors.Control;
            btnGuardar.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGuardar.ForeColor = Color.Black;
            btnGuardar.Location = new Point(2, 97);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(114, 37);
            btnGuardar.TabIndex = 4;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = SystemColors.Control;
            btnCancelar.Location = new Point(122, 97);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(111, 37);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // DepartmentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(442, 189);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(txtGroupName);
            Controls.Add(txtName);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "DepartmentForm";
            Text = "Formulario de departamento";
            Load += DepartmentForm_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtName;
        private TextBox txtGroupName;
        private Button btnGuardar;
        private ErrorProvider errorProvider1;
        private Button btnCancelar;
    }
}