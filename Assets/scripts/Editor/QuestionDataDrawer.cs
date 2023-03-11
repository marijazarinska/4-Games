using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;



//ovaa skripta e za promena na izgledo na Questions vo proekto, t.e nacino na dodavanje na prasanja da e po ednostaven i pregleden

//atributi
[CustomEditor(typeof(Questions))]  //pisuvame go/sozdavame CustomEditor od Questions
[CanEditMultipleObjects]
[System.Serializable]
public class QuestionDataDrawer : Editor
{
    private Questions QuestionsInstance => target as Questions;   //ukazuva na istancata na Question objektot
    private ReorderableList QuestionsList;

    private void OnEnable()
    {
        InitializeReordableList(ref QuestionsList, "questionsList" , "Questions List");
    }

    public override void OnInspectorGUI()  //da go sozdademe CustomGUI
    {
        serializedObject.Update();
        QuestionsList.DoLayoutList();
        serializedObject.ApplyModifiedProperties();
    }


    //inicijalizacija
    private void InitializeReordableList (ref ReorderableList list , string propertyName, string listLabel)
    {
        list = new ReorderableList(serializedObject, serializedObject.FindProperty(propertyName), draggable: true,
            displayHeader: true, displayAddButton: true, displayRemoveButton: true);

        list.onAddCallback = reordableList => QuestionsInstance.AddQuestion();

        list.drawHeaderCallback = (Rect rect) =>
        {
            EditorGUI.LabelField(rect, listLabel);
        };

        var l = list;

        list.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) =>
        {
            var element = l.serializedProperty.GetArrayElementAtIndex(index);
            rect.y += 2;

            EditorGUI.PropertyField(
                new Rect(rect.x, rect.y, 300, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative("question"),
                GUIContent.none);

            EditorGUI.PropertyField(
                new Rect(rect.x + 310, rect.y, 300, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative("isTrue"),
                GUIContent.none);
        };
    }
}
