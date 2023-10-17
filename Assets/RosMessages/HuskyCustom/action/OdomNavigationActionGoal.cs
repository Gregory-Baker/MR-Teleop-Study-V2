using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;
using RosMessageTypes.Std;
using RosMessageTypes.Actionlib;

namespace RosMessageTypes.HuskyCustom
{
    public class OdomNavigationActionGoal : ActionGoal<OdomNavigationGoal>
    {
        public const string k_RosMessageName = "husky_custom_actions/OdomNavigationActionGoal";
        public override string RosMessageName => k_RosMessageName;


        public OdomNavigationActionGoal() : base()
        {
            this.goal = new OdomNavigationGoal();
        }

        public OdomNavigationActionGoal(HeaderMsg header, GoalIDMsg goal_id, OdomNavigationGoal goal) : base(header, goal_id)
        {
            this.goal = goal;
        }
        public static OdomNavigationActionGoal Deserialize(MessageDeserializer deserializer) => new OdomNavigationActionGoal(deserializer);

        OdomNavigationActionGoal(MessageDeserializer deserializer) : base(deserializer)
        {
            this.goal = OdomNavigationGoal.Deserialize(deserializer);
        }
        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.header);
            serializer.Write(this.goal_id);
            serializer.Write(this.goal);
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
