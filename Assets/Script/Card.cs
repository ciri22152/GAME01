using UnityEngine;

public class Card : MonoBehaviour
{
    public RectTransform rectTransform;
    private FieldManager fieldManager;
    private Vector2 offset; // ドラッグ開始時のオフセット
    public Vector2 initialPosition; // カードの初期位置

    /// <summary>
    /// カードの初期化処理
    /// </summary>
    public void Init(FieldManager manager)
    {
        fieldManager = manager;
        rectTransform = GetComponent<RectTransform>();
        initialPosition = rectTransform.anchoredPosition; // 初期位置を保存
    }

    void OnMouseDown()
    {
        // ドラッグ開始時にカードの位置を取得し、オフセットを設定
        Vector2 mousePosition = (Vector2)Input.mousePosition;  // ここで明示的に Vector2 に変換
        offset = rectTransform.anchoredPosition - mousePosition;

        fieldManager.StartDragging(this); // ドラッグ開始
    }

    void OnMouseDrag()
    {
        // ドラッグ中のカードの位置更新
        Vector2 mousePosition = (Vector2)Input.mousePosition + offset;  // ここで明示的に Vector2 に変換
        fieldManager.UpdateDragging(mousePosition); // ドラッグ中
    }

    void OnMouseUp()
    {
        fieldManager.EndDragging(); // ドラッグ終了
    }
}
