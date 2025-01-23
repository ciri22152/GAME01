using UnityEngine;

public abstract class CombatCard : CardBase
{
    public int hp;              // �q�b�g�|�C���g
    public int attackCost;      // �U���ɕK�v�ȃR�X�g
    public int attackPower;     // �U����
    public string attackName;   // �U���̖��O

    public void TakeDamage(int damage)
    {
        hp -= damage;
        Debug.Log($"{cardName}��{damage}�_���[�W���󂯂��I �c��HP: {hp}");
        if (hp <= 0)
        {
            Debug.Log($"{cardName}���|����܂����I");
        }
    }
}
