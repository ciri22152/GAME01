using System.Collections.Generic;
using UnityEngine;

public class FieldManager : MonoBehaviour
{
    private BattleManager battleManager;
    public Transform handsCanvas;
    public Transform trashZone;
    public List<Transform> cardZones; // CardZone, CardZone1, CardZone2, CardZone3 のリスト

    private int currentZoneIndex = 0;

    public void InitHands(BattleManager _battleManager)
    {
        battleManager = _battleManager;
        Debug.Log("FieldManager.cs : 初期化完了");

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

    // 使用可能な次のゾーンを返す
    public Transform GetNextAvailableZone()
    {
        // ゾーンがすべて使用されているかチェック
        for (int i = currentZoneIndex; i < cardZones.Count; i++)
        {
            Transform zone = cardZones[i];
            // ゾーン内のカード数を確認
            if (zone.childCount == 0)  // ゾーンにカードがない場合
            {
                currentZoneIndex = i + 1;  // 次のゾーンに進む
                Debug.Log($"次の空きゾーン: {zone.name}");
                return zone;
            }
        }

        Debug.Log("すべてのゾーンが使用されています！");
        return null; // 空いているゾーンがない場合
    }
}