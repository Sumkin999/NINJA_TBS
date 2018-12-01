using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Additional
{
    public class MenuGameStart:MonoBehaviour
    {
        public void StartGame()
        {
            SceneManager.LoadScene("Level");
        }
    }
}
