//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.KinovaCustom
{
    [Serializable]
    public class PickObjectFullResult : Message
    {
        public const string k_RosMessageName = "kinova_custom_actions/PickObjectFull";
        public override string RosMessageName => k_RosMessageName;

        // result
        public bool success;

        public PickObjectFullResult()
        {
            this.success = false;
        }

        public PickObjectFullResult(bool success)
        {
            this.success = success;
        }

        public static PickObjectFullResult Deserialize(MessageDeserializer deserializer) => new PickObjectFullResult(deserializer);

        private PickObjectFullResult(MessageDeserializer deserializer)
        {
            deserializer.Read(out this.success);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.success);
        }

        public override string ToString()
        {
            return "PickObjectFullResult: " +
            "\nsuccess: " + success.ToString();
        }

#if UNITY_EDITOR
        [UnityEditor.InitializeOnLoadMethod]
#else
        [UnityEngine.RuntimeInitializeOnLoadMethod]
#endif
        public static void Register()
        {
            MessageRegistry.Register(k_RosMessageName, Deserialize, MessageSubtopic.Result);
        }
    }
}
