//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Valve.VR
{
    using System;
    using UnityEngine;
    
    
    public partial class SteamVR_Actions
    {
        
        private static SteamVR_Action_Boolean p_common_Switch_Control;
        
        private static SteamVR_Action_Pose p_common_Pose;
        
        private static SteamVR_Action_Boolean p_common_RadialMenu_Select;
        
        private static SteamVR_Action_Boolean p_common_RadialMenu_Activate;
        
        private static SteamVR_Action_Vector2 p_common_RadialMenu_CursorPosition;
        
        private static SteamVR_Action_Boolean p_common_Turn_Cam_Left;
        
        private static SteamVR_Action_Boolean p_common_Turn_Cam_Right;
        
        private static SteamVR_Action_Boolean p_common_Centre_Cam;
        
        private static SteamVR_Action_Boolean p_common_NextTutorial;
        
        private static SteamVR_Action_Boolean p_base_Select_Target;
        
        private static SteamVR_Action_Vector2 p_base_Rotate_Target;
        
        private static SteamVR_Action_Boolean p_base_Confirm_Target;
        
        private static SteamVR_Action_Boolean p_base_Stop_Robot;
        
        private static SteamVR_Action_Boolean p_base_MoveForward;
        
        private static SteamVR_Action_Boolean p_base_MoveBackward;
        
        private static SteamVR_Action_Boolean p_arm_Move_Target_Enable;
        
        private static SteamVR_Action_Boolean p_arm_Confirm_Target;
        
        private static SteamVR_Action_Boolean p_arm_Stop_Arm;
        
        public static SteamVR_Action_Boolean common_Switch_Control
        {
            get
            {
                return SteamVR_Actions.p_common_Switch_Control.GetCopy<SteamVR_Action_Boolean>();
            }
        }
        
        public static SteamVR_Action_Pose common_Pose
        {
            get
            {
                return SteamVR_Actions.p_common_Pose.GetCopy<SteamVR_Action_Pose>();
            }
        }
        
        public static SteamVR_Action_Boolean common_RadialMenu_Select
        {
            get
            {
                return SteamVR_Actions.p_common_RadialMenu_Select.GetCopy<SteamVR_Action_Boolean>();
            }
        }
        
        public static SteamVR_Action_Boolean common_RadialMenu_Activate
        {
            get
            {
                return SteamVR_Actions.p_common_RadialMenu_Activate.GetCopy<SteamVR_Action_Boolean>();
            }
        }
        
        public static SteamVR_Action_Vector2 common_RadialMenu_CursorPosition
        {
            get
            {
                return SteamVR_Actions.p_common_RadialMenu_CursorPosition.GetCopy<SteamVR_Action_Vector2>();
            }
        }
        
        public static SteamVR_Action_Boolean common_Turn_Cam_Left
        {
            get
            {
                return SteamVR_Actions.p_common_Turn_Cam_Left.GetCopy<SteamVR_Action_Boolean>();
            }
        }
        
        public static SteamVR_Action_Boolean common_Turn_Cam_Right
        {
            get
            {
                return SteamVR_Actions.p_common_Turn_Cam_Right.GetCopy<SteamVR_Action_Boolean>();
            }
        }
        
        public static SteamVR_Action_Boolean common_Centre_Cam
        {
            get
            {
                return SteamVR_Actions.p_common_Centre_Cam.GetCopy<SteamVR_Action_Boolean>();
            }
        }
        
        public static SteamVR_Action_Boolean common_NextTutorial
        {
            get
            {
                return SteamVR_Actions.p_common_NextTutorial.GetCopy<SteamVR_Action_Boolean>();
            }
        }
        
        public static SteamVR_Action_Boolean base_Select_Target
        {
            get
            {
                return SteamVR_Actions.p_base_Select_Target.GetCopy<SteamVR_Action_Boolean>();
            }
        }
        
        public static SteamVR_Action_Vector2 base_Rotate_Target
        {
            get
            {
                return SteamVR_Actions.p_base_Rotate_Target.GetCopy<SteamVR_Action_Vector2>();
            }
        }
        
        public static SteamVR_Action_Boolean base_Confirm_Target
        {
            get
            {
                return SteamVR_Actions.p_base_Confirm_Target.GetCopy<SteamVR_Action_Boolean>();
            }
        }
        
        public static SteamVR_Action_Boolean base_Stop_Robot
        {
            get
            {
                return SteamVR_Actions.p_base_Stop_Robot.GetCopy<SteamVR_Action_Boolean>();
            }
        }
        
        public static SteamVR_Action_Boolean base_MoveForward
        {
            get
            {
                return SteamVR_Actions.p_base_MoveForward.GetCopy<SteamVR_Action_Boolean>();
            }
        }
        
        public static SteamVR_Action_Boolean base_MoveBackward
        {
            get
            {
                return SteamVR_Actions.p_base_MoveBackward.GetCopy<SteamVR_Action_Boolean>();
            }
        }
        
        public static SteamVR_Action_Boolean arm_Move_Target_Enable
        {
            get
            {
                return SteamVR_Actions.p_arm_Move_Target_Enable.GetCopy<SteamVR_Action_Boolean>();
            }
        }
        
        public static SteamVR_Action_Boolean arm_Confirm_Target
        {
            get
            {
                return SteamVR_Actions.p_arm_Confirm_Target.GetCopy<SteamVR_Action_Boolean>();
            }
        }
        
        public static SteamVR_Action_Boolean arm_Stop_Arm
        {
            get
            {
                return SteamVR_Actions.p_arm_Stop_Arm.GetCopy<SteamVR_Action_Boolean>();
            }
        }
        
        private static void InitializeActionArrays()
        {
            Valve.VR.SteamVR_Input.actions = new Valve.VR.SteamVR_Action[] {
                    SteamVR_Actions.common_Switch_Control,
                    SteamVR_Actions.common_Pose,
                    SteamVR_Actions.common_RadialMenu_Select,
                    SteamVR_Actions.common_RadialMenu_Activate,
                    SteamVR_Actions.common_RadialMenu_CursorPosition,
                    SteamVR_Actions.common_Turn_Cam_Left,
                    SteamVR_Actions.common_Turn_Cam_Right,
                    SteamVR_Actions.common_Centre_Cam,
                    SteamVR_Actions.common_NextTutorial,
                    SteamVR_Actions.base_Select_Target,
                    SteamVR_Actions.base_Rotate_Target,
                    SteamVR_Actions.base_Confirm_Target,
                    SteamVR_Actions.base_Stop_Robot,
                    SteamVR_Actions.base_MoveForward,
                    SteamVR_Actions.base_MoveBackward,
                    SteamVR_Actions.arm_Move_Target_Enable,
                    SteamVR_Actions.arm_Confirm_Target,
                    SteamVR_Actions.arm_Stop_Arm};
            Valve.VR.SteamVR_Input.actionsIn = new Valve.VR.ISteamVR_Action_In[] {
                    SteamVR_Actions.common_Switch_Control,
                    SteamVR_Actions.common_Pose,
                    SteamVR_Actions.common_RadialMenu_Select,
                    SteamVR_Actions.common_RadialMenu_Activate,
                    SteamVR_Actions.common_RadialMenu_CursorPosition,
                    SteamVR_Actions.common_Turn_Cam_Left,
                    SteamVR_Actions.common_Turn_Cam_Right,
                    SteamVR_Actions.common_Centre_Cam,
                    SteamVR_Actions.common_NextTutorial,
                    SteamVR_Actions.base_Select_Target,
                    SteamVR_Actions.base_Rotate_Target,
                    SteamVR_Actions.base_Confirm_Target,
                    SteamVR_Actions.base_Stop_Robot,
                    SteamVR_Actions.base_MoveForward,
                    SteamVR_Actions.base_MoveBackward,
                    SteamVR_Actions.arm_Move_Target_Enable,
                    SteamVR_Actions.arm_Confirm_Target,
                    SteamVR_Actions.arm_Stop_Arm};
            Valve.VR.SteamVR_Input.actionsOut = new Valve.VR.ISteamVR_Action_Out[0];
            Valve.VR.SteamVR_Input.actionsVibration = new Valve.VR.SteamVR_Action_Vibration[0];
            Valve.VR.SteamVR_Input.actionsPose = new Valve.VR.SteamVR_Action_Pose[] {
                    SteamVR_Actions.common_Pose};
            Valve.VR.SteamVR_Input.actionsBoolean = new Valve.VR.SteamVR_Action_Boolean[] {
                    SteamVR_Actions.common_Switch_Control,
                    SteamVR_Actions.common_RadialMenu_Select,
                    SteamVR_Actions.common_RadialMenu_Activate,
                    SteamVR_Actions.common_Turn_Cam_Left,
                    SteamVR_Actions.common_Turn_Cam_Right,
                    SteamVR_Actions.common_Centre_Cam,
                    SteamVR_Actions.common_NextTutorial,
                    SteamVR_Actions.base_Select_Target,
                    SteamVR_Actions.base_Confirm_Target,
                    SteamVR_Actions.base_Stop_Robot,
                    SteamVR_Actions.base_MoveForward,
                    SteamVR_Actions.base_MoveBackward,
                    SteamVR_Actions.arm_Move_Target_Enable,
                    SteamVR_Actions.arm_Confirm_Target,
                    SteamVR_Actions.arm_Stop_Arm};
            Valve.VR.SteamVR_Input.actionsSingle = new Valve.VR.SteamVR_Action_Single[0];
            Valve.VR.SteamVR_Input.actionsVector2 = new Valve.VR.SteamVR_Action_Vector2[] {
                    SteamVR_Actions.common_RadialMenu_CursorPosition,
                    SteamVR_Actions.base_Rotate_Target};
            Valve.VR.SteamVR_Input.actionsVector3 = new Valve.VR.SteamVR_Action_Vector3[0];
            Valve.VR.SteamVR_Input.actionsSkeleton = new Valve.VR.SteamVR_Action_Skeleton[0];
            Valve.VR.SteamVR_Input.actionsNonPoseNonSkeletonIn = new Valve.VR.ISteamVR_Action_In[] {
                    SteamVR_Actions.common_Switch_Control,
                    SteamVR_Actions.common_RadialMenu_Select,
                    SteamVR_Actions.common_RadialMenu_Activate,
                    SteamVR_Actions.common_RadialMenu_CursorPosition,
                    SteamVR_Actions.common_Turn_Cam_Left,
                    SteamVR_Actions.common_Turn_Cam_Right,
                    SteamVR_Actions.common_Centre_Cam,
                    SteamVR_Actions.common_NextTutorial,
                    SteamVR_Actions.base_Select_Target,
                    SteamVR_Actions.base_Rotate_Target,
                    SteamVR_Actions.base_Confirm_Target,
                    SteamVR_Actions.base_Stop_Robot,
                    SteamVR_Actions.base_MoveForward,
                    SteamVR_Actions.base_MoveBackward,
                    SteamVR_Actions.arm_Move_Target_Enable,
                    SteamVR_Actions.arm_Confirm_Target,
                    SteamVR_Actions.arm_Stop_Arm};
        }
        
        private static void PreInitActions()
        {
            SteamVR_Actions.p_common_Switch_Control = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/Common/in/Switch Control")));
            SteamVR_Actions.p_common_Pose = ((SteamVR_Action_Pose)(SteamVR_Action.Create<SteamVR_Action_Pose>("/actions/Common/in/Pose")));
            SteamVR_Actions.p_common_RadialMenu_Select = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/Common/in/RadialMenu_Select")));
            SteamVR_Actions.p_common_RadialMenu_Activate = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/Common/in/RadialMenu_Activate")));
            SteamVR_Actions.p_common_RadialMenu_CursorPosition = ((SteamVR_Action_Vector2)(SteamVR_Action.Create<SteamVR_Action_Vector2>("/actions/Common/in/RadialMenu_CursorPosition")));
            SteamVR_Actions.p_common_Turn_Cam_Left = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/Common/in/Turn Cam Left")));
            SteamVR_Actions.p_common_Turn_Cam_Right = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/Common/in/Turn Cam Right")));
            SteamVR_Actions.p_common_Centre_Cam = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/Common/in/Centre Cam")));
            SteamVR_Actions.p_common_NextTutorial = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/Common/in/NextTutorial")));
            SteamVR_Actions.p_base_Select_Target = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/Base/in/Select Target")));
            SteamVR_Actions.p_base_Rotate_Target = ((SteamVR_Action_Vector2)(SteamVR_Action.Create<SteamVR_Action_Vector2>("/actions/Base/in/Rotate Target")));
            SteamVR_Actions.p_base_Confirm_Target = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/Base/in/Confirm Target")));
            SteamVR_Actions.p_base_Stop_Robot = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/Base/in/Stop Robot")));
            SteamVR_Actions.p_base_MoveForward = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/Base/in/MoveForward")));
            SteamVR_Actions.p_base_MoveBackward = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/Base/in/MoveBackward")));
            SteamVR_Actions.p_arm_Move_Target_Enable = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/Arm/in/Move Target Enable")));
            SteamVR_Actions.p_arm_Confirm_Target = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/Arm/in/Confirm_Target")));
            SteamVR_Actions.p_arm_Stop_Arm = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/Arm/in/Stop Arm")));
        }
    }
}
