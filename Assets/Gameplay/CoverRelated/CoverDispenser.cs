using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[System.Serializable]
[CreateAssetMenu(menuName = "Typical Customs/Dispensers/Cover Dispenser")]
public class CoverDispenser : ScriptableObject
{
    public CoverObjectScriptable[] cover_objects;
}
