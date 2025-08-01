using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private string Game;
    public void StartButton()
    {
        SceneManager.LoadScene(Game);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
