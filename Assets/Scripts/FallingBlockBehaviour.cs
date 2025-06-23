using System.Collections;
using UnityEngine;

public class FallingBlockBehaviour : MonoBehaviour
{
    bool stopMoving = false;
    void Start()
    {
        StartCoroutine(MoveDown());
    }
    IEnumerator MoveDown()
    {
        while (!stopMoving)
        {
            transform.position -= new Vector3(0, 0.5f, 0);
            yield return new WaitForSecondsRealtime(0.5f);
        }
        yield return null;
    }
}
