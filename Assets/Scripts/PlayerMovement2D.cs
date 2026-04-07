using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    public float moveSpeed;
    public string wallTag = "Wall";
    public float bufferTime = 0.3f;

    public GameObject colliderRight;
    public GameObject colliderLeft;
    public GameObject colliderUp;
    public GameObject colliderDown;

    Rigidbody2D rb;
    Vector2 moveDirection = Vector2.zero;
    bool isMoving = false;

    Vector2 bufferedDirection = Vector2.zero;
    float bufferTimer = 0f;
    int bufferUsedCount = 0;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        DisableAllColliders();
    }

    void Update()
    {
        Vector2 inputDirection = GetInputDirection();

        if (inputDirection != Vector2.zero)
        {
            if (!isMoving)
            {
                StartMoving(inputDirection);
            }
            else
            {
                bufferedDirection = inputDirection;
                bufferTimer = bufferTime;
            }
        }

        if (bufferTimer > 0f)
        {
            bufferTimer -= Time.deltaTime;
            if (bufferTimer <= 0f)
            {
                bufferedDirection = Vector2.zero;
            }
        }
    }

    Vector2 GetInputDirection()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            return Vector2.right;
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            return Vector2.left;
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            return Vector2.up;
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            return Vector2.down;
        return Vector2.zero;
    }

    void StartMoving(Vector2 direction)
    {
        moveDirection = direction;
        ActivateCollider(direction);
        isMoving = true;
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

        if (bufferedDirection != Vector2.zero && bufferTimer > 0f)
        {
            bufferUsedCount++;
            Debug.Log("Buffer utilise: " + bufferUsedCount + " fois");
            StartMoving(bufferedDirection);
            bufferedDirection = Vector2.zero;
            bufferTimer = 0f;
        }
    }

    void ActivateCollider(Vector2 direction)
    {
        DisableAllColliders();
        if (direction == Vector2.right) colliderRight.SetActive(true);
        else if (direction == Vector2.left) colliderLeft.SetActive(true);
        else if (direction == Vector2.up) colliderUp.SetActive(true);
        else if (direction == Vector2.down) colliderDown.SetActive(true);
    }

    void DisableAllColliders()
    {
        colliderRight.SetActive(false);
        colliderLeft.SetActive(false);
        colliderUp.SetActive(false);
        colliderDown.SetActive(false);
    }
}
