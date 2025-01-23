using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IPointerClickHandler
{
    public string name; // カードの名前

    // コンストラクタ
    public Card(string cardName)
    {
        name = cardName;
    }

    // カードがクリックされたときの処理
    public void OnPointerClick(PointerEventData eventData)
    {
        GameManager.Instance.SelectCard(this.gameObject); // ゲームマネージャーにカード選択の通知を送る
    }
}
