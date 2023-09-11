using UnityEngine;

public class Demolition : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tumbler"))
        {
            Destroy(collision.gameObject);
        }
    }
}