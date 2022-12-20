using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication6
{
    /// <summary>
    /// Класс первичной формы, открывающейся при запуске программы.
    /// В основном содержит методы, обрабатывающие события "нажатие кнопки", обработчики обрезки изображения, наложения текста на изображение, управления прозрачностью накладываемого на исходное изображения.
    /// </summary>
    public partial class Form1 : Form
    {
        Graphics gr;
        BufferedGraphicsContext context;
        BufferedGraphics doublegr;
        Pen selectionPen;
        contrastForm f2;
        /// <summary>
        /// Обрезанное изображение. Такая буферизация позволяет откат к исходному изображению, что остается неизменным. 
        /// </summary>
        public Bitmap Cropped;
        /// <summary>
        /// Накладываемое изображение (поверх исходного), к которому применены настройки прозрачности
        /// </summary>
        public Bitmap SourceBitmapFGVis;
        /// <summary>
        /// Результирующее изображение.
        /// </summary>
        public Bitmap result;
        /// <summary>
        /// Параметр прозрачности 2 изображения (наложения поверх)
        /// </summary>
        public double vis = 0.800;
        multiLayerForm f3;
        /// <summary>
        /// Накладываемое изображение (поверх исходного)
        /// </summary>
        public Bitmap SourceBitmapFG;
        /// <summary>
        /// Исходное изображение
        /// </summary>
        public Bitmap SourceBitmap;
        bool isSelectionEnabled;
        bool Progress;
        Point SelectionInitial;
        Rectangle SelectionRect;

        Color drawColor = Color.Black;
        Font drawFont = new Font("arial", 36, FontStyle.Bold);

        bool cropped = false;

        /// <summary>
        /// Инициализация первичной формы с определением параметров выделения (для обрезки).
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            selectionPen = new Pen(Color.Yellow); //Желтый цвет рамки выделения
            selectionPen.DashStyle = DashStyle.Dash; //Тип линии - пунктир

            isSelectionEnabled = false; //По умолчанию режим выделения выключен
            SelectionRect = new Rectangle(); //Тип выделения - прямоугольник
        }

        /// <summary>
        /// Заполнение pictureBox'а загруженным изображением.
        /// </summary>
        /// <param name="image"></param>
        public void loadpic(Image image)
        {
            this.Width += image.Width - pictureBox1.Width;
            this.Height += image.Height - pictureBox1.Height;
            pictureBox1.Image = image;
            gr = pictureBox1.CreateGraphics();
            context = new BufferedGraphicsContext();
            doublegr = context.Allocate(gr, this.ClientRectangle);
        }

        /// <summary>
        /// Обработчик события "Нажата копка "Открыть файл". Открывает диалог открытия файла.
        /// </summary>
        public void openfile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "PNG (.png)|*.png|JPEG (.jpg)|*.jpg|BMP (.bmp)|*.bmp";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                SourceBitmap = (Bitmap)Image.FromFile(openFileDialog1.FileName);
                loadpic(SourceBitmap);
                сохранитьФайлToolStripMenuItem.Enabled = true;
                contrast.Enabled = crop.Enabled = true;
                toBlackWhite.Enabled = imgAbove.Enabled = true;
                text.Enabled = fontSet.Enabled = true;
            }
        }

        /// <summary>
        /// Обработчик события "Нажата кнопка "Сохранить файл". Открывает диалог сохранения."
        /// </summary>
        public void savefile(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Bitmap Image |*.bmp|Gif image |*.gif |JPEG image| *.jpg |PNG image |*.png";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                pictureBox1.Image.Save(saveFileDialog1.FileName);
        }
        /// <summary>
        /// Обработчик процесса обрезки. После отпускания мыши отрисовываем выделенный ранее прямоугольник в picturebox'е.
        /// </summary>
        public void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (isSelectionEnabled)
            {
                isSelectionEnabled = true;
                Bitmap ResultBitmap = CropImage(pictureBox1.Image, SelectionRect);
                loadpic((Image)ResultBitmap);
            }
            isSelectionEnabled = Progress = false;
            this.Cursor = Cursors.Arrow;
        }

        /// <summary>
        /// Копируем обрезанный фрагмент (для того, чтобы сохранить возможность возврата к исходному изображению. ы
        /// </summary>
        /// <param name="image"></param>
        /// <param name="selection"></param>
        /// <returns></returns>
        public Bitmap CropImage(Image image, Rectangle selection)
        {
            Bitmap pic = new Bitmap(image);
            Cropped = pic.Clone(selection, pic.PixelFormat);
            cropped = true;
            return Cropped;
        }
        /// <summary>
        /// Обработчик процесса обрезки. Если режим обрезки активен, то курсор, помещенный в область pictureBox'а принимает форму перекрестья (для удобства пользователя). 
        /// </summary>
        public void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            if (isSelectionEnabled)
                this.Cursor = Cursors.Cross;
        }

        /// <summary>
        /// Обработчик события "Нажата кнопка "Обрезать". Включает/выключает режим обрезки.
        /// </summary>
        public void обрезатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isSelectionEnabled = !isSelectionEnabled;
        }

        /// <summary>
        /// Обработчик процесса обрезки. Если зажата ЛКМ и обрезка активна, то ставим в точку нажатия опорную точку выделения.
        /// Активируем процесс обрезки.
        /// </summary>
        public void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Progress = true;
            if (isSelectionEnabled)
            {
                this.Cursor = Cursors.Cross;
                SelectionInitial = new Point(e.X, e.Y);
                SelectionRect.Location = SelectionInitial;
            }
        }
        /// <summary>
        /// Обработчик процесса обрезки. Если процесс активен, то в зависимости от движения мыши (param e) и опорной точки выделения определяем зону выделения.
        /// Выделение - всегда вправо и вниз. 
        /// </summary>
        /// <param name="e"></param>
        public void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Progress)
            {
                if (e.X < SelectionInitial.X)
                    SelectionRect.X = e.X;
                else
                    SelectionRect.X = SelectionInitial.X;

                if (e.Y < SelectionInitial.Y)
                    SelectionRect.Y = e.Y;
                else
                    SelectionRect.Y = SelectionInitial.Y;
                SelectionRect.Width = Math.Abs(e.X - SelectionInitial.X);
                SelectionRect.Height = Math.Abs(e.Y - SelectionInitial.Y);
                doublegr.Graphics.Clear(Color.Transparent);
                doublegr.Graphics.DrawImage(pictureBox1.Image, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
                doublegr.Graphics.DrawRectangle(selectionPen, SelectionRect);
                doublegr.Render();
            }
        }

        /// <summary>
        /// Обработчик события "Нажата кнопка "Восстановить". Отменяет все изменения - возвращает в picturebox загруженный изначально файл. 
        /// </summary>
        public void восстановитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadpic((Image)SourceBitmap);
            cropped = false;
        }
        /// <summary>
        /// Обработчик события "Нажата кнопка "Контрастность". Запускает форму с управлением контрастностью. 
        /// </summary>
        public void contrast_Click(object sender, EventArgs e)
        {
            f2 = new contrastForm(this);
            f2.ShowDialog();
        }

        /// <summary>
        /// Обработчик события "Нажата кнопка "Ч/Б". Каждый пиксель изображения конвертируется по правилу: 0,3R, 0.59G, 0.11B - получаем оттенки серого.
        /// </summary>
        public void toBlackWhite_Click(object sender, EventArgs e)
        {
            Bitmap buf = new Bitmap(pictureBox1.Image);
            for (int y = 0; y < pictureBox1.Image.Height; y++)
            {
                for (int x = 0; x < pictureBox1.Image.Width; x++)
                {
                    Color c = buf.GetPixel(x, y);
                    byte rgb = (byte)(0.3 * c.R + 0.59 * c.G + 0.11 * c.B);
                    buf.SetPixel(x, y, Color.FromArgb(c.A, rgb, rgb, rgb));
                }
                pictureBox1.Image = (Image)buf;
            }
        }
        /// <summary>
        /// Обработчик события "Нажата кнопка "Загрузить слой". Открывает файловый диалог с открытием файла. После успешного открытия запускает функцию visibility.
        /// </summary>
        public void loadLayer_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "PNG (.png)|*.png|JPEG (.jpg)|*.jpg|BMP (.bmp)|*.bmp";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                SourceBitmapFG = (Bitmap)Image.FromFile(openFileDialog1.FileName);
                transparency.Enabled = true;
            }
            visibility(vis);
        }

        /// <summary>
        /// Загрузка в picturebox нового слоя изображения с передаваемой в функцию прозрачностью. 
        /// </summary>
        /// <param name="vis"></param>
        public void visibility(double vis)
        {
            SourceBitmapFGVis = new Bitmap(SourceBitmapFG.Width, SourceBitmapFG.Height);
            Graphics g = Graphics.FromImage(SourceBitmapFGVis);
            ColorMatrix mtr = new ColorMatrix();
            mtr.Matrix33 = (float)vis;
            ImageAttributes picattr = new ImageAttributes();
            picattr.SetColorMatrix(mtr, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            g.DrawImage(SourceBitmapFG, new Rectangle(0, 0, SourceBitmapFGVis.Width, SourceBitmapFGVis.Height), 0, 0, SourceBitmapFG.Width, SourceBitmapFG.Height, GraphicsUnit.Pixel, picattr);
            pictureBox1.Image = SourceBitmapFGVis;
            g.Dispose();
        }

        /// <summary>
        /// Применение настроек, указанных в дочерней форме с настройками прозрачности. 
        /// </summary>
        public void showresult()
        {
            result = new Bitmap(pictureBox1.Image.Width, pictureBox1.Image.Height);
            Graphics g = Graphics.FromImage(result);
            if (cropped)
                g.DrawImage(Cropped, 0, 0, result.Width, result.Height);
           else
                g.DrawImage(SourceBitmap, 0, 0, result.Width, result.Height);
            g.DrawImage(SourceBitmapFGVis, 0, 0, SourceBitmapFGVis.Width, SourceBitmapFGVis.Height);
            pictureBox1.Image = result;
        }
        /// <summary>
        /// Обработчик события "Нажата кнопка "Прозрачность". Открывает другую форму для настроек.
        /// </summary>
        public void transparency_Click_1(object sender, EventArgs e)
        {
            f3 = new multiLayerForm(this);
            f3.ShowDialog();
        }
        /// <summary>
        /// Обработчик события "Нажата кнопка "Шрифт". Открывает диалог настройки шрифта - выбранные параметры изменяют параметры по умолчанию: "Arial 36px".
        /// </summary>
        public void fontSet_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog1 = new FontDialog();
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                drawFont = fontDialog1.Font;
            }
        }
        /// <summary>
        /// Обработчик события "Нажата кнопка "Добавить текст". Выделяет внизу по середине прямоугольник, который заполняется текстом их TextBox'а.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void add_Click(object sender, EventArgs e)
        {
            string letters = text.Text; //Получение текста из текстового поля
            int height = Convert.ToInt32(pictureBox1.Height * 0.80); //Ширина прямоугольника с текстом - 80% высоты изображения
            Bitmap pic = new Bitmap(pictureBox1.Image);
            Graphics g = Graphics.FromImage(pic);
            Rectangle rect = new Rectangle(15, 30, pictureBox1.Width, height); //Создание прямоугольника от (15;30) во всю длину picturebox'a и с заданной выше шириной
            StringFormat format = new StringFormat();
            TextFormatFlags flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.Bottom; //Текст по центру и внизу прямоугольника
            TextRenderer.DrawText(g, letters, drawFont, rect, drawColor, flags); //Отрисовка текста в прямоугольнике
            pictureBox1.Image = pic; //Обновление picturebox'а
            pictureBox1.Invalidate();
        }
    }
}