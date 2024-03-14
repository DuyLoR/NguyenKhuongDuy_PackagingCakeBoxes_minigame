using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayUIController : MonoBehaviour
{
    public static GamePlayUIController instance;
    public Button homeBtn;
    public Button resetBtn;
    public GameObject levelComplate;
    public GameObject levelFailed;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        homeBtn.onClick.AddListener(BackToHome);
        resetBtn.onClick.AddListener(LoadSence);
    }

    public void LoadSence()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToHome()
    {
        SceneManager.LoadScene("Home");
    }
    public void LevelComplate()
    {
        levelComplate.SetActive(true);
    }
    public void LevelFailed()
    {
        levelFailed.SetActive(true);
    }
    public void NextLevel()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (sceneIndex < SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(sceneIndex);
        else
        {
            SceneManager.LoadScene("Home");
        }
    }
    public void SelectLevel()
    {
        SceneManager.LoadScene("SelectLevel");
    }
}
