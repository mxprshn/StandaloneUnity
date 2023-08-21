// Unity C# reference source
// Copyright (c) Unity Technologies. For terms of use, see
// https://unity3d.com/legal/licenses/Unity_Reference_Only_License

namespace UnityEngine
{
    [VisibleToOtherModules("UnityEngine.UIElementsModule")]
    internal struct EventInterests
    {
        private bool textFieldInputMock;

        public bool wantsMouseMove { get; set; }
        public bool wantsMouseEnterLeaveWindow { get; set; }
        public bool wantsLessLayoutEvents { get; set; }

        public bool WantsEvent(EventType type)
        {
            switch (type)
            {
                case EventType.MouseMove:
                    return wantsMouseMove;
                case EventType.MouseEnterWindow:
                case EventType.MouseLeaveWindow:
                    return wantsMouseEnterLeaveWindow;
                default:
                    return true;
            }
        }

        public bool WantsLayoutPass(EventType type)
        {
            if (!wantsLessLayoutEvents)
                return true;

            switch (type)
            {
                case EventType.Repaint:
                case EventType.ExecuteCommand:
                    return true;

                case EventType.KeyDown:
                case EventType.KeyUp:
                    return textFieldInputMock;// !MODIFIED GUIUtility.textFieldInput;

                case EventType.MouseDown:
                case EventType.MouseUp:
                    return wantsMouseMove;

                case EventType.MouseEnterWindow:
                case EventType.MouseLeaveWindow:
                    return wantsMouseEnterLeaveWindow;
            }

            return false;
        }
    }
}
