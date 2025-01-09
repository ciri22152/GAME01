using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [SerializeField] private FieldManager fieldManager;

    private void Start()
    {
        if (fieldManager != null)
        {
            fieldManager.Init(this); // FieldManager�̏�����
            fieldManager.InitHands(); // Hands�L�����o�X��������
        }
        else
        {
            Debug.LogError("FieldManager���ݒ肳��Ă��܂���I");
        }
    }
}
