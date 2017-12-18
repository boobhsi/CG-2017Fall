using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathQueue
{
    private Queue<Vector3> mPathQueue = new Queue<Vector3>();
    private static int waitFrameNum = 10;
    private int waitCount = 0;

    public Vector3 oneInoneOut(Vector3 vin) {
        Vector3 vout = new Vector3(0, 0, 0);
        if (waitCount > waitFrameNum) {
            vout = mPathQueue.Dequeue();
            mPathQueue.Enqueue(vin);
        }
        else {
            mPathQueue.Enqueue(vin);
            waitCount += 1;
        }

        return vout;
    }
}
