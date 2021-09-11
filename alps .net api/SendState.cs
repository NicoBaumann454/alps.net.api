using System;
using System.Collections.Generic;
using System.IO;
using VDS.RDF;

namespace alps.net_api
{
    /// <summary>
    /// Class that represents a send state
    /// </summary>
    public class SendState : StandartPASSState, ISendState
    {
        private ISendFunction sendFunction;
        private ISendTransition sendTransition;
        private Dictionary<string, ISendingFailedTransition> sendingFailedTransition = new Dictionary<string, ISendingFailedTransition>();
        private string tmpSendFunction;
        private string tmpSendTransition;
        private string tmpSendingFailedTransition;
        /// <summary>
        /// Name of the class
        /// </summary>
        new public const string className = "SendState";

        /// <summary>
        /// Constructor that creates a new empty instance of the send state class
        /// </summary>
        public SendState()
        {
            setModelComponentID("SendState");
            setComment("The standart Element for SendState");
        }

        /// <summary>
        /// Constructor that creates a new fully specified instance of the send state class
        /// </summary>
        /// <param name="additionalAttribute"></param>
        /// <param name="modelComponentID"></param>
        /// <param name="modelComponentLabel"></param>
        /// <param name="comment"></param>
        /// <param name="subjectBehavior"></param>
        /// <param name="incomingTransition"></param>
        /// <param name="outgoingTransition"></param>
        /// <param name="functionSpecification"></param>
        /// <param name="guardBehavior"></param>
        /// <param name="action"></param>
        /// <param name="receiveFunction"></param>
        /// <param name="sendTransition"></param>
        /// <param name="sendingFailedTransition"></param>
        public SendState(List<string> additionalAttribute, string modelComponentID, List<string> modelComponentLabel, string comment, SubjectBehavior subjectBehavior, Transition incomingTransition, Transition outgoingTransition, FunctionSpecification functionSpecification, GuardBehavior guardBehavior, Action action, ReceiveFunction receiveFunction, SendTransition sendTransition, SendingFailedTransition sendingFailedTransition)
        {
            setAdditionalAttribute(additionalAttribute);
            setModelComponentID(modelComponentID);
            setModelComponentLabel(modelComponentLabel);
            setComment(comment);
            setBelongsToSubjectBehavior(subjectBehavior);
            setIncomingTransition(incomingTransition);
            setOutgoingTransition(outgoingTransition);
            setFunctionSpecification(functionSpecification);
            setGuardBehavior(guardBehavior);
            setAction(action);
            setFunctionSpecification(receiveFunction);
            setSendTransition(sendTransition);
            setSendingFailedTransition(sendingFailedTransition);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="action"></param>
        /// <param name="guardBehavior"></param>
        /// <param name="functionSpecification"></param>
        /// <param name="incomingTransition"></param>
        /// <param name="outgoingTransition"></param>
        /// <param name="sendFunction"></param>
        /// <param name="sendTransition"></param>
        /// <param name="sendingFailedTransition"></param>
        /// <param name="additionalAttribute"></param>
        public SendState(string label, string comment = "", IAction action = null, IGuardBehavior guardBehavior = null, IFunctionSpecification functionSpecification = null, ITransition incomingTransition = null, ITransition outgoingTransition = null, ISendFunction sendFunction = null, ISendTransition sendTransition = null, Dictionary<string, ISendingFailedTransition> sendingFailedTransition = null, List<string> additionalAttribute = null) : base(label, comment, action, guardBehavior, functionSpecification, incomingTransition, outgoingTransition, additionalAttribute)
        {
            if (sendFunction != null)
            {
                this.sendFunction = sendFunction;
            }

            if (sendTransition != null)
            {
                this.sendTransition = sendTransition;
            }

            if (sendingFailedTransition != null)
            {
                this.sendingFailedTransition = sendingFailedTransition;
            }

        }

        /// <summary>
        /// Method that sets the send function attribute of the instance
        /// </summary>
        /// <param name="sendFunction"></param>
        public void setFunctionSpecification(ISendFunction sendFunction)
        {
            this.sendFunction = sendFunction;
        }

        /// <summary>
        /// Method that sets the send transition attribute of the instance
        /// </summary>
        /// <param name="sendTransition"></param>
        public void setSendTransition(ISendTransition sendTransition)
        {
            this.sendTransition = sendTransition;
        }

        /// <summary>
        /// Method that sets the sending failed transition attribute of the instance
        /// </summary>
        /// <param name="sendingFailedTransition"></param>
        public void setSendingFailedTransition(ISendingFailedTransition sendingFailedTransition)
        {
            this.sendingFailedTransition.Add(sendingFailedTransition.getModelComponentID(), sendingFailedTransition);
        }

        /// <summary>
        /// Method that returns the send function attribute of the instance
        /// </summary>
        /// <returns>The send function attribute of the instance</returns>
        public ISendFunction getSendFunction()
        {
            return sendFunction;
        }

        /// <summary>
        /// Method that sets the send transition attribute of the instance
        /// </summary>
        /// <returns>The send transition attribute of the instance</returns>
        public ISendTransition getSendTransition()
        {
            return sendTransition;
        }

        /// <summary>
        /// Method that sets the sending failed transition attribute of the instance
        /// </summary>
        /// <returns>The sending failed transition attribute of the instance</returns>
        public Dictionary<string, ISendingFailedTransition> getSendingFailedTransition()
        {
            return sendingFailedTransition;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getTmpSendFunction()
        {
            return tmpSendFunction;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getTmpSendTransition()
        {
            return tmpSendTransition;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getTmpSendingFailedTransition()
        {
            return tmpSendingFailedTransition;
        }

        /// <summary>
        /// Factory method that creates and returns a new empty instance of the send state class
        /// </summary>
        /// <returns>A new empty instance of the send state class</returns>
        new public SendState factoryMethod()
        {
            SendState sendState = new SendState();

            return sendState;
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

                if (s.Contains("hasSendFunction"))
                {
                    tmpSendFunction = attribute[counter];
                    toBeRemoved.Add(counter);
                }

                if (s.Contains("hasSendTransition"))
                {
                    tmpSendTransition = attribute[counter];
                    toBeRemoved.Add(counter);
                }

                if (s.Contains("hasSendingFailedTransition"))
                {
                    tmpSendingFailedTransition = attribute[counter];
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
                    if (new SendFunction().GetType().IsInstanceOfType(allElements[s]))
                    {
                        this.sendFunction = (SendFunction)allElements[s];
                        int place = getAdditionalAttribute().IndexOf(s);
                        getAdditionalAttributeType().RemoveAt(place);
                        getAdditionalAttribute().Remove(s);
                        //tmp.Remove(s);
                    }

                    if (new SendTransition().GetType().IsInstanceOfType(allElements[s]))
                    {
                        this.sendTransition = (SendTransition)allElements[s];
                        int place = getAdditionalAttribute().IndexOf(s);
                        getAdditionalAttributeType().RemoveAt(place);
                        getAdditionalAttribute().Remove(s);
                        //tmp.Remove(s);
                    }

                    if (new SendingFailedTransition().GetType().IsInstanceOfType(allElements[s]))
                    {
                        this.sendingFailedTransition.Add(allElements[s].getModelComponentID(), (SendingFailedTransition)allElements[s]);
                        int place = getAdditionalAttribute().IndexOf(s);
                        getAdditionalAttributeType().RemoveAt(place);
                        getAdditionalAttribute().Remove(s);
                        //tmp.Remove(s);
                    }
                }
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
                if (sendFunction != null)
                {
                    sw.WriteLine("      <standard-pass-ont:hasFunctionSpecification" + " rdf:resource=\"" + sendFunction.getModelComponentID() + "\" ></standard-pass-ont:hasFunctionSpecification>");
                }

                if (sendTransition != null)
                {
                    sw.WriteLine("      <standard-pass-ont:hasOutgoingTransition" + " rdf:resource=\"" + sendTransition.getModelComponentID() + "\" ></standard-pass-ont:hasOutgoingTransition>");
                }
                foreach (KeyValuePair<string, ISendingFailedTransition> i in sendingFailedTransition)
                {
                    if (i.Value != null)
                    {
                        sw.WriteLine("      <standard-pass-ont:hasOutgoingTransition" + " rdf:resource=\"" + i.Value.getModelComponentID() + "\" ></standard-pass-ont:hasOutgoingTransition>");
                    }
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
