using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IPointerDownHandler
{
    private bool isPlayed = false; // カードがすでにプレイされたかどうか
    public Transform cardZone; // 配置先のCardZone
    public Transform trashZone; // トラッシュゾーンのTransform

    public int HP { get; private set; } = 100; // 初期HP

    public void OnPointerDown(PointerEventData eventData)
    {
        if (isPlayed)
        {
            Debug.Log("このカードはすでにプレイされています！");
            return;
        }

        if (HP <= 0)
        {
            Debug.Log("カードのHPが0のためプレイできません！");
            return;
        }

        if (cardZone != null)
        {
            // カードをCardZoneに移動
            transform.SetParent(cardZone, false);
            transform.localPosition = Vector3.zero; // CardZoneの中心に配置
            isPlayed = true; // カードをプレイ済みに設定
            Debug.Log($"{gameObject.name} が CardZone に配置されました！");
        }
    }

    // HPを減少させるメソッド
    public void ReduceHP(int amount)
    {
        HP -= amount;
        Debug.Log($"{gameObject.name} のHPが {HP} になりました。");

        if (HP <= 0)
        {
            HP = 0; // 下限を0に固定
            MoveToTrash(); // トラッシュゾーンに移動
        }
    }

    // カードをトラッシュゾーンに移動するメソッド
    private void MoveToTrash()
    {
        if (trashZone != null)
        {
            transform.SetParent(trashZone, false);
            transform.localPosition = Vector3.zero; // トラッシュゾーンの中心に配置
            Debug.Log($"{gameObject.name} がトラッシュゾーンに移動しました！");
        }
        else
        {
            Debug.LogError("トラッシュゾーンが設定されていません！");
        }
    }
}

