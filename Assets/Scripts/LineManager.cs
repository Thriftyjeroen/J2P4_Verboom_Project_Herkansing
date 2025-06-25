using System.Collections;
using UnityEngine;

public class LineManager : MonoBehaviour
{
    [SerializeField] Grid grid;
    private Vector3Int currentCell;
    private Vector3Int startPos;

    private void Start()
    {
        currentCell = startPos = grid.WorldToCell(transform.position);
    }

    // Update is called once per frame
    public IEnumerator CheckForLines()
    {
        for (int i = 0; i < 18; i++)
        {
            Vector3 cellCenter = grid.GetCellCenterWorld(currentCell);

            transform.position = cellCenter;

            RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, Vector3.right, 6f);
            Debug.DrawLine(transform.position, transform.position + new Vector3(6, 0, 0), Color.blue, 2);

            if (i == 0)
            {
                print(hits.Length);

                foreach (RaycastHit2D hit in hits)
                {
                    print(hit.collider.gameObject.name);
                }
            }
            

            if (hits.Length > 9)
            {
                foreach (RaycastHit2D hit in hits)
                {
                    Destroy(hit.collider.gameObject);
                }

                foreach (FallingBlockBehaviour fallingScript in GetComponentInParent<SpawnManager>().GetComponentsInChildren<FallingBlockBehaviour>())
                {
                    StartCoroutine(fallingScript.FallDown());
                }
            }

            currentCell += Vector3Int.up;
        }

        currentCell = startPos;
        yield return null;
    }
}
