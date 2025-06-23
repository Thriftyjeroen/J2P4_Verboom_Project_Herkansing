using UnityEngine;

public class MovementHandler : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position -= new Vector3(0.5f, 0, 0);
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
}
