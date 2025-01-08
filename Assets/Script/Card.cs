using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// �J�[�h�����N���X
/// </summary>
public class Card : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isDragging = false; // �J�[�h���h���b�O�����ǂ���
    private Camera mainCamera; // ���C���J�����̎Q��

    // Start(�V�[���J�n��or�C���X�^���X�쐬����1����s)
    void Start()
    {
        mainCamera = Camera.main; // ���C���J�����̎擾
        Debug.Log("�V�[���J�n");
    }

    // Update(���t���[��1�񂸂��s)
    void Update()
    {
        if (isDragging)
        {
            // �}�E�X�ʒu���擾���ăJ�[�h���ړ�
            Vector3 mousePosition = Input.mousePosition; // �}�E�X�̃X�N���[�����W
            mousePosition.z = 10f; // �J��������̋�����ݒ�
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition); // ���[���h���W�ɕϊ�
            transform.position = worldPosition; // �J�[�h���ړ�
        }
    }

    /// <summary>
    /// �^�b�v�J�n���Ɏ��s
    /// IPointerDownHandler���K�v
    /// </summary>
    /// <param name="eventData">�^�b�v���</param>
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("�J�[�h���^�b�v����܂���");
        isDragging = true; // �h���b�O���J�n
    }

    /// <summary>
    /// �^�b�v�I�����Ɏ��s
    /// IPointerUpHandler���K�v
    /// </summary>
    /// <param name="eventData">�^�b�v���</param>
    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("�J�[�h�ւ̃^�b�v���I�����܂���");
        isDragging = false; // �h���b�O���I��
    }
}
