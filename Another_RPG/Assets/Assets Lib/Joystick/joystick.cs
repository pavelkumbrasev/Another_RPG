using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///using UnityEngine.GUI;
//using CnControls;

public class joystick : MonoBehaviour {


    public float HorizontalAxis = 0; // Вердикт контроллера по оси X
    public float VerticalAxis = 0; // Тоже
    public float jump = 0;
    public float Atack = 0;

    UnityEngine.UI.Button btLeft, btRihgt, btJum, btAtack;
    



    // Use this for initialization
    void Start ()
    {
        // Забацать размеры

     //   btLeft.OnPointerDown();
       



    }

    
    


  


    public float GetX()
    {
        return HorizontalAxis;
    }



    public float GetAtack()
    {
        return Atack;

    }


    public float GetY()
    {

        return VerticalAxis;
    }



    public void setAtackEnable()
    {
        Atack = 1;
        Debug.Log("Atack Enable");

    }



    public void setAtackDisable()
    {
        Atack = 0;
        Debug.Log("Atack disable");
    }

    public void setHorizontalLeft()
    {

        HorizontalAxis = -1;
        Debug.Log("Horizontal is left!");
    }

    public void setHorizontalRight()
    {

        HorizontalAxis = 1;
        Debug.Log("Horizontal is Right!");
    }

    public void setHorizontalNull()
    {

        HorizontalAxis = 0;
        Debug.Log("Horizontal is leftNull");

    }


    public void setVerticallDown()
    {

        VerticalAxis = -1;
        Debug.Log("VerticalAxis is Down!");
    }

    public void setVerticallUp()
    {

        VerticalAxis = 1;
        Debug.Log("VerticalAxis is Up!");
    }

    public void setVerticallNull()
    {

        VerticalAxis = 0;
        Debug.Log("VerticalAxis is leftNull");

    }



    // Update is called once per frame
    void Update ()

    {


    }


  





}
