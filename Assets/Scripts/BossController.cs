using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.U2D;

public class BossController : MonoBehaviour
{
    [SerializeField] private Transform bossStartPos;
    [SerializeField] private ThrowController yuyWeaponPrefab;
    private SpriteRenderer sprite;
    [SerializeField] private float speed;
    [SerializeField] private PlayerController player;
    [SerializeField] private BossCutsceneWin cut;
    [SerializeField] private PlayableDirector cutSceneManager;
    public bool isWon = false;
    public int bossHealth = 8;
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        gameObject.SetActive(false);
    }
    private void FixedUpdate()
    {
        transform.position += new Vector3((player.transform.position.x > transform.position.x ? 1 : -1), 0, 0) * speed * Time.deltaTime;
        if (transform.childCount <= 1)
        {
            ThrowController cane = Instantiate(yuyWeaponPrefab, transform.position, Quaternion.identity, transform);
            Vector2 throwDirection = !sprite.flipX ? Vector2.right : Vector2.left;
            cane.Throw(throwDirection);
            Destroy(cane.gameObject, 5.0f);
        }
        if (player.health <= 0)
        {
            bossHealth = 8;
            gameObject.transform.position = bossStartPos.position;
            gameObject.SetActive(false);
            player.health = 3;
            player.transform.position = player.spawnPoint.position;
        }
        else if(bossHealth <= 0) 
        {
            bossHealth = 8;
            BossController bossController = GetComponent<BossController>();
            bossController.enabled = false;
            cutSceneManager.Play();
            cut.StartCoroutine("yuyMonologue");   
            isWon = true;
        }
    }
}