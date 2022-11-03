using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Briefing for level", menuName = "BriefingText", order = 1)]
public class BriefingText : ScriptableObject
{
    [TextArea(5, 10)]
    public string briefingText = "New mission briefing text";
    public bool flashingElipsis = false;
}
