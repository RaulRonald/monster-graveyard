using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileControls : MonoBehaviour
{
    public bool moveright, moveleft,jump,fire;
    private void Update()
    {
        moveCoveira();
    }
    public void moveCoveira()
    {
        if(moveright == true && moveleft == false)
        {
            gameObject.GetComponent<Coveira>().DefVel = 1;
        }
        else
        if (moveright == false && moveleft == true)
        {
            gameObject.GetComponent<Coveira>().DefVel = -1;
        }
        else gameObject.GetComponent<Coveira>().DefVel = 0;
    }
    public void RightButtonDown()
    {
        moveright = true;
    }
    public void RightButtonUp()
    {
        moveright = false;
    }
    public void LeftButtonDown()
    {
        moveleft = true;
    }
    public void LeftButtonUp()
    {
        moveleft = false;
    }
    public void JumpButton()
    {
        if(gameObject.GetComponent<Coveira>().pulando == false)
        jump = true;
    }
    public void AtkButton()
    {
        fire = true;
    }
}
