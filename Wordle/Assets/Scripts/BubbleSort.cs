using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSort : MonoBehaviour
{
    public int[] integers;
    bool hasSorted = true;

    [ContextMenu("sort")]
    public void Sort()
    {
        while (BubbleSorting(integers))
        {
            BubbleSorting(integers);
        }
    }

    public bool BubbleSorting(int[] input)
    {
        hasSorted = false;
        for (int i = 0; i < input.Length - 1; i++)
        {
            if (input[i] > input[i + 1])
            {
                int temp = input[i];
                input[i] = input[i + 1];
                input[i + 1] = temp;
                hasSorted = true;
            }
        }
        return hasSorted;
    }
}
