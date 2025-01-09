using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// フィールド管理クラス
/// </summary>
public class FieldManager : MonoBehaviour
{
    // オブジェクト・コンポーネント参照
    private BattleManager battleManager; // 戦闘画面マネージャ
    public Transform handsCanvas; // HandsキャンパスのTransform

    // 初期化処理
    public void InitHands(BattleManager _battleManager)
    {
        // 参照取得
        battleManager = _battleManager;

        Debug.Log("FieldManager.cs : 初期化完了");

        // カードをランダムに配置
        PlaceRandomCards();
    }

    // カードをランダムに配置するメソッド
    private void PlaceRandomCards()
    {
        List<Transform> cards = new List<Transform>();

        // 子オブジェクトからカードを取得
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            if (child.name.StartsWith("Card"))
            {
                cards.Add(child);
            }
        }

        // カードをランダムにシャッフル
        for (int i = 0; i < cards.Count; i++)
        {
            Transform temp = cards[i];
            int randomIndex = Random.Range(i, cards.Count);
            cards[i] = cards[randomIndex];
            cards[randomIndex] = temp;
        }

        // 最初の5枚をHandsキャンパスに配置
        for (int i = 0; i < 5 && i < cards.Count; i++)
        {
            cards[i].SetParent(handsCanvas, false);
        }
    }

    // Update
    void Update()
    {

    }
}