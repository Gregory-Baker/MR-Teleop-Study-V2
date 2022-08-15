using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;
using RosMessageTypes.Std;
using RosMessageTypes.Actionlib;

namespace RosMessageTypes.KinovaCustom
{
    public class OdomNavigationActionFeedback : ActionFeedback<OdomNavigationFeedback>
    {
        public const string k_RosMessageName = "kinova_custom_actions/OdomNavigationActionFeedback";
        public override string RosMessageName => k_RosMessageName;


        public OdomNavigationActionFeedback() : base()
        {
            this.feedback = new OdomNavigationFeedback();
        }

        public OdomNavigationActionFeedback(HeaderMsg header, GoalStatusMsg status, OdomNavigationFeedback feedback) : base(header, status)
        {
            this.feedback = feedback;
        }
        public static OdomNavigationActionFeedback Deserialize(MessageDeserializer deserializer) => new OdomNavigationActionFeedback(deserializer);

        OdomNavigationActionFeedback(MessageDeserializer deserializer) : base(deserializer)
        {
            this.feedback = OdomNavigationFeedback.Deserialize(deserializer);
        }
        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.header);
            serializer.Write(this.status);
            serializer.Write(this.feedback);
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
