//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.HuskyCustom
{
    [Serializable]
    public class MoveDistanceGoal : Message
    {
        public const string k_RosMessageName = "husky_custom_actions/MoveDistance";
        public override string RosMessageName => k_RosMessageName;

        // goal - 
        public float move_distance;

        public MoveDistanceGoal()
        {
            this.move_distance = 0.0f;
        }

        public MoveDistanceGoal(float move_distance)
        {
            this.move_distance = move_distance;
        }

        public static MoveDistanceGoal Deserialize(MessageDeserializer deserializer) => new MoveDistanceGoal(deserializer);

        private MoveDistanceGoal(MessageDeserializer deserializer)
        {
            deserializer.Read(out this.move_distance);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.move_distance);
        }

        public override string ToString()
        {
            return "MoveDistanceGoal: " +
            "\nmove_distance: " + move_distance.ToString();
        }

#if UNITY_EDITOR
        [UnityEditor.InitializeOnLoadMethod]
#else
        [UnityEngine.RuntimeInitializeOnLoadMethod]
#endif
        public static void Register()
        {
            MessageRegistry.Register(k_RosMessageName, Deserialize, MessageSubtopic.Goal);
        }
    }
}
