using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Siziritu : MonoBehaviour
{
    public Transform cardZoneTrash; // CardZone_TrashのTransform
    public GameObject highImage;    // Highイメージ
    public GameObject midImage;     // Midイメージ
    public GameObject lowImage;     // Lowイメージ

    // Start is called before the first frame update
    void Start()
    {
        // 最初の状態でチェックして設定
        UpdateCardZoneDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        // 毎フレームカードの数に基づいて表示を更新
        UpdateCardZoneDisplay();
    }

    // CardZone_Trashのカード数に応じて表示を更新するメソッド
    private void UpdateCardZoneDisplay()
    {
        if (cardZoneTrash == null)
        {
            Debug.LogError("CardZone_Trashが設定されていません！");
            return;
        }

        // CardZone_Trash内のカードの数を取得
        int cardCount = cardZoneTrash.childCount;

        // 0枚の場合 (Highイメージを表示)
        if (cardCount == 0)
        {
            SetImageVisibility(highImage, true);
            SetImageVisibility(midImage, false);
            SetImageVisibility(lowImage, false);
        }
        // 1枚の場合
        else if (cardCount == 1)
        {
            SetImageVisibility(highImage, false);
            SetImageVisibility(midImage, true);
            SetImageVisibility(lowImage, false);
        }
        // 2枚の場合
        else if (cardCount == 2)
        {
            SetImageVisibility(highImage, false);
            SetImageVisibility(midImage, false);
            SetImageVisibility(lowImage, true);
        }
        // その他の場合はすべて非表示
        else
        {
            SetImageVisibility(highImage, false);
            SetImageVisibility(midImage, false);
            SetImageVisibility(lowImage, false);
        }
    }

    // 画像の表示・非表示を切り替えるヘルパーメソッド
    private void SetImageVisibility(GameObject imageObject, bool isVisible)
    {
        if (imageObject != null)
        {
            imageObject.SetActive(isVisible);
        }
    }
}

