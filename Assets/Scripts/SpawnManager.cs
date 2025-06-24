using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] blocks;
    [SerializeField] Grid grid;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject block = Instantiate(blocks[Random.Range(0, blocks.Length)], transform);
            block.GetComponent<FallingBlockBehaviour>().Init(grid);
        }
    }
}
