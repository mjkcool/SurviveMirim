﻿using System;
using UnityEngine;
using System.Globalization;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("fix this" + gameObject.name);
        }
        else
        {
            instance = this;
        }
    }

    public void DelaySystem(int MS) //시간 지연 함수
    {
        DateTime dtAfter = DateTime.Now;
        TimeSpan dtDuration = new TimeSpan(0, 0, 0, 0, MS);
        DateTime dtThis = dtAfter.Add(dtDuration);

        while (dtThis >= dtAfter)
        {
            dtAfter = DateTime.Now;
        }
    }

    //anim
    public GameObject QuestObj;
    public GameObject starAnimation;
    public GameObject LoadingAnimation;
    public GameObject LoadingGround;
    public GameObject success;
    public GameObject failure;

    private bool correct;

    public void startLoading(bool correct)
    {
        QuestObj.SetActive(false);
        this.correct = correct;
        LoadingGround.SetActive(true);
        LoadingAnimation.SetActive(true);
        Invoke("loading2", 3f);
        Debug.Log("iscorrect");
    }
    private void loading2()
    {
        LoadingAnimation.SetActive(false);
        if (correct) success.SetActive(true);
        else failure.SetActive(true);
        Invoke("loading3", 2f);
    }
    private void loading3()
    {
        success.SetActive(false); failure.SetActive(false);
        LoadingGround.SetActive(false);
        QuestObj.SetActive(true);
    }
}
