using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    public float moveSpeed;
    public string wallTag = "Wall";

    public GameObject colliderRight;
    public GameObject colliderLeft;
    public GameObject colliderUp;
    public GameObject colliderDown;

    Rigidbody2D rb;
    Vector2 moveDirection = Vector2.zero;
    bool isMoving = false;

    //public event Action OnEndMovement;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        DisableAllColliders();

        //OnEndMovement?.Invoke();
    }

    void Update()
    {
        if (!isMoving)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                moveDirection = Vector2.right;
                ActivateCollider(colliderRight);
                isMoving = true;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                moveDirection = Vector2.left;
                ActivateCollider(colliderLeft);
                isMoving = true;
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                moveDirection = Vector2.up;
                ActivateCollider(colliderUp);
                isMoving = true;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                moveDirection = Vector2.down;
                ActivateCollider(colliderDown);
                isMoving = true;
            }
        }
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            rb.linearVelocity = moveDirection * moveSpeed;
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
    }

    public void Stop()
    {
        isMoving = false;
        rb.linearVelocity = Vector2.zero;
    }

    void ActivateCollider(GameObject active)
    {
        DisableAllColliders();
        active.SetActive(true);
    }

    void DisableAllColliders()
    {
        colliderRight.SetActive(false);
        colliderLeft.SetActive(false);
        colliderUp.SetActive(false);
        colliderDown.SetActive(false);
    }
}
