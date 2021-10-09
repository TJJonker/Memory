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

        int[] numbers = { 0, 0, 1, 1, 2, 2, 3, 3 };
        numbers = ShuffleArray(numbers);

        for(int i = 0; i < gridCols; i++)
        {
            for (int j = 0; j < gridRows; j++)
            {
                MemoryCard card;
                // Create a new card if it's not the base card
                if (i == 0 && j == 0) card = originalCard;
                else card = Instantiate(originalCard) as MemoryCard;

                // Determines card index and assigns ID
                int index = j * gridCols + i;
                int id = numbers[index];
                originalCard.SetCard(id, images[id]);

                // Place card
                float posX = (offsetX * i) + startPos.x;
                float posY = -(offsetY * j) + startPos.y;
                card.transform.position = new Vector3(posX, posY, startPos.z);
            }
        }

    }

    // Shuffles an array with integers
    private int[] ShuffleArray(int[] numbers)
    {
        int[] newArray = numbers.Clone() as int[];
        for(int i = 0; i < newArray.Length; i++)
        {
            // Grabs a certain entry
            int tmp = newArray[i];
            // Grabs a random entry
            int r = Random.Range(i, newArray.Length);
            // Switches the value of the certain and random index
            newArray[i] = newArray[r];
            newArray[r] = tmp;
        }
        return newArray;
    }
}
