using UnityEngine;

public class CardManager : MonoBehaviour
{
    public GameObject cardPrefab;       // カードのプレハブ
    public Transform cardParent;        // カードを配置する親オブジェクト

    public CardData[] cardDataArray;    // 使用するCardData（配列）

    void Start()
    {
        CreateCards();
    }

    void CreateCards()
    {
        foreach (CardData cardData in cardDataArray)
        {
            // カードプレハブをインスタンス化
            GameObject newCard = Instantiate(cardPrefab, cardParent);

            // CardDisplayスクリプトを取得
            CardDisplay cardDisplay = newCard.GetComponent<CardDisplay>();

            // CardDataから情報を設定
            cardDisplay.SetCardData(cardData);
        }
    }
}
