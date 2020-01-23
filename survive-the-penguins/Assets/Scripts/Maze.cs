﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Maze : MonoBehaviour
{
    public int sizeX, sizeZ;
    public MazeCell cellPrefab;
    private MazeCell[,] cells;

    //generate maze with the size sizeX and sizeZ
    public void Generate()
    {
        cells = new MazeCell[sizeX, sizeZ];
        for (int x = 0; x < sizeX; x++)
        {
            for (int z = 0; z < sizeZ; z++)
            {
                CreateCell(x, z);
            }
        }
    }

    //fill the cells
    private void CreateCell(int x, int z)
    {
        //fill the floor of the maze according to the size
        MazeCell newCell = Instantiate(cellPrefab) as MazeCell;
        cells[x, z] = newCell;
        newCell.name = "Maze Cell " + x + ", " + z;
        //turn the maze cell into a child object of the maze
        newCell.transform.parent = transform;
        //position so that the entire grid is centered on the middle
        newCell.transform.localPosition = new Vector3(x - sizeX * 0.5f + 0.5f, 0f, z - sizeZ * 0.5f + 0.5f);
    }
}
