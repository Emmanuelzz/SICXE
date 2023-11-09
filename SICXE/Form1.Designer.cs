namespace SICXE
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.analizar = new System.Windows.Forms.Button();
            this.dt_TabSim = new System.Windows.Forms.DataGridView();
            this.SIMBOLO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DIRECCION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TIPO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtg_archIn = new System.Windows.Forms.DataGridView();
            this.Linea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Formato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Etiq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Inst = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MOD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CODOP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ERRORES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tam = new System.Windows.Forms.Label();
            this.registros = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dt_TabSim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_archIn)).BeginInit();
            this.SuspendLayout();
            // 
            // analizar
            // 
            this.analizar.Location = new System.Drawing.Point(42, 27);
            this.analizar.Name = "analizar";
            this.analizar.Size = new System.Drawing.Size(75, 23);
            this.analizar.TabIndex = 0;
            this.analizar.Text = "ANALIZAR";
            this.analizar.UseVisualStyleBackColor = true;
            this.analizar.Visible = false;
            // 
            // dt_TabSim
            // 
            this.dt_TabSim.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dt_TabSim.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SIMBOLO,
            this.DIRECCION,
            this.TIPO});
            this.dt_TabSim.Location = new System.Drawing.Point(872, 56);
            this.dt_TabSim.Name = "dt_TabSim";
            this.dt_TabSim.Size = new System.Drawing.Size(299, 150);
            this.dt_TabSim.TabIndex = 1;
            // 
            // SIMBOLO
            // 
            this.SIMBOLO.HeaderText = "SIMBOLO";
            this.SIMBOLO.Name = "SIMBOLO";
            this.SIMBOLO.ReadOnly = true;
            this.SIMBOLO.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // DIRECCION
            // 
            this.DIRECCION.HeaderText = "DIRECCION/VALOR";
            this.DIRECCION.MaxInputLength = 100;
            this.DIRECCION.Name = "DIRECCION";
            this.DIRECCION.ReadOnly = true;
            this.DIRECCION.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DIRECCION.Width = 110;
            // 
            // TIPO
            // 
            this.TIPO.FillWeight = 50F;
            this.TIPO.HeaderText = "TIPO";
            this.TIPO.MaxInputLength = 10;
            this.TIPO.Name = "TIPO";
            this.TIPO.ReadOnly = true;
            this.TIPO.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.TIPO.Width = 40;
            // 
            // dtg_archIn
            // 
            this.dtg_archIn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_archIn.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Linea,
            this.Formato,
            this.CP,
            this.Etiq,
            this.Inst,
            this.OP,
            this.MOD,
            this.CODOP,
            this.ERRORES});
            this.dtg_archIn.Location = new System.Drawing.Point(42, 56);
            this.dtg_archIn.Name = "dtg_archIn";
            this.dtg_archIn.Size = new System.Drawing.Size(823, 462);
            this.dtg_archIn.TabIndex = 3;
            // 
            // Linea
            // 
            this.Linea.HeaderText = "Linea";
            this.Linea.Name = "Linea";
            this.Linea.Width = 108;
            // 
            // Formato
            // 
            this.Formato.HeaderText = "Formato";
            this.Formato.Name = "Formato";
            this.Formato.Width = 108;
            // 
            // CP
            // 
            this.CP.HeaderText = "CP";
            this.CP.Name = "CP";
            this.CP.Width = 108;
            // 
            // Etiq
            // 
            this.Etiq.HeaderText = "Etiq";
            this.Etiq.Name = "Etiq";
            this.Etiq.Width = 108;
            // 
            // Inst
            // 
            this.Inst.HeaderText = "Inst";
            this.Inst.Name = "Inst";
            this.Inst.Width = 107;
            // 
            // OP
            // 
            this.OP.HeaderText = "OP";
            this.OP.Name = "OP";
            this.OP.Width = 108;
            // 
            // MOD
            // 
            this.MOD.HeaderText = "MOD";
            this.MOD.Name = "MOD";
            this.MOD.Width = 108;
            // 
            // CODOP
            // 
            this.CODOP.HeaderText = "CODOP";
            this.CODOP.Name = "CODOP";
            this.CODOP.Width = 108;
            // 
            // ERRORES
            // 
            this.ERRORES.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ERRORES.HeaderText = "ERRORES";
            this.ERRORES.Name = "ERRORES";
            // 
            // Tam
            // 
            this.Tam.AutoSize = true;
            this.Tam.Location = new System.Drawing.Point(871, 247);
            this.Tam.Name = "Tam";
            this.Tam.Size = new System.Drawing.Size(0, 13);
            this.Tam.TabIndex = 4;
            // 
            // registros
            // 
            this.registros.FormattingEnabled = true;
            this.registros.HorizontalScrollbar = true;
            this.registros.Location = new System.Drawing.Point(874, 275);
            this.registros.Name = "registros";
            this.registros.ScrollAlwaysVisible = true;
            this.registros.Size = new System.Drawing.Size(297, 225);
            this.registros.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1204, 560);
            this.Controls.Add(this.registros);
            this.Controls.Add(this.Tam);
            this.Controls.Add(this.dtg_archIn);
            this.Controls.Add(this.dt_TabSim);
            this.Controls.Add(this.analizar);
            this.Name = "Form1";
            this.Text = "ANALIZADOR";
            ((System.ComponentModel.ISupportInitialize)(this.dt_TabSim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_archIn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button analizar;
        private System.Windows.Forms.DataGridView dt_TabSim;
        private System.Windows.Forms.DataGridView dtg_archIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Linea;
        private System.Windows.Forms.DataGridViewTextBoxColumn Formato;
        private System.Windows.Forms.DataGridViewTextBoxColumn CP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Etiq;
        private System.Windows.Forms.DataGridViewTextBoxColumn Inst;
        private System.Windows.Forms.DataGridViewTextBoxColumn OP;
        private System.Windows.Forms.DataGridViewTextBoxColumn MOD;
        private System.Windows.Forms.DataGridViewTextBoxColumn CODOP;
        private System.Windows.Forms.DataGridViewTextBoxColumn ERRORES;
        private System.Windows.Forms.Label Tam;
        private System.Windows.Forms.ListBox registros;
        private System.Windows.Forms.DataGridViewTextBoxColumn SIMBOLO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DIRECCION;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIPO;
    }
}

