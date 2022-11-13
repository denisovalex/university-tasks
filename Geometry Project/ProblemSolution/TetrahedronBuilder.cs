using System;
using System.Collections.Generic;
using Objects;

namespace ProblemSolution
{
	public class TetrahedronBuilder
	{
		public List<Point> Build(Point A, Point B, Point C)
		{
			// Добавляем точки A и B в список вершин фигуры
			List<Point> figurePoints = new List<Point>();
			Point copyA = new Point(A.X, A.Y, A.Z);
			Point copyB = new Point(B.X, B.Y, B.Z);
			figurePoints.Add(copyA); figurePoints.Add(copyB);

			// Строим векторы AB и AC и находим их векторное произведение product
			Vector AB = new Vector(A, B);
			Vector AC = new Vector(A, C);
			Vector product = AB.GetVectorProductOn(AC);

			// H - сережина AB. HA, умноженное векторно на product, задаёт направление высоты треугольника основания
			Point H = AB.GetMidpoint();
			Vector HA = new Vector(H, A);
			Vector HCC = HA.GetVectorProductOn(product);

			// Задав найденному наравлению длину высоты равностороннего треугольника, получаем саму высоту, а самое главное её конец - точку С'.
			HCC = HCC.Normalize().GetProductOnScalar(CountHeightOfTriangle(AB.CountLength()));
			Point CC = HCC.GetEnd(H);
			figurePoints.Add(CC);

			// Находим инцентр I треугольника основания, из которого выходит высота тэтраедра
			Point I = GetIncenterOfTriangle(H, HCC);

			// Откладыввем product от I, и придаём ему длину высоты тэтраедра и находим её конец - недостающую вершину S
			product = product.Normalize().GetProductOnScalar(CountHeightOfTetrahedron(AB.CountLength()));
			Point S = product.GetEnd(I);
			figurePoints.Add(S);

			return figurePoints;
		}

		private static double CountHeightOfTriangle(double side)
        {
			return (side * Math.Sqrt(3)) / 2;
        }

		private static Point GetIncenterOfTriangle(Point heightBase, Vector height)
        {
			double newLength = height.CountLength() / 3;
			height = height.Normalize().GetProductOnScalar(newLength);
			Point incenter = height.GetEnd(heightBase);

			return incenter;
        }

		private static double CountHeightOfTetrahedron(double side)
        {
			return side * (Math.Sqrt(2) / Math.Sqrt(3));
        }
	}
}
