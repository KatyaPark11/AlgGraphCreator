using System.Drawing;
using System.Drawing.Imaging;
using System.Reflection;

namespace GraphCreator
{
    class Program
    {
        public static Algorithm Algorithm;
        public static object AlgClassInstance;
        public static MethodInfo AlgMethodInfo;
        public static Graphics Graphics;
        public static Pen AxisPen, PointPen, LinePen, ApproxLinePen;
        public static Font LabelFont;
        public static Brush LabelBrush;
        public static SizeF TextSizeMaxElem;
        public static int Width, Height, StepX, StepY, ValueLabelPad, PlotWidth, PlotHeight, PlotX, PlotY;
        public static List<double> CoorsX,CoorsY, MarkCoorsY, FuncCoorsY;
        public static double MaxElem, MinPoint, MaxPoint;

        static void Main(string[] args)
        {
            //получение информации об алгоритме через рефлексию
            Algorithm = Algorithm.GetAlgorithms().FirstOrDefault(alg => alg.AlgName == args[0]);
            string algClassName = string.Format("{0}.{1}", Algorithm.AlgNamespace, Algorithm.AlgClass);
            string algMethodName = Algorithm.AlgMethod;
            Type algCassType = Type.GetType(algClassName);
            AlgClassInstance = Activator.CreateInstance(algCassType);
            AlgMethodInfo = algCassType.GetMethod(algMethodName);

            //число точек на ОX и ОY
            MinPoint = 0;
            MaxPoint = 100;
            //шаг числа на OX
            StepX = Algorithm.ElemsCount / (int)MaxPoint;
            //частота подписываемых меток значений
            ValueLabelPad = 10;

            //получение параметров для вычисления координат y
            CoorsY = new List<double>();
            MethodInfo coorsGettingMethodInfo = algCassType.GetMethod("GetYCoors");
            coorsGettingMethodInfo.Invoke(AlgClassInstance, null);

            //шаг числа на OY
            StepY = (int)Math.Ceiling(MaxElem / MaxPoint);
            if (StepY == 0) StepY = 1;

            //размер изображения
            Width = 1280;
            Height = 1024;

            //создание холста для графика
            Bitmap bitmap = new(Width, Height);
            Graphics = Graphics.FromImage(bitmap);

            //цвет фона
            Graphics.Clear(Color.Ivory);

            //параметры текста
            AxisPen = new Pen(Color.HotPink, 2);
            LabelFont = new Font("TimesNewRoman", 10);
            LabelBrush = new SolidBrush(Color.HotPink);

            //отступ для графика
            TextSizeMaxElem = Graphics.MeasureString(MaxElem.ToString(), LabelFont);
            int padding;
            if (TextSizeMaxElem.Width > 100)
                padding = (int)TextSizeMaxElem.Width + 10;
            else padding = 100;

            //длина и ширина графика
            PlotWidth = Width - 2 * padding;
            PlotHeight = Height - 2 * padding;
            PlotX = padding;
            PlotY = padding;

            //параметры графика (точки и линии)
            PointPen = new Pen(Color.Fuchsia, 5);
            LinePen = new Pen(Color.CornflowerBlue, 2);
            ApproxLinePen = new Pen(Color.DarkRed, 2);

            //координаты с учётом масштабирования
            CoorsX = new List<double>();
            MarkCoorsY = new List<double>();
            FuncCoorsY = new List<double>();

            Graphics.DrawAxis();
            Graphics.DrawTheHeader();
            Graphics.DrawTheNet();
            //отрисовка ОY и ОX
            Graphics.DrawLine(AxisPen, PlotX, PlotY, PlotX, PlotY + PlotHeight);
            Graphics.DrawLine(AxisPen, PlotX, PlotY + PlotHeight, PlotX + PlotWidth, PlotY + PlotHeight);
            Graphics.DrawValueLabels();
            Graphics.DrawDashes();

            //удаляем последнюю координату, т.к. она нужна была только для отрисовки последней метки и чёрточки
            CoorsX.RemoveAt(CoorsX.Count - 1);

            Graphics.DrawTheGraph();

            //отрисовка аппроксимации через рефлексию
            MethodInfo graphicsExtMethod = typeof(ApproxExtensionsForGraphics).GetMethod(string.Format("Draw{0}Approximation", Algorithm.AlgComplexity));
            graphicsExtMethod.Invoke(null, new object[] { Graphics });

            //сохранение графика
            string outputFile = $"C:\\Users\\User\\Desktop\\Моё\\Программы\\Graphs_Png\\graph_{Algorithm.AlgName}.png";
            bitmap.Save(outputFile, ImageFormat.Png);
        }
    }
}