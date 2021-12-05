using UnityEngine;

public class MinMaxRandomizer : MonoBehaviour, IRandomizer
{
    private int _max;
    
    public void SetMax(int max)
    {
        _max = max;
    }

    public int GetIndex()
    {
        return Random.Range(0, _max);
    }
}
