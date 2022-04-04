namespace movi_escritorio.Presentacion.Personal
{
    partial class PersonalPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PersonalPrincipal));
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotalPersonal = new System.Windows.Forms.Label();
            this.btnNuevoPersonal = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnFicha = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dataListadoPersonal = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cbIncluyeBajas = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataListadoPersonal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.Image = global::movi_escritorio.Properties.Resources.refresh;
            this.btnRefrescar.Location = new System.Drawing.Point(763, 92);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(31, 32);
            this.btnRefrescar.TabIndex = 54;
            this.btnRefrescar.UseVisualStyleBackColor = true;
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 13);
            this.label2.TabIndex = 53;
            this.label2.Text = "Busqueda por apellido o nombre";
            // 
            // lblTotalPersonal
            // 
            this.lblTotalPersonal.AutoSize = true;
            this.lblTotalPersonal.Location = new System.Drawing.Point(648, 134);
            this.lblTotalPersonal.Name = "lblTotalPersonal";
            this.lblTotalPersonal.Size = new System.Drawing.Size(35, 13);
            this.lblTotalPersonal.TabIndex = 52;
            this.lblTotalPersonal.Text = "label2";
            // 
            // btnNuevoPersonal
            // 
            this.btnNuevoPersonal.Location = new System.Drawing.Point(472, 104);
            this.btnNuevoPersonal.Name = "btnNuevoPersonal";
            this.btnNuevoPersonal.Size = new System.Drawing.Size(139, 23);
            this.btnNuevoPersonal.TabIndex = 51;
            this.btnNuevoPersonal.Text = "Nuevo personal";
            this.btnNuevoPersonal.UseVisualStyleBackColor = true;
            this.btnNuevoPersonal.Click += new System.EventHandler(this.btnNuevoPersonal_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(29, 104);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(181, 20);
            this.txtBuscar.TabIndex = 48;
            this.txtBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscar_KeyPress);
            // 
            // btnFicha
            // 
            this.btnFicha.Location = new System.Drawing.Point(310, 104);
            this.btnFicha.Name = "btnFicha";
            this.btnFicha.Size = new System.Drawing.Size(75, 23);
            this.btnFicha.TabIndex = 50;
            this.btnFicha.Text = "Ver ficha";
            this.btnFicha.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(391, 104);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 49;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(229, 104);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 47;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click_1);
            // 
            // dataListadoPersonal
            // 
            this.dataListadoPersonal.AllowUserToAddRows = false;
            this.dataListadoPersonal.AllowUserToDeleteRows = false;
            this.dataListadoPersonal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataListadoPersonal.Location = new System.Drawing.Point(29, 150);
            this.dataListadoPersonal.MultiSelect = false;
            this.dataListadoPersonal.Name = "dataListadoPersonal";
            this.dataListadoPersonal.ReadOnly = true;
            this.dataListadoPersonal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataListadoPersonal.Size = new System.Drawing.Size(765, 291);
            this.dataListadoPersonal.TabIndex = 46;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Impact", 55F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(263, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(309, 91);
            this.label1.TabIndex = 45;
            this.label1.Text = "Personal";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = global::movi_escritorio.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(55, 57);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 44;
            this.pictureBox1.TabStop = false;
            // 
            // cbIncluyeBajas
            // 
            this.cbIncluyeBajas.AutoSize = true;
            this.cbIncluyeBajas.Location = new System.Drawing.Point(651, 104);
            this.cbIncluyeBajas.Name = "cbIncluyeBajas";
            this.cbIncluyeBajas.Size = new System.Drawing.Size(88, 17);
            this.cbIncluyeBajas.TabIndex = 55;
            this.cbIncluyeBajas.Text = "Incluye bajas";
            this.cbIncluyeBajas.UseVisualStyleBackColor = true;
            // 
            // PersonalPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 479);
            this.Controls.Add(this.cbIncluyeBajas);
            this.Controls.Add(this.btnRefrescar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTotalPersonal);
            this.Controls.Add(this.btnNuevoPersonal);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.btnFicha);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dataListadoPersonal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PersonalPrincipal";
            this.Text = "PersonalPrincipal";
            this.Load += new System.EventHandler(this.PersonalPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataListadoPersonal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotalPersonal;
        private System.Windows.Forms.Button btnNuevoPersonal;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnFicha;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dataListadoPersonal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox cbIncluyeBajas;
    }
}