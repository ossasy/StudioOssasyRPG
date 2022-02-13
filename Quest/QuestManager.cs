using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


//Quest�S�̂��Ǘ�
public class QuestManager : MonoBehaviour
{
    public StageUIManager stageUI;
    public GameObject enemyPrefab;
    public BattleManager battleManager;
    public SceneTransitionManager sceneTransitionManager;
    public GameObject questBG;
            
    //�G�ɑ�������e�[�u���F-1�Ȃ瑘�����Ȃ��A0�Ȃ瑘��
    int[] encountTable = { -1, -1, 0, -1, 0, -1 };

    int currentStage = 0;//���݂̐i�s�x
    private void Start()
    {
        stageUI.UpdateUI(currentStage);
        DialogTextManager.instance.SetScenarios(new string[] {"�_���W�����ɂ����B"});
    }

    IEnumerator Searching()
    {
        DialogTextManager.instance.SetScenarios(new string[] { "�T�����E�E�E�B" });

        //�w�i�傫��
        questBG.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 2f)
            .OnComplete(() => questBG.transform.localScale = new Vector3(1, 1, 1));
        //�t�F�[�h�A�E�g
        SpriteRenderer questBGSpriteRenderer = questBG.GetComponent<SpriteRenderer>();
        questBGSpriteRenderer.DOFade(0, 2f)
                        .OnComplete(() => questBGSpriteRenderer.DOFade(1, 0));

        //2�b�ԏ������Ƃ߂�
        yield return new WaitForSeconds(2f);


        currentStage++;
        //�i�s�x��UI�ɔ��f
        stageUI.UpdateUI(currentStage);

        if (encountTable.Length <= currentStage)
        {
            Debug.Log("�N�G�X�g�N���A");
            QuestClear();
        }

        else if (encountTable[currentStage] == 0)
        {
            EncountEnemy();
        }
        else
        {
            stageUI.ShowButtons();
        }
    }

    public void OnNextButton()
    {
        SoundManager.instance.PlaySE(0);
        stageUI.HideButtons();
        StartCoroutine(Searching());
    }

    public void OnToTownButton()
    {
        SoundManager.instance.PlaySE(0);
    }

    void EncountEnemy()
    {
        DialogTextManager.instance.SetScenarios(new string[] { "�����X�^�[�ɑ��������I�I" });

        stageUI.HideButtons();
        GameObject enemyObj = Instantiate(enemyPrefab);
        EnemyManager enemy = enemyObj.GetComponent<EnemyManager>();
        battleManager.Setup(enemy);
    }

    public void EndBattle()
    {
        stageUI.ShowButtons();  
    }
   
    void QuestClear()
    {
        DialogTextManager.instance.SetScenarios(new string[] { "��V����ɓ��ꂽ�B\n �X�ɖ߂낤�B" });

        SoundManager.instance.StopBGM();
        SoundManager.instance.PlaySE(2);

        //�N�G�X�g�N���A�I���ĕ\������
        //�X�ɖ߂�{�^���̂ݕ\��
        stageUI.ShowClearText();
        //sceneTransitionManager.LoadTo("Town");
    }

    public void PlayerDeath()
    {
        sceneTransitionManager.LoadTo("Title");

    }
}
