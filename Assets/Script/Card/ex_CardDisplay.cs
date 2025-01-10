using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public TextMeshProUGUI nameText;     // �L�����N�^�[��
    public TextMeshProUGUI abilityText;  // �J�[�h�̔\��
    public TextMeshProUGUI powerText;    // �U����
    public TextMeshProUGUI taxText;      // �K�v�R�X�g
    public Image characterImage;         // �L�����N�^�[�摜
    public Image backgroundImage;        // �w�i�摜
    public Image iconImage;              // �A�C�R���摜
    public Image cardFrameImage;         // �J�[�h�̃t���[���摜

    // �J�[�h�f�[�^��ݒ肷�郁�\�b�h
    public void SetCardData(CardData cardData)
    {
        nameText.text = cardData.characterName;   // �L�����N�^�[��
        abilityText.text = cardData.cardAbility;  // �J�[�h�̔\��
        powerText.text = cardData.power.ToString();  // �U����
        taxText.text = cardData.tax.ToString();      // �K�v�R�X�g

        characterImage.sprite = cardData.characterImage;  // �L�����N�^�[�摜
        backgroundImage.sprite = cardData.backgroundImage;  // �w�i�摜
        iconImage.sprite = cardData.iconImage;           // �A�C�R���摜
        cardFrameImage.sprite = cardData.cardFrameImage;  // �J�[�h�̃t���[���摜
    }
}
