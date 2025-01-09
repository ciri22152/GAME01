using UnityEngine;

public class Card : MonoBehaviour
{
    public RectTransform rectTransform;
    private FieldManager fieldManager;
    private Vector2 offset; // �h���b�O�J�n���̃I�t�Z�b�g
    public Vector2 initialPosition; // �J�[�h�̏����ʒu

    /// <summary>
    /// �J�[�h�̏���������
    /// </summary>
    public void Init(FieldManager manager)
    {
        fieldManager = manager;
        rectTransform = GetComponent<RectTransform>();
        initialPosition = rectTransform.anchoredPosition; // �����ʒu��ۑ�
    }

    void OnMouseDown()
    {
        // �h���b�O�J�n���ɃJ�[�h�̈ʒu���擾���A�I�t�Z�b�g��ݒ�
        Vector2 mousePosition = (Vector2)Input.mousePosition;  // �����Ŗ����I�� Vector2 �ɕϊ�
        offset = rectTransform.anchoredPosition - mousePosition;

        fieldManager.StartDragging(this); // �h���b�O�J�n
    }

    void OnMouseDrag()
    {
        // �h���b�O���̃J�[�h�̈ʒu�X�V
        Vector2 mousePosition = (Vector2)Input.mousePosition + offset;  // �����Ŗ����I�� Vector2 �ɕϊ�
        fieldManager.UpdateDragging(mousePosition); // �h���b�O��
    }

    void OnMouseUp()
    {
        fieldManager.EndDragging(); // �h���b�O�I��
    }
}
