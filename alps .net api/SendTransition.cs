using System;
using System.Collections.Generic;
using System.IO;
using VDS.RDF;

namespace alps.net_api
{
    /// <summary>
    /// Class that represents a send transition
    /// </summary>
    public class SendTransition : CommunicationTransition, ISendTransition
    {
        private IDataMappingLocalToOutgoing dataMappingLocalToOutgoing;
        private ISendTransitionCondition sendTransitionCondition;
        private string tmpDataMappingLocalToOutgoing;
        private string tmpSendTransitionCondition;
        /// <summary>
        /// Name of the class
        /// </summary>
        new public const string className = "SendTransition";

        /// <summary>
        /// Constructor that creates a new empty instance of the send transition class
        /// </summary>
        public SendTransition()
        {
            setModelComponentID("SendTransition");
            setComment("The standart Element for SendTransition");
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
        public SendTransition(List<string> additionalAttribute, string modelComponentID, List<string> modelComponentLabel, string comment, SubjectBehavior subjectBehavior, Action belongsToaction, State sourceState, State targetState, TransitionCondition transitionCondition, MessageExchangeCondition messageExchangeCondition, DataMappingLocalToOutgoing dataMappingLocalToOutgoing, SendTransitionCondition sendTransitionCondition)
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
        /// Constructor that creates a new fully specified instance of the send transition class
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="action"></param>
        /// <param name="sourceState"></param>
        /// <param name="targetState"></param>
        /// <param name="transitionCondition"></param>
        /// <param name="messageExchangeCondition"></param>
        /// <param name="dataMappingLocalToOutgoing"></param>
        /// <param name="sendTransitionCondition"></param>
        /// <param name="TransitionType"></param>
        /// <param name="additionalAttribute"></param>
        public SendTransition(string label, string comment = "", IAction action = null, IState sourceState = null, IState targetState = null, ITransitionCondition transitionCondition = null, IMessageExchangeCondition messageExchangeCondition = null, IDataMappingLocalToOutgoing dataMappingLocalToOutgoing = null, ISendTransitionCondition sendTransitionCondition = null, transitionType TransitionType = transitionType.Standard, List<string> additionalAttribute = null) : base(label, comment, action, sourceState, targetState, transitionCondition, messageExchangeCondition, TransitionType, additionalAttribute)
        {
            if (dataMappingLocalToOutgoing != null)
            {
                this.dataMappingLocalToOutgoing = dataMappingLocalToOutgoing;
            }

            if (sendTransitionCondition != null)
            {
                this.sendTransitionCondition = sendTransitionCondition;
            }

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
                    if (new DataMappingLocalToOutgoing().GetType().IsInstanceOfType(allElements[s]) && getAdditionalAttributeType()[getAdditionalAttribute().IndexOf(s)].Contains("DataMappingFunction"))
                    {
                        this.dataMappingLocalToOutgoing = (DataMappingLocalToOutgoing)allElements[s];
                        int place = getAdditionalAttribute().IndexOf(s);
                        getAdditionalAttributeType().RemoveAt(place);
                        getAdditionalAttribute().Remove(s);
                        //tmp.Remove(s);
                    }

                    if (new SendTransitionCondition().GetType().IsInstanceOfType(allElements[s]) && getAdditionalAttributeType()[getAdditionalAttribute().IndexOf(s)].Contains("TransitionCondition"))
                    {
                        this.sendTransitionCondition = (SendTransitionCondition)allElements[s];
                        int place = getAdditionalAttribute().IndexOf(s);
                        if (place >= 0)
                        {
                            getAdditionalAttributeType().RemoveAt(place);
                            getAdditionalAttribute().Remove(s);
                        }

                        //tmp.Remove(s);
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="g"></param>
        public override void export(ref Graph g)
        {
            base.export(ref g);
            //Graph g = new Graph();
            INode subject;
            INode predicate;
            INode objec;
            Triple test;

            string nameString = getModelComponentID();

            Uri name = new Uri(nameString);
            //Console.WriteLine(name);
            //Console.WriteLine();

            if (this.dataMappingLocalToOutgoing != null)
            {
                subject = g.CreateUriNode(name);
                predicate = g.CreateUriNode("rdf:hasDataMappingLocalToOutgoing");
                objec = g.CreateUriNode("standard-pass-ont:" + this.dataMappingLocalToOutgoing.getModelComponentID());

                test = new Triple(subject, predicate, objec);
                g.Assert(test);

                //Console.WriteLine(name + "  " + "http://www.w3.org/1999/02/22-rdf-syntax-ns#type" + "  " + "http://www.w3.org/2002/07/owl#NamedIndividual");
            }

            if (this.sendTransitionCondition != null)
            {
                subject = g.CreateUriNode(name);
                predicate = g.CreateUriNode("rdf:hasSendTransitionCondition");
                objec = g.CreateUriNode("standard-pass-ont:" + sendTransitionCondition.getModelComponentID());

                test = new Triple(subject, predicate, objec);
                g.Assert(test);

                //Console.WriteLine(name + "  " + "http://www.w3.org/1999/02/22-rdf-syntax-ns#type" + "  " + "http://www.w3.org/2002/07/owl#NamedIndividual");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="last"></param>
        /// <param name="filename"></param>
        public override void exporting(bool last, string filename)
        {
            base.exporting(false, filename);

            using (StreamWriter sw = File.AppendText("../../../../" + filename + ".owl"))
            {
                if (dataMappingLocalToOutgoing != null)
                {
                    sw.WriteLine("      <standard-pass-ont:hasDataMappingFunction" + " rdf:resource=\"" + dataMappingLocalToOutgoing.getModelComponentID() + "\" ></standard-pass-ont:hasDataMappingFunction>");
                }

                if (sendTransitionCondition != null)
                {
                    sw.WriteLine("      <standard-pass-ont:hasTransitionCondition" + " rdf:resource=\"" + sendTransitionCondition.getModelComponentID() + "\" ></standard-pass-ont:hasTransitionCondition>");
                }

                if (last)
                {
                    sw.WriteLine("      <rdf:type rdf:resource=" + "\"&standard-pass-ont;" + this.GetType().ToString().Split('.')[2] + "\" ></rdf:type>");
                    sw.WriteLine("  </owl:NamedIndividual>");
                }
            }
        }
    }
}