using UnityEngine;

public class MeleeHitbox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hitbox just touched: " + collision.gameObject.name);

        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Hit enemy");
            Destroy(collision.gameObject);
        }
    }
}