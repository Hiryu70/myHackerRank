using System.Collections.Generic;
using System;
using System.IO;


class Solution
{
	enum Direction
	{
		Up,
		Down,
		Left,
		Right,
		UpLeft,
		UpRight,
		DownLeft,
		DownRight
	}

	struct Coord
	{
		public Coord(int row, int column)
		{
			Row = row;
			Column = column;
		}

		public int Row { get; set; }

		public int Column { get; set; }

		public bool IsValid()
		{
			if (Row > _size || Column > _size || Row < 1 || Column < 1)
			{
				return false;
			}

			return true;
		}

		public override string ToString()
		{
			return $"[{Row},{Column}]";
		}

		public static bool operator ==(Coord c1, Coord c2)
		{
			return c1.Equals(c2);
		}

		public static bool operator !=(Coord c1, Coord c2)
		{
			return !c1.Equals(c2);
		}

		public static Coord operator +(Coord c1, Coord c2)
		{
			return new Coord(c1.Row + c2.Row, c1.Column + c2.Column);
		}

		public static Coord operator -(Coord c1, Coord c2)
		{
			return new Coord(c1.Row - c2.Row, c1.Column - c2.Column);
		}
	}

	static int _size;
	static int _obstaclesCount;
	static Coord _queen;
	static Dictionary<Direction, Coord> _obstacles = new Dictionary<Direction, Coord>();

	static int CountByDirection(Coord delta)
	{
		Coord currentCoord = _queen;
		int count = 0;

		while (currentCoord.IsValid())
		{
			if (_obstacles.ContainsValue(currentCoord))
			{
				return count;
			}

			if (currentCoord != _queen)
			{
				count++;
			}

			currentCoord = currentCoord + delta;
		}

		return count;
	}

	static int QueensAttack()
	{
		List<Coord> deltas = new List<Coord>
		{
			new Coord(1, 0),
			new Coord(-1, 0),
			new Coord(0, 1),
			new Coord(0, -1),
			new Coord(1, 1),
			new Coord(-1, 1),
			new Coord(1, -1),
			new Coord(-1, -1)
		};

		int summ = 0;

		foreach (Coord delta in deltas)
		{
			int byDirection = CountByDirection(delta);
			Console.WriteLine($"{delta} : {byDirection}");
			summ = summ + byDirection;
		}

		return summ;
	}

	static void CheckAndAddObstacle(Coord obstacle)
	{
		Direction direction;

		if (obstacle.Row == _queen.Row)
		{
			direction = obstacle.Column > _queen.Column ? Direction.Right : Direction.Left;
			AddObstacle(obstacle, direction);
			return;
		}

		if (obstacle.Column == _queen.Column)
		{
			direction = obstacle.Row > _queen.Row ? Direction.Up : Direction.Down;
			AddObstacle(obstacle, direction);
			return;
		}

		Coord directionCoord = obstacle - _queen;
		if (directionCoord.Row == directionCoord.Column)
		{
			direction = directionCoord.Row > 0 ? Direction.UpRight : Direction.DownLeft;
			AddObstacle(obstacle, direction);
		}
		else if (directionCoord.Row == -directionCoord.Column)
		{
			direction = directionCoord.Row > 0 ? Direction.UpLeft : Direction.DownRight;
			AddObstacle(obstacle, direction);
		}
	}

	static void AddObstacle(Coord obstacle, Direction direction)
	{
		Coord currentObstacle;
		if (!_obstacles.TryGetValue(direction, out currentObstacle))
		{
			_obstacles[direction] = obstacle;
			return;
		}

		switch (direction)
		{
			case Direction.Up:
				if (obstacle.Row < currentObstacle.Row)
				{
					_obstacles[direction] = obstacle;
				}
				break;
			case Direction.Down:
				if (obstacle.Row > currentObstacle.Row)
				{
					_obstacles[direction] = obstacle;
				}
				break;
			case Direction.Left:
			case Direction.UpLeft:
			case Direction.DownLeft:
				if (obstacle.Column > currentObstacle.Column)
				{
					_obstacles[direction] = obstacle;
				}
				break;
			case Direction.Right:
			case Direction.UpRight:
			case Direction.DownRight:
				if (obstacle.Column < currentObstacle.Column)
				{
					_obstacles[direction] = obstacle;
				}
				break;
		}
	}

	static void Main(string[] args)
	{
		TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

		string[] nk = Console.ReadLine().Split(' ');
		_size = Convert.ToInt32(nk[0]);
		_obstaclesCount = Convert.ToInt32(nk[1]);

		string[] r_qC_q = Console.ReadLine().Split(' ');
		int r_q = Convert.ToInt32(r_qC_q[0]);
		int c_q = Convert.ToInt32(r_qC_q[1]);
		_queen = new Coord(r_q, c_q);

		int[][] obstacles = new int[_obstaclesCount][];

		for (int i = 0; i < _obstaclesCount; i++)
		{
			obstacles[i] = Array.ConvertAll(Console.ReadLine().Split(' '), obstaclesTemp => Convert.ToInt32(obstaclesTemp));
			Coord obstacle = new Coord(obstacles[i][0], obstacles[i][1]);
			CheckAndAddObstacle(obstacle);
		}

		int result = QueensAttack();

		textWriter.WriteLine(result);

		textWriter.Flush();
		textWriter.Close();
	}
}
