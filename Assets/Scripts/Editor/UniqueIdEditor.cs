using System;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace CodeBase
{
    [CustomEditor(typeof(UniqueId))]
    public class UniqueIdEditor : UnityEditor.Editor
    {
        private void OnEnable()
        {
            UniqueId uniqueId = (UniqueId)target;

            if (IsPrefab(uniqueId))
                return;
            
            if(string.IsNullOrEmpty(uniqueId.Id))
            {
                Generate(uniqueId);
            }
            else {
                foreach (var unqiue in FindObjectsOfType<UniqueId>())
                {
                    if(uniqueId != unqiue && uniqueId.Id == unqiue.Id)
                    {
                        Generate(uniqueId);
                    }
                }
            }
        }

        private bool IsPrefab(UniqueId uniqueId) =>
            uniqueId.gameObject.scene.rootCount == 0;


        private void Generate(UniqueId uniqueId)
        {
            if (Application.isPlaying)
                return;

            uniqueId.Id = $"{uniqueId.gameObject.scene.name}_{Guid.NewGuid().ToString()}";
            EditorUtility.SetDirty(uniqueId);
            EditorSceneManager.MarkSceneDirty(uniqueId.gameObject.scene);
        }
    }
}
