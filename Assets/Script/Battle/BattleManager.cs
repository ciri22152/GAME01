using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    [SerializeField] private FieldManager fieldManager;
    [SerializeField] private Button testButton; // Test�{�^��

    private void Start()
    {
        if (fieldManager != null)
        {
            fieldManager.InitHands(this);
        }
        else
        {
            Debug.LogError("FieldManager���ݒ肳��Ă��܂���I");
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
            Debug.LogError("Test�{�^�����ݒ肳��Ă��܂���I");
        }
    }
}
