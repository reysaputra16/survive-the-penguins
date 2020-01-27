using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MazeFull : MonoBehaviour {

	public IntVector size;

	public CellMaze cellPrefab;

	public float generationStepDelay;

	public PassageMaze passagePrefab;
	public WallMaze wallPrefab;

	private CellMaze[,] cells;

	public IntVector RandomCoordinates {
		get {
			return new IntVector(Random.Range(0, size.x), Random.Range(0, size.z));
		}
	}

	public bool ContainsCoordinates (IntVector coordinate) {
		return coordinate.x >= 0 && coordinate.x < size.x && coordinate.z >= 0 && coordinate.z < size.z;
	}

	public CellMaze GetCell (IntVector coordinates) {
		return cells[coordinates.x, coordinates.z];
	}

	public IEnumerator Generate () {
		WaitForSeconds delay = new WaitForSeconds(generationStepDelay);
		cells = new CellMaze[size.x, size.z];
		List<CellMaze> activeCells = new List<CellMaze>();
		DoFirstGenerationStep(activeCells);
		while (activeCells.Count > 0) {
			yield return delay;
			NextStep(activeCells);
		}
	}

	private void DoFirstGenerationStep (List<CellMaze> activeCells) {
		activeCells.Add(CreateCell(RandomCoordinates));
	}

    private void NextStep(List<CellMaze> activeCells) {
		int currentIndex = activeCells.Count - 1;
		CellMaze currentCell = activeCells[currentIndex];
		if (currentCell.IsFullyInitialized) {
			activeCells.RemoveAt(currentIndex);
			return;
		}
		DirectionMaze direction = currentCell.RandomUninitializedDirection;
		IntVector coordinates = currentCell.coordinates + direction.ToIntVector();
		if (ContainsCoordinates(coordinates)) {
            CellMaze neighbor = GetCell(coordinates);
			if (neighbor == null) {
				neighbor = CreateCell(coordinates);
				CreatePassage(currentCell, neighbor, direction);
				activeCells.Add(neighbor);
			}
			else {
				CreateWall(currentCell, neighbor, direction);
			}
		}
		else {
			CreateWall(currentCell, null, direction);
		}
	}

	private CellMaze CreateCell (IntVector coordinates) {
		CellMaze newCell = Instantiate(cellPrefab) as CellMaze;
		cells[coordinates.x, coordinates.z] = newCell;
		newCell.coordinates = coordinates;
		newCell.name = "Maze Cell " + coordinates.x + ", " + coordinates.z;
		newCell.transform.parent = transform;
		newCell.transform.localPosition = new Vector3(coordinates.x - size.x * 0.5f + 0.5f, 0f, coordinates.z - size.z * 0.5f + 0.5f);
		return newCell;
	}

    private void CreatePassage(CellMaze cell, CellMaze otherCell, DirectionMaze direction) {
        PassageMaze passage = Instantiate(passagePrefab) as PassageMaze;
		passage.Initialize(cell, otherCell, direction);
		passage = Instantiate(passagePrefab) as PassageMaze;
		passage.Initialize(otherCell, cell, direction.GetOpposite());
	}

	private void CreateWall (CellMaze cell, CellMaze otherCell, DirectionMaze direction) {
		WallMaze wall = Instantiate(wallPrefab) as WallMaze;
		wall.Initialize(cell, otherCell, direction);
		if (otherCell != null) {
			wall = Instantiate(wallPrefab) as WallMaze;
			wall.Initialize(otherCell, cell, direction.GetOpposite());
		}
	}
}