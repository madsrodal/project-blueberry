using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtonsScript : MonoBehaviour
{
   
    public GameObject LevelSelectPanel;
    
    // Start is called before the first frame update
    void Start()
    {
        LevelSelectPanel.SetActive(false);
    }

    public void ShowMenuPanel()
    {
        LevelSelectPanel.SetActive(false);
    }

    public void ToggleLevelSelectPanel()
    {
        LevelSelectPanel.SetActive(!LevelSelectPanel.activeSelf);
    }

    public void SelectLevelOne()
    {
        SceneManager.LoadScene(0);
    }
    public void SelectLevelTwo()
    {
        SceneManager.LoadScene(1);
    }
    public void SelectLevelThree()
    {
        SceneManager.LoadScene(2);
    }

    public void SelectLevelFour()
    {
        SceneManager.LoadScene(3);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
