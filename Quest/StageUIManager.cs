using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//StageUI���Ǘ�(���ā[����UI/�i�s�{�^��/�X�̖߂�{�^��)
public class StageUIManager : MonoBehaviour
{
    public Text stageText;
    public GameObject nextButton;
    public GameObject toTownButton;
    public GameObject stageClearImage;

    private void Start()
    {
        stageClearImage.SetActive(false);
    }

    public void UpdateUI(int currentStage)
    {
        stageText.text = string.Format("�X�e�[�W�F{0}", currentStage+1);

    }

    public void HideButtons()
    {
        nextButton.SetActive(false);
        toTownButton.SetActive(false);
    }

    public void ShowButtons()
    {
        nextButton.SetActive(true);
        toTownButton.SetActive(true);
    }

    public void ShowClearText()
    {
        stageClearImage.SetActive(true);
        nextButton.SetActive(false);
        toTownButton.SetActive(true);


    }

}