using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;
using RosMessageTypes.Std;
using RosMessageTypes.Actionlib;

namespace RosMessageTypes.KinovaCustom
{
    public class OdomNavigationActionResult : ActionResult<OdomNavigationResult>
    {
        public const string k_RosMessageName = "kinova_custom_actions/OdomNavigationActionResult";
        public override string RosMessageName => k_RosMessageName;


        public OdomNavigationActionResult() : base()
        {
            this.result = new OdomNavigationResult();
        }

        public OdomNavigationActionResult(HeaderMsg header, GoalStatusMsg status, OdomNavigationResult result) : base(header, status)
        {
            this.result = result;
        }
        public static OdomNavigationActionResult Deserialize(MessageDeserializer deserializer) => new OdomNavigationActionResult(deserializer);

        OdomNavigationActionResult(MessageDeserializer deserializer) : base(deserializer)
        {
            this.result = OdomNavigationResult.Deserialize(deserializer);
        }
        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.header);
            serializer.Write(this.status);
            serializer.Write(this.result);
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
