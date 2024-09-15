using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneLoader : MonoBehaviour
{
    private bool isPlayed = false;
    [SerializeField] private PlayableDirector cutSceneManager;
    [SerializeField] private SansDialogueScript sans;
    [SerializeField] private SansAndPapyrusScene sP;
    [SerializeField] private int typeOfAnim = 0;
    [SerializeField] private PlayerController player;
    [SerializeField] private GameObject[] walls;
    [SerializeField] private BossController boss;
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            if (!isPlayed)
            {
                cutSceneManager.Play();
                player.cutSceneFrozen = 0;
                isPlayed = true;
                if (typeOfAnim == 1)
                {
                    sans.StartCoroutine("DialogueLoop");
                    player.spawnPoint.position = transform.position;
                }
                else if (typeOfAnim == 2)
                    for (int i = 0; i < walls.Length; i++)
                        walls[i].SetActive(true);
                else if (typeOfAnim == 3)
                {
                    sP.StartCoroutine("Dialogue");
                    player.spawnPoint.position = transform.position;
                }
            }
            if(typeOfAnim == 2 && !boss.isWon) boss.gameObject.SetActive(true);
        }
    }
    private void Update()
    {
        if (typeOfAnim == 2 && (player.health <= 0 || boss.bossHealth <= 0))
            for (int i = 0; i < walls.Length; i++)
                walls[i].SetActive(false);
        if (player.cutSceneFrozen == 0 && cutSceneManager.state != PlayState.Playing)
            player.cutSceneFrozen = 1;
    }
}
