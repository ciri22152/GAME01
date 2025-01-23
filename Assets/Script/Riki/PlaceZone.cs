using UnityEngine;

public class PlaceZone : MonoBehaviour
{
    public enum ZoneType { Field, Seat }

    public ZoneType zoneType; // 場か議席かを判定
    public int maxCardsInZone = 1; // 場の場合は1枚、議席の場合は3枚まで

    private int currentCardCount = 0; // 現在配置されているカードの数

    // カードがここに配置されたときの処理
    public bool CanPlaceCard()
    {
        return currentCardCount < maxCardsInZone;
    }

    // カードをこのゾーンに配置
    public void PlaceCard(GameObject card)
    {
        if (CanPlaceCard())
        {
            currentCardCount++;
            // 位置を調整（カードが置かれる位置）
            RectTransform cardRect = card.GetComponent<RectTransform>();
            cardRect.position = transform.position; // ゾーンの中心に配置

            // 場か議席かによってカードサイズを変更
            if (zoneType == ZoneType.Field)
            {
                cardRect.localScale = new Vector3(1.5f, 1.5f, 1); // 場に置かれるとカードが大きくなる
            }
            else if (zoneType == ZoneType.Seat)
            {
                cardRect.localScale = new Vector3(1f, 1f, 1); // 議席に置かれると元の大きさ
            }
        }
    }

    // カードが取り除かれたときの処理
    public void RemoveCard()
    {
        if (currentCardCount > 0)
        {
            currentCardCount--;
        }
    }
}
