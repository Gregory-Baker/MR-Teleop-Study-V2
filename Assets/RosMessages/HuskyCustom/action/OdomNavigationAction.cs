using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;


namespace RosMessageTypes.HuskyCustom
{
    public class OdomNavigationAction : Action<OdomNavigationActionGoal, OdomNavigationActionResult, OdomNavigationActionFeedback, OdomNavigationGoal, OdomNavigationResult, OdomNavigationFeedback>
    {
        public const string k_RosMessageName = "husky_custom_actions/OdomNavigationAction";
        public override string RosMessageName => k_RosMessageName;


        public OdomNavigationAction() : base()
        {
            this.action_goal = new OdomNavigationActionGoal();
            this.action_result = new OdomNavigationActionResult();
            this.action_feedback = new OdomNavigationActionFeedback();
        }

        public static OdomNavigationAction Deserialize(MessageDeserializer deserializer) => new OdomNavigationAction(deserializer);

        OdomNavigationAction(MessageDeserializer deserializer)
        {
            this.action_goal = OdomNavigationActionGoal.Deserialize(deserializer);
            this.action_result = OdomNavigationActionResult.Deserialize(deserializer);
            this.action_feedback = OdomNavigationActionFeedback.Deserialize(deserializer);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.action_goal);
            serializer.Write(this.action_result);
            serializer.Write(this.action_feedback);
        }

    }
}
