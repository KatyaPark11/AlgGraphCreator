using System.Drawing;
using static GraphCreator.Program;

namespace GraphCreator
{
    /// <summary>
    /// Класс для стандартных методов расширения System.Drawing.Graphics.
    /// </summary>
    public static class StandartExtensionsForGraphics
    {
        /// <summary>
        /// Метод для отрисовки осей на графике.
        /// </summary>
        /// <param name="Graphics">График для отрисовки.</param>
        public static void DrawAxis(this Graphics Graphics)
        {
            //тексты подписей осей
            string textOX, textOY;
            if (!AlgMethodInfo.Name.Contains("Pow"))
            {
                textOX = "n, к-во эл-в";
                textOY = "t, время в мс";
            }
            else
            {
                textOX = "e, степень";
                textOY = "n, число эл-х оп-й";
            }

            //размеры подписей осей
            SizeF textSizeX = Graphics.MeasureString(textOX, LabelFont);
            SizeF textSizeY = Graphics.MeasureString(textOY, LabelFont);
            //подпись осей
            Graphics.DrawString(textOX, LabelFont, LabelBrush, PlotX + PlotWidth + 5,
                                PlotY + PlotHeight - (textSizeX.Height / 2));
            Graphics.DrawString(textOY, LabelFont, LabelBrush, PlotX - (textSizeY.Width / 2),
                                PlotY - 15 - (textSizeY.Height / 2));
        }

        /// <summary>
        /// Метод для отрисовки заголовка на графике.
        /// </summary>
        /// <param name="Graphics">График для отрисовки.</param>
        public static void DrawTheHeader(this Graphics Graphics)
        {
            //размер текста заголовка
            Font headerFont = new("TimesNewRoman", 14);
            //текст заголовка
            string headerText = $"{Program.Algorithm.AlgName.Replace("_", " ")}";
            //координаты заголовка
            float headerX = Width / 2;
            float headerY = 15;
            //отрисовка заголовка
            Graphics.DrawString(headerText, headerFont, LabelBrush, headerX, headerY, new StringFormat { Alignment = StringAlignment.Center });
        }

        /// <summary>
        /// Метод для отрисовки сетки на графике.
        /// </summary>
        /// <param name="Graphics">График для отрисовки.</param>
        public static void DrawTheNet(this Graphics Graphics)
        {
            //отрисовка сетки
            Pen netPen = new(Color.AntiqueWhite, 2);
            for (int i = 0; i <= MaxPoint; i++)
            {
                double vx = PlotX + (i - MinPoint) / (MaxPoint - MinPoint) * PlotWidth;
                CoorsX.Add(vx);
                double hy = PlotY + (i - MinPoint) / (MaxPoint - MinPoint) * PlotHeight;
                MarkCoorsY.Add(hy);

                if (i % 3 != 0) continue;
                // вертикальные линии
                int vy1 = PlotY + PlotHeight;
                int vy2 = PlotY;
                Graphics.DrawLine(netPen, (int)vx, vy1, (int)vx, vy2);

                // горизонтальные линии
                int hx1 = PlotX + PlotWidth;
                int hx2 = PlotX;
                Graphics.DrawLine(netPen, hx1, (int)hy, hx2, (int)hy);
            }
        }

        /// <summary>
        /// Метод для отрисовки меток значений на графике.
        /// </summary>
        /// <param name="Graphics">График для отрисовки.</param>
        public static void DrawValueLabels(this Graphics Graphics)
        {
            //отрисовка меток значений
            for (int i = 0; i <= MaxPoint; i += ValueLabelPad)
            {
                //положение точки
                int x = (int)CoorsX[i];
                int y = (int)(MarkCoorsY[(int)MaxPoint - i] - TextSizeMaxElem.Height / 2);

                //координата на ОY для меток по ОX
                int coorAtOYForOX = PlotY + PlotHeight + 10;
                //координата на ОX для меток по ОY
                int coorAtOXForOY = PlotX - (int)TextSizeMaxElem.Width - 20;
                //отрисовка метки по ОX
                string labelOX = (i * StepX).ToString();
                Graphics.DrawString(labelOX, LabelFont, LabelBrush, x, coorAtOYForOX,
                                    new StringFormat { Alignment = StringAlignment.Center });
                //отрисовка метки по ОY
                string labelOY;
                labelOY = (i * StepY).ToString();
                Graphics.DrawString(labelOY, LabelFont, LabelBrush, coorAtOXForOY, y);
            }
        }

        /// <summary>
        /// Метод для отрисовки чёрточек на графике.
        /// </summary>
        /// <param name="Graphics">График для отрисовки.</param>
        public static void DrawDashes(this Graphics Graphics)
        {
            //отрисовка чёрточек
            for (int i = 0; i <= MaxPoint; i++)
            {
                //отрисовка вертикальных чёрточек
                int x = (int)CoorsX[i];
                int y1 = PlotY + PlotHeight;
                int y2 = y1 + 5;

                Graphics.DrawLine(AxisPen, x, y1, x, y2);

                //отрисовка горизонтальных чёрточек
                int y = (int)MarkCoorsY[i];
                int x1 = PlotX;
                int x2 = x1 - 5;

                Graphics.DrawLine(AxisPen, x1, y, x2, y);
            }
        }

        /// <summary>
        /// Метод для отрисовки точек и линий на графике.
        /// </summary>
        /// <param name="Graphics">График для отрисовки.</param>
        public static void DrawTheGraph(this Graphics Graphics)
        {
            //отрисовка точек и линии графика
            for (int i = 0; i < CoorsY.Count; i++)
            {
                //положение точки с использованием масштабирования
                int x = (int)CoorsX[i];
                int y = (int)(PlotY + PlotHeight - (CoorsY[i] / StepY - MinPoint) / (MaxPoint - MinPoint) * PlotHeight);
                FuncCoorsY.Add(y);

                if (i == 0) continue;
                //положение предыдущих точек
                int prevX = (int)CoorsX[i - 1];
                int prevY = (int)FuncCoorsY[i - 1];

                //отрисовка линии
                Graphics.DrawLine(LinePen, prevX, prevY, x, y);
            }
        }
    }
}
