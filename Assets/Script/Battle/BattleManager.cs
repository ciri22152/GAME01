using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    [SerializeField] private FieldManager fieldManager;
    [SerializeField] private Button testButton;
    [SerializeField] private CardZone cardZone; // CardZoneを追加

    private void Start()
    {
        if (fieldManager != null)
        {
            fieldManager.InitHands(this);
        }
        else
        {
            Debug.LogError("FieldManagerが設定されていません！");
        }

        if (testButton != null)
        {
            testButton.onClick.AddListener(OnTestButtonClick);
        }
        else
        {
            Debug.LogError("Testボタンが設定されていません！");
        }
    }

    private void OnTestButtonClick()
    {
        Debug.Log("Testボタンが押されました！");
        ReduceCardHP();
    }

    private void ReduceCardHP()
    {
        // CardZoneにあるカードのHPを-100する処理を追加
        foreach (Transform cardTransform in cardZone.transform)
        {
            Card card = cardTransform.GetComponent<Card>();
            if (card != null)
            {
                card.ReduceHP(100); // HPを減少させるメソッドを呼び出す
                Debug.Log("カードのHPが-100されました。現在のHP: " + card.HP);
            }
        }

        // CardZoneのチェックを行う
        cardZone.CheckAndMoveToTrash();
    }
}