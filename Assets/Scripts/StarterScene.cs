﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StarterScene : MonoBehaviour
{

    public void ChangeScene(int sceneId)
    {
        
           SceneManager.LoadScene(sceneId);
    }

}
