using System;
using System.Collections.Generic;
using Objects;
using ProblemSolution;

namespace App
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Эта программа строит ортогональные проекции правильного тетраэдра, правильной черёхугольной пирамиды, куба по трём точкам, задающим плоскость основания данных фигур в пространстве.\n");

            Point A = new Point(0, 0, 4);
            Point B = new Point(0, 4, 0);
            Point C = new Point(-1, 2, 1);

            if (AreOnSameLine(A, B, C))
            {
                Console.WriteLine("Данные точки лежат на одной прямой и не задают плоскость.");
                return;
            }

            TetrahedronBuilder tetrahedron = new TetrahedronBuilder();
            List<Point> tetrahedronPoints = tetrahedron.Build(A, B, C);

            List<Point> projectedPoints = Point.GetProjectionOntoXOY(tetrahedronPoints);

            Console.WriteLine("Тетраэдр");
            Console.WriteLine("Point A projection       x:{0}, y:{1}, z:{2}", projectedPoints[0].X, projectedPoints[0].Y, projectedPoints[0].Z);
            Console.WriteLine("Point B projection       x:{0}, y:{1}, z:{2}", projectedPoints[1].X, projectedPoints[1].Y, projectedPoints[1].Z);
            Console.WriteLine("Point C' projection      x:{0}, y:{1}, z:{2}", projectedPoints[2].X, projectedPoints[2].Y, projectedPoints[2].Z);
            Console.WriteLine("Point S projection       x:{0}, y:{1}, z:{2}\n", projectedPoints[3].X, projectedPoints[3].Y, projectedPoints[3].Z);

            PyramidBuilder pyramid = new PyramidBuilder();
            List<Point> pyramidPoints = pyramid.Build(A, B, C);

            projectedPoints = Point.GetProjectionOntoXOY(pyramidPoints);

            Console.WriteLine("Четырёхугольная пирамида с равными сторонами");
            Console.WriteLine("Point A projection       x:{0}, y:{1}, z:{2}", projectedPoints[0].X, projectedPoints[0].Y, projectedPoints[0].Z);
            Console.WriteLine("Point B projection       x:{0}, y:{1}, z:{2}", projectedPoints[1].X, projectedPoints[1].Y, projectedPoints[1].Z);
            Console.WriteLine("Point C' projection      x:{0}, y:{1}, z:{2}", projectedPoints[2].X, projectedPoints[2].Y, projectedPoints[2].Z);
            Console.WriteLine("Point D projection       x:{0}, y:{1}, z:{2}", projectedPoints[3].X, projectedPoints[3].Y, projectedPoints[3].Z);
            Console.WriteLine("Point S projection       x:{0}, y:{1}, z:{2}\n", projectedPoints[4].X, projectedPoints[4].Y, projectedPoints[4].Z);

            CubeBuilder cube = new CubeBuilder();
            List<Point> cubePoints = cube.Build(A, B, C);

            projectedPoints = Point.GetProjectionOntoXOY(cubePoints);

            Console.WriteLine("Куб");
            Console.WriteLine("Point A projection       x:{0}, y:{1}, z:{2}", projectedPoints[0].X, projectedPoints[0].Y, projectedPoints[0].Z);
            Console.WriteLine("Point B projection       x:{0}, y:{1}, z:{2}", projectedPoints[1].X, projectedPoints[1].Y, projectedPoints[1].Z);
            Console.WriteLine("Point C' projection      x:{0}, y:{1}, z:{2}", projectedPoints[2].X, projectedPoints[2].Y, projectedPoints[2].Z);
            Console.WriteLine("Point D projection       x:{0}, y:{1}, z:{2}", projectedPoints[3].X, projectedPoints[3].Y, projectedPoints[3].Z);
            Console.WriteLine("Point A1 projection      x:{0}, y:{1}, z:{2}", projectedPoints[4].X, projectedPoints[4].Y, projectedPoints[4].Z);
            Console.WriteLine("Point B1 projection      x:{0}, y:{1}, z:{2}", projectedPoints[5].X, projectedPoints[5].Y, projectedPoints[5].Z);
            Console.WriteLine("Point C'1 projection     x:{0}, y:{1}, z:{2}", projectedPoints[6].X, projectedPoints[6].Y, projectedPoints[6].Z);
            Console.WriteLine("Point D1 projection      x:{0}, y:{1}, z:{2}", projectedPoints[7].X, projectedPoints[7].Y, projectedPoints[7].Z);
        }

        static bool AreOnSameLine(Point A, Point B, Point C)
        {
            if ((C.X - A.X) * (B.Y - A.Y) == (C.Y - A.Y) * (B.X - A.X) && (C.Y - A.Y) * (B.Z - A.Z) == (C.Z - A.Z) * (B.Y - A.Y))
                return true;

            return false;
        }
    }
}
