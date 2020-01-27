using UnityEngine;

public abstract class CellEdgeMaze : MonoBehaviour {

	public CellMaze cell, otherCell;

	public DirectionMaze direction;

	public void Initialize (CellMaze cell, CellMaze otherCell, DirectionMaze direction) {
		this.cell = cell;
		this.otherCell = otherCell;
		this.direction = direction;
		cell.SetEdge(direction, this);
		transform.parent = cell.transform;
		transform.localPosition = Vector3.zero;

		transform.localRotation = direction.ToRotation();
	}
}