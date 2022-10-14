#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using UnityEditor.Animations;

public class Function_Integrated_Ani : MonoBehaviour
{
    [MenuItem("Assets/애니메이션 클립 통합", true)]
    static public bool nestAnimClipsValidate() => Selection.activeObject.GetType() == typeof(AnimatorController);

    [MenuItem("Assets/애니메이션 클립 통합")]
    static public void nestAnimClips()
    {
        AnimatorController anim_controller = (AnimatorController)Selection.activeObject;
        if (anim_controller == null) return;

        // Get all objects currently in Controller asset, we'll destroy them later
        Object[] objects = AssetDatabase.LoadAllAssetsAtPath(AssetDatabase.GetAssetPath(anim_controller));

        AssetDatabase.SaveAssets();

        // Add animations from all animation layers, without duplicating them
        var oldToNew = new Dictionary<AnimationClip, AnimationClip>();
        foreach (AnimatorControllerLayer layer in anim_controller.layers)
        {
            foreach (var state in layer.stateMachine.states)
            {
                var old = state.state.motion as AnimationClip;
                if (old == null) continue;

                if (!oldToNew.ContainsKey(old))    // New animation in list - create new instance
                {
                    var newClip = Instantiate(old) as AnimationClip;
                    newClip.name = old.name;
                    AssetDatabase.AddObjectToAsset(newClip, anim_controller);
                    AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(newClip));
                    oldToNew[old] = newClip;
                    Debug.Log("Nested animation clip: " + newClip.name);
                }

                state.state.motion = oldToNew[old];
            }
        }

        // Destroy all old AnimationClips in asset
        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i].GetType() == typeof(AnimationClip))
            {
                DestroyImmediate(objects[i], true);
            }
        }
        AssetDatabase.SaveAssets();
    }
}
#endif