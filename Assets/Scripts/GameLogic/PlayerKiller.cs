using UnityEngine;

public class PlayerKiller : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("The player is dead.");
        }
    }
}
