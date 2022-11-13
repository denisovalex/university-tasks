using Objects;
using System;
using System.Collections.Generic;

namespace ProblemSolution
{
    public class PyramidBuilder
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

            // Векторное произведение product на AB задаёт направление двух сторон основания, выходящих из имеющихся вершин.
            // Задаём найденному вектору длину стороны квадрата и находим недостающие вершины основания.
            Vector AD = product.GetVectorProductOn(AB);
            AD = AD.Normalize().GetProductOnScalar(AB.CountLength());
            figurePoints.Add(AD.GetEnd(B)); figurePoints.Add(AD.GetEnd(A));

            // Середина AC' - точка O, из которой проводится высота пирамиды
            Point CC = AD.GetEnd(B);
            Vector ACC = new Vector(A, CC);
            Point O = ACC.GetMidpoint();

            // product задаёт направление высоты пирамиды. Отложив product от O и придав ему длину высоты, получаем последнюю вершину пирамиды S.
            product = product.Normalize().GetProductOnScalar(CountHeightOfPyramid(AB.CountLength()));
            Point S = product.GetEnd(O);
            figurePoints.Add(S);

            return figurePoints;
        }

        private static double CountHeightOfPyramid(double side)
        {
            double squareDiagonal = side * Math.Sqrt(2);
            double height = Math.Sqrt(Math.Pow(side, 2) - Math.Pow(squareDiagonal, 2) / 4);

            return height;
        }
    }
}
