using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using Random = UnityEngine.Random;
using System.Text;
using Object = UnityEngine.Object;

public static partial class Utils
{
    public static Vector3 GetTrajectoryPointAtTime(this Rigidbody2D body, float time)
    {
        return GetTrajectoryPointAtTime(body.transform.position, body.velocity, time, body.gravityScale);
    }

    /// <summary>
    /// Plots the trajectory at time.
    /// 
    /// Based on: v = 1/2 * a * t * t + s * t + v0
    /// 
    /// </summary>
    /// <returns>The trajectory at time.</returns>
    /// <param name="start">Start.</param>
    /// <param name="startVelocity">Start velocity.</param>
    /// <param name="time">Time.</param>
    public static Vector3 GetTrajectoryPointAtTime(Vector3 start, Vector3 startVelocity, float time, float gravityScale)
    {
        return 0.5f * Physics.gravity * gravityScale * time * time + startVelocity * time + start;
    }

    public static void PlotTrajectory(Vector3 start, Vector3 startVelocity, float timestep, float maxTime, float gravityScale)
    {
        Vector3 prev = start;
        for (int i = 1; ; i++)
        {
            float t = timestep * i;
            if (t > maxTime)
                break;
            Vector3 pos = GetTrajectoryPointAtTime(start, startVelocity, t, gravityScale);
            if (Physics.Linecast(prev, pos))
                break;
            Debug.DrawLine(prev, pos, Color.red);
            prev = pos;
        }
    }

    public static Vector3 SetVelocityToHitTargetInTime(this Rigidbody2D body, Vector3 target, float time)
    {
        return body.velocity = GetProjectedVelocityForTargetAtTime(body.transform.position, target, time);
    }

    /// <summary>
    /// Gets the projected velocity for target at time.
    /// 
    /// Based on: s = (- 1/2 * a * t * t + v - v0) / t 
    /// 
    /// </summary>
    /// <returns>The projected velocity for target at time.</returns>
    /// <param name="startPosition">Start position.</param>
    /// <param name="destinationPosition">Destination position.</param>
    /// <param name="time">Time.</param>
    public static Vector3 GetProjectedVelocityForTargetAtTime(Vector3 startPosition, Vector3 destinationPosition, float time)
    {
        return (-0.5f * Physics.gravity * time * time + destinationPosition - startPosition) / time;
    }

    public static bool GetFiftyFiftyChance()
    {
        return Random.value < 0.5f;
    }

    // dict.RandomValues().ElementAt(0)
    public static IEnumerable<TValue> RandomValues<TKey, TValue>(this IDictionary<TKey, TValue> dict)
    {
        System.Random rand = new System.Random();
        List<TValue> values = Enumerable.ToList(dict.Values);
        int size = dict.Count;
        while (true)
            yield return values[rand.Next(size)];
    }

    public static Vector3 Direction(this Vector3 source, Vector3 target)
    {
        return (target - source).normalized;
    }

    public static GameObject Instantiate(this GameObject prefab)
    {
        return Object.Instantiate(prefab) as GameObject;
    }

    public static float Range(float min, float max, float excludeRangeMin, float excludeRangeMax)
    {
        return GetFiftyFiftyChance() ? Random.Range(min, excludeRangeMin) : Random.Range(excludeRangeMax, max);
    }

    public static string ToString<T>(this IEnumerable<T> list, string separator)
    {
        StringBuilder sb = new StringBuilder();
        foreach (var obj in list)
        {
            if (sb.Length > 0)
            {
                sb.Append(separator);
            }
            sb.Append(obj);
        }
        return sb.ToString();
    }

    public static IEnumerator EaseColor(this SpriteRenderer sprite, Color source, Color target, float time, Easing.Type easingType)
    {
        sprite.color = source;
        sprite.enabled = true;

        float startTime = 0;

        while (startTime <= time)
        {

            startTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();

            sprite.color = new Color()
            {
                r = source.r,
                g = source.g,
                b = source.b,
                a = Mathf.Lerp(source.a, target.a, easingType.Ease(startTime))
            };
        }
    }
}
