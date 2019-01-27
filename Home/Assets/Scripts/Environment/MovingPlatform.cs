using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float moveSpeed = 10f;
    public GameObject[] movementPoints;
    public movementMode MovementMode = movementMode.loop;
    public int StartingIndex = 0;

    private bool decreasing;
    public enum movementMode
    {
        sequence, // 0, 1, 2, 1, 0
        loop, // 0, 1, 2, 0, 1, 2
        teleport // 0, 1, 2, teleport to 0
    }

    private int curNodeIndex = 0;

    private void Start()
    {
        curNodeIndex = StartingIndex;
    }

    private void Update()
    {
        // check if we have reached a node on our path
        if ((transform.position - movementPoints[curNodeIndex].transform.position).sqrMagnitude < 0.1f)
        {
            switch(MovementMode)
            {
                case (movementMode.loop):
                    curNodeIndex++;
                    if (curNodeIndex == movementPoints.Length)
                    {
                        curNodeIndex = 0;
                    }
                    break;
                case (movementMode.sequence):
                    if (!decreasing)
                    {
                        curNodeIndex++;
                    }
                    else
                    {
                        curNodeIndex--;
                    }
                    if (curNodeIndex == -1)
                    {
                        curNodeIndex = 1;
                        decreasing = false;
                    }
                    if (curNodeIndex == movementPoints.Length)
                    {
                        curNodeIndex -= 2;
                        decreasing = true;
                    }
                    break;
                case (movementMode.teleport):
                    curNodeIndex++;
                    if (curNodeIndex == movementPoints.Length)
                    {
                        transform.position = movementPoints[0].transform.position;
                        curNodeIndex = 1;
                    }
                    break;
            }
        }

        // move towards the next node
        Vector3 dirVec = (movementPoints[curNodeIndex].transform.position - transform.position).normalized * moveSpeed * Time.deltaTime;
        transform.position += dirVec;
    }
}
