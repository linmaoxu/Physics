using UnityEngine;
using UnityEditor;

namespace Physics2D.Test
{
    [CustomEditor(typeof(Test2DIntersect))]
    public class Test2DIntersectEditor : Editor
    {

        private void OnSceneGUI()
        {
            Test2DIntersect tg = (Test2DIntersect)target;

            Handles.color = Color.red;
            Handles.DrawWireCube(Vector3.zero,Vector3.one);
        }
    }
}