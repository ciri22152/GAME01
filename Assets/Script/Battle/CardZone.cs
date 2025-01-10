using System.Collections.Generic;
using UnityEngine;

public class CardZone : MonoBehaviour
{
    // ゾーン種類定義
    public enum ZoneType
    {
        Hand,         // 手札
        PlayBoard0,   // プレイボード0～4番目
        PlayBoard1,
        PlayBoard2,
        PlayBoard3,
        Trash         // トラッシュ(ゴミ箱)
    }

    // このゾーンの種類
    public ZoneType zoneType;

    // トラッシュゾーンの参照
    public CardZone trashZone;

    void Update()
    {
        // 手札やプレイボードのカードの状態をチェック
        if (zoneType != ZoneType.Trash)
        {
            CheckAndMoveToTrash();
        }
    }

    // HPが0以下のカードをトラッシュゾーンに移動
    public void CheckAndMoveToTrash() // メソッドをpublicに変更
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
    }
}