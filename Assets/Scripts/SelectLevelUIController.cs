using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevelUIController : MonoBehaviour
{
    public void BackToHome()
    {
        SceneManager.LoadScene("Home");
    }
}
