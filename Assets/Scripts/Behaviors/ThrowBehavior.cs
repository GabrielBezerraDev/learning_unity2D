using UnityEngine;

public  class ThrowBehavior : MonoBehaviour
{
    public float velocityY = 0;
    public float velocityX = 0;
    private float rotz;

    public float[] getSpeedRelativeToTheMouse()
    {
        rotz = MouseBehavior.rotZ;
        checkQuadrant(rotz);
        float[] velocitys = {velocityX, velocityY};
        return velocitys;
    }

    public void resetVelocitys(){
        velocityX = 0;
        velocityY = 0;
    }

    public void checkQuadrant(float rotz)
    {
        resetVelocitys();
        if (rotz > 0)
        {
            mouseIsFirstQuadrantOrSecond(rotz);
        }
        else
        {
            mouseIsFourthQuadrantOrFifth(rotz);
        }
    }

    public void mouseIsFirstQuadrantOrSecond(float rotz)
    {
        if (rotz > 0 && rotz < 90)
        {
            Debug.Log("Primeiro quadrante");
            setVelocity(90f, 0, rotz, -rotz, 1f, 1f, false);
        }
        else
        {
            Debug.Log("Segundo quadrante");
            setVelocity(-90f, 0, -rotz, 0, -1f, 1f, true);
        }
    }

    public void mouseIsFourthQuadrantOrFifth(float rotz)
    {
        if (rotz < 0 && rotz > -90)
        {
            Debug.Log("Quarto quadrante");
            setVelocity(90f, 0, -rotz, rotz, 1f, -1f, false);
        }
        else
        {
            Debug.Log("Terceiro quadrante");
            setVelocity(-90f, 90f, rotz, 0, -1f, -1f, true);
        }
    }

    public void setVelocity(
        float angleCircleX,
        float angleCircleY,
        float rotzToX,
        float rotzToY,
        float signX,
        float signY,
        bool minusYByX
    )
    {
        velocityX = angleCircleX - rotzToX;
        if (minusYByX) velocityY = 90 - velocityX;
        else{
            velocityY = angleCircleY - rotzToY;
        }
        velocityX *= signX;
        velocityY *= signY;
    }

    public void testInstance(){
        for(int i = 1; i < 0; i++){
            Debug.Log(1);
        }
    }
}

