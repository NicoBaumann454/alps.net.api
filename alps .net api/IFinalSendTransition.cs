using System.Collections.Generic;

namespace alps.net_api
{
    interface IFinalSendTransition
    {
        /// <summary>
        /// Method that sets the data mapping local to outgoing attribute of the instance
        /// </summary>
        /// <param name="dataMappingLocalToOutgoing"></param>
        void setDataMappingFunctionLocalToOutgoing(IDataMappingLocalToOutgoing dataMappingLocalToOutgoing);

        /// <summary>
        /// Method that returns the data mapping local to outgoing attribute of the instance
        /// </summary>
        /// <returns>The data mapping local to outgoing attribute of the instance</returns>
        IDataMappingLocalToOutgoing getDataMappingLocalToOutgoing();

        /// <summary>
        /// Method that sets the send transition condition attribute of the instance
        /// </summary>
        /// <param name="sendTransitionCondition"></param>
        void setSendTransitionCondition(ISendTransitionCondition sendTransitionCondition);

        /// <summary>
        /// Method that returns the send transition condition attribute of the instance
        /// </summary>
        /// <returns>The send transition condition attribute of the instance</returns>
        ISendTransitionCondition getSendTransitionCondition();

        bool createInstance(List<string> attribute, List<string> attributeType);

        /// <summary>
        /// Method that sets the Object Properties of the created Objects, it first takes the base Class to this and asks if the Object can take 
        /// </summary>
        /// <param name="allElements"></param>
        /// <param name="tmp"></param>
        /// 
        void completeObject(ref Dictionary<string, PASSProcessModelElement> allElements, ref List<string> tmp);

    }
}
