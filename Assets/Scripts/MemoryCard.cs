using UnityEngine;

public class MemoryCard : MonoBehaviour
{
    [SerializeField] GameObject cardBack;
    [SerializeField] SceneController sceneController;

    private int _id;
    public int Id
    {
        get { return _id; }
    }

    public void SetCard(int id, Sprite image)
    {
        _id = id;
        GetComponent<SpriteRenderer>().sprite = image;
    }

    public void OnMouseDown()
    {
        if (cardBack.activeSelf && sceneController.canReveal)
        {
            cardBack.SetActive(false);
            sceneController.CardReveal(this);
        }
    }

    public void Unreveal() => cardBack.SetActive(true);
}
