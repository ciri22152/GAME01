using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �J�[�h�]�[��(�̈�)�ݒ�N���X
/// </summary>
public class CardZone : MonoBehaviour
{
	// �]�[����ޒ�`
	public enum ZoneType
	{
		// ��D
		Hand,
		// �v���C�{�[�h0�`4�Ԗ�
		PlayBoard0,
		PlayBoard1,
		PlayBoard2,
		PlayBoard3,
		PlayBoard4,
		// �g���b�V��(�S�~��)
		Trash,
	}

	// ���̃]�[���̎��
	public ZoneType zoneType;

	// Start
	void Start()
	{
	}
}