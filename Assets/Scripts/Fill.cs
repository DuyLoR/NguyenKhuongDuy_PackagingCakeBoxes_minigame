using UnityEngine;
using UnityEngine.UI;

public class Fill : MonoBehaviour
{
    [SerializeField] public Sprite fillSprite;
    [SerializeField] public float speed;
    public bool canDestroy;
    private void Awake()
    {
        if (fillSprite != null)
        {
            gameObject.GetComponent<Image>().sprite = fillSprite;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        if (transform.localPosition != Vector3.zero)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, Vector3.zero, speed * Time.deltaTime);
        }
        if (canDestroy)
        {
            if (transform.localPosition == Vector3.zero)
            {
                GamePlayUIController.instance.LevelComplate();
                Destroy(gameObject);
            }
        }
    }
}
