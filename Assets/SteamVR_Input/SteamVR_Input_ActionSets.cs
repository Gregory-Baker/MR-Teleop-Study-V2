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
        
        private static SteamVR_Input_ActionSet_Common p_Common;
        
        private static SteamVR_Input_ActionSet_Base p_Base;
        
        private static SteamVR_Input_ActionSet_Arm p_Arm;
        
        public static SteamVR_Input_ActionSet_Common Common
        {
            get
            {
                return SteamVR_Actions.p_Common.GetCopy<SteamVR_Input_ActionSet_Common>();
            }
        }
        
        public static SteamVR_Input_ActionSet_Base Base
        {
            get
            {
                return SteamVR_Actions.p_Base.GetCopy<SteamVR_Input_ActionSet_Base>();
            }
        }
        
        public static SteamVR_Input_ActionSet_Arm Arm
        {
            get
            {
                return SteamVR_Actions.p_Arm.GetCopy<SteamVR_Input_ActionSet_Arm>();
            }
        }
        
        private static void StartPreInitActionSets()
        {
            SteamVR_Actions.p_Common = ((SteamVR_Input_ActionSet_Common)(SteamVR_ActionSet.Create<SteamVR_Input_ActionSet_Common>("/actions/Common")));
            SteamVR_Actions.p_Base = ((SteamVR_Input_ActionSet_Base)(SteamVR_ActionSet.Create<SteamVR_Input_ActionSet_Base>("/actions/Base")));
            SteamVR_Actions.p_Arm = ((SteamVR_Input_ActionSet_Arm)(SteamVR_ActionSet.Create<SteamVR_Input_ActionSet_Arm>("/actions/Arm")));
            Valve.VR.SteamVR_Input.actionSets = new Valve.VR.SteamVR_ActionSet[] {
                    SteamVR_Actions.Common,
                    SteamVR_Actions.Base,
                    SteamVR_Actions.Arm};
        }
    }
}
