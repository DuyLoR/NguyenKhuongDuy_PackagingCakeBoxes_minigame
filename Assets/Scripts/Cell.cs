using UnityEngine;

public class Cell : MonoBehaviour
{
    public Cell right;
    public Cell down;
    public Cell left;
    public Cell up;

    public Fill fill;

    public Sprite cakeSprite;
    public Sprite candySprite;
    public Sprite giftSprite;
    private void Start()
    {
        if (transform.childCount != 0)
        {
            fill = transform.GetChild(0).GetComponent<Fill>();
        }
    }
    private void OnEnable()
    {
        GameController.slide += OnSlide;
    }
    private void OnDisable()
    {
        GameController.slide -= OnSlide;
    }

    private void OnSlide(string whatWasSend)
    {
        if (whatWasSend == "w")
        {
            if (up != null)
            {
                return;
            }
            Cell currentCell = this;
            SlideUp(currentCell);

        }
        if (whatWasSend == "s")
        {
            if (down != null)
            {
                return;
            }
            Cell currentCell = this;
            SlideDown(currentCell);
        }
        if (whatWasSend == "a")
        {
            if (left != null)
            {
                return;
            }
            Cell currentCell = this;
            SlideLeft(currentCell);
        }
        if (whatWasSend == "d")
        {
            if (right != null)
            {
                return;
            }
            Cell currentCell = this;
            SlideRight(currentCell);
        }
    }

    private void SlideRight(Cell currentCell)
    {
        if (currentCell.left == null)
        {
            return;
        }
        if (currentCell.fill != null)
        {
            Cell nextCell = currentCell.left;
            while (nextCell.left != null && nextCell.fill == null)
            {
                nextCell = nextCell.left;
            }
            if (nextCell.fill != null)
            {
                if (nextCell.fill.fillSprite == candySprite) return;
                if (currentCell.left.fill == null)
                {
                    nextCell.fill.transform.parent = currentCell.left.transform;
                    currentCell.left.fill = nextCell.fill;
                    nextCell.fill = null;
                }
            }
        }
        else
        {
            Cell nextCell = currentCell.left;
            while (nextCell.left != null && nextCell.fill == null)
            {
                nextCell = nextCell.left;
            }
            if (nextCell.fill != null)
            {
                if (nextCell.fill.fillSprite == candySprite) return;
                nextCell.fill.transform.parent = currentCell.transform;
                currentCell.fill = nextCell.fill;
                nextCell.fill = null;
                SlideRight(currentCell);
            }
        }
        if (currentCell.left == null)
        {
            return;
        }
        SlideRight(currentCell.left);
    }

    private void SlideLeft(Cell currentCell)
    {
        if (currentCell.right == null)
        {
            return;
        }
        if (currentCell.fill != null)
        {
            Cell nextCell = currentCell.right;
            while (nextCell.right != null && nextCell.fill == null)
            {
                nextCell = nextCell.right;
            }
            if (nextCell.fill != null)
            {
                if (nextCell.fill.fillSprite == candySprite) return;
                if (currentCell.right.fill == null)
                {
                    nextCell.fill.transform.parent = currentCell.right.transform;
                    currentCell.right.fill = nextCell.fill;
                    nextCell.fill = null;
                }
            }
        }
        else
        {
            Cell nextCell = currentCell.right;
            while (nextCell.right != null && nextCell.fill == null)
            {
                nextCell = nextCell.right;
            }
            if (nextCell.fill != null)
            {
                if (nextCell.fill.fillSprite == candySprite) return;
                nextCell.fill.transform.parent = currentCell.transform;
                currentCell.fill = nextCell.fill;
                nextCell.fill = null;
                SlideLeft(currentCell);
            }
        }
        if (currentCell.right == null)
        {
            return;
        }
        SlideLeft(currentCell.right);
    }

    private void SlideDown(Cell currentCell)
    {
        if (currentCell.up == null)
        {
            return;
        }
        if (currentCell.fill != null)
        {
            Cell nextCell = currentCell.up;
            while (nextCell.up != null && nextCell.fill == null)
            {
                nextCell = nextCell.up;
            }
            if (nextCell.fill != null)
            {
                if (nextCell.fill.fillSprite == candySprite) return;
                if (currentCell.fill.fillSprite == giftSprite && nextCell.fill.fillSprite == cakeSprite)
                {
                    nextCell.fill.transform.parent = currentCell.transform;
                    currentCell.fill = nextCell.fill;
                    nextCell.fill.canDestroy = true;
                }
                else if (currentCell.up.fill == null)
                {
                    nextCell.fill.transform.parent = currentCell.up.transform;
                    currentCell.up.fill = nextCell.fill;
                    nextCell.fill = null;
                }
            }
        }
        else
        {
            Cell nextCell = currentCell.up;
            while (nextCell.up != null && nextCell.fill == null)
            {
                nextCell = nextCell.up;
            }
            if (nextCell.fill != null)
            {
                if (nextCell.fill.fillSprite == candySprite) return;
                nextCell.fill.transform.parent = currentCell.transform;
                currentCell.fill = nextCell.fill;
                nextCell.fill = null;
                SlideDown(currentCell);
            }
        }
        if (currentCell.up == null)
        {
            return;
        }
        SlideDown(currentCell.up);
    }

    public void SlideUp(Cell currentCell)
    {
        if (currentCell.down == null)
        {
            return;
        }
        if (currentCell.fill != null)
        {
            Cell nextCell = currentCell.down;
            while (nextCell.down != null && nextCell.fill == null)
            {
                nextCell = nextCell.down;
            }
            if (nextCell.fill != null)
            {
                if (nextCell.fill.fillSprite == candySprite) return;
                if (currentCell.fill.fillSprite == cakeSprite && nextCell.fill.fillSprite == giftSprite)
                {
                    currentCell.fill.canDestroy = true;
                    nextCell.fill.transform.parent = currentCell.transform;
                    this.fill = nextCell.fill;
                    nextCell.fill = null;
                }
                else if (currentCell.down.fill == null)
                {
                    nextCell.fill.transform.parent = currentCell.down.transform;
                    currentCell.down.fill = nextCell.fill;
                    nextCell.fill = null;
                }
            }
        }
        else
        {
            Cell nextCell = currentCell.down;
            while (nextCell.down != null && nextCell.fill == null)
            {
                nextCell = nextCell.down;
            }
            if (nextCell.fill != null)
            {
                if (nextCell.fill.fillSprite == candySprite) return;
                nextCell.fill.transform.parent = currentCell.transform;
                currentCell.fill = nextCell.fill;
                nextCell.fill = null;
                SlideUp(currentCell);
            }
        }
        if (currentCell.down == null)
        {
            return;
        }
        SlideUp(currentCell.down);
    }
}
