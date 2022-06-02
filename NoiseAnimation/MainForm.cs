using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace NoiseAnimation
{
    public partial class MainForm : Form
    {
        bool tim = true;
        Rectangle rect;
        byte[] arrb;
        Bitmap img;
        int w, h;
        byte[] permutationTable;
        public MainForm()
        {
            InitializeComponent();
        }

        int let;
        int xds = 0;
        int yds = 0;
        private void timerUpt_Tick(object sender, EventArgs e)
        {
            if (let > 1)
            {
                if (xds < w - 1)
                {
                    if (xds >= h - let)
                        lrflag = true;
                    else
                        lrflag = false;

                    for (int yds = 0; yds < h - 1;)
                    {
                        DiamondSquare(xds, yds, xds + let, yds + let);
                        tBIterationCount.Text = "" + IterationCount;
                        yds += let;
                    }
                    IterationCount++;
                    {
                        //yds = 0;
                        xds += let;
                    }
                    if (tim)
                    {
                        Int64 count = 0;
                        for (Int64 j = 0; j < h - 1; j++)
                            for (Int64 i = 0; i < w - 1; i++)
                            {
                                byte k = (byte)(Math.Round((heighmap[i + w * j] - min) / (maxi - min) * 255.0f));
                                arrb[count] = k;
                                arrb[count + 1] = k;
                                arrb[count + 2] = k;
                                count += 4;
                            }

                        BitmapData data = img.LockBits(rect, ImageLockMode.WriteOnly, img.PixelFormat);
                        Marshal.Copy(arrb, 0, data.Scan0, arrb.Length);
                        img.UnlockBits(data);
                        noise.Invalidate();
                        //img.Save("" + numb + ".png", ImageFormat.Png);
                    }
                }
                else
                {
                    let /= 2;
                    xds = 0;
                    if (timerUpt.Interval != 1)
                    {
                        timerUpt.Interval /= 2;
                    }
                }
            }
            else
            {
                timerUpt.Enabled = false;

            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            w = noise.Width;
            h = noise.Height;

            let = (h - 1);

            rect = new Rectangle(0, 0, w, h);

            arrb = new byte[w * h * 4];
            for (int i = 0; i < arrb.Length; i += 4)
            {
                arrb[i + 3] = 255;
            }

            img = new Bitmap(w, h, PixelFormat.Format32bppRgb);
            noise.Image = img;

            //timerUpt.Enabled = true;

        }

        private void buttond_Click(object sender, EventArgs e)
        {
            if (timerUpt.Enabled)
            {
                timerUpt.Enabled = false;
                tim = false;
                cBTurnAnimation.Checked = false;
            }
            h = w = int.Parse(tBSizeNoise.Text);
            let = h;
            xds = 0;
            yds = 0;
            ushort seed;
            if (ushort.TryParse(tBSeedNoise.Text, out seed))
            {
                DiamondSquareNoise(seed, false, 1);

                if (tim)
                    timerUpt.Enabled = true;
                else
                    timno();
            }
            else
                MessageBox.Show("ошибка в сиде");

        }

        VectorXY[] octavesOffsettim;

        private void buttonp_Click(object sender, EventArgs e)
        {
            if (timerUpt.Enabled)
            {
                timerUptper.Enabled = false;
                tim = false;
                cBTurnAnimation.Checked = false;
            }

            h = w = int.Parse(tBSizeNoise.Text);

            ushort seed;
            if (ushort.TryParse(tBSeedNoise.Text, out seed))
            {
                if (tim)
                {
                    Perlin2D(seed);
                    noiseMap = new float[w * h];
                    Int64 count = 0;
                    for (Int64 i = 0; i < w * h; i++)
                    {
                        byte k = permutationTable[i];
                        noiseMap[i] = (float)permutationTable[i];
                        arrb[count] = k;
                        arrb[count + 1] = k;
                        arrb[count + 2] = k;
                        count += 4;
                    }
                    BitmapData data = img.LockBits(rect, ImageLockMode.WriteOnly, img.PixelFormat);
                    Marshal.Copy(arrb, 0, data.Scan0, arrb.Length);
                    img.UnlockBits(data);
                    noise.Invalidate();

                    VectorXY offset = new VectorXY(0, 0);

                    //Порождающий элемент
                    randtim = new System.Random(1);

                    //Сдвиг октав
                    octavesOffsettim = new VectorXY[3];
                    for (int i = 0; i < 3; i++)
                    {
                        float xOffset = randtim.Next(-100000, 100000) + offset.x;
                        float yOffset = randtim.Next(-100000, 100000) + offset.y;
                        octavesOffsettim[i] = new VectorXY(xOffset / w, yOffset / h);
                    }

                    //Учитываем половину ширины и высоты
                    halfWidthtim = w / 2f;
                    halfHeighttim = h / 2f;
                    timerUptper.Enabled = true;
                }
                else
                {
                    PerlineNoise(w, h, seed, seed);
                    Int64 count = 0;
                    for (Int64 j = 0; j < h; j++)
                        for (Int64 i = 0; i < w; i++)
                        {
                            byte k = (byte)(Math.Round(noiseMap[i + w * j] * 255.0f));
                            arrb[count] = k;
                            arrb[count + 1] = k;
                            arrb[count + 2] = k;
                            count += 4;
                        }
                    BitmapData data = img.LockBits(rect, ImageLockMode.WriteOnly, img.PixelFormat);
                    Marshal.Copy(arrb, 0, data.Scan0, arrb.Length);
                    img.UnlockBits(data);
                    noise.Invalidate();
                }
            }
            else
                MessageBox.Show("Ошибка в сиде");
        }

        private void timno()
        {
            for (int let = (h - 1); let > 1; let /= 2)
                for (int x = 0; x < w - 1; x += let)
                {
                    if (x >= h - let)
                        lrflag = true;
                    else
                        lrflag = false;

                    for (int y = 0; y < h - 1; y += let)
                    {
                        DiamondSquare(x, y, x + let, y + let);
                        IterationCount++;


                    }
                }
            Int64 count = 0;
            for (Int64 j = 0; j < h - 1; j++)
                for (Int64 i = 0; i < w - 1; i++)
                {
                    byte k = (byte)(Math.Round((heighmap[i + w * j] - min) / (maxi - min) * 255.0f));
                    arrb[count] = k;
                    arrb[count + 1] = k;
                    arrb[count + 2] = k;
                    count += 4;
                }
            BitmapData data = img.LockBits(rect, ImageLockMode.WriteOnly, img.PixelFormat);
            Marshal.Copy(arrb, 0, data.Scan0, arrb.Length);
            img.UnlockBits(data);
            noise.Invalidate();
            tBIterationCount.Text = "" + IterationCount;
        }


        public static float[] heighmap;
        //Определяет разницу высот
        private static float roughness = 1.0f;
        private static Random randds;
        public static float maxi, min;
        private static bool lrflag = false;
        Int64 IterationCount = 0;

        public void DiamondSquareNoise(UInt16 seed, bool rectangle, float RMin = 0.3f, float RMax = 0.6f)
        {
            randds = new Random(seed);
            if (RMin > RMax)
            {
                RMax += RMin;
                RMin = RMax - RMin;
                RMax -= RMin;
            }
            h = w = w + 1;


            //Начальные значения по краям карты

            heighmap = new float[w * h];

            heighmap[0] = 0;
            heighmap[w * (h - 1)] = 0.5f;
            heighmap[w * h - 1] = 1;
            heighmap[w - 1] = 0.5f;

            maxi = RMax;
            min = RMin;

        }

        private void DiamondSquare(int lx, int ly, int rx, int ry)
        {
            //Сторона текущего квадрата
            int l = (rx - lx) / 2;

            //Расчёт центра квадрата
            Square(lx, ly, rx, ry);

            //Расчёт углов ромба
            Diamond(lx, ly + l, l);
            Diamond(rx, ry - l, l);
            Diamond(rx - l, ry, l);
            Diamond(lx + l, ly, l);
        }

        private void noise_DoubleClick(object sender, EventArgs e)
        {
            img.Save("img.png", ImageFormat.Png);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            noise.Size = new Size(int.Parse(tBSizeNoise.Text), int.Parse(tBSizeNoise.Text));
            MainForm_Load(sender, e);
            w = noise.Width;
            h = noise.Height;
            IterationCount = 0;
            noise.Update();
        }

        private void Square(int lx, int ly, int rx, int ry)
        {
            //Сторона текущего квадрата
            int l = (rx - lx) / 2;

            float a, b, c, d;

            //Получаем углы текущего квадрата
            a = heighmap[lx + w * ly];              //  А-------C
            b = heighmap[lx + w * ry];              //  |       |
            c = heighmap[rx + w * ly];              //  |   c   |
            d = heighmap[rx + w * ry];              //  |       |        
            //Координаты центра квадрата                //  В-------D
            int centerX = lx + l;
            int centerY = ly + l;

            //Новая точка на основе среднего и случайного кофицента
            float z = l * 2 * roughness / h;
            heighmap[centerX + w * centerY] = (a + b + c + d) / 4 + (float)(randds.NextDouble() * (z - (-z)) + (-z));
            //Вычисляем общий диапазон
            if (maxi < heighmap[centerX + w * centerY])
                maxi = heighmap[centerX + w * centerY];
            if (min > heighmap[centerX + w * centerY])
                min = heighmap[centerX + w * centerY];
        }

        private void Diamond(int tgx, int tgy, int l)
        {
            float a, b, c, d;

            //Полчение углов ромба
            if (tgy - l >= 0)
                a = heighmap[tgx + w * (tgy - l)];             //      A--------
            else                                               //      |        |
                a = heighmap[tgx + w * (h - l)];               // B---t g----D  |
                                                               //      |        |
                                                               //      C--------
            if (tgx - l >= 0)
                b = heighmap[(tgx - l) + w * tgy];
            else
                if (lrflag)
                b = heighmap[(w - l) + w * tgy - 1];
            else
                b = heighmap[(h - l) + w * tgy - 1];


            if (tgy + l < h)
                c = heighmap[tgx + w * (tgy + l)];
            else
                c = heighmap[tgx + w * l];


            if (lrflag)
            {
                if (tgx + l < w)
                    d = heighmap[(tgx + l) + 1 + w * tgy];
                else
                    d = heighmap[l + 1 + w * tgy];
            }
            else
            {
                if (tgx + l < h)
                    d = heighmap[(tgx + l) + w * tgy];
                else
                    d = heighmap[l + w * tgy];
            }

            //Новая точка на основе среднего и случайного кофицента
            float z = l * 2 * roughness / h;
            heighmap[tgx + w * tgy] = (a + b + c + d) / 4 + (float)(randds.NextDouble() * (z - (-z)) + (-z));
            //Вычисляем общий диапазон
            if (maxi < heighmap[tgx + w * tgy])
                maxi = heighmap[tgx + w * tgy];
            if (min > heighmap[tgx + w * tgy])
                min = heighmap[tgx + w * tgy];
        }

        private struct VectorXY
        {
            public VectorXY(float X, float Y)
            {
                x = X;
                y = Y;
            }
            public float x;
            public float y;
        }
        //Карта шума
        private float[] noiseMap;

        public float[] PerlineNoise(int width, int height, int seedOctaveShift = 1, int seedPermutationTable = 1, float scale = 100, int octaves = 3, float persistence = 0.5f, float lacunarity = 2, float startX = 0, float startY = 0)
        {
            w = width;
            h = height;
            //Массив данных о вершинах
            noiseMap = new float[w * h];

            Perlin2D(seedPermutationTable);

            VectorXY offset = new VectorXY(startX, startY);

            //Порождающий элемент
            System.Random rand = new System.Random(seedOctaveShift);

            //Сдвиг октав
            VectorXY[] octavesOffset = new VectorXY[octaves];
            for (int i = 0; i < octaves; i++)
            {
                float xOffset = rand.Next(-100000, 100000) + offset.x;
                float yOffset = rand.Next(-100000, 100000) + offset.y;
                octavesOffset[i] = new VectorXY(xOffset / w, yOffset / h);
            }

            if (scale < 0)
            {
                scale = 0.0001f;
            }

            //Учитываем половину ширины и высоты
            float halfWidth = w / 2f;
            float halfHeight = h / 2f;

            //Генерируем точки на карте высот
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    //Задаём значения для первой октавы
                    float amplitude = 1;
                    float frequency = 1;
                    float noiseHeight = 0;
                    float superpositionCompensation = 0;

                    //Обработка наложения октав
                    for (int i = 0; i < octaves; i++)
                    {
                        //Рассчет координаты для получения значения из шума перлина
                        float xResult = (x - halfWidth) / scale * frequency + octavesOffset[i].x * frequency;
                        float yResult = (y - halfHeight) / scale * frequency + octavesOffset[i].y * frequency;

                        //Получение высоты из шума
                        float generatedValue = NoisePerline(xResult, yResult);
                        //Наложение октав
                        noiseHeight += generatedValue * amplitude;
                        //Компенсируем наложение октав чтобы остаться в границах диапазона [-1,1]
                        noiseHeight -= superpositionCompensation;

                        // Расчёт амплитуды, частоты и компенсации для следующей октавы
                        amplitude *= persistence;
                        frequency *= lacunarity;
                        superpositionCompensation = amplitude / 2;
                    }

                    // Из-за наложения октав есть вероятность выхода за границы диапазона [-1,1]
                    if (noiseHeight < -1.0f)
                        noiseHeight = -1.0f;
                    if (noiseHeight > 1.0f)
                        noiseHeight = 1.0f;

                    // Сохраняем точку для карты высот
                    noiseMap[y * w + x] = (noiseHeight + 1) / 2;
                }
            }
            return noiseMap;
        }

        private void Perlin2D(int seed = 0)
        {
            //Таблица со случайными числами
            var rand = new System.Random(seed);
            permutationTable = new byte[w * h];
            rand.NextBytes(permutationTable);
        }

        private float[] GetPseudoRandomGradientVector(int x, int y)
        {
            //Хэш-функция с простыми числами
            int v = (int)(((x * 1836311903) ^ (y * 2971215073) + 4807526976) & 1023);
            v = permutationTable[v] & 3;
            //Выбор градиентного вектора
            switch (v)
            {
                case 0: return new float[] { 1, 0 };
                case 1: return new float[] { -1, 0 };
                case 2: return new float[] { 0, 1 };
                default: return new float[] { 0, -1 };
            }
        }

        private static float QunticCurve(float t)
        {
            //Билинейная интерполяция
            return t * t * t * (t * (t * 6 - 15) + 10);
        }

        private static float Lerp(float a, float b, float t)
        {
            //Линейная интерполяция
            return a + (b - a) * t;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (cBTurnAnimation.Checked)
                tim = true;
            else
                tim = false;
        }


        System.Random randtim;
        float halfWidthtim;
        float halfHeighttim;


        int yper = 0;
        float amplitude = 1;
        float frequency = 1;
        float noiseHeight = 0;
        float superpositionCompensation = 0;

        private void timerUptper_Tick(object sender, EventArgs e)
        {
            if (yper < h)
            {
                for (int xper = 0; xper < w; xper++)
                {
                    //Задаём значения для первой октавы
                        amplitude = 1;
                        frequency = 1;
                        noiseHeight = 0;
                        superpositionCompensation = 0;

                    //Обработка наложения октав
                    for (int iper = 0; iper < 3;)
                    {
                        //Рассчет координаты для получения значения из шума перлина
                        float xResult = (xper - halfWidthtim) / 100 * frequency + octavesOffsettim[iper].x * frequency;
                        float yResult = (yper - halfHeighttim) / 100 * frequency + octavesOffsettim[iper].y * frequency;

                        //Получение высоты из шума
                        float generatedValue = NoisePerline(xResult, yResult);
                        //Наложение октав
                        noiseHeight += generatedValue * amplitude;
                        //Компенсируем наложение октав чтобы остаться в границах диапазона [-1,1]
                        noiseHeight -= superpositionCompensation;

                        // Расчёт амплитуды, частоты и компенсации для следующей октавы
                        amplitude *= 0.5f;
                        frequency *= 2;
                        superpositionCompensation = amplitude / 2;
                        iper++;

                        tBIterationCount.Text = IterationCount.ToString();
                    }

                    // Из-за наложения октав есть вероятность выхода за границы диапазона [-1,1]
                    if (noiseHeight < -1.0f)
                        noiseHeight = -1.0f;
                    if (noiseHeight > 1.0f)
                        noiseHeight = 1.0f;

                    // Сохраняем точку для карты высот
                    noiseMap[yper * w + xper] = (noiseHeight + 1) / 2;
                }

                {
                    yper++;
                }
            }
            IterationCount++;
            Int64 count = 0;
            for (Int64 i = 0; i < w * h; i++)
            {
                //if (noiseMap[i] == 0)
                //break;
                byte k = (byte)(Math.Round(noiseMap[i] * 255.0f));
                arrb[count] = k;
                arrb[count + 1] = k;
                arrb[count + 2] = k;
                count += 4;
            }
            BitmapData data = img.LockBits(rect, ImageLockMode.WriteOnly, img.PixelFormat);
            Marshal.Copy(arrb, 0, data.Scan0, arrb.Length);
            img.UnlockBits(data);
            noise.Invalidate();
            //img.Save("" + numb + ".png", ImageFormat.Png);
            if (yper == h)
                timerUptper.Enabled = false;
        }

        private static float Dot(float[] a, float[] b)
        {
            //Cкалярное произведение векторов
            return a[0] * b[0] + a[1] * b[1];
        }

        private float NoisePerline(float fx, float fy)
        {
            //Координаты левой верхней вершины квадрата
            int left = (int)System.Math.Floor(fx);
            int top = (int)System.Math.Floor(fy);
            //Локальные координаты точки внутри квадрата
            float pointInQuadX = fx - left;
            float pointInQuadY = fy - top;
            //Получение градиентных векторов для всех вершин квадрата
            float[] topLeftGradient = GetPseudoRandomGradientVector(left, top);
            float[] topRightGradient = GetPseudoRandomGradientVector(left + 1, top);
            float[] bottomLeftGradient = GetPseudoRandomGradientVector(left, top + 1);
            float[] bottomRightGradient = GetPseudoRandomGradientVector(left + 1, top + 1);
            //Вектора от вершин квадрата до точки внутри квадрата
            float[] distanceToTopLeft = new float[] { pointInQuadX, pointInQuadY };
            float[] distanceToTopRight = new float[] { pointInQuadX - 1, pointInQuadY };
            float[] distanceToBottomLeft = new float[] { pointInQuadX, pointInQuadY - 1 };
            float[] distanceToBottomRight = new float[] { pointInQuadX - 1, pointInQuadY - 1 };
            //Скалярные произведения
            float tx1 = Dot(distanceToTopLeft, topLeftGradient);
            float tx2 = Dot(distanceToTopRight, topRightGradient);
            float bx1 = Dot(distanceToBottomLeft, bottomLeftGradient);
            float bx2 = Dot(distanceToBottomRight, bottomRightGradient);
            //Параметры интерполяции
            pointInQuadX = QunticCurve(pointInQuadX);
            pointInQuadY = QunticCurve(pointInQuadY);
            //Интерполяция
            float tx = Lerp(tx1, tx2, pointInQuadX);
            float bx = Lerp(bx1, bx2, pointInQuadX);
            float tb = Lerp(tx, bx, pointInQuadY);

            return tb;
        }
    }
}
