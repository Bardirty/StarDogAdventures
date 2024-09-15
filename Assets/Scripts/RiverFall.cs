using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverFall : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
            collision.transform.position = spawnPoint.position;
    }
}
