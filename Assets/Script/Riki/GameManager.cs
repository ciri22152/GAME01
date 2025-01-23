using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject selectedCard;  // 選ばれたカード

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // 手札からカードを選ぶ処理
    public void SelectCard(GameObject card)
    {
        if (selectedCard != null)
        {
            // 既に選ばれたカードがあれば選択解除などの処理
        }

        selectedCard = card;  // 新しいカードを選択
        Debug.Log("選ばれたカード: " + selectedCard.name);
    }
}
