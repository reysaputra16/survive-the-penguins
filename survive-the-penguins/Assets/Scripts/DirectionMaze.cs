using UnityEngine;

public enum DirectionMaze {
	North,
	East,
	South,
	West
}

public static class DirectionsMaze {

	public const int Count = 4;

	public static DirectionMaze RandomValue {
		get {
			return (DirectionMaze)Random.Range(0, Count);
		}
	}

	private static DirectionMaze[] opposites = {
		DirectionMaze.South,
		DirectionMaze.West,
		DirectionMaze.North,
		DirectionMaze.East
	};

	public static DirectionMaze GetOpposite (this DirectionMaze direction) {
		return opposites[(int)direction];
	}
	
	private static IntVector[] vectors = {
		new IntVector(0, 1),
		new IntVector(1, 0),
		new IntVector(0, -1),
		new IntVector(-1, 0)
	};
	
	public static IntVector ToIntVector (this DirectionMaze direction) {
		return vectors[(int)direction];
	}

	private static Quaternion[] rotations = {
		Quaternion.identity,
		Quaternion.Euler(0f, 90f, 0f),
		Quaternion.Euler(0f, 180f, 0f),
		Quaternion.Euler(0f, 270f, 0f)
	};
	
	public static Quaternion ToRotation (this DirectionMaze direction) {
		return rotations[(int)direction];
	}
}