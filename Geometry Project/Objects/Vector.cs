using System;

namespace Objects
{
	public class Vector
	{
		public double X { get; private set; }
		public double Y { get; private set; }
		public double Z { get; private set; }
		public Point Start { get; private set; }
		public Point End { get; private set; }


		public Vector(Point start, Point end)
		{
			X = - start.X + end.X;
			Y = - start.Y + end.Y;
			Z = - start.Z + end.Z;
			Start = start;
			End = end;
		}

		public Vector(double x, double y, double z)
		{
			X = x;
			Y = y;
			Z = z;
		}

		public double CountLength()
		{
			return Math.Sqrt(X * X + Y * Y + Z * Z);
		}

		public Vector GetProductOnScalar(double scalar)
		{
			Vector product = new Vector(
				this.X * scalar,
				this.Y * scalar,
				this.Z * scalar
				);

			return product;
		}

		public Vector GetVectorProductOn(Vector vector)
		{
			Vector product = new Vector(
				this.Y * vector.Z - this.Z * vector.Y,
				this.Z * vector.X - this.X * vector.Z,
				this.X * vector.Y - this.Y * vector.X
				);

			return product;
		}

		public Vector Normalize()
		{
			return this.GetProductOnScalar(1 / this.CountLength());
		}

		public Vector Rotate(Vector axis, double angle)
		{
			double cos = Math.Cos(angle);
			double sin = Math.Sin(angle);

			double[,] rotationMatrix = new double[3, 3] {
				{ cos + (1 - cos) * axis.X * axis.X, (1 - cos) * axis.X * axis.Y - sin * axis.Z, (1 - cos) * axis.X * axis.Z + sin * axis.Y},
				{ (1 - cos) * axis.X * axis.Y + sin * axis.Z, cos + (1 - cos) * axis.Y * axis.Y, (1 - cos) * axis.Y * axis.Z - sin * axis.X},
				{ (1 - cos) * axis.X * axis.Z - sin * axis.Y, (1 - cos) * axis.Z * axis.Y + sin * axis.X, cos + (1 - cos) * axis.Z * axis.Z}
			};

			Vector newVector = new Vector(
				rotationMatrix[0, 0] * this.X + rotationMatrix[0, 1] * this.Y + rotationMatrix[0, 2] * this.Z,
				rotationMatrix[1, 0] * this.X + rotationMatrix[1, 1] * this.Y + rotationMatrix[1, 2] * this.Z,
				rotationMatrix[2, 0] * this.X + rotationMatrix[2, 1] * this.Y + rotationMatrix[2, 2] * this.Z
				);

			return newVector;
		}

		public Point GetMidpoint()
        {
			Point seredina = new Point((Start.X + End.X) / 2, (Start.Y + End.Y) / 2, (Start.Z + End.Z) / 2);
			return seredina;
		}

		public Point GetEnd(Point start)
        {
			Point end = new Point(this.X + start.X, this.Y + start.Y, this.Z + start.Z);
			return end;
        }
	}
}
