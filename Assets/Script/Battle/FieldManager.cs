using System.Collections.Generic;
using UnityEngine;

public class FieldManager : MonoBehaviour
{
    private BattleManager battleManager;
    public Transform handsCanvas;
    public Transform trashZone;
    public CardZone playBoardZone; // プレイボードゾーンの参照

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

    // プレイボードゾーンを返す
    public CardZone GetPlayBoardZone()
    {
        return playBoardZone;
    }
}