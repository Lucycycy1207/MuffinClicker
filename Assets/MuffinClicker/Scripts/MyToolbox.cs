using UnityEngine;

public static class MyToolbox
{
    //all in static
    /// <summary>
    /// Get one random x and y with higher bounds and lower bounds.
    /// </summary>
    /// <param name="xl"></param>
    /// <param name="xu"></param>
    /// <param name="yl"></param>
    /// <param name="yu"></param>
    /// <returns></returns>
    public static Vector2 GetRandomVector2(float xl, float xu, float yl, float yu)
    {
        // x -150 180
        // y -150 150
        Vector2 value = new Vector2();
        value.x = Random.Range(xl, xu);
        value.y = Random.Range(yl, yu);
        return value;
    }
}
