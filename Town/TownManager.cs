using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownManager : MonoBehaviour
{
    private void Start()
    {
        DialogTextManager.instance.SetScenarios(new string[] { "�X�ɂ����B" });

    }
    public void OnToQuestButton()
    {
        SoundManager.instance.PlaySE(0);
    }
}
