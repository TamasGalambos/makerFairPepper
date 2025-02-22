using System;
using System.Collections;
using System.Collections.Generic;
using g3;
using UnityEngine;
using UnityEngine.Rendering;

namespace UltimateProceduralPrimitives
{
  public static class Utils
  {
    public static float Sign(float num)
    {
      return num < 0 ? -1 : (num > 0 ? 1 : 0);
    }
    public static Vector3 Sign(Vector3 vector3)
    {
      var x = vector3.x < 0 ? -1 : (vector3.x > 0 ? 1 : 0);
      var y = vector3.y < 0 ? -1 : (vector3.y > 0 ? 1 : 0);
      var z = vector3.z < 0 ? -1 : (vector3.z > 0 ? 1 : 0);
      return new Vector3(x, y, z);
    }

    public static Vector3 Mul(Quaternion q, Vector3 v)
    {
      Vector3 t = 2.0f * Vector3.Cross(new Vector3(q.x, q.y, q.z), v);
      return v + q.w * t + Vector3.Cross(new Vector3(q.x, q.y, q.z), t);
    }

    public static Vector3 MultiplyVec3(Vector3 a, Vector3 b)
    {
      Vector3 result = new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
      return result;
    }

    public static Quaternion AxisAngle(Vector3 axis, float angle)
    {
      float sina, cosa;
      sina = Mathf.Sin(0.5f * angle);
      cosa = Mathf.Cos(0.5f * angle);
      return new Quaternion(axis.x * sina, axis.y * sina, axis.z * sina, cosa);
    }


    public static System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
    public static void TimerStart()
    {
      sw.Reset();
      sw.Start();
    }
    public static void TimerStop(Shape shape)
    {
      sw.Stop();
      TimeSpan ts = TimeSpan.FromMilliseconds(sw.ElapsedMilliseconds);
      Debug.Log($"UPP Results : Mesh creation time [hh:mm:ss:ms] {ts} {shape.ToString()}");
    }
  }
}
