using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public MoveSC moveSC;
   

    public void Start()
    {
        
    }

    public void EnterClick()
    {
        if(moveSC.EnterValue ==false){
        moveSC.EnterValue = true;
        }
    }

    public void leftDown()
    {
       
        moveSC.LeftValue = true;
        
    }
    public void leftUp()
    {
        
        moveSC.LeftValue = false;
        
    }

    public void RightDown()
    {
        
        moveSC.RightValue = true;
        
    }

    public void RightUp()
    {
        
        moveSC.RightValue = false;
        
    }
    
    public void JumpClick()
    {
        if(moveSC.JumpValue == false){
        moveSC.JumpValue = true;
        }
    }
}
