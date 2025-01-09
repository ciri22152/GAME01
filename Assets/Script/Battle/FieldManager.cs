using System.Collections.Generic;
using UnityEngine;

public class FieldManager : MonoBehaviour
{
    private BattleManager battleManager; // 戦闘画面マネージャ
    public Transform handsCanvas; // HandsキャンバスのTransform
    public Transform trashZone; // トラッシュゾーンのTransform
    public Transform cardZone; // CardZoneのTransform

    // 初期化処理
    public void InitHands(BattleManager _battleManager)
    {
        battleManager = _battleManager;
        Debug.Log("FieldManager.cs : 初期化完了");

        // カードをランダムに配置
        PlaceRandomCards();
    }

    private void PlaceRandomCards()
    {
        List<Transform> cards = new List<Transform>();

        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            if (child.name.StartsWith("Card"))
            {
                cards.Add(child);
            }
        }

        for (int i = 0; i < cards.Count; i++)
        {
            Transform temp = cards[i];
            int randomIndex = Random.Range(i, cards.Count);
            cards[i] = cards[randomIndex];
            cards[randomIndex] = temp;
        }

        for (int i = 0; i < 5 && i < cards.Count; i++)
        {
            cards[i].SetParent(handsCanvas, false);
        }
    }

    // CardZoneイメージ内のカードのHPを減少させるメソッド
    public void ReduceHPInCardZone(int amount)
    {
        if (cardZone == null)
        {
            Debug.LogError("CardZoneが設定されていません！");
            return;
        }

        foreach (Transform card in cardZone)
        {
            Card cardComponent = card.GetComponent<Card>();
            if (cardComponent != null)
            {
                cardComponent.ReduceHP(amount);
            }
        }
    }
}
