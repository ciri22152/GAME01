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

    // カードオブジェクトリスト
    [SerializeField] private Transform cardParent; // カードオブジェクトの親 (20枚のカードの親)
    [SerializeField] private Transform handsCanvas; // Handsキャンバス

    private List<Transform> cardList = new List<Transform>();

    // 初期化処理
    public void Init(BattleManager _battleManager)
    {
        // 参照取得
        battleManager = _battleManager;

        // 子オブジェクトのカードをリストに追加
        foreach (Transform card in cardParent)
        {
            cardList.Add(card);
        }

        Debug.Log("FieldManager.cs : 初期化完了");

        // カードをランダムに配置
        PlaceRandomCards();
    }

    /// <summary>
    /// ランダムに5枚のカードをHandsキャンバスに配置
    /// </summary>
    private void PlaceRandomCards()
    {
        if (cardList.Count < 5)
        {
            Debug.LogError("カードの数が不足しています！");
            return;
        }

        // 使用済みのインデックスを追跡するためのリスト
        List<int> usedIndices = new List<int>();
        int cardCount = 5;

        for (int i = 0; i < cardCount; i++)
        {
            int randomIndex;

            // 未使用のインデックスを選択
            do
            {
                randomIndex = Random.Range(0, cardList.Count);
            } while (usedIndices.Contains(randomIndex));

            usedIndices.Add(randomIndex);

            // カードをHandsキャンバスに移動
            Transform selectedCard = cardList[randomIndex];
            selectedCard.SetParent(handsCanvas);
            selectedCard.localPosition = Vector3.zero; // 初期位置をリセット
            Debug.Log($"カード {selectedCard.name} をHandsに配置しました。");
        }
    }
    /// <summary>
    /// Handsキャンバスの初期化
    /// </summary>
    public void InitHands()
    {
        // ランダムにカードをHandsキャンバスに配置
        PlaceRandomCards();
        Debug.Log("FieldManager.cs : Handsの初期化完了");
    }

    // Update
    void Update()
    {

    }
}
