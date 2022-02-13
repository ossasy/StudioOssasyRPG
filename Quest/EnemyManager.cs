using System;
using UnityEngine;
using DG.Tweening;


//�G���Ǘ��i�X�e�[�^�X/�N���b�N���o�j
public class EnemyManager : MonoBehaviour
{
    //�֐��o�^
    Action tapAction; //�N�C�b�N���ꂽ�Ƃ����s�������֐�

    public new string name;
    public int hp;
    public int at;
    public GameObject hitEffect;

    //�U��������
    public int Attack(PlayerManager player)
    {
        int damage = player.Damage(at);
        return damage;
    }
    //�_���[�W���󂯂�
    public int Damage(int damage)
    {
        Instantiate(hitEffect, this.transform, false);
        transform.DOShakePosition(0.3f, 0.5f, 20, 0, false, true);
        hp -= damage;
        if (hp <= 0)
        {
            hp = 0;
        }
        return damage;

    }

    //tapAction�Ɋ֐���o�^����֐������
    public void AddEventListenerOnTap(Action action)
    {
        tapAction += action;
    }

    public void OnTap()
    {
        Debug.Log("�N���b�N���ꂽ");
        tapAction();    
    }
}
