using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[System.Serializable]
[CreateAssetMenu(menuName = "Typical Customs/Dispensers/Script Dispenser")]
public class ScriptDispenser : ScriptableObject
{
    private int index;
    public ScriptObjectScriptable[] scripts;

    public ScriptObjectScriptable CurrentScript {
        get
        {
            return scripts[index];
        }
    }

    public bool SetNext(ScriptObjectScriptable next)
    {
        for(int i = 0; i < scripts.Length; i++)
        {
            if (next.Equals(scripts[i]))
            {
                Debug.Log(next);
                index = i;
                return true;
            }
        }
        return false;
    }

    private void OnEnable()
    {
        Debug.LogError("implement player pref reading for configuring start screen script");
        index = 0;
        Debug.Log(CurrentScript);
    }
}
