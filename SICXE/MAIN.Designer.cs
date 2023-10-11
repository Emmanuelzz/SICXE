namespace SICXE
{
    partial class MAIN
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
            this.barrasuperior = new System.Windows.Forms.Panel();
            this.cintaopciones = new System.Windows.Forms.Panel();
            this.panelcontenedor = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // barrasuperior
            // 
            this.barrasuperior.BackColor = System.Drawing.SystemColors.Highlight;
            this.barrasuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.barrasuperior.Location = new System.Drawing.Point(0, 0);
            this.barrasuperior.Name = "barrasuperior";
            this.barrasuperior.Size = new System.Drawing.Size(1300, 25);
            this.barrasuperior.TabIndex = 1;
            // 
            // cintaopciones
            // 
            this.cintaopciones.BackColor = System.Drawing.SystemColors.Desktop;
            this.cintaopciones.Location = new System.Drawing.Point(0, 25);
            this.cintaopciones.Name = "cintaopciones";
            this.cintaopciones.Size = new System.Drawing.Size(1301, 47);
            this.cintaopciones.TabIndex = 0;
            // 
            // panelcontenedor
            // 
            this.panelcontenedor.BackColor = System.Drawing.SystemColors.Highlight;
            this.panelcontenedor.Location = new System.Drawing.Point(0, 68);
            this.panelcontenedor.Name = "panelcontenedor";
            this.panelcontenedor.Size = new System.Drawing.Size(1300, 585);
            this.panelcontenedor.TabIndex = 2;
            // 
            // MAIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 650);
            this.Controls.Add(this.panelcontenedor);
            this.Controls.Add(this.barrasuperior);
            this.Controls.Add(this.cintaopciones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MAIN";
            this.Text = "MAIN";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel barrasuperior;
        private System.Windows.Forms.Panel cintaopciones;
        private System.Windows.Forms.Panel panelcontenedor;
    }
}