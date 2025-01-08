using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// カード処理クラス
/// </summary>
public class Card : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	// Start(シーン開始時orインスタンス作成時に1回実行)
	void Start()
	{
		Debug.Log("シーン開始");
	}

	// Update(毎フレーム1回ずつ実行)
	void Update()
	{

	}

	/// <summary>
	/// タップ開始時に実行
	/// IPointerDownHandlerが必要
	/// </summary>
	/// <param name="eventData">タップ情報</param>
	public void OnPointerDown(PointerEventData eventData)
	{
		Debug.Log("カードがタップされました");
	}
	/// <summary>
	/// タップ終了時に実行
	/// IPointerUpHandlerが必要
	/// </summary>
	/// <param name="eventData">タップ情報</param>
	public void OnPointerUp(PointerEventData eventData)
	{
		Debug.Log("カードへのタップを終了しました");
	}
}