using UnityEngine;

public class CellMaze : MonoBehaviour {

	public IntVector coordinates;

	private CellEdgeMaze[] edges = new CellEdgeMaze[DirectionsMaze.Count];

	private int initializedEdgeCount;

	public bool IsFullyInitialized {
		get {
			return initializedEdgeCount == DirectionsMaze.Count;
		}
	}

	public DirectionMaze RandomUninitializedDirection {
		get {
			int skips = Random.Range(0, DirectionsMaze.Count - initializedEdgeCount);
			for (int i = 0; i < DirectionsMaze.Count; i++) {
				if (edges[i] == null) {
					if (skips == 0) {
						return (DirectionMaze)i;
					}
					skips -= 1;
				}
			}
			throw new System.InvalidOperationException("MazeCell has no uninitialized directions left.");
		}
	}

	public CellEdgeMaze GetEdge (DirectionMaze direction) {
		return edges[(int)direction];
	}

	public void SetEdge (DirectionMaze direction, CellEdgeMaze edge) {
		edges[(int)direction] = edge;
		initializedEdgeCount += 1;
	}
}