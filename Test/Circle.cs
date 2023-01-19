using System;

namespace Test
{
    public class Circle : IFigure
    {
        public const double MinRadius = 1e-6;

        /// <exception cref="ArgumentException"></exception>
        public Circle(double radius)
        {
            if (radius - MinRadius < Constants.CalculationAccuracy)
            {
                throw new ArgumentException("Ошибка. Неверно указаны данные.", nameof(radius));
            };
            Radius = radius;
        }

        public double Radius { get; }

        public double GetArea()
        {
            return Math.PI * Math.Pow(Radius, 2d);
        }
    }
}
