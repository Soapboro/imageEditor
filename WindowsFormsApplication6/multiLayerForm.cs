using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication6
{
    /// <summary>
    /// Класс формы, управляющей прозрачностью второго слоя изображения. Содержит обработчик движения трекбара прозрачности. 
    /// </summary>
    public partial class multiLayerForm : Form
    {
        Form1 f1;
        public multiLayerForm(Form1 _f1)
        {
            InitializeComponent();
            f1 = _f1;
        }
        
        private void transparencyScroll_ValueChanged(object sender, EventArgs e)
        {
            double vis;
            vis = (double)(transparencyScroll.Value * 0.001);
            f1.visibility(vis);
            f1.showresult();
        }
    }
}
