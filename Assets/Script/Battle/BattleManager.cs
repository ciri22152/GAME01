using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [SerializeField] private FieldManager fieldManager;

    private void Start()
    {
        if (fieldManager != null)
        {
            fieldManager.InitHands(this); // FieldManagerの初期化とHandsキャンバスの初期化
        }
        else
        {
            Debug.LogError("FieldManagerが設定されていません！");
        }
    }
}
