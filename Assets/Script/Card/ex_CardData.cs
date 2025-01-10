using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "CardGame/CardData")]
public class CardData : ScriptableObject
{
    public string characterName;        // �L�����N�^�[��
    public string cardAbility;          // �J�[�h�̔\��
    public int power;                   // �U����
    public int tax;                     // �K�v�R�X�g
    public Sprite characterImage;       // �L�����N�^�[�摜
    public Sprite backgroundImage;      // �L�����N�^�[�w�i�摜
    public Sprite iconImage;            // �J�[�h�̎�ރA�C�R��
    public Sprite cardFrameImage;       // �J�[�h�̃t���[���摜
}
