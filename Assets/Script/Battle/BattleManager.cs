using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    [SerializeField] private FieldManager fieldManager;
    [SerializeField] private Button testButton; // Testボタン

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
            testButton.onClick.AddListener(() =>
            {
                if (fieldManager != null)
                {
                    fieldManager.ReduceHPInCardZone(100);
                }
            });
        }
        else
        {
            Debug.LogError("Testボタンが設定されていません！");
        }
    }
}
