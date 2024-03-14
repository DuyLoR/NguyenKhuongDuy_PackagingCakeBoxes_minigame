using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeUIController : MonoBehaviour
{
    public Button playBtn;
    public Button howToPlayBtn;
    private void Start()
    {
        playBtn.onClick.AddListener(StartGame);
        howToPlayBtn.onClick.AddListener(HowToPlay);
    }

    private void HowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    private void StartGame()
    {
        SceneManager.LoadScene("LV1");
    }
}
