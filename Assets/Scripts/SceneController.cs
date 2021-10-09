using UnityEngine;

public class SceneController : MonoBehaviour
{
    public const int gridRows = 2;
    public const int gridCols = 4;
    public const float offsetX = 2f;
    public const float offsetY = 2.5f;

    [SerializeField] MemoryCard originalCard;
    [SerializeField] Sprite[] images;

    private void Start()
    {
        // First card will determine offset rest of the cards
        Vector3 startPos = originalCard.transform.position;

        for(int i = 0; i < gridCols; i++)
        {
            for (int j = 0; j < gridRows; j++)
            {
                MemoryCard card;
                // Create a new card if it's not the base card
                if (i == 0 && j == 0) card = originalCard;
                else card = Instantiate(originalCard) as MemoryCard;

                // Randomize card
                int id = Random.Range(0, images.Length);
                originalCard.SetCard(id, images[id]);

                // Place card
                float posX = (offsetX * i) + startPos.x;
                float posY = -(offsetY * j) + startPos.y;
                card.transform.position = new Vector3(posX, posY, startPos.z);
            }
        }

    }
}
