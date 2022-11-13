using System;
using System.Collections.Generic;

namespace Objects
{
	public class Point
	{
		public double X { get; private set; }
		public double Y { get; private set; }
		public double Z { get; private set; }

		public Point(double x, double y, double z)
		{
			X = x;
			Y = y;
			Z = z;
		}

		public static List<Point> GetProjectionOntoXOY(List<Point> points)
		{
			foreach (Point point in points)
				point.Z = 0;

			return points;
		}
	}
}
