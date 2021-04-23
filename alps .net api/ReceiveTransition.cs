using System;
using System.Collections.Generic;
using System.IO;
using VDS.RDF;

namespace alps.net_api
{
    /// <summary>
    /// Class that represents a receive transition
    /// </summary>
    public class ReceiveTransition : CommunicationTransition, IReceiveTransition
    {
        private IDataMappingIncomingToLocal dataMappingIncomingToLocal;
        private int priorityNumber = 0;
        private IReceiveTransitionCondition receiveTransitionCondition;
        private string tmpDataMappingIncomingToLocal;
        private string tmpPriorityNumber;
        private string tmpReceiveTransitionCondition;
        /// <summary>
        /// Name of the class
        /// </summary>
        new public const string className = "ReceiveTransition";

        /// <summary>
        /// Constructor that creates a new empty instance of the receive transition class 
        /// </summary>
        public ReceiveTransition()
        {
            setModelComponentID("ReceiveTransition");
            setComment("The standart Element for ReceiveTransition");
        }

        /// <summary>
        /// Constructor that creates a new fully specified instance of the receive transition class
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
        public ReceiveTransition(List<string> additionalAttribute, string modelComponentID, List<string> modelComponentLabel, string comment, SubjectBehavior subjectBehavior, Action belongsToaction, State sourceState, State targetState, TransitionCondition transitionCondition, MessageExchangeCondition messageExchangeCondition, DataMappingIncomingToLocal dataMappingIncomingToLocal, int priorityNumber, ReceiveTransitionCondition receiveTransitionCondition)
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
        /// Constructor that creates a new fully specified instance of the receive transition class
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="action"></param>
        /// <param name="sourceState"></param>
        /// <param name="targetState"></param>
        /// <param name="transitionCondition"></param>
        /// <param name="messageExchangeCondition"></param>
        /// <param name="dataMappingIncomingToLocal"></param>
        /// <param name="priorityNumber"></param>
        /// <param name="receiveTransitionCondition"></param>
        /// <param name="TransitionType"></param>
        /// <param name="additionalAttribute"></param>
        public ReceiveTransition(string label, string comment = "", IAction action = null, IState sourceState = null, IState targetState = null, ITransitionCondition transitionCondition = null, IMessageExchangeCondition messageExchangeCondition = null, IDataMappingIncomingToLocal dataMappingIncomingToLocal = null, int priorityNumber = 0, IReceiveTransitionCondition receiveTransitionCondition = null, transitionType TransitionType = transitionType.Standard, List<string> additionalAttribute = null) : base(label, comment, action, sourceState, targetState, transitionCondition, messageExchangeCondition, TransitionType, additionalAttribute)
        {
            if (dataMappingIncomingToLocal != null)
            {
                this.dataMappingIncomingToLocal = dataMappingIncomingToLocal;
            }

            if (receiveTransitionCondition != null)
            {
                this.receiveTransitionCondition = receiveTransitionCondition;
            }

            this.priorityNumber = priorityNumber;
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

        /// <summary>
        /// Factory method that creates and returns a new empty instance of the receive transition class
        /// </summary>
        /// <returns>A new empty instance of the receive transition class</returns>
        new public ReceiveTransition factoryMethod()
        {
            ReceiveTransition receiveTransition = new ReceiveTransition();

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
                    tmpPriorityNumber = tmpPriorityNumber.Split('^')[0];
                    priorityNumber = Int32.Parse(tmpPriorityNumber);
                    toBeRemoved.Add(counter);
                }

                if (s.Contains("hasTransitionCondition"))
                {
                    tmpReceiveTransitionCondition = attribute[counter];
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
                        if (place >= 0)
                        {
                            getAdditionalAttributeType().RemoveAt(place);
                            getAdditionalAttribute().Remove(s);
                        }
                        //tmp.Remove(s);
                    }

                    if (new ReceiveTransitionCondition().GetType().IsInstanceOfType(allElements[s]))
                    {
                        this.receiveTransitionCondition = (ReceiveTransitionCondition)allElements[s];
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

            if (dataMappingIncomingToLocal != null)
            {
                subject = g.CreateUriNode(name);
                predicate = g.CreateUriNode("rdf:hasDataMappingIncomingToLocal");
                objec = g.CreateUriNode("standard-pass-ont:" + dataMappingIncomingToLocal.getModelComponentID());

                test = new Triple(subject, predicate, objec);
                g.Assert(test);

                //Console.WriteLine(name + "  " + "http://www.w3.org/1999/02/22-rdf-syntax-ns#type" + "  " + "http://www.w3.org/2002/07/owl#NamedIndividual");
            }

            if (this.receiveTransitionCondition != null)
            {
                subject = g.CreateUriNode(name);
                predicate = g.CreateUriNode("rdf:hasReceiveTransitionCondition");
                objec = g.CreateUriNode("standard-pass-ont:" + this.receiveTransitionCondition.getModelComponentID());

                test = new Triple(subject, predicate, objec);
                //Console.WriteLine(test.Subject.ToString() + " " + test.Predicate.ToString() + " " + test.Object.ToString());
                g.Assert(test);

            }

            if (priorityNumber >= 0)
            {
                subject = g.CreateUriNode(name);
                predicate = g.CreateUriNode("rdf:hasPriorityNumber");
                objec = g.CreateUriNode("standard-pass-ont:" + priorityNumber);

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

                if (dataMappingIncomingToLocal != null)
                {
                    sw.WriteLine("      <standard-pass-ont:hasDataMappingFunction" + " rdf:resource=\"" + dataMappingIncomingToLocal.getModelComponentID() + "\" ></standard-pass-ont:hasDataMappingFunction>");
                }

                if (priorityNumber > -1)
                {
                    sw.WriteLine("      <standard-pass-ont:hasPriorityNumber rdf:datatype=\"http://www.w3.org/2001/XMLSchema#positiveInteger\" >" + priorityNumber + "</standard-pass-ont:hasPriorityNumber>");
                }

                if (receiveTransitionCondition != null)
                {
                    sw.WriteLine("      <standard-pass-ont:hasTransitionCondition" + " rdf:resource=\"" + receiveTransitionCondition.getModelComponentID() + "\" ></standard-pass-ont:hasTransitionCondition>");
                }

                if (last)
                {
                    sw.WriteLine("      <rdf:type rdf:resource=" + "\"&standard-pass-ont;" + this.GetType().ToString().Split('.')[2] + "\" ></rdf:type>");
                    sw.WriteLine("  </owl:NamedIndividual>");
                }
            }
        }

        /// <summary>
        /// Retruns all string attributes which are not yet set with Objects
        /// </summary>
        /// <returns></returns>
        public List<string> getAllStringAttributes()
        {
            List<string> stringAttributes = new List<string>();
            stringAttributes.Add(tmpDataMappingIncomingToLocal);
            stringAttributes.Add(tmpReceiveTransitionCondition);
            stringAttributes.Add(getTmpBelonstToAction());
            stringAttributes.Add(getTmpSourceState());
            stringAttributes.Add(getTmpTargetState());
            stringAttributes.Add(getTmpTransitionCondition());
            stringAttributes.Add(getTmpMessageExchangeCondition());
            stringAttributes.Add(getTmpSubjectBehavior());

            return stringAttributes;
        }
    }
}