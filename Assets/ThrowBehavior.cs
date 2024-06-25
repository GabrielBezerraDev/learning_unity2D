using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThrowBehavior : HealthBarScript
{

    public float velocityY;
    public float velocityX;

    public void getSpeedRelativeToTheMouse(float rotz){
        checkQuadrant(rotz);
    }

    public void checkQuadrant(float rotz){
        rotZ > 0 ? mouseIsFirstQuadrantOrSecond(rotZ) : mouseIsFourthQuadrantOrFifth(rotZ);
    }

    public void mouseIsFirstQuadrantOrSecond(float rotZ){
        rotZ > 0 && rotZ < 90 
        ? setVelocity(90f,0,rotz,rotz,1f,1f,false)
        : setVelocity(90f,90f,rotz,0,-1f,1f,true);
    }

    public void mouseIsFourthQuadrantOrFifth(float rotZ){
        rotZ < 0 && rotZ > -90 
        ? setVelocity(90f,0,(-rotz),rotz,1f,1f,false) 
        : setVelocity(90f,90f,(-rotz),0,-1f,-1f,true);
    }

    public void setVelocity(
    float angleCircleX, 
    float angleCircleY, 
    float rotzToX, 
    float rotzToY, 
    float signX 
    float signY,
    bool minusYByX 
    ){
        velocityX = (angleCircleX - rotzToX) * (signX);
        velocityY = (angleCircleY - rotzToY) * (signY);
        minusYByX ? velocityY -= velocityX : velocityY; 
    }
}

