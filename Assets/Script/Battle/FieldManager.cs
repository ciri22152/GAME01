using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldManager : MonoBehaviour
{
    public Transform handsArea; // HandsエリアのTransform
    public GameObject cardPrefab; // カードのプレハブ
    public Transform playBoardArea; // PlayBoardエリアのTransform
    public Transform trashArea; // CardZone_TrashエリアのTransform

    private Card draggingCard; // ドラッグ中のカード
    private bool isDragging = false; // ドラッグフラグ

    /// <summary>
    /// Handsエリアにカードを配置する
    /// </summary>
    public void InitHands()
    {
        const int cardCount = 5; // 配置するカードの枚数
        const float spacing = 150f; // カード間のスペース
        const float startX = -300f; // 最初のカードのX座標
        const float cardWidth = 100f; // カードの幅
        const float cardHeight = 150f; // カードの高さ

        for (int i = 0; i < cardCount; i++)
        {
            // カード生成
            GameObject cardObject = Instantiate(cardPrefab, handsArea);

            // RectTransform を取得してサイズを設定
            RectTransform cardRect = cardObject.GetComponent<RectTransform>();
            cardRect.sizeDelta = new Vector2(cardWidth, cardHeight); // カードのサイズを設定
            cardRect.localScale = Vector3.one; // スケールをリセット

            // 配置位置を計算して設定
            float xPosition = startX + i * spacing;
            cardRect.anchoredPosition = new Vector2(xPosition, 0);

            // カードのドラッグイベントを設定
            Card card = cardObject.GetComponent<Card>();
            card.Init(this); // Initメソッドでドラッグ操作を管理
            Debug.Log($"カード{i + 1}をHandsエリアに配置しました");
        }
    }

    /// <summary>
    /// ドラッグを開始する
    /// </summary>
    public void StartDragging(Card card)
    {
        draggingCard = card;
        isDragging = true;
        card.transform.SetAsLastSibling(); // 最前面に表示
    }

    /// <summary>
    /// ドラッグ中にカードを移動する
    /// </summary>
    public void UpdateDragging(Vector2 mousePosition)
    {
        if (isDragging && draggingCard != null)
        {
            // カードの位置をマウス位置に合わせる
            draggingCard.rectTransform.position = mousePosition;
        }
    }

    /// <summary>
    /// ドラッグを終了し、カードを適切なゾーンに配置する
    /// </summary>
    public void EndDragging()
    {
        if (draggingCard == null)
            return;

        // マウスの位置を取得
        Vector3 mousePosition = Input.mousePosition;

        // PlayBoardエリアまたはCardZone_Trashエリアにカードを配置
        if (RectTransformUtility.RectangleContainsScreenPoint(playBoardArea.GetComponent<RectTransform>(), mousePosition))
        {
            // PlayBoardエリアに配置
            draggingCard.rectTransform.SetParent(playBoardArea);
            draggingCard.rectTransform.anchoredPosition = Vector2.zero; // PlayBoard上の指定位置に設定
            Debug.Log("カードをPlayBoardエリアに配置しました");
        }
        else if (RectTransformUtility.RectangleContainsScreenPoint(trashArea.GetComponent<RectTransform>(), mousePosition))
        {
            // Trashエリアに配置
            draggingCard.rectTransform.SetParent(trashArea);
            draggingCard.rectTransform.anchoredPosition = Vector2.zero; // Trashエリア上の指定位置に設定
            Debug.Log("カードをCardZone_Trashエリアに配置しました");
        }
        else
        {
            // 配置先がなければ元の位置に戻す
            draggingCard.rectTransform.SetParent(handsArea);
            draggingCard.rectTransform.anchoredPosition = draggingCard.initialPosition;
            Debug.Log("カードが元の位置に戻されました");
        }

        // ドラッグ状態を終了
        isDragging = false;
        draggingCard = null;
    }
}


