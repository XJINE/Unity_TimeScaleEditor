using UnityEngine;
using UnityEditor.Toolbars;
using Position = UnityEditor.Toolbars.MainToolbarDockPosition;

namespace TimeScaleEditors
{
    public static class TimeScaleEditor
    {
        private const string   ElementId    = nameof(TimeScaleEditor);
        private const Position DockPosition = Position.Middle;
        private const float    MaxTimeScale = 10f;

        [MainToolbarElement(ElementId, defaultDockPosition = DockPosition)]
        public static MainToolbarElement CreateTimeScaleSlider()
        {
            var content     = new MainToolbarContent("Time Scale :", tooltip : "Same as Project Settings > Time > Time Scale.");
            var sliderValue = Time.timeScale;

            return new MainToolbarSlider(content, sliderValue, 0f, MaxTimeScale, (changedValue) =>
            {
                Time.timeScale = changedValue;
            });
        }
    }
}
