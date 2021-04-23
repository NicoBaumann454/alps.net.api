using System.Collections.Generic;

namespace alps.net_api
{
    class TriggerReceiveTransition : AbstractPASSTransition, ITriggerReceiveTransition
    {
        private IDataMappingIncomingToLocal dataMappingIncomingToLocal;
        private int priorityNumber;
        private IReceiveTransitionCondition receiveTransitionCondition;
        private IMessageExchangeCondition messageExchangeCondition;
        private string tmpMessageExchangeCondition;
        private string tmpDataMappingIncomingToLocal;
        private string tmpPriorityNumber;
        private string tmpReceiveTransitionCondition;
        /// <summary>
        /// Name of the class
        /// </summary>
        new public const string className = "TriggerReceiveTransition";

        /// <summary>
        /// Constructor that creates a new empty instance of the Trigger receive transition class 
        /// </summary>
        public TriggerReceiveTransition()
        {
            setModelComponentID("TriggerReceiveTransition");
            setComment("The standart Element for TriggerReceiveTransition");
        }

        /// <summary>
        /// Constructor that creates a new fully specified instance of the Trigger receive transition class
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
        /// <param name="dataMappingIncomingToLocal"></param>
        /// <param name="priorityNumber"></param>
        /// <param name="receiveTransitionCondition"></param>
        public TriggerReceiveTransition(List<string> additionalAttribute, string modelComponentID, List<string> modelComponentLabel, string comment, SubjectBehavior subjectBehavior, Action belongsToaction, State sourceState, State targetState, TransitionCondition transitionCondition, MessageExchangeCondition messageExchangeCondition, DataMappingIncomingToLocal dataMappingIncomingToLocal, int priorityNumber, ReceiveTransitionCondition receiveTransitionCondition)
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
            setDataMappingFunctionIncomingToLocal(dataMappingIncomingToLocal);
            setPriorityNumber(priorityNumber);
            setReceiveTransitionCondition(receiveTransitionCondition);
        }

        /// <summary>
        /// Method that sets the data mapping incoming to local attribute of the instance
        /// </summary>
        /// <param name="dataMappingIncomingToLocal"></param>
        public void setDataMappingFunctionIncomingToLocal(IDataMappingIncomingToLocal dataMappingIncomingToLocal)
        {
            this.dataMappingIncomingToLocal = dataMappingIncomingToLocal;
        }

        /// <summary>
        /// Method that sets the priority number attribute of the instance
        /// </summary>
        /// <param name="nonNegativInteger"></param>
        public void setPriorityNumber(int nonNegativInteger)
        {
            this.priorityNumber = nonNegativInteger;
        }

        /// <summary>
        /// Method that sets the receiver transition condition attribute of the instance
        /// </summary>
        /// <param name="receiveTransitionCondition"></param>
        public void setReceiveTransitionCondition(IReceiveTransitionCondition receiveTransitionCondition)
        {
            this.receiveTransitionCondition = receiveTransitionCondition;
        }

        /// <summary>
        /// Method that returns the data mapping incoming to local attribute of the instance
        /// </summary>
        /// <returns>The data mapping incoming to local attribute of the instance</returns>
        public IDataMappingIncomingToLocal getDataMappingIncomingToLocal()
        {
            return dataMappingIncomingToLocal;
        }

        /// <summary>
        /// Method that returns the priority number attribute of the instance
        /// </summary>
        /// <returns>The priority number attribute of the instance</returns>
        public int getPriorityNumber()
        {
            return priorityNumber;
        }

        /// <summary>
        /// Method that returns the receive transition condition attribute of the instance
        /// </summary>
        /// <returns>The receive transition condition attribute of the instance</returns>
        public IReceiveTransitionCondition getReceiveTransitionCondition()
        {
            return receiveTransitionCondition;
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
        /// Factory method that creates and returns a new empty instance of the receive transition class
        /// </summary>
        /// <returns>A new empty instance of the receive transition class</returns>
        new public FinalReceiveTransition factoryMethod()
        {
            FinalReceiveTransition receiveTransition = new FinalReceiveTransition();

            return receiveTransition;
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

                if (s.Contains("hasDataMappingIncomingToLocal"))
                {
                    tmpDataMappingIncomingToLocal = attribute[counter];
                    toBeRemoved.Add(counter);
                }

                if (s.Contains("hasPriorityNumber"))
                {
                    tmpPriorityNumber = attribute[counter];
                    toBeRemoved.Add(counter);
                }

                if (s.Contains("hasTransitionCondition"))
                {
                    tmpReceiveTransitionCondition = attribute[counter];
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
                    if (new DataMappingIncomingToLocal().GetType().IsInstanceOfType(allElements[s]))
                    {
                        this.dataMappingIncomingToLocal = (DataMappingIncomingToLocal)allElements[s];
                        int place = getAdditionalAttribute().IndexOf(s);
                        getAdditionalAttributeType().RemoveAt(place);
                        getAdditionalAttribute().Remove(s);
                        //tmp.Remove(s);
                    }

                    if (new ReceiveTransitionCondition().GetType().IsInstanceOfType(allElements[s]))
                    {
                        this.receiveTransitionCondition = (ReceiveTransitionCondition)allElements[s];
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
