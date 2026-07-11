using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEditor.Toolbars;

namespace TimeScaleEditors {
public static class TimeScaleEditor
{
    private const string Path         = nameof(TimeScaleEditor);
    private const float  MaxTimeScale = 10f;

    [MainToolbarElement(Path, defaultDockPosition = MainToolbarDockPosition.Middle)]
    public static IEnumerable<MainToolbarElement> CreateTimeScaleSlider()
    {
        var content     = new MainToolbarContent("Time Scale :", tooltip : "Same as Project Settings > Time > Time Scale.");
        var sliderValue = Time.timeScale;

        yield return new MainToolbarSlider(content, sliderValue, 0f, MaxTimeScale, (changedValue) =>
        {
            Time.timeScale = changedValue;

            // var settingsWindowType = typeof(EditorWindow).Assembly.GetType("UnityEditor.SettingsWindow");
            // if (settingsWindowType != null)
            // {
            //     foreach (var window in Resources.FindObjectsOfTypeAll(settingsWindowType))
            //     {
            //         ((EditorWindow)window).Repaint();
            //     }
            // }
        });
    }
}}