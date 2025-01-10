using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IPointerDownHandler
{
    private bool isPlayed = false; // カードがすでにプレイされたかどうか
    private FieldManager fieldManager;

    public int HP { get; private set; } = 100; // 初期HP

    private void Start()
    {
        fieldManager = FindObjectOfType<FieldManager>();
    }

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

        if (fieldManager != null)
        {
            Transform targetZone = fieldManager.GetNextAvailableZone();
            if (targetZone != null)
            {
                transform.SetParent(targetZone, false);
                transform.localPosition = Vector3.zero; // ゾーンの中心に配置
                isPlayed = true; // カードをプレイ済みに設定
                Debug.Log($"{gameObject.name} が {targetZone.name} に配置されました！");
            }
            else
            {
                Debug.Log("空きゾーンがありません！");
            }
        }
    }

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

    private void MoveToTrash()
    {
        Transform trashZone = fieldManager?.trashZone;
        if (trashZone != null)
        {
            transform.SetParent(trashZone, false);
            transform.localPosition = Vector3.zero;
            Debug.Log($"{gameObject.name} がトラッシュゾーンに移動しました！");
        }
        else
        {
            Debug.LogError("トラッシュゾーンが設定されていません！");
        }
    }
}