using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [SerializeField] private FieldManager fieldManager;

    private void Start()
    {
        if (fieldManager != null)
        {
            fieldManager.Init(this); // FieldManagerの初期化
            fieldManager.InitHands(); // Handsキャンバスを初期化
        }
        else
        {
            Debug.LogError("FieldManagerが設定されていません！");
        }
    }
}
