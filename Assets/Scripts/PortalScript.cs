using System;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    public PortalScript arrivalTp;
    public bool IsActive { get; set; }


    void Start()
    {
        IsActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsActive && (collision.tag == "player" || collision.tag == "Enemy"))
        {
            arrivalTp.IsActive = false;
            collision.transform.position = arrivalTp.transform.position;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "player" || collision.tag == "Enemy")
        {
            IsActive = true;
        }
    }
}
