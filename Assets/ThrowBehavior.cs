using UnityEngine;

public class ThrowBehavior : MonoBehaviour
{
    public float velocityY;
    public float velocityX;

    public float[] getSpeedRelativeToTheMouse(float rotz)
    {
        rotz = MouseBehavior.rotZ;
        checkQuadrant(rotz);
        float[] velocitys = { velocityX, velocityY};
        return velocitys;
    }

    public void checkQuadrant(float rotz)
    {
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
            setVelocity(90f, 0, rotz, rotz, 1f, 1f, false);
        }
        else
        {
            setVelocity(90f, 90f, rotz, 0, -1f, 1f, true);
        }
    }

    public void mouseIsFourthQuadrantOrFifth(float rotz)
    {
        if (rotz < 0 && rotz > -90)
        {
            setVelocity(90f, 0, -rotz, rotz, 1f, 1f, false);
        }
        else
        {
            setVelocity(90f, 90f, -rotz, 0, -1f, -1f, true);
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
        velocityX = (angleCircleX - rotzToX) * signX;
        velocityY = (angleCircleY - rotzToY) * signY;
        if (minusYByX)
        {
            velocityY -= velocityX;
        }
    }
}

