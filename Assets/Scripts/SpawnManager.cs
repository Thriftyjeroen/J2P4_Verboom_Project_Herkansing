using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] blocks;
    [SerializeField] Grid grid;

    private void Start()
    {
        SpawnNewBlock();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            GameObject block = Instantiate(blocks[Random.Range(0, blocks.Length)], transform);
            block.GetComponent<FallingBlockBehaviour>().Init(grid);
        }
    }

    public void SpawnNewBlock()
    {
        GameObject block = Instantiate(blocks[Random.Range(0, blocks.Length)], transform);
        block.GetComponent<FallingBlockBehaviour>().Init(grid);
    }
}
