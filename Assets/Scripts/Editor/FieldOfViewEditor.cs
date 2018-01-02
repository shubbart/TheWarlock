﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EnemyView))]
public class FieldOfViewEditor : Editor
{

    void OnSceneGUI()
    {
        EnemyView fow = (EnemyView)target;
        Handles.color = Color.red;
        Handles.DrawWireArc(fow.transform.position, Vector3.up, Vector3.forward, 360, fow.viewRadius);
        Vector3 viewAngleA = fow.dirFromAngle(-fow.viewAngle / 2, false);
        Vector3 viewAngleB = fow.dirFromAngle(fow.viewAngle / 2, false);

        Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleA * fow.viewRadius);
        Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleB * fow.viewRadius);

        Handles.color = Color.red;
        foreach (Transform visibleTarget in fow.visibleTargets)
        {
            Handles.DrawLine(fow.transform.position, visibleTarget.position);
        }

    }
}