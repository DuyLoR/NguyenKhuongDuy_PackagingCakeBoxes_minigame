using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HowToPlayUIController : MonoBehaviour
{
    public Button exitBtn;
    private void Start()
    {
        exitBtn.onClick.AddListener(BackToHome);
    }

    private void BackToHome()
    {
        SceneManager.LoadScene("Home");
    }
}
