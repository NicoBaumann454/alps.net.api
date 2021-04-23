using System;
using System.Collections.Generic;
using System.IO;
using VDS.RDF;

namespace alps.net_api
{
    /// <summary>
    /// Class that represents a communication transition
    /// </summary>
    public class CommunicationTransition : Transition, ICommunicationTransition
    {
        private IMessageExchangeCondition messageExchangeCondition;
        private string tmpMessageExchangeCondition;
        /// <summary>
        /// The name of the class
        /// </summary>
        new public static string className = "CommunicationTransition";

        /// <summary>
        /// Constructor that creates a empty instance of the communication transition class
        /// </summary>
        public CommunicationTransition()
        {
            setModelComponentID("CommunicationTransition");
            setComment("The standart Element for CommunicationTransition");
        }

        /// <summary>
        /// Constructor that creates a new fully specified instance of the communication transition class
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
        public CommunicationTransition(List<string> additionalAttribute, string modelComponentID, List<string> modelComponentLabel, string comment, SubjectBehavior subjectBehavior, Action belongsToaction, State sourceState, State targetState, TransitionCondition transitionCondition, MessageExchangeCondition messageExchangeCondition)
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

        }

        /// <summary>
        /// Constructor that creates a new fully specified instance of the communication transition
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="action"></param>
        /// <param name="sourceState"></param>
        /// <param name="targetState"></param>
        /// <param name="transitionCondition"></param>
        /// <param name="messageExchangeCondition"></param>
        /// <param name="TransitionType"></param>
        /// <param name="additionalAttribute"></param>
        public CommunicationTransition(string label, string comment = "", IAction action = null, IState sourceState = null, IState targetState = null, ITransitionCondition transitionCondition = null, IMessageExchangeCondition messageExchangeCondition = null, transitionType TransitionType = transitionType.Standard, List<string> additionalAttribute = null) : base(label, comment, action, sourceState, targetState, transitionCondition, TransitionType, additionalAttribute)
        {
            if (messageExchangeCondition != null)
            {
                this.messageExchangeCondition = messageExchangeCondition;
            }
        }

        /// <summary>
        /// Method that sets the message exchange condition attribute
        /// </summary>
        /// <param name="messageExchangeCondition"></param>
        public void setMessageExchangeCondition(IMessageExchangeCondition messageExchangeCondition)
        {
            this.messageExchangeCondition = messageExchangeCondition;
        }

        /// <summary>
        /// Method that returns the message exchange condition attribute
        /// </summary>
        /// <returns>The message exchange condition attribute</returns>
        public IMessageExchangeCondition getMessageExchangeCondition()
        {
            return messageExchangeCondition;
        }

        /// <summary>
        /// Factory Method that creates a new empty instance of the communication transition class
        /// </summary>
        /// <returns>A new empty instance of the communication transition class</returns>
        new public CommunicationTransition factoryMethod()
        {
            CommunicationTransition communicationTransition = new CommunicationTransition();

            return communicationTransition;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getTmpMessageExchangeCondition()
        {
            return tmpMessageExchangeCondition;
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
                    if (new MessageExchangeCondition().GetType().IsInstanceOfType(allElements[s]) && getAdditionalAttributeType()[getAdditionalAttribute().IndexOf(s)].Contains("MessageExchangeCondition"))
                    {
                        this.messageExchangeCondition = (MessageExchangeCondition)allElements[s];
                        int place = getAdditionalAttribute().IndexOf(s);
                        getAdditionalAttributeType().RemoveAt(place);
                        getAdditionalAttribute().Remove(s);
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

            if (messageExchangeCondition != null)
            {
                subject = g.CreateUriNode(name);
                predicate = g.CreateUriNode("rdf:belongsToMessage");
                objec = g.CreateUriNode("standard-pass-ont:" + messageExchangeCondition.getModelComponentID());

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

                if (messageExchangeCondition != null)
                {
                    sw.WriteLine("      <standard-pass-ont:hasMessageExchangeCondition" + " rdf:resource=\"" + messageExchangeCondition.getModelComponentID() + "\" ></standard-pass-ont:hasMessageExchangeCondition>");
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