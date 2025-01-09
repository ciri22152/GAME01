using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public FieldManager fieldManager; // フィールド管理クラスの参照

    void Start()
    {
        // フィールド管理の初期化 (カード配置など)
        if (fieldManager != null)
        {
            Debug.Log("BattleManager: フィールド初期化を実行します");
            fieldManager.InitHands(); // InitHands メソッドを呼び出す
        }
        else
        {
            Debug.LogError("BattleManager: FieldManager が割り当てられていません");
        }
    }
}
