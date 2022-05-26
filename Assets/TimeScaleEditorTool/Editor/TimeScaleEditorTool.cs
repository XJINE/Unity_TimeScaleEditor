using UnityEngine;
using UnityEditor;
using UnityToolbarExtender;

namespace TimeScaleEditor
{
    [InitializeOnLoad]
    public class TimeScaleEditorTool
    {
        private const float MaxTimeScale = 10f;
        private const float SliderPower  = 3f;

        private static float _timeScaleCache;
        private static bool  _disabled;

        static TimeScaleEditorTool()
        {
            ToolbarExtender.RightToolbarGUI.Add(OnToolbarGUI);
            _timeScaleCache = Time.timeScale;
        }

        private static void OnToolbarGUI()
        {
            // NOTE:
            // Disable UI when Time.timeScale is changed in outside.
            _disabled = EditorApplication.isPlaying && (_timeScaleCache != Time.timeScale);

            EditorGUILayout.BeginHorizontal(GUILayout.MaxWidth(250));
            EditorGUI.BeginDisabledGroup(_disabled);

            EditorGUILayout.LabelField("Time Scale", GUILayout.Width(70));

            var powerSliderValue = Mathf.Pow(Time.timeScale / MaxTimeScale, 1 / SliderPower);
                powerSliderValue = GUILayout.HorizontalSlider(powerSliderValue, 0, 1);

            Time.timeScale = Mathf.Pow(powerSliderValue, SliderPower) * MaxTimeScale;
            Time.timeScale = (float)System.Math.Round(Time.timeScale, 2);
            Time.timeScale = EditorGUILayout.FloatField(Time.timeScale, GUILayout.Width(50));

            EditorGUI.EndDisabledGroup();
            EditorGUILayout.EndHorizontal();

            if (!_disabled)
            {
                _timeScaleCache = Time.timeScale;
            }
        }
    }
}