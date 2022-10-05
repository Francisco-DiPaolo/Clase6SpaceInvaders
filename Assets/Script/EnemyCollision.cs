using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Laser") && collision.transform.rotation.z == 0)
        {
            AudioManager.instanceSound("invaderKilled");
            this.gameObject.SetActive(false);
            collision.gameObject.SetActive(false);
        }
    }
}
