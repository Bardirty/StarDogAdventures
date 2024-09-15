using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Image autors;
    private bool isAutors = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isAutors)
        {
            autors.gameObject.SetActive(false);
            isAutors = false;
        }
    }
    public void Play()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void Autors()
    {
        autors.gameObject.SetActive(true);
        isAutors = true;
    }
    public void Exit()
    {
        Application.Quit();
    }
}
