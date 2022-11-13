using Objects;
using System.Collections.Generic;

namespace ProblemSolution
{
    public class CubeBuilder
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

            // product свою очередь даёт направление для нахождения оставшихся вершин
            Vector AA1 = product.Normalize().GetProductOnScalar(AB.CountLength());
            figurePoints.Add(AA1.GetEnd(A)); figurePoints.Add(AA1.GetEnd(B)); 
            figurePoints.Add(AA1.GetEnd(figurePoints[2])); figurePoints.Add(AA1.GetEnd(figurePoints[3]));

            return figurePoints;
        }
    }
}
