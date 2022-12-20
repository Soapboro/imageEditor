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
    /// Класс формы, управляющей контрастностью изображения.
    /// </summary>
    public partial class contrastForm : Form
    {
        Form1 f1;
        UInt32[,] pixels;
        Bitmap SourceBitmap;
        Bitmap ResultBitmap;
        /// <summary>
        /// Инициализация дочерней формы управления контрастностью. Выгружаем из исходной формы изображение по пикселям, получаем их ARGB-параметры и заносим их в массив.
        /// </summary>
        /// <param name="_f1"></param>
        public contrastForm(Form1 _f1)
        {
            InitializeComponent();
            f1 = _f1;
            SourceBitmap = new Bitmap(f1.pictureBox1.Image);
            ResultBitmap = SourceBitmap;
            pixels = new UInt32[SourceBitmap.Width, SourceBitmap.Height];
            for (int y = 0; y < SourceBitmap.Height; y++)
                for (int x = 0; x < SourceBitmap.Width; x++)
                    pixels[x, y] = (UInt32)(SourceBitmap.GetPixel(x, y).ToArgb());
        }
        /// <summary>
        /// Обработчик события "Нажата кнопка "Подтвердить". Значение трекбара переводим в проценты, изменяем цветность в массиве цветов пикселей. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void contrastButton_Click(object sender, EventArgs e)
        {
            UInt32 temp;
            int N = (100 / trackBar1.Maximum) * trackBar1.Value;
            for (int y = 0; y < SourceBitmap.Height; y++)
                for (int x = 0; x < SourceBitmap.Width; x++)
                {
                    temp = ChangeBrightness(pixels[x, y], N);
                    ResultBitmap.SetPixel(x, y, Color.FromArgb((int)temp));
                }
            f1.pictureBox1.Image = (Image)ResultBitmap;
        }
        /// <summary>
        /// Изменение цветности в массиве. Параметры RGB приводим в соответствие с процентом цветности. 
        /// В шестнадцатеричной системе: R сдвиг на 16 + 1.28N; G сдвиг на 8 + 1.28N; B без сдвига + 1.28N
        /// Если полученные цвета вне (0, 255) - подставляем граничное значение.
        /// Возвращаем цветность пикселя. 
        /// </summary>
        /// <param name="points"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public UInt32 ChangeBrightness(UInt32 points, int N)
        {
            int R = (int)(((points & 0x00FF0000) >> 16) + N * 128 / 100);
            int G = (int)(((points & 0x0000FF00) >> 8) + N * 128 / 100);
            int B = (int)((points & 0x000000FF) + N * 128 / 100);
            if (R < 0) R = 0; if (R > 255) R = 255;
            if (G < 0) G = 0; if (G > 255) G = 255;
            if (B < 0) B = 0; if (B > 255) B = 255;

            points = 0xFF000000 | (((UInt32)R << 16) | ((UInt32)G << 8) | ((UInt32)B));
            return points;
        }
    }
}
