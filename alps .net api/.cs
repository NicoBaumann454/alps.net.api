using System;
using System.Collections.Generic;
using VDS.RDF;

namespace alps.net_api
{
    class PrecedenceSendTransition : AbstractPASSTransition
    {
        private IDataMappingLocalToOutgoing dataMappingLocalToOutgoing;
        private ISendTransitionCondition sendTransitionCondition;
        private IMessageExchangeCondition messageExchangeCondition;
        private string tmpMessageExchangeCondition;
        private string tmpDataMappingLocalToOutgoing;
        private string tmpSendTransitionCondition;
        /// <summary>
        /// Name of the class
        /// </summary>
        new public const string className = "PrecedenceSendTransition";

        /// <summary>
        /// Constructor that creates a new empty instance of the send transition class
        /// </summary>
        public PrecedenceSendTransition()
        {
            setModelComponentID("PrecedenceSendTransition");
            setComment("The standart Element for FinalSendTransition");
        }

        /// <summary>
        /// Constructor that creates a new fully specified instance of the send transition class
        /// </summary>
        /// <param name="additionalAttribute"></param>
        /// <param name="modelComponentID"></param>
        /// <param name="modelComponentLabel"></param>
        /// <param name="comment"></param>
        /// <param name="subjectBehavior"></param>
        /// <param name="belongsToaction"></param>
        /// <param name="sourceState"></param>
        /// <param name="targetState"></param>
        /// <param name="transitionCondition"></param>
        /// <param name="messageExchangeCondition"></param>
        /// <param name="dataMappingLocalToOutgoing"></param>
        /// <param name="sendTransitionCondition"></param>
        public PrecedenceSendTransition(List<string> additionalAttribute, string modelComponentID, List<string> modelComponentLabel, string comment, SubjectBehavior subjectBehavior, Action belongsToaction, State sourceState, State targetState, TransitionCondition transitionCondition, MessageExchangeCondition messageExchangeCondition, DataMappingLocalToOutgoing dataMappingLocalToOutgoing, SendTransitionCondition sendTransitionCondition)
        {
            setAdditionalAttribute(additionalAttribute);
            setModelComponentID(modelComponentID);
            setModelComponentLabel(modelComponentLabel);
            setComment(comment);
            setBelongsToSubjectBehavior(subjectBehavior);
            setBelongsToAction(belongsToaction);
            setSourceState(sourceState);
            setTargetState(targetState);
            setTransitionCondition(transitionCondition);
            setMessageExchangeCondition(messageExchangeCondition);
            setDataMappingFunctionLocalToOutgoing(dataMappingLocalToOutgoing);
            setSendTransitionCondition(sendTransitionCondition);

        }

        /// <summary>
        /// Method that sets the data mapping local to outgoing attribute of the instance
        /// </summary>
        /// <param name="dataMappingLocalToOutgoing"></param>
        public void setDataMappingFunctionLocalToOutgoing(IDataMappingLocalToOutgoing dataMappingLocalToOutgoing)
        {
            this.dataMappingLocalToOutgoing = dataMappingLocalToOutgoing;
        }

        /// <summary>
        /// Method that sets the send transition condition attribute of the instance
        /// </summary>
        /// <param name="sendTransitionCondition"></param>
        public void setSendTransitionCondition(ISendTransitionCondition sendTransitionCondition)
        {
            this.sendTransitionCondition = sendTransitionCondition;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getTmpDataMappingLocalToOutgoing()
        {
            return tmpDataMappingLocalToOutgoing;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getTmpSendTransitionCondition()
        {
            return tmpSendTransitionCondition;
        }

        /// <summary>
        /// Method that returns the data mapping local to outgoing attribute of the instance
        /// </summary>
        /// <returns>The data mapping local to outgoing attribute of the instance</returns>
        public IDataMappingLocalToOutgoing getDataMappingLocalToOutgoing()
        {
            return dataMappingLocalToOutgoing;
        }

        /// <summary>
        /// Method that returns the send transition condition attribute of the instance
        /// </summary>
        /// <returns>The send transition condition attribute of the instance</returns>
        public ISendTransitionCondition getSendTransitionCondition()
        {
            return sendTransitionCondition;
        }

        public void setMessageExchangeCondition(MessageExchangeCondition messageExchangeCondition)
        {
            this.messageExchangeCondition = messageExchangeCondition;
        }

        public IMessageExchangeCondition getMessageExchangeCondition()
        {
            return messageExchangeCondition;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="attributeType"></param>
        /// <returns></returns>
        public override bool createInstance(List<string> attribute, List<string> attributeType)
        {
            base.createInstance(attribute, attributeType);

            emptyAdditionalAttribute();

            bool result = false;
            int counter = 0;
            List<int> toBeRemoved = new List<int>();

            foreach (string s in attributeType)
            {

                if (s.Contains("hasDataMappingLocalToOutgoing"))
                {
                    tmpDataMappingLocalToOutgoing = attribute[counter];
                    toBeRemoved.Add(counter);
                }

                if (s.Contains("hasTransitionCondition"))
                {
                    tmpSendTransitionCondition = attribute[counter];
                    toBeRemoved.Add(counter);
                }

                if (s.Contains("hasTransitionCondition"))
                {
                    tmpMessageExchangeCondition = attribute[counter];
                    toBeRemoved.Add(counter);
                }

                counter++;
            }

            toBeRemoved.Sort();
            toBeRemoved.Reverse();

            foreach (int i in toBeRemoved)
            {

                attribute.RemoveAt(i);
                attributeType.RemoveAt(i);
            }

            setAdditionalAttribute(attribute);
            setAdditionalAttributeType(attributeType);

            return result;
        }

        /// <summary>
        /// Method that sets the Object Properties of the created Objects, it first takes the base Class to this and asks if the Object can take 
        /// </summary>
        /// <param name="allElements"></param>
        /// <param name="tmp"></param>
        /// 
        public override void completeObject(ref Dictionary<string, PASSProcessModelElement> allElements, ref List<string> tmp)
        {
            base.completeObject(ref allElements, ref tmp);

            foreach (string s in tmp)
            {

                if (allElements.ContainsKey(s))
                {
                    if (new DataMappingLocalToOutgoing().GetType().IsInstanceOfType(allElements[s]))
                    {
                        this.dataMappingLocalToOutgoing = (DataMappingLocalToOutgoing)allElements[s];
                        int place = getAdditionalAttribute().IndexOf(s);
                        getAdditionalAttributeType().RemoveAt(place);
                        getAdditionalAttribute().Remove(s);
                        //tmp.Remove(s);
                    }

                    if (new SendTransitionCondition().GetType().IsInstanceOfType(allElements[s]))
                    {
                        this.sendTransitionCondition = (SendTransitionCondition)allElements[s];
                        int place = getAdditionalAttribute().IndexOf(s);
                        getAdditionalAttributeType().RemoveAt(place);
                        getAdditionalAttribute().Remove(s);
                        //tmp.Remove(s);
                    }

                    if (new MessageExchangeCondition().GetType().IsInstanceOfType(allElements[s]))
                    {
                        this.messageExchangeCondition = (MessageExchangeCondition)allElements[s];
                        int place = getAdditionalAttribute().IndexOf(s);
                        getAdditionalAttributeType().RemoveAt(place);
                        getAdditionalAttribute().Remove(s);
                    }
                }
            }
        }

    }
}
