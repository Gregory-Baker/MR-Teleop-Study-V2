using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;
using RosMessageTypes.Std;
using RosMessageTypes.Actionlib;

namespace RosMessageTypes.HuskyCustom
{
    public class TurnAngleActionResult : ActionResult<TurnAngleResult>
    {
        public const string k_RosMessageName = "husky_custom_actions/TurnAngleActionResult";
        public override string RosMessageName => k_RosMessageName;


        public TurnAngleActionResult() : base()
        {
            this.result = new TurnAngleResult();
        }

        public TurnAngleActionResult(HeaderMsg header, GoalStatusMsg status, TurnAngleResult result) : base(header, status)
        {
            this.result = result;
        }
        public static TurnAngleActionResult Deserialize(MessageDeserializer deserializer) => new TurnAngleActionResult(deserializer);

        TurnAngleActionResult(MessageDeserializer deserializer) : base(deserializer)
        {
            this.result = TurnAngleResult.Deserialize(deserializer);
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
