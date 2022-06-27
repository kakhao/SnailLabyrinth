using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSnail : ISnail
{
    public float ErrorProb = 0.01f;
    public SnailCommand Think(bool LeftSensor, bool CenterSensor, bool RightSensor)
    {
        return Random.Range(0f, 1f)<ErrorProb ?
            RandomCommand() :
            BugBrain(LeftSensor, CenterSensor, RightSensor);
    }

    public Color GetColor() { return Color.red; }
    public string GetName() { return "Test Snail"; }

    public void Finish(){ Debug.Log("Ta-daa!"); }
    public void Failed(){ Debug.Log("Oh Noo!"); }

    private SnailCommand RandomCommand()
    {
        return Random.Range(-1f, 1f) > 0 ?
                SnailCommand.MoveForward
                :
                (Random.Range(-1f, 1f) > 0 ? SnailCommand.TurnLeft : SnailCommand.TurnRight);
    }

    private SnailCommand BugBrain(bool LeftSensor, bool CenterSensor, bool RightSensor)
    {
        if (CenterSensor)
            return SnailCommand.MoveForward;
        if (LeftSensor)
            return SnailCommand.TurnLeft;
        if (RightSensor)
            return SnailCommand.TurnRight;

        return SnailCommand.NoCommand;
    }



}
