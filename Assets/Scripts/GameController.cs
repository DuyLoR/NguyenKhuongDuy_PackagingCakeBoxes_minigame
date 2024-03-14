using System;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Sprite cakeSprite;
    [SerializeField] private Sprite candySprite;
    [SerializeField] private Sprite giftSprite;
    [SerializeField] private GameObject fillPrefab;
    [SerializeField] private Transform[] allCells;
    [SerializeField] private TextMeshProUGUI timeTMP;

    private float timer = 45f;
    public static Action<string> slide;

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0.1)
        {
            GamePlayUIController.instance.LevelFailed();
        }
        else
        {
            UpdateTimeText();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            slide("w");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            slide("s");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            slide("a");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            slide("d");
        }
    }
    private void UpdateTimeText()
    {
        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.FloorToInt(timer % 60f);

        timeTMP.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}
