using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float speed;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void Movement()
    {
        float inputx = Input.GetAxis("Horizontal");

        if (speed != 0)
        {
            transform.Translate(inputx * Time.deltaTime * speed);
        }
    }
}
