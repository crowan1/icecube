using UnityEngine;

public class DirectionCollider : MonoBehaviour
{
    PlayerMovement2D player;

    void Awake()
    {
        player = GetComponentInParent<PlayerMovement2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(player.wallTag))
        {
            player.Stop();
        }
    }
}
