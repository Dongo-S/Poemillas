using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObject/DataScenesValue")]
public class DataScenesValues : ScriptableObject, ISerializationCallbackReceiver
{
    public bool storyHasBeenSeen = false;

    public bool storyHasBeenSeenRuntime;
    public void OnAfterDeserialize()
    {
        storyHasBeenSeenRuntime = storyHasBeenSeen;
    }

    public void OnBeforeSerialize()
    {
       
    }
}
