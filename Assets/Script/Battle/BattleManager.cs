using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [SerializeField] private FieldManager fieldManager;

    private void Start()
    {
        if (fieldManager != null)
        {
            fieldManager.InitHands(this); // FieldManager�̏�������Hands�L�����o�X�̏�����
        }
        else
        {
            Debug.LogError("FieldManager���ݒ肳��Ă��܂���I");
        }
    }
}
