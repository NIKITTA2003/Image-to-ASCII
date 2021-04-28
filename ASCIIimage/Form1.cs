using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Threading;
using System.IO;


namespace ASCIIimage
{
    public partial class Form1 : Form
    {
        Thread[] p = new Thread[2];
        public static string str1 = "";
        public static string str2 = "";
        public static string filePath;
        public static bool vk = false;

        StreamReader read;
        string result;
        string[] frames;
        int frame = 0;
        Font f;
        Graphics g;

        Bitmap map;

        Pen pen = new Pen(Color.White);
        SolidBrush br;
        int lenght;
        public Form1()
        {
            InitializeComponent();
            map = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            g = Graphics.FromImage(map);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            g.Clear(Color.Black);

            br = new SolidBrush(Color.Green);
            f = fontDialog1.Font;
            pictureBox1.Image = map;
        }

        public static void ConvertImage()
        {
            Image img = Image.FromFile(filePath);
            Bitmap bmp = new Bitmap(img, new Size(img.Width, img.Height));
            img.Dispose();
            Rectangle bounds = new Rectangle(0, 0, bmp.Width, bmp.Height);
            ColorMatrix matrix = new ColorMatrix();

            for (int i = 0; i <= 2; i++)
                for (int j = 0; j <= 2; j++)
                    matrix[i, j] = 1 / 3f;
            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(matrix);

            Graphics gphGrey = Graphics.FromImage(bmp);
            gphGrey.DrawImage(bmp, bounds, 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, attributes);

            gphGrey.Dispose();

            int startY, startX, brightness, cY, cX, b, sb;
            Color c;

            for (int h = 0; h < bmp.Height/2; h++)
            {
                 startY = h;

                for (int w = 0; w < bmp.Width; w++)
                {
                     startX = w;

                     brightness = 0;

                    for (int y = 0; y < 10; y++)
                    {
                        for (int x = 0; x < 10; x++)
                        {
                             cY = y + startY;
                             cX = x + startX;

                            try
                            {
                                 c = bmp.GetPixel(cX, cY);
                                 b = (int)(c.GetBrightness() * 10);
                                brightness = (brightness + b);
                            }
                            catch
                            {
                                brightness = (brightness + 10);
                            }
                        }
                    }

                     sb = (brightness / 10);
                    if (vk)
                    {
                        if (sb > 50)
                        {
                            str1 = str1 + 'Ж';
                        }
                        else
                            str1 = str1 + ' ';
                    }
                    else
                    {
                        if (sb > 80)
                        {
                            str1 = str1 + '#';
                        }
                        else if (sb > 75)
                        {
                            str1 = str1 + '@';
                        }
                        else if (sb > 70)
                        {
                            str1 = str1 + 'Ш';
                        }
                        else if (sb > 65)
                        {
                            str1 = str1 + '$';
                        }
                        else if (sb > 60)
                        {
                            str1 = str1 + '&';
                        }
                        else if (sb > 55)
                        {
                            str1 = str1 + 'Ё';
                        }
                        else if (sb > 50)
                        {
                            str1 = str1 + 'Ё';
                        }
                        else if (sb > 45)
                        {
                            str1 = str1 + 'г';
                        }
                        else if (sb > 40)
                        {
                            str1 = str1 + '¤';
                        }
                        else if (sb > 35)
                        {
                            str1 = str1 + '/';
                        }
                        else if (sb > 30)
                        {
                            str1 = str1 + '^';
                        }
                        else if (sb > 25)
                        {
                            str1 = str1 + '~';
                        }
                        else if (sb > 10)
                        {
                            str1 = str1 + '.';
                        }
                        else
                        {
                            str1 = str1 + " ";
                        }
                    }

                }
                    str1 = str1 + '\n';

            }
            bmp.Dispose();
        }

