using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �퓬��ʃ}�l�[�W���N���X
/// </summary>
public class BattleManager : MonoBehaviour
{
	// �Ǘ����R���|�[�l���g
	public FieldManager fieldManager; // �t�B�[���h�Ǘ��N���X

	// Start
	void Start()
	{
		// �Ǘ����R���|�[�l���g������
		fieldManager.Init(this);

		Debug.Log("BattleManager.cs : ����������");
	}

	// Update
	void Update()
	{

	}
}