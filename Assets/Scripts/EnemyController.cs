using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float enemySpeed;
    private SpriteRenderer sprite;
    private float direction = 1;
    private void Start()
    {
        StartCoroutine(Walking());
        sprite = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        transform.position += new Vector3(direction, 0, 0) * enemySpeed * Time.deltaTime;
        if (transform.position.y < -5) Destroy(gameObject);
        sprite.flipX = direction > 0 ? true : false;
    }

    private IEnumerator Walking()
    {
        yield return new WaitForSeconds(2f);
        direction = -direction;
        Destroy(gameObject, 10f);
        StartCoroutine(Walking());
    }
}
