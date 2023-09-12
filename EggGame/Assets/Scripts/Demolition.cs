using UnityEngine;

public class Demolition : MonoBehaviour
{
    public GameObject GameOver;
    public Bar bar;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tumbler"))
        {
            Destroy(collision.gameObject);
            GameOver.SetActive(true);
            bar.Pause();
        }
    }
}