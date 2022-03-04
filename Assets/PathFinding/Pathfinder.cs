using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{

    [SerializeField] Node currentSearchNode;
    Vector2Int[] directions ={ Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down };
    Dictionary<Vector2Int, Node> grid;
    GridManager gridManager;

    void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        if(gridManager != null)
        {
            grid = gridManager.Grid;
        }
    }

    void Start()
    {
        ExploreNeighbours();
    }

    void ExploreNeighbours()
    {
        List<Node> neighbours = new List<Node>();
        foreach(Vector2Int direction in directions)
        {
           Vector2Int neighbourCoordinates = currentSearchNode.coordinates + direction;
            if(grid.ContainsKey(neighbourCoordinates))
            {
              neighbours.Add(grid[neighbourCoordinates]);  

              // TODO: Remove after testing
              grid[neighbourCoordinates].isExplored = true;
              grid[currentSearchNode.coordinates].isPath = true;
            }
        }
    }


}
