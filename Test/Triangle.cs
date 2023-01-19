using System;

namespace Test
{
    public class Triangle : ITriangle
	{
		private readonly double eps = Constants.CalculationAccuracy;

		public Triangle(double edgeA, double edgeB, double edgeC)
		{
			if (edgeA < eps)
			{ 
				throw new ArgumentException("Ошибка. Неверно указаны данные.", nameof(edgeA)); 
			};

			if (edgeB < eps)
			{ 
				throw new ArgumentException("Ошибка. Неверно указаны данные.", nameof(edgeB)); 
			};

			if (edgeC < eps)
			{ 
				throw new ArgumentException("Ошибка. Неверно указаны данные.", nameof(edgeC)); 
			};

			var maxEdge = Math.Max(edgeA, Math.Max(edgeB, edgeC));
			var perimeter = edgeA + edgeB + edgeC;
			if ((perimeter - maxEdge) - maxEdge < Constants.CalculationAccuracy)
			{ 
				throw new ArgumentException("Ошибка. Неверно указаны данные."); 
			};

			EdgeA = edgeA;
			EdgeB = edgeB;
			EdgeC = edgeC;

			_isRightTriangle = new Lazy<bool>(GetIsRightTriangle);
		}

		public double EdgeA { get; }
		public double EdgeB { get; }
		public double EdgeC { get; }
		
		public double GetArea()
		{
			var halfP = (EdgeA + EdgeB + EdgeC) / 2d;
			var square = Math.Sqrt(halfP * (halfP - EdgeA) * (halfP - EdgeB) * (halfP - EdgeC));

			return square;
		}

		private readonly Lazy<bool> _isRightTriangle;
		public bool IsRightTriangle => _isRightTriangle.Value;

		private bool GetIsRightTriangle()
        {
			double maxEdge = EdgeA, b = EdgeB, c = EdgeC, temp;
			if (b - maxEdge > Constants.CalculationAccuracy)
            {
				temp = maxEdge;
				maxEdge = b;
				b = temp;
            }

			if (c - maxEdge > Constants.CalculationAccuracy)
			{
				temp = maxEdge;
				maxEdge = c;
				c = temp;
			}

			return Math.Abs(Math.Pow(maxEdge, 2) - Math.Pow(b, 2) - Math.Pow(c, 2)) < Constants.CalculationAccuracy;
		}
	}
}
