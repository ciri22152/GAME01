using System.Collections.Generic;
using UnityEngine;

public class CardZone : MonoBehaviour
{
    // ゾーン種類定義
    public enum ZoneType
    {
        Hand,         // 手札
        PlayBoard,    // プレイボード
        Trash         // トラッシュ(ゴミ箱)
    }

    // このゾーンの種類
    public ZoneType zoneType;

    // トラッシュゾーンの参照
    public CardZone trashZone;

    // 手札ゾーンの参照
    public CardZone handZone;

    void Update()
    {
        // 手札やプレイボードのカードの状態をチェック
        if (zoneType == ZoneType.PlayBoard)
        {
            CheckAndMoveToTrash();
        }
    }

    // HPが0以下のカードをトラッシュゾーンに移動
    public void CheckAndMoveToTrash()
    {
        List<Transform> toTrash = new List<Transform>();

        // ゾーン内のカードをチェック
        foreach (Transform cardTransform in transform)
        {
            Card card = cardTransform.GetComponent<Card>();
            if (card != null && card.HP <= 0) // HPが0以下のカードを確認
            {
                toTrash.Add(cardTransform);
            }
        }

        // トラッシュゾーンに移動
        foreach (Transform cardTransform in toTrash)
        {
            cardTransform.SetParent(trashZone.transform, false);
            cardTransform.localPosition = Vector3.zero; // トラッシュの中心に配置
            Debug.Log($"{cardTransform.name} が {zoneType} から Trash に移動しました！");
        }

        // カードゾーンが空の場合、手札からカードを移動
        if (transform.childCount == 0)
        {
            Debug.Log("プレイボードが空です。手札からカードをクリックして配置してください。");
        }
    }

    // 手札からカードをクリックしてプレイボードに配置
    public void MoveCardFromHandToPlayBoard(Card card)
    {
        card.transform.SetParent(transform, false);
        card.transform.localPosition = Vector3.zero; // ゾーンの中心に配置
        Debug.Log($"{card.name} が手札からプレイボードに移動しました！");
    }
}