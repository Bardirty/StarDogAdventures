using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowController : MonoBehaviour
{
    [SerializeField] private bool isPlayer = false;
    private PlayerController player;
    private float throwForce = 10f;
    private BossController bossController;
    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
        if(transform.parent.gameObject.CompareTag("Player"))
            isPlayer = true;
        bossController = FindObjectOfType<BossController>();
    }
    public void Throw(Vector2 direction)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(direction * throwForce, ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Enemy") && isPlayer)
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
        if(col.CompareTag("Boss") && isPlayer)
        {
            bossController.bossHealth--;
            Destroy(gameObject);
        }
        else if(col.CompareTag("Player") && !isPlayer) 
        {
            player.health--;
            Destroy(gameObject);
        }
    }
}
