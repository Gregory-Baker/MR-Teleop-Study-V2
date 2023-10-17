//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.HuskyCustom
{
    [Serializable]
    public class MoveDistanceFeedback : Message
    {
        public const string k_RosMessageName = "husky_custom_actions/MoveDistance";
        public override string RosMessageName => k_RosMessageName;

        // feedback
        public float distance_moved;

        public MoveDistanceFeedback()
        {
            this.distance_moved = 0.0f;
        }

        public MoveDistanceFeedback(float distance_moved)
        {
            this.distance_moved = distance_moved;
        }

        public static MoveDistanceFeedback Deserialize(MessageDeserializer deserializer) => new MoveDistanceFeedback(deserializer);

        private MoveDistanceFeedback(MessageDeserializer deserializer)
        {
            deserializer.Read(out this.distance_moved);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.distance_moved);
        }

        public override string ToString()
        {
            return "MoveDistanceFeedback: " +
            "\ndistance_moved: " + distance_moved.ToString();
        }

#if UNITY_EDITOR
        [UnityEditor.InitializeOnLoadMethod]
#else
        [UnityEngine.RuntimeInitializeOnLoadMethod]
#endif
        public static void Register()
        {
            MessageRegistry.Register(k_RosMessageName, Deserialize, MessageSubtopic.Feedback);
        }
    }
}