        public static void ConvertImage2()
        {
            Image img = Image.FromFile(filePath);
            Bitmap bmp = new Bitmap(img, new Size(img.Width, img.Height));
            img.Dispose();
            Rectangle bounds = new Rectangle(0, 0, bmp.Width, bmp.Height);
            ColorMatrix matrix = new ColorMatrix();

            for (int i = 0; i <= 2; i++)
                for (int j = 0; j <= 2; j++)
                    matrix[i, j] = 1 / 3f;
            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(matrix);

            Graphics gphGrey = Graphics.FromImage(bmp);
            gphGrey.DrawImage(bmp, bounds, 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, attributes);

            gphGrey.Dispose();

            int startY, startX, brightness, cY, cX, b, sb;
            Color c;

            for (int h = (bmp.Height / 2); h < bmp.Height; h++)
            {
                 startY = h;

                for (int w = 0; w < bmp.Width; w++)
                {
                     startX = w ;

                     brightness = 0;

                    for (int y = 0; y < 10; y++)
                    {
                        for (int x = 0; x < 10; x++)
                        {
                             cY = y + startY;
                             cX = x + startX;

                            try
                            {
                                 c = bmp.GetPixel(cX, cY);
                                 b = (int)(c.GetBrightness() * 10);
                                brightness = (brightness + b);
                            }
                            catch
                            {
                                brightness = (brightness + 10);
                            }
                        }
                    }

                     sb = (brightness / 10);
                    if (vk)
                    {
                        if (sb > 50)
                        {
                            str2 = str2 + 'Ж';
                        }
                        else
                            str2 = str2 + ' ';
                    }
                    else
                    {
                        if (sb > 80)
                        {
                            str2 = str2 + '#';
                        }
                        else if (sb > 75)
                        {
                            str2 = str2 + '@';
                        }
                        else if (sb > 70)
                        {
                            str2 = str2 + 'Ш';
                        }
                        else if (sb > 65)
                        {
                            str2 = str2 + '$';
                        }
                        else if (sb > 60)
                        {
                            str2 = str2 + '&';
                        }
                        else if (sb > 55)
                        {
                            str2 = str2 + 'Ё';
                        }
                        else if (sb > 50)
                        {
                            str2 = str2 + 'Ё';
                        }
                        else if (sb > 45)
                        {
                            str2 = str2 + 'г';
                        }
                        else if (sb > 40)
                        {
                            str2 = str2 + '¤';
                        }
                        else if (sb > 35)
                        {
                            str2 = str2 + '/';
                        }
                        else if (sb > 30)
                        {
                            str2 = str2 + '^';
                        }
                        else if (sb > 25)
                        {
                            str2 = str2 + '~';
                        }
                        else if (sb > 10)
                        {
                            str2 = str2 + '.';
                        }
                        else
                        {
                            str2 = str2 + " ";
                        }
                    }

                }
                str2 = str2 + '\n';

            }
            bmp.Dispose();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                string[] filesname = new string[1];
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    filesname = Directory.GetFiles(folderBrowserDialog1.SelectedPath);



                    StreamWriter SW = new StreamWriter(new FileStream(textBox1.Text + ".txt", FileMode.Create, FileAccess.Write));

                    for (int i = 0; i <= filesname.Length; i++)
                    {

                        filePath = filesname[i];

                        p[0] = new Thread(ConvertImage);
                        p[1] = new Thread(ConvertImage2);
                        p[0].Priority = ThreadPriority.Highest;
                        p[0].Start();
                        p[1].Start();

                        while (!(p[0].IsAlive == false && p[1].IsAlive == false))
                        { }
                        SW.Write(str1 + str2 + "ъ" + "\n");
                        str1 = "";
                        str2 = "";
                    }
                    MessageBox.Show("Готово :)");
                    SW.Close();
                    button2.Enabled = true;
                }
            }
            else
                MessageBox.Show("Задайте имя файла для сохранения");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Width = 1280 ;
            richTextBox1.Height = 720 ;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                read = new StreamReader(openFileDialog1.FileName);
                result = read.ReadToEnd();
                frames = result.Split('ъ');
                timer1.Enabled = true;
                lenght = frames.Length;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (frame < lenght)
            {
                g.Clear(Color.Black);

                g.DrawString(frames[frame].Trim(), f, br, 0, 0);
                pictureBox1.Image = map;
                frame++;
            }
            else
            {
                timer1.Enabled = false;
                frame = 0;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Image.Save("Matrix.jpg");
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            f = new Font(f.Name, trackBar1.Value, f.Style);
        }
    }
}
