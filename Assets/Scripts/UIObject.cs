using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UIObject
{
    [Header("Component")]
    public string Name;
    public GameObject gameObject;

    [Header("Coroutine properties")]
    public DropdownMenus.ReturnTypes returnType;
    public DropdownMenus.Actions coroutineAction;
    [HideInInspector] public YieldInstruction coroutineReturn;
    public float delay;

    [Header("Actions")]
    public List<DropdownMenus.Actions> actions;
    [HideInInspector] public List<Action> actionsToExecute = new();
    public float blinkInterval;
    public int blinkAmount;
}
