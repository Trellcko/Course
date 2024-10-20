﻿using UnityEngine;

namespace CodeBase.Data
{
    public static class DataExtension
    {
        public static Vector3Data AsVectorData(this Vector3 vector) => 
            new(vector.x, vector.y, vector.z);

        public static Vector3 AsUnityVector(this Vector3Data vector) => 
            new(vector.X, vector.Y, vector.Z);

        public static T ToDeserialize<T>(this string json) => 
            JsonUtility.FromJson<T>(json);
    }
}
