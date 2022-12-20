namespace WindowsFormsApplication6
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Файл = new System.Windows.Forms.ToolStripDropDownButton();
            this.загрузитьФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crop = new System.Windows.Forms.ToolStripDropDownButton();
            this.обрезатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.восстановитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contrast = new System.Windows.Forms.ToolStripButton();
            this.toBlackWhite = new System.Windows.Forms.ToolStripButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.imgAbove = new System.Windows.Forms.ToolStripDropDownButton();
            this.loadLayer = new System.Windows.Forms.ToolStripMenuItem();
            this.transparency = new System.Windows.Forms.ToolStripMenuItem();
            this.fontSet = new System.Windows.Forms.ToolStripButton();
            this.text = new System.Windows.Forms.ToolStripTextBox();
            this.add = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(546, 393);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Файл,
            this.crop,
            this.contrast,
            this.toBlackWhite,
            this.imgAbove,
            this.fontSet,
            this.text,
            this.add});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(575, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Файл
            // 
            this.Файл.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Файл.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.загрузитьФайлToolStripMenuItem,
            this.сохранитьФайлToolStripMenuItem});
            this.Файл.Image = ((System.Drawing.Image)(resources.GetObject("Файл.Image")));
            this.Файл.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Файл.Name = "Файл";
            this.Файл.Size = new System.Drawing.Size(49, 22);
            this.Файл.Text = "Файл";
            // 
            // загрузитьФайлToolStripMenuItem
            // 
            this.загрузитьФайлToolStripMenuItem.Name = "загрузитьФайлToolStripMenuItem";
            this.загрузитьФайлToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.загрузитьФайлToolStripMenuItem.Text = "Загрузить файл";
            this.загрузитьФайлToolStripMenuItem.Click += new System.EventHandler(this.openfile);
            // 
            // сохранитьФайлToolStripMenuItem
            // 
            this.сохранитьФайлToolStripMenuItem.Enabled = false;
            this.сохранитьФайлToolStripMenuItem.Name = "сохранитьФайлToolStripMenuItem";
            this.сохранитьФайлToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.сохранитьФайлToolStripMenuItem.Text = "Сохранить файл";
            this.сохранитьФайлToolStripMenuItem.Click += new System.EventHandler(this.savefile);
            // 
            // crop
            // 
            this.crop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.crop.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.обрезатьToolStripMenuItem,
            this.восстановитьToolStripMenuItem});
            this.crop.Enabled = false;
            this.crop.Image = ((System.Drawing.Image)(resources.GetObject("crop.Image")));
            this.crop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.crop.Name = "crop";
            this.crop.Size = new System.Drawing.Size(66, 22);
            this.crop.Text = "Обрезка";
            // 
            // обрезатьToolStripMenuItem
            // 
            this.обрезатьToolStripMenuItem.Name = "обрезатьToolStripMenuItem";
            this.обрезатьToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.обрезатьToolStripMenuItem.Text = "Обрезать";
            this.обрезатьToolStripMenuItem.Click += new System.EventHandler(this.обрезатьToolStripMenuItem_Click);
            // 
            // восстановитьToolStripMenuItem
            // 
            this.восстановитьToolStripMenuItem.Name = "восстановитьToolStripMenuItem";
            this.восстановитьToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.восстановитьToolStripMenuItem.Text = "Восстановить";
            this.восстановитьToolStripMenuItem.Click += new System.EventHandler(this.восстановитьToolStripMenuItem_Click);
            // 
            // contrast
            // 
            this.contrast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.contrast.Enabled = false;
            this.contrast.Image = ((System.Drawing.Image)(resources.GetObject("contrast.Image")));
            this.contrast.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.contrast.Name = "contrast";
            this.contrast.Size = new System.Drawing.Size(61, 22);
            this.contrast.Text = "Контраст";
            this.contrast.Click += new System.EventHandler(this.contrast_Click);
            // 
            // toBlackWhite
            // 
            this.toBlackWhite.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toBlackWhite.Enabled = false;
            this.toBlackWhite.Image = ((System.Drawing.Image)(resources.GetObject("toBlackWhite.Image")));
            this.toBlackWhite.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toBlackWhite.Name = "toBlackWhite";
            this.toBlackWhite.Size = new System.Drawing.Size(31, 22);
            this.toBlackWhite.Text = "Ч/Б";
            this.toBlackWhite.Click += new System.EventHandler(this.toBlackWhite_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // imgAbove
            // 
            this.imgAbove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.imgAbove.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadLayer,
            this.transparency});
            this.imgAbove.Enabled = false;
            this.imgAbove.Image = ((System.Drawing.Image)(resources.GetObject("imgAbove.Image")));
            this.imgAbove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.imgAbove.Name = "imgAbove";
            this.imgAbove.Size = new System.Drawing.Size(84, 22);
            this.imgAbove.Text = "Наложение";
            // 
            // loadLayer
            // 
            this.loadLayer.Name = "loadLayer";
            this.loadLayer.Size = new System.Drawing.Size(182, 22);
            this.loadLayer.Text = "Загрузить слой";
            this.loadLayer.Click += new System.EventHandler(this.loadLayer_Click);
            // 
            // transparency
            // 
            this.transparency.Name = "transparency";
            this.transparency.Size = new System.Drawing.Size(182, 22);
            this.transparency.Text = "Прозрачность слоя";
            this.transparency.Click += new System.EventHandler(this.transparency_Click_1);
            // 
            // fontSet
            // 
            this.fontSet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fontSet.Enabled = false;
            this.fontSet.Image = ((System.Drawing.Image)(resources.GetObject("fontSet.Image")));
            this.fontSet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fontSet.Name = "fontSet";
            this.fontSet.Size = new System.Drawing.Size(50, 22);
            this.fontSet.Text = "Шрифт";
            this.fontSet.Click += new System.EventHandler(this.fontSet_Click);
            // 
            // text
            // 
            this.text.Enabled = false;
            this.text.Name = "text";
            this.text.Size = new System.Drawing.Size(100, 25);
            // 
            // add
            // 
            this.add.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.add.Image = ((System.Drawing.Image)(resources.GetObject("add.Image")));
            this.add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(94, 22);
            this.add.Text = "Добавить текст";
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 432);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Обрезка и контрастность";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem загрузитьФайлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьФайлToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton Файл;
        private System.Windows.Forms.ToolStripDropDownButton crop;
        private System.Windows.Forms.ToolStripMenuItem обрезатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem восстановитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton contrast;
        /// <summary>
        /// Основной элемент формы - контейнер для изображения, в котором производятся все операции по редактированию.
        /// </summary>
        public System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripButton toBlackWhite;
        private System.Windows.Forms.ToolStripDropDownButton imgAbove;
        private System.Windows.Forms.ToolStripMenuItem loadLayer;
        private System.Windows.Forms.ToolStripMenuItem transparency;
        private System.Windows.Forms.ToolStripButton fontSet;
        private System.Windows.Forms.ToolStripTextBox text;
        private System.Windows.Forms.ToolStripButton add;
    }
}

