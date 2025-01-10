using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IPointerDownHandler
{
    private FieldManager fieldManager;
    private CardZone cardZone;

    public int HP { get; private set; } = 100; // 初期HP

    private void Start()
    {
        fieldManager = FindObjectOfType<FieldManager>();
        cardZone = GetComponentInParent<CardZone>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (HP <= 0)
        {
            Debug.Log("カードのHPが0のためプレイできません！");
            return;
        }

        if (cardZone != null && cardZone.zoneType == CardZone.ZoneType.Hand)
        {
            // 手札からプレイボードに移動
            CardZone playBoardZone = fieldManager.GetPlayBoardZone();
            if (playBoardZone != null)
            {
                playBoardZone.MoveCardFromHandToPlayBoard(this);
            }
            else
            {
                Debug.Log("プレイボードゾーンが見つかりません！");
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