
namespace WindowsFormsApplication6
{
    partial class multiLayerForm
    {
        /// <summary>
        /// Требуемая переменная для корректной работы дизайнера форм.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Очистка использованных ресурсов.
        /// </summary>
        /// <param name="disposing">Если передано true, то производится очистка ресурсов.</param>
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
            this.transparencyScroll = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.transparencyScroll)).BeginInit();
            this.SuspendLayout();
            // 
            // transparencyScroll
            // 
            this.transparencyScroll.Location = new System.Drawing.Point(12, 12);
            this.transparencyScroll.Maximum = 1000;
            this.transparencyScroll.Name = "transparencyScroll";
            this.transparencyScroll.Size = new System.Drawing.Size(374, 45);
            this.transparencyScroll.TabIndex = 1;
            this.transparencyScroll.ValueChanged += new System.EventHandler(this.transparencyScroll_ValueChanged);
            // 
            // multiLayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 64);
            this.Controls.Add(this.transparencyScroll);
            this.Name = "multiLayerForm";
            this.Text = "Прозрачность";
            ((System.ComponentModel.ISupportInitialize)(this.transparencyScroll)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar transparencyScroll;
    }
}