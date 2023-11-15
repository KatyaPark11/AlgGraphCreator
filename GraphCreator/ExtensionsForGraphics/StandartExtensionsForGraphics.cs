using System.Drawing;
using static GraphCreator.Program;

namespace GraphCreator.ExtensionsForGraphics
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

            SizeF textSizeX = Graphics.MeasureString(textOX, LabelFont);
            SizeF textSizeY = Graphics.MeasureString(textOY, LabelFont);

            Graphics.DrawString(textOX, LabelFont, LabelBrush, PlotX + PlotWidth + 5,
                                PlotY + PlotHeight - textSizeX.Height / 2);
            Graphics.DrawString(textOY, LabelFont, LabelBrush, PlotX - textSizeY.Width / 2,
                                PlotY - 15 - textSizeY.Height / 2);
        }

        /// <summary>
        /// Метод для отрисовки заголовка на графике.
        /// </summary>
        /// <param name="Graphics">График для отрисовки.</param>
        public static void DrawTheHeader(this Graphics Graphics)
        {
            Font headerFont = new("TimesNewRoman", 14);
            string headerText = $"{Program.Algorithm.AlgName.Replace("_", " ")}";
            float headerX = Width / 2;
            float headerY = 15;

            Graphics.DrawString(headerText, headerFont, LabelBrush, headerX, headerY, new StringFormat { Alignment = StringAlignment.Center });
        }

        /// <summary>
        /// Метод для отрисовки сетки на графике.
        /// </summary>
        /// <param name="Graphics">График для отрисовки.</param>
        public static void DrawTheNet(this Graphics Graphics)
        {
            Pen netPen = new(Color.AntiqueWhite, 2);
            for (int i = 0; i <= MaxPoint; i++)
            {
                double vx = PlotX + (i - MinPoint) / (MaxPoint - MinPoint) * PlotWidth;
                CoorsX.Add(vx);
                double hy = PlotY + (i - MinPoint) / (MaxPoint - MinPoint) * PlotHeight;
                MarkCoorsY.Add(hy);

                if (i % 3 != 0) continue;
                int vy1 = PlotY + PlotHeight;
                int vy2 = PlotY;
                Graphics.DrawLine(netPen, (int)vx, vy1, (int)vx, vy2);

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
            for (int i = 0; i <= MaxPoint; i += ValueLabelPad)
            {
                int x = (int)CoorsX[i];
                int y = (int)(MarkCoorsY[(int)MaxPoint - i] - TextSizeMaxElem.Height / 2);

                int coorAtOYForOX = PlotY + PlotHeight + 10;
                int coorAtOXForOY = PlotX - (int)TextSizeMaxElem.Width - 20;

                string labelOX = (i * StepX).ToString();
                Graphics.DrawString(labelOX, LabelFont, LabelBrush, x, coorAtOYForOX,
                                    new StringFormat { Alignment = StringAlignment.Center });
   
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
            for (int i = 0; i <= MaxPoint; i++)
            {
                int x = (int)CoorsX[i];
                int y1 = PlotY + PlotHeight;
                int y2 = y1 + 5;
                Graphics.DrawLine(AxisPen, x, y1, x, y2);

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
            for (int i = 0; i < CoorsY.Count; i++)
            {
                int x = (int)CoorsX[i];
                int y = (int)(PlotY + PlotHeight - (CoorsY[i] / StepY - MinPoint) / (MaxPoint - MinPoint) * PlotHeight);
                FuncCoorsY.Add(y);

                if (i == 0) continue;
                int prevX = (int)CoorsX[i - 1];
                int prevY = (int)FuncCoorsY[i - 1];

                Graphics.DrawLine(LinePen, prevX, prevY, x, y);
            }
        }
    }
}
