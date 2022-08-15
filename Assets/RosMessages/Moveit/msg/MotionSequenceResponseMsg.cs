//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.Moveit
{
    [Serializable]
    public class MotionSequenceResponseMsg : Message
    {
        public const string k_RosMessageName = "moveit_msgs/MotionSequenceResponse";
        public override string RosMessageName => k_RosMessageName;

        //  An error code reflecting what went wrong
        public MoveItErrorCodesMsg error_code;
        //  The full starting state of the robot at the start of the sequence
        public RobotStateMsg sequence_start;
        //  The trajectories that the planner produced for execution
        public RobotTrajectoryMsg[] planned_trajectories;
        //  The amount of time it took to complete the motion plan
        public double planning_time;

        public MotionSequenceResponseMsg()
        {
            this.error_code = new MoveItErrorCodesMsg();
            this.sequence_start = new RobotStateMsg();
            this.planned_trajectories = new RobotTrajectoryMsg[0];
            this.planning_time = 0.0;
        }

        public MotionSequenceResponseMsg(MoveItErrorCodesMsg error_code, RobotStateMsg sequence_start, RobotTrajectoryMsg[] planned_trajectories, double planning_time)
        {
            this.error_code = error_code;
            this.sequence_start = sequence_start;
            this.planned_trajectories = planned_trajectories;
            this.planning_time = planning_time;
        }

        public static MotionSequenceResponseMsg Deserialize(MessageDeserializer deserializer) => new MotionSequenceResponseMsg(deserializer);

        private MotionSequenceResponseMsg(MessageDeserializer deserializer)
        {
            this.error_code = MoveItErrorCodesMsg.Deserialize(deserializer);
            this.sequence_start = RobotStateMsg.Deserialize(deserializer);
            deserializer.Read(out this.planned_trajectories, RobotTrajectoryMsg.Deserialize, deserializer.ReadLength());
            deserializer.Read(out this.planning_time);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.error_code);
            serializer.Write(this.sequence_start);
            serializer.WriteLength(this.planned_trajectories);
            serializer.Write(this.planned_trajectories);
            serializer.Write(this.planning_time);
        }

        public override string ToString()
        {
            return "MotionSequenceResponseMsg: " +
            "\nerror_code: " + error_code.ToString() +
            "\nsequence_start: " + sequence_start.ToString() +
            "\nplanned_trajectories: " + System.String.Join(", ", planned_trajectories.ToList()) +
            "\nplanning_time: " + planning_time.ToString();
        }

#if UNITY_EDITOR
        [UnityEditor.InitializeOnLoadMethod]
#else
        [UnityEngine.RuntimeInitializeOnLoadMethod]
#endif
        public static void Register()
        {
            MessageRegistry.Register(k_RosMessageName, Deserialize);
        }
    }
}