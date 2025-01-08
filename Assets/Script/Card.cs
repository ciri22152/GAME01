using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// カード処理クラス
/// </summary>
public class Card : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isDragging = false; // カードがドラッグ中かどうか
    private Camera mainCamera; // メインカメラの参照

    // Start(シーン開始時orインスタンス作成時に1回実行)
    void Start()
    {
        mainCamera = Camera.main; // メインカメラの取得
        Debug.Log("シーン開始");
    }

    // Update(毎フレーム1回ずつ実行)
    void Update()
    {
        if (isDragging)
        {
            // マウス位置を取得してカードを移動
            Vector3 mousePosition = Input.mousePosition; // マウスのスクリーン座標
            mousePosition.z = 10f; // カメラからの距離を設定
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition); // ワールド座標に変換
            transform.position = worldPosition; // カードを移動
        }
    }

    /// <summary>
    /// タップ開始時に実行
    /// IPointerDownHandlerが必要
    /// </summary>
    /// <param name="eventData">タップ情報</param>
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("カードがタップされました");
        isDragging = true; // ドラッグを開始
    }

    /// <summary>
    /// タップ終了時に実行
    /// IPointerUpHandlerが必要
    /// </summary>
    /// <param name="eventData">タップ情報</param>
    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("カードへのタップを終了しました");
        isDragging = false; // ドラッグを終了
    }
}
