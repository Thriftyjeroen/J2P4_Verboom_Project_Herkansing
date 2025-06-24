using UnityEngine;

public class MovementHandler : MonoBehaviour
{
    [SerializeField] Grid grid;
    private Vector3Int currentCell;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
           // SnapToTopOfTile();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(0.5f, 0, 0);
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Rotate(0, 0, 90);
        }
    }

    private void SnapToTopOfTile(Vector3Int cellPos)
    {
        Vector3 cellCenter = grid.GetCellCenterWorld(cellPos);
        Vector3 cellSize = grid.cellSize;

        Vector3 topOfTile = new Vector3(
            cellCenter.x,
            cellCenter.y + (cellSize.y / 2f),
            transform.position.z
        );

        transform.position = topOfTile;
    }
}
