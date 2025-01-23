using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDropHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 originalPosition; // 元の位置を保存
    private Transform originalParent; // 元の親オブジェクトを保存
    private Canvas canvas; // ドラッグ中の描画に必要なCanvas

    private void Start()
    {
        // カードを描画するCanvasを取得（ドラッグ中の位置調整に必要）
        canvas = GetComponentInParent<Canvas>();
    }

    // ドラッグ開始時の処理
    public void OnBeginDrag(PointerEventData eventData)
    {
        originalPosition = transform.localPosition; // 元の位置を記録
        originalParent = transform.parent; // 元の親を記録

        // ドラッグ中はCanvasの一番上に描画されるように親を変更
        transform.SetParent(canvas.transform);
    }

    // ドラッグ中の処理
    public void OnDrag(PointerEventData eventData)
    {
        // マウスの位置に追従させる（ScreenPointをWorldPointに変換）
        RectTransformUtility.ScreenPointToWorldPointInRectangle(
            canvas.GetComponent<RectTransform>(),
            eventData.position,
            eventData.pressEventCamera,
            out Vector3 worldPoint
        );

        transform.position = worldPoint; // カードをマウス位置に移動
    }

    // ドロップ時の処理
    public void OnEndDrag(PointerEventData eventData)
    {
        // Raycastでドロップ先を検知
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // ドロップ先がDropZoneタグを持つオブジェクトかどうかを確認
            if (hit.collider.CompareTag("DropZone"))
            {
                // ドロップ先のTransformを取得
                Transform dropZone = hit.collider.transform;

                // カードをドロップゾーンにスナップ
                transform.SetParent(dropZone);
                transform.localPosition = Vector3.zero;

                // ドロップ先のサイズに合わせてスケールを調整
                RectTransform dropZoneRect = dropZone.GetComponent<RectTransform>();
                RectTransform cardRect = GetComponent<RectTransform>();

                if (dropZoneRect != null && cardRect != null)
                {
                    Vector2 dropZoneSize = dropZoneRect.sizeDelta; // ドロップゾーンのサイズを取得
                    Vector2 cardSize = cardRect.sizeDelta; // カードの元サイズを取得

                    // スケールを計算して適用
                    float scaleX = dropZoneSize.x / cardSize.x;
                    float scaleY = dropZoneSize.y / cardSize.y;
                    float uniformScale = Mathf.Min(scaleX, scaleY); // 縦横比を維持するため小さい方を採用
                    transform.localScale = new Vector3(uniformScale, uniformScale, 1f);
                }

                return;
            }
        }

        // ドロップ先が不正な場合、元の位置に戻す
        transform.SetParent(originalParent);
        transform.localPosition = originalPosition;
    }
}
