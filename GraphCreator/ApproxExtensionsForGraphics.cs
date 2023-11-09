using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using System.Drawing;
using static GraphCreator.Program;

namespace GraphCreator
{
    /// <summary>
    /// Класс для методов расширения System.Drawing.Graphics, связанных с отрисовкой аппроксимации.
    /// </summary>
    public static class ApproxExtensionsForGraphics
    {
        /// <summary>
        /// Метод для отрисовки на графике аппроксимации постоянной функцией.
        /// </summary>
        /// <param name="Graphics">График для отрисовки на нём аппроксимации.</param>
        public static void DrawConstApproximation(this Graphics Graphics)
        {
            double a = FuncCoorsY.Average();
            double func() => a;
            for (int i = 0; i < CoorsX.Count; i++)
            {
                if (i == 0) continue;
                //положение точки с использованием масштабирования
                long x = (long)CoorsX[i];
                long y = (long)func();

                //положение предыдущих точек
                long prevX = (long)CoorsX[i - 1];
                long prevY = (long)func();

                //отрисовка точки
                Graphics.DrawEllipse(PointPen, x - 2, y - 2, 3, 3);
                //отрисовка линии
                Graphics.DrawLine(ApproxLinePen, prevX, prevY, x, y);
            }
            
        }

        /// <summary>
        /// Метод для отрисовки на графике аппроксимации линейной функцией.
        /// </summary>
        /// <param name="Graphics">График для отрисовки на нём аппроксимации.</param>
        public static void DrawLineApproximation(this Graphics Graphics)
        {
            // Создаем матрицу A и вектор b для МНК
            Matrix<double> A = DenseMatrix.OfColumns(new List<double>[] { CoorsX, DenseVector.Create(CoorsX.Count, 1.0).ToList() });
            Vector<double> vectB = DenseVector.OfEnumerable(FuncCoorsY);

            // Решаем систему уравнений Ax = b
            Vector<double> coefficients = A.Solve(vectB);

            // Получаем коэффициенты a и b для линейной функции y = ax + b
            double a = coefficients[0];
            double coefB = coefficients[1];

            double func(double num) => a * num + coefB;

            for (int i = CoorsX.Count - 1; i >= 0; i--)
            {
                if (i == 0) continue;
                //положение точки с использованием масштабирования
                long x = (long)CoorsX[i];
                long y = (long)func(CoorsX[i]);

                //положение предыдущих точек
                long prevX = (long)CoorsX[i - 1];
                long prevY = (long)func(CoorsX[i - 1]);

                if (prevY > PlotY + PlotHeight) break;
                //отрисовка точки
                Graphics.DrawEllipse(PointPen, prevX - 2, prevY - 2, 3, 3);
                //отрисовка линии
                Graphics.DrawLine(ApproxLinePen, prevX, prevY, x, y);
            }
        }

        /// <summary>
        /// Метод для отрисовки на графике аппроксимации квадратичной функцией.
        /// </summary>
        /// <param name="Graphics">График для отрисовки на нём аппроксимации.</param>
        public static void DrawQuadraticApproximation(this Graphics Graphics)
        {
            Matrix<double> A = DenseMatrix.OfColumns(new[] { CoorsX.Select(x => x * x), CoorsX, DenseVector.Create(CoorsX.Count, 1.0) });
            Vector<double> B = DenseVector.OfEnumerable(FuncCoorsY);

            // Решаем систему уравнений Ax = b
            Vector<double> coefficients = A.Solve(B);

            // Получаем коэффициенты a, b и c
            double a = coefficients[0];
            double b = coefficients[1];
            double c = coefficients[2];
            double func(double num) => a * num * num + b * num + c;
            long bottomCoorY = -1;

            for (int i = CoorsX.Count - 1; i >= 0; i--)
            {
                if (i == 0) continue;
                //положение точки с использованием масштабирования
                long x = (long)CoorsX[i];
                long y = (long)func(CoorsX[i]);

                //положение предыдущих точек
                long prevX = (long)CoorsX[i - 1];
                long prevY = (long)func(CoorsX[i - 1]);
                if (bottomCoorY == -1 && (y > prevY || y > PlotY + PlotHeight))
                {
                    prevY = y;
                    bottomCoorY = y;
                }
                else if (bottomCoorY != -1)
                {
                    prevY = bottomCoorY;
                    y = bottomCoorY;
                }

                //отрисовка точки
                Graphics.DrawEllipse(PointPen, prevX - 2, prevY - 2, 3, 3);
                //отрисовка линии
                Graphics.DrawLine(ApproxLinePen, prevX, prevY, x, y);
            }
        }

        /// <summary>
        /// Метод для отрисовки на графике аппроксимации логарифмической функцией.
        /// </summary>
        /// <param name="Graphics">График для отрисовки на нём аппроксимации.</param>
        public static void DrawLogApproximation(this Graphics Graphics)
        {
            // Создаем матрицу A и вектор b для МНК для логарифмической функции
            Matrix<double> A = DenseMatrix.OfColumns(new[] { CoorsX.Select(x => Math.Log(x)), DenseVector.Create(CoorsX.Count, 1.0) });
            Vector<double> B = DenseVector.OfEnumerable(FuncCoorsY);

            // Решаем систему уравнений Ax = b
            Vector<double> coefficients = A.Solve(B);

            // Получаем коэффициенты a и b для логарифмической функции y = a * ln(x) + b
            double a = coefficients[0];
            double b = coefficients[1];

            double func(double num) => a * Math.Log(num) + b;

            for (int i = 0; i < CoorsX.Count; i++)
            {
                if (i == 0) continue;
                //положение точки с использованием масштабирования
                long x = (long)CoorsX[i];
                long y = (long)func(CoorsX[i]);

                //положение предыдущих точек
                long prevX = (long)CoorsX[i - 1];
                long prevY = (long)func(CoorsX[i - 1]);

                //отрисовка точки
                Graphics.DrawEllipse(PointPen, x - 2, y - 2, 3, 3);
                //отрисовка линии
                Graphics.DrawLine(ApproxLinePen, prevX, prevY, x, y);
            }
        }

        /// <summary>
        /// Метод для отрисовки на графике аппроксимации линейно-логарифмической функцией.
        /// </summary>
        /// <param name="Graphics">График для отрисовки на нём аппроксимации.</param>
        public static void DrawLineLogApproximation(this Graphics Graphics)
        {
            // Создаем матрицу A и вектор b для МНК для логарифмической функции
            Matrix<double> A = DenseMatrix.OfColumns(new[] { CoorsX.Select(x => x * Math.Log(x)), DenseVector.Create(CoorsX.Count, 1.0) });
            Vector<double> B = DenseVector.OfEnumerable(FuncCoorsY);

            // Решаем систему уравнений Ax = b
            Vector<double> coefficients = A.Solve(B);

            // Получаем коэффициенты a и b для логарифмической функции y = a * x * ln(x) + b
            double a = coefficients[0];
            double b = coefficients[1];

            double func(double num) => a * num * Math.Log(num) + b;

            for (int i = 0; i < CoorsX.Count; i++)
            {
                if (i == 0) continue;
                //положение точки с использованием масштабирования
                long x = (long)CoorsX[i];
                long y = (long)func(CoorsX[i]);

                //положение предыдущих точек
                long prevX = (long)CoorsX[i - 1];
                long prevY = (long)func(CoorsX[i - 1]);

                //отрисовка точки
                Graphics.DrawEllipse(PointPen, x - 2, y - 2, 3, 3);
                //отрисовка линии
                Graphics.DrawLine(ApproxLinePen, prevX, prevY, x, y);
            }
        }
    }
}
