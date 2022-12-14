//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;
using RosMessageTypes.Std;

namespace RosMessageTypes.Control
{
    [Serializable]
    public class SingleJointPositionFeedback : Message
    {
        public const string k_RosMessageName = "control_msgs/SingleJointPosition";
        public override string RosMessageName => k_RosMessageName;

        public HeaderMsg header;
        public double position;
        public double velocity;
        public double error;

        public SingleJointPositionFeedback()
        {
            this.header = new HeaderMsg();
            this.position = 0.0;
            this.velocity = 0.0;
            this.error = 0.0;
        }

        public SingleJointPositionFeedback(HeaderMsg header, double position, double velocity, double error)
        {
            this.header = header;
            this.position = position;
            this.velocity = velocity;
            this.error = error;
        }

        public static SingleJointPositionFeedback Deserialize(MessageDeserializer deserializer) => new SingleJointPositionFeedback(deserializer);

        private SingleJointPositionFeedback(MessageDeserializer deserializer)
        {
            this.header = HeaderMsg.Deserialize(deserializer);
            deserializer.Read(out this.position);
            deserializer.Read(out this.velocity);
            deserializer.Read(out this.error);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.header);
            serializer.Write(this.position);
            serializer.Write(this.velocity);
            serializer.Write(this.error);
        }

        public override string ToString()
        {
            return "SingleJointPositionFeedback: " +
            "\nheader: " + header.ToString() +
            "\nposition: " + position.ToString() +
            "\nvelocity: " + velocity.ToString() +
            "\nerror: " + error.ToString();
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
