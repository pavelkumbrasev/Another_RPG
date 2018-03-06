using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//using CnControls;

public class joystick : MonoBehaviour {


    public float HorizontalAxis; // Вердикт контроллера по оси X
    public float VerticalAxis; // Тоже




    public float deathZone = 1.0f / 2; // Мертвая зона контроллера [0..1]. 1/10 - 10% расстояния не будут восприниматься никак 

    
    public GameObject jTOP; // Объекты по рендер. Подложка и крышка
    public GameObject jDOWN;




    public float size; // В пикселях. Реальный размер джойстика в пикселях
    public float sizeCoef = 1.0f / 8; // [0,1] относительно ширины экрана 
    public float differentCoef = 1.0f / (10.0f / 8); // Разница подложки и крышки 1 - нет раницы [0..1]



  //  public GameObject text; 
  

    public float localXpositionCoef = 1.0f / 4;  //[0 .. 1/2] локальная позиция в экране в доле
    public float localYpositionCoef = 1.0f / 5;  //[0 .. 1/2] локальная позиция в экране

    public float localXposition = 0; // Дефолтное положение джойстика. Рассчитывается с коефами выше
    public float localYposition = 0;


    public int touchid = -1; // id тача на джойстике

    


    public float maxOutTopCoef = 1.0f/ 6; // Коэфицент на который можно унести верхнуюю часть от подложки в зависимости от высоты экрана
    public float maxOutTopDist; // Реальная пиксельная дистанция


    // Use this for initialization
    void Start ()
    {
     
        

        localXposition = Screen.width * localXpositionCoef;
        localYposition = Screen.height * localYpositionCoef;
        //  public float localYposition = 0;
        maxOutTopDist = maxOutTopCoef * Screen.height;

        resetJoystic();
        setSize();

    }


    void resetJoystic()
    {
        jTOP.GetComponent<RectTransform>().position = new Vector2(localXposition, localYposition);
        jDOWN.GetComponent<RectTransform>().position = new Vector2(localXposition, localYposition);
    }


    void setSize() // Расчет рамера элементов. Подстройка по размеры
    {

        size = Screen.width * sizeCoef;
        jTOP.GetComponent<RectTransform>().sizeDelta = new Vector2(size * differentCoef, size * differentCoef);
        jDOWN.GetComponent<RectTransform>().sizeDelta = new Vector2(size, size);

    }



    public float GetX()
    {
        return HorizontalAxis;
    }




    public float GetY()
    {
        return VerticalAxis;
    }




    void setNewPosition(int x, int y)
    {

        jTOP.GetComponent<RectTransform>().position = new Vector2(x, y);
        jDOWN.GetComponent<RectTransform>().position = new Vector2(x, y);

    }



    void setNewPositionTop(int x, int y)
    {

        jTOP.GetComponent<RectTransform>().position = new Vector2(x, y);
      //  jDOWN.GetComponent<RectTransform>().position = new Vector2(x, y);

    }


    // Update is called once per frame
    void Update () {

        //    text.GetComponent<UnityEngine.UI.Text>().text = "Testing";




       // text.GetComponent<UnityEngine.UI.Text>().text =  "X: " + HorizontalAxis.ToString() + " " + "Y: " + VerticalAxis.ToString();

        if (Input.touchCount > 0 && touchid == -1) // Найдем нужный нам палец левой нижней четверти и запомним его, если его небыло раньше
        {

         //   text.GetComponent<UnityEngine.UI.Text>().text = "Cicle is down!";

            for (int i = 0; i < Input.touchCount; i++)
            {
                if ((Input.touches[i].position.x < Screen.width /2) && 
                    (Input.touches[i].position.y < Screen.height / 2) && 
                    Input.touches[i].phase == TouchPhase.Began)
                {
                    touchid = Input.touches[i].fingerId;
                 //   text.GetComponent<UnityEngine.UI.Text>().text = "I Found Id!";
                    break;
                  
                }
                
            }


        }



        /*if (Input.touchCount > 0 )
            if (Input.touches[0].phase == TouchPhase.Began) // Добавить распознование зоны и id клика
            {

                setNewPosition((int)Input.touches[0].position.x, (int)Input.touches[0].position.y);
                Debug.Log("I'm run! Touch!");
            }

        if (Input.touchCount > 0)
            if (Input.touches[0].phase == TouchPhase.Moved) // Добавить распознование зоны и id клика
            {
                setNewPositionTop((int)Input.touches[0].position.x, (int)Input.touches[0].position.y);
                Debug.Log("I'm run! Touch!");
            }
*/


        if (touchid != -1) // Если, таки, палец есть
        {

            if (Input.GetTouch(touchid).phase == TouchPhase.Began)
            {
                setNewPosition((int)Input.GetTouch(touchid).position.x, (int)Input.GetTouch(touchid).position.y);
                return;
            }


            if (Input.GetTouch(touchid).phase == TouchPhase.Moved)
            {


              

                Vector2 vect = Input.GetTouch(touchid).position - (Vector2)jDOWN.GetComponent<RectTransform>().position;


                if (Mathf.Sqrt(vect.x * vect.x + vect.y * vect.y) > maxOutTopDist)
                {

                    
                    
                    vect = vect.normalized;
                    setNewPositionTop((int)(jDOWN.GetComponent<RectTransform>().position.x + vect.x * maxOutTopDist), (int)(jDOWN.GetComponent<RectTransform>().position.y + vect.y * maxOutTopDist));





                    if (Mathf.Abs( vect.x * maxOutTopDist) > maxOutTopDist * deathZone)
                    {
                        if (vect.x > 0) HorizontalAxis = 1;
                        else HorizontalAxis = -1;
                    }
                    else  HorizontalAxis = 0;




                    if (Mathf.Abs(vect.y * maxOutTopDist) > maxOutTopDist * deathZone)
                    {
                        if (vect.y > 0) VerticalAxis = 1;
                        else VerticalAxis = -1;
                    }
                    else VerticalAxis = 0;



                }
                else

                {



                    if (Mathf.Abs(vect.x) > maxOutTopDist * deathZone)
                    {
                        if (vect.x > 0) HorizontalAxis = 1;
                        else HorizontalAxis = -1;
                    }
                    else HorizontalAxis = 0;



                    if (Mathf.Abs(vect.y) > maxOutTopDist * deathZone)
                    {
                        if (vect.y > 0) VerticalAxis = 1;
                        else VerticalAxis = -1;
                    }
                    else VerticalAxis = 0;



                    setNewPositionTop((int)(jDOWN.GetComponent<RectTransform>().position.x + vect.x), (int)(jDOWN.GetComponent<RectTransform>().position.y + vect.y));





                }


               
                return;
            }


            if (Input.GetTouch(touchid).phase == TouchPhase.Ended)
            {
                touchid = -1;
                resetJoystic();
                HorizontalAxis = 0;
                VerticalAxis = 0;
                return;
            }

        }



      /*  if (Input.GetMouseButtonDown(0))
        {
            setNewPosition((int)Input.mousePosition.x, (int)Input.mousePosition.y);
            Debug.Log("I'm run! Mouse Start!");
        }





        if (Input.GetMouseButton(0))
        {
            setNewPositionTop((int)Input.mousePosition.x, (int)Input.mousePosition.y);
            Debug.Log("Mouse in Moove");
        }







        if (Input.GetMouseButtonUp(0))
        {
            resetJoystic();
            Debug.Log("I'm run! Mouse End!");

        }

        


    */

    }








}
