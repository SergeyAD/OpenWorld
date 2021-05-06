using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIview : MonoBehaviour
{
    
    [SerializeField]
    public GUIStyle healthBarFontStyle;
    [SerializeField]
    public GUIStyle healthBarStyle;
    [SerializeField]
    public GUIStyle pouseBarStyle;
    [SerializeField]
    public GUIStyle pouseTextStyle;
    [SerializeField]
    public GUIStyle optionsBoxStyle;
    [SerializeField]
    public GUIStyle sliderOptionsStyle;
    [SerializeField]
    public GameObject mainPerson;


    public float health = 100;
    public bool pouseMenu = false;
    private float mainPersonWalkSpeed;
    private float mainPersonRunSpeed;


    private void Awake()
    {
        mainPersonWalkSpeed = mainPerson.GetComponent<MainMove>().speedWalk;
        mainPersonRunSpeed = mainPerson.GetComponent<MainMove>().speedRun;

    }

    public void OnGUI()
    {
 
       if (pouseMenu)
        {
            GUI.Label(new Rect(Screen.width * 0.5f - 100, Screen.height * 0.5f - 130, 200,10), "ПАУЗА", pouseTextStyle);
            GUI.Box(new Rect(Screen.width * 0.5f - 100, Screen.height * 0.5f - 100, 200, 200), "", pouseBarStyle);

            

            GUI.Box(new Rect(0, Screen.height * 0.5f - 150, 120, 120), "Настройки", optionsBoxStyle);
            GUI.Label(new Rect(10, Screen.height * 0.5f - 110, 200, 20), "Скорость ходьбы " + Mathf.RoundToInt(mainPersonWalkSpeed), sliderOptionsStyle);
            mainPersonWalkSpeed = GUI.HorizontalSlider(new Rect(10, Screen.height * 0.5f - 90, 100, 20), mainPersonWalkSpeed, 0 , 20);
            GUI.Label(new Rect(10, Screen.height * 0.5f - 70, 200, 20), "Скорость бега " + Mathf.RoundToInt(mainPersonRunSpeed), sliderOptionsStyle);
            mainPersonRunSpeed = GUI.HorizontalSlider(new Rect(10, Screen.height * 0.5f - 50, 100, 20), mainPersonRunSpeed, 10, 40);

            mainPerson.GetComponent<MainMove>().speedWalk = mainPersonWalkSpeed;
            mainPerson.GetComponent<MainMove>().speedRun = mainPersonRunSpeed;

        }
        GUI.Box(new Rect(0, 0, 230, 50), "Здоровье", healthBarFontStyle);
        GUI.Box(new Rect(10, 20, 10 + health * 2, 20), health + "%", healthBarStyle);
    }
}
