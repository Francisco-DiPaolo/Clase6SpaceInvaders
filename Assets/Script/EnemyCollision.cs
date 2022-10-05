using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    Enemy enemiesList;

    private void Start()
    {
        enemiesList = FindObjectOfType<Enemy>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Laser") && collision.transform.rotation.z == 0)
        {
            AudioManager.instanceSound("invaderKilled");
            GameManager.addScoreEvent?.Invoke();
            collision.gameObject.SetActive(false);

            enemiesList.enemies.Remove(gameObject);
            gameObject.SetActive(false);

            enemiesList.speedEnemy = enemiesList.enemiestotal / enemiesList.enemies.Count;
        }
    }
}
