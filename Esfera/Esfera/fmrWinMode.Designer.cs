namespace ejemplo
{
    partial class fmrWinMode
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
            this.components = new System.ComponentModel.Container();
            this.picUFO = new System.Windows.Forms.PictureBox();
            this.tmrUFO = new System.Windows.Forms.Timer(this.components);
            this.tmrCreate = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picUFO)).BeginInit();
            this.SuspendLayout();
            // 
            // picUFO
            // 
            this.picUFO.Location = new System.Drawing.Point(1, 2);
            this.picUFO.Name = "picUFO";
            this.picUFO.Size = new System.Drawing.Size(797, 450);
            this.picUFO.TabIndex = 0;
            this.picUFO.TabStop = false;
            this.picUFO.Click += new System.EventHandler(this.fmrWinMode_Load);
            // 
            // tmrUFO
            // 
            
            // 
            // tmrCreate
            // 
            // fmrWinMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.picUFO);
            this.Name = "fmrWinMode";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picUFO)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picUFO;
        private System.Windows.Forms.Timer tmrUFO;
        private System.Windows.Forms.Timer tmrCreate;
    }
}

