using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IPointerDownHandler
{
    private bool isPlayed = false; // カードがすでにプレイされたかどうか
    public Transform cardZone; // カードを配置するCardZone

    public void OnPointerDown(PointerEventData eventData)
    {
        if (isPlayed)
        {
            Debug.Log("このカードはすでにプレイされています！");
            return; // 一度だけプレイできるように制御
        }

        if (cardZone == null)
        {
            Debug.LogError("CardZoneが設定されていません！");
            return;
        }

        // カードをCardZoneに移動
        transform.SetParent(cardZone, false);
        transform.localPosition = Vector3.zero; // CardZoneの中心に配置
        isPlayed = true; // カードをプレイ済みに設定

        Debug.Log($"{gameObject.name} が CardZone に配置されました！");
    }
}
