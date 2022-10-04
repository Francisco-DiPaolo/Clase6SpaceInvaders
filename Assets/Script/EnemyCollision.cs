using UnityEngine;

public class EnemyCollision : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.layer == LayerMask.NameToLayer("Laser"))
        {
            this.gameObject.SetActive(false);
            collision.gameObject.SetActive(false);
        }
    }
}
