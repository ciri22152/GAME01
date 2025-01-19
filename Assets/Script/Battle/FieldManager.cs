using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UIイベント用

public class FieldManager : MonoBehaviour
{
    private BattleManager battleManager;
    public Transform handsCanvas;
    public Transform trashZone;
    public CardZone playBoardZone; // プレイボードゾーンの参照

    public Button deckButton; // デッキイメージに対応するボタン
    private List<Transform> remainingCards = new List<Transform>(); // デッキに残っているカードのリスト

    public void InitHands(BattleManager _battleManager)
    {
        battleManager = _battleManager;
        Debug.Log("FieldManager.cs : 初期化完了");

        InitializeDeck();
        PlaceRandomCards();

        // デッキイメージのボタンにクリックイベントを登録
        deckButton.onClick.AddListener(DrawCardFromDeck);
    }

    private void InitializeDeck()
    {
        // デッキにカードを登録
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            if (child.name.StartsWith("Card"))
            {
                remainingCards.Add(child);
            }
        }

        // カードをランダムにシャッフル
        for (int i = 0; i < remainingCards.Count; i++)
        {
            Transform temp = remainingCards[i];
            int randomIndex = Random.Range(i, remainingCards.Count);
            remainingCards[i] = remainingCards[randomIndex];
            remainingCards[randomIndex] = temp;
        }
    }

    private void PlaceRandomCards()
    {
        // 初期手札を5枚配置
        for (int i = 0; i < 5 && remainingCards.Count > 0; i++)
        {
            // 先頭のカードを Hands に移動
            Transform card = remainingCards[0];
            card.SetParent(handsCanvas, false);

            // デッキから削除
            remainingCards.RemoveAt(0);
        }
    }


    private void DrawCardFromDeck()
    {
        if (remainingCards.Count > 0)
        {
            // 残りのカードからランダムに1枚取得
            int randomIndex = Random.Range(0, remainingCards.Count);
            Transform selectedCard = remainingCards[randomIndex];

            // Handsに移動
            selectedCard.SetParent(handsCanvas, false);

            // デッキから削除
            remainingCards.RemoveAt(randomIndex);

            Debug.Log($"Card {selectedCard.name} has been drawn and moved to Hands.");
        }
        else
        {
            Debug.Log("No cards left in the deck.");
        }
    }

    // プレイボードゾーンを返す
    public CardZone GetPlayBoardZone()
    {
        return playBoardZone;
    }
}
