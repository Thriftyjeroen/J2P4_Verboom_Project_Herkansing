using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Tilemaps;
public class FallingBlockBehaviour : MonoBehaviour
{
    [SerializeField] GameObject[] positions;
    [SerializeField] Grid grid;
    private Vector3Int currentCell;

    bool moving = true;
    bool initDone = false;

    private void Start()
    {
        if (grid == null) return;
        if (initDone) return;

        Init(grid);
    }

    public void Init(Grid pGrid)
    {
        grid = pGrid;
        currentCell = grid.WorldToCell(transform.position);
        SnapToTile(currentCell);
        StartCoroutine(MoveDown());
        initDone = true;
    }

    IEnumerator MoveDown()
    {
        while (moving)
        {
            yield return new WaitForSecondsRealtime(0.5f);
            currentCell += Vector3Int.down;
            SnapToTile(currentCell);
        }
        yield return null;
    }

    private void SnapToTile(Vector3Int cellPos)
    {
        if (!moving) return;

        Vector3 cellCenter = grid.GetCellCenterWorld(cellPos);
        Vector3 cellSize = grid.cellSize;

        if (transform.localEulerAngles.z == 90 || transform.localEulerAngles.z == 270)
        {
            Vector3 topOfTile = new Vector3(
                cellCenter.x,
                cellCenter.y + (cellSize.y / 2f),
                transform.position.z
            );

            transform.position = topOfTile;
        }
        else
        {
            Vector3 sideOfTile = new Vector3(
                cellCenter.x + (cellSize.x / 2f),
                cellCenter.y,
                transform.position.z
            );

            transform.position = sideOfTile;
        }
    }

    void Update()
    {
        if (!moving) return; 
        foreach (GameObject pos in positions)
        {
            RaycastHit2D[] hits = Physics2D.RaycastAll(pos.transform.position, Vector3.down, 0.3f);
            
            foreach (RaycastHit2D hit in hits)
            {
                bool isSelf = false;
                foreach (Transform child in transform.GetComponentsInChildren<Transform>())
                {
                    if (hit.collider.gameObject == child.gameObject)
                    {
                        isSelf = true;
                        break;
                    }
                }

                if (!isSelf)
                {
                    moving = false;
                    return;
                }
            }
        }
        
        if (!initDone) return;
        if (!moving) return;

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            SnapToTile(currentCell += Vector3Int.left);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            SnapToTile(currentCell += Vector3Int.right);
        }


        if (Input.GetKeyDown(KeyCode.Z))
        {
            transform.Rotate(0, 0, -90);
            SnapToTile(currentCell);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            transform.Rotate(0, 0, 90);
            SnapToTile(currentCell);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            currentCell += Vector3Int.down;
            SnapToTile(currentCell);
        }
    }
}
