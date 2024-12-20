﻿using UnityEngine;

namespace CodeBase.Data
{
    public static class DataExtension
    {
        public static Vector3Data AsVectorData(this Vector3 vector) => 
            new(vector.x, vector.y, vector.z);

        public static Vector3 AsUnityVector(this Vector3Data vector) => 
            new(vector.X, vector.Y, vector.Z);

        public static string ToJson(this object value) =>
            JsonUtility.ToJson(value);

        public static Vector3 AddY(this Vector3 target, float y)
        {
            target.y += y;
            return target;
        }
        public static T ToDeserialize<T>(this string json) => 
            JsonUtility.FromJson<T>(json);
    }
}
