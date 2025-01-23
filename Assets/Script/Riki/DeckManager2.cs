using System.Collections.Generic;
using UnityEngine;

public class DeckManager2 : MonoBehaviour
{
    public Transform deck; // Deckの親オブジェクト（子に20枚のカードが配置されている）
    public Transform handZone; // HandZoneのTransform
    public float handZoneWidth = 750f; // HandZoneの横幅（全体の幅を指定）
    private List<GameObject> deckCards = new List<GameObject>(); // デッキのカードリスト

    void Start()
    {
        InitializeDeck();
        ShuffleDeck();
        DrawInitialHand(5);
    }

    // デッキの初期化: Deckの子オブジェクトをリストに格納
    void InitializeDeck()
    {
        foreach (Transform card in deck)
        {
            deckCards.Add(card.gameObject);
        }
    }

    // デッキをシャッフル
    void ShuffleDeck()
    {
        for (int i = 0; i < deckCards.Count; i++)
        {
            GameObject temp = deckCards[i];
            int randomIndex = Random.Range(0, deckCards.Count);
            deckCards[i] = deckCards[randomIndex];
            deckCards[randomIndex] = temp;
        }
    }

    // 初期手札を引く（必ず1枚は総理または議員カードを含む）
    void DrawInitialHand(int handSize)
    {
        List<GameObject> hand = new List<GameObject>();
        GameObject importantCard = null;

        // 1枚は総理または議員カードを探す
        foreach (GameObject card in deckCards)
        {
            CardBase cardBase = card.GetComponent<CardBase>();
            if (cardBase is PrimeMinisterCard || cardBase is MemberCard)
            {
                importantCard = card;
                break;
            }
        }

        if (importantCard != null)
        {
            hand.Add(importantCard);
            deckCards.Remove(importantCard);
        }

        // 残りのカードを追加
        while (hand.Count < handSize)
        {
            if (deckCards.Count == 0)
            {
                Debug.LogError("デッキにカードが足りません！");
                break;
            }

            hand.Add(deckCards[0]);
            deckCards.RemoveAt(0);
        }

        // 手札をHandZoneに配置
        ArrangeHandCards(hand);
    }

    // 手札を横並びでHandZoneに配置（重ならないよう調整）
    void ArrangeHandCards(List<GameObject> hand)
    {
        int cardCount = hand.Count;
        float cardSpacing = handZoneWidth / (cardCount + 1); // カード間の間隔を計算
        float startX = -handZoneWidth / 2 + cardSpacing; // 配置の開始位置

        for (int i = 0; i < hand.Count; i++)
        {
            GameObject card = hand[i];
            card.transform.SetParent(handZone);
            card.transform.localPosition = new Vector3(startX + i * cardSpacing, 0, 0); // 横並びに配置
            card.transform.localRotation = Quaternion.identity; // 回転をリセット
            // ※ localScaleを維持
        }

        Debug.Log("手札がHandZoneに配置されました。");
    }
}
