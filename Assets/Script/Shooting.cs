using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float proyectileSpeed;
    public float cooldownShot;

    float lastShot;
    PoollingObject poolProyectile;

    public virtual void Start()
    {
        poolProyectile = FindObjectOfType<PoollingObject>();
    }

    public virtual void Shoot(Transform transformShotPosition)
    {
        if (Time.time - lastShot < cooldownShot)
        {
            return;
        }
        lastShot = Time.time;

        GameObject proyectile = poolProyectile.GetPooledObject();

        if (proyectile != null)
        {
            proyectile.transform.position = transformShotPosition.position;
            proyectile.transform.rotation = transformShotPosition.rotation;
            proyectile.SetActive(true);
            proyectile.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0, proyectileSpeed));
        }
    }
}
