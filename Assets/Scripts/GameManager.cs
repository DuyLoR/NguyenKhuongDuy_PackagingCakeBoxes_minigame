using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private const string Level = "Level";
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        int level = PlayerPrefs.GetInt(Level, 1);
    }
    public void UpdateLevel()
    {
        int currentLevel = PlayerPrefs.GetInt(Level, 1);
        if (currentLevel <= 1)
        {
            PlayerPrefs.SetInt(Level, currentLevel++);
            PlayerPrefs.Save();
        }
    }
}
