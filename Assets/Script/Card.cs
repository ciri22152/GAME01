using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// �J�[�h�����N���X
/// </summary>
public class Card : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	// Start(�V�[���J�n��or�C���X�^���X�쐬����1����s)
	void Start()
	{
		Debug.Log("�V�[���J�n");
	}

	// Update(���t���[��1�񂸂��s)
	void Update()
	{

	}

	/// <summary>
	/// �^�b�v�J�n���Ɏ��s
	/// IPointerDownHandler���K�v
	/// </summary>
	/// <param name="eventData">�^�b�v���</param>
	public void OnPointerDown(PointerEventData eventData)
	{
		Debug.Log("�J�[�h���^�b�v����܂���");
	}
	/// <summary>
	/// �^�b�v�I�����Ɏ��s
	/// IPointerUpHandler���K�v
	/// </summary>
	/// <param name="eventData">�^�b�v���</param>
	public void OnPointerUp(PointerEventData eventData)
	{
		Debug.Log("�J�[�h�ւ̃^�b�v���I�����܂���");
	}
}