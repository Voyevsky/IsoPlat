using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControls : MonoBehaviour
{
    public GameObject startGame, howTo, quitGame, goBackFromControls, menuSprite, howToSprite;
    public string levelToLoad = "MainTestingGround";

    private int menuSelection = 0; // 0 - start, 1 - howto, 2 - quit
    private bool axisRead = false, howToMenu = false;

    void Start()
    {
        Cursor.visible = false;

        startGame.SetActive(true);
        howTo.SetActive(false);
        quitGame.SetActive(false);
        goBackFromControls.SetActive(false);
        howToSprite.SetActive(false);
    }

    void Update()
    {
        if(!howToMenu)
        {
            ReadInput();
            AxisToBin();
            CurrentSelection();
            ButtonSelect();
        }
        else
        {
            ExitControls();
        }
        
    }

    #region Functions
    void ReadInput()
    {
        if((Input.GetAxisRaw("Vertical") > 0 || Input.GetAxisRaw("DPadVer") > 0) && !axisRead)
        {
            menuSelection--;
            if (menuSelection < 0)
            {
                menuSelection = 2;
            }
        }
        if ((Input.GetAxisRaw("Vertical") < 0 || Input.GetAxisRaw("DPadVer") < 0) && !axisRead)
        {
            menuSelection++;
            if (menuSelection > 2)
            {
                menuSelection = 0;
            }
        }
    }
    void AxisToBin()
    {
        if (Input.GetAxisRaw("Vertical") != 0f || Input.GetAxisRaw("DPadVer") != 0f)
        {
            axisRead = true;
        }
        else
        {
            axisRead = false;
        }
    }

    void CurrentSelection()
    {
        switch(menuSelection)
        {
            case 0:
                startGame.SetActive(true);
                howTo.SetActive(false);
                quitGame.SetActive(false);
                break;
            case 1:
                startGame.SetActive(false);
                howTo.SetActive(true);
                quitGame.SetActive(false);
                break;
            case 2:
                startGame.SetActive(false);
                howTo.SetActive(false);
                quitGame.SetActive(true);
                break;
        }
    }
    void ButtonSelect()
    {
        if(Input.GetButtonDown("Submit") || Input.GetButtonDown("Jump") || Input.GetButtonDown("Attack"))
        {
            switch(menuSelection)
            {
                case 0:
                    SceneManager.LoadScene(levelToLoad);
                    break;
                case 1:
                    HowToPlayMenu();
                    break;
                case 2:
                    Application.Quit();
                    break;
            }
        }
    }
    void ExitControls()
    {
        if (Input.GetButtonDown("Submit") || Input.GetButtonDown("Jump") || Input.GetButtonDown("Attack"))
        {
            BackToMainMenu();
        }
    }
    void HowToPlayMenu()
    {
        menuSprite.SetActive(false);
        startGame.SetActive(false);
        howTo.SetActive(false);
        quitGame.SetActive(false);
        howToSprite.SetActive(true);
        goBackFromControls.SetActive(true);
        howToMenu = true;
    }

    void BackToMainMenu()
    {
        menuSprite.SetActive(true);
        startGame.SetActive(false);
        howTo.SetActive(true);
        quitGame.SetActive(false);
        howToSprite.SetActive(false);
        goBackFromControls.SetActive(false);
        howToMenu = false;
    }
    #endregion

}
