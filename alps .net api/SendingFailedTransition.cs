using System;
using System.Collections.Generic;
using System.IO;
using VDS.RDF;

namespace alps.net_api
{
    /// <summary>
    /// Class that represents a sending failed transition 
    /// </summary>
    public class SendingFailedTransition : Transition, ISendingFailedTransition
    {
        private ISendState sourceState;
        private ISendingFailedCondition sendingFailedCondition;
        private string tmpSourceState;
        private string tmpSendingFailedCondition;
        /// <summary>
        /// Name of the class
        /// </summary>
        new public const string className = "SendingFailedTransition";

        /// <summary>
        /// Constructor that creates a new empty instance of the sending failed transition class
        /// </summary>
        public SendingFailedTransition()
        {
            setModelComponentID("SendingFailedTransition");
            setComment("The standart Element for SendingFailedTransition");
        }

        /// <summary>
        /// Constructor that creates a new fully specified instance of the sending failed transition class
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
        /// <param name="sendState"></param>
        /// <param name="sendingFailedCondition"></param>
        public SendingFailedTransition(List<string> additionalAttribute, string modelComponentID, List<string> modelComponentLabel, string comment, SubjectBehavior subjectBehavior, Action belongsToaction, State sourceState, State targetState, TransitionCondition transitionCondition, SendState sendState, SendingFailedCondition sendingFailedCondition)
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
            setSourceState(sourceState);
            setTransitionCondition(sendingFailedCondition);

        }

        /// <summary>
        /// Constructor that creates a new fully specified instance of the sending failed transition class
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="action"></param>
        /// <param name="sourceState"></param>
        /// <param name="targetState"></param>
        /// <param name="transitionCondition"></param>
        /// <param name="sendState"></param>
        /// <param name="sendingFailedCondition"></param>
        /// <param name="TransitionType"></param>
        /// <param name="additionalAttribute"></param>
        public SendingFailedTransition(string label, string comment = "", IAction action = null, IState sourceState = null, IState targetState = null, ITransitionCondition transitionCondition = null, ISendState sendState = null, ISendingFailedCondition sendingFailedCondition = null, transitionType TransitionType = transitionType.Standard, List<string> additionalAttribute = null) : base(label, comment, action, sourceState, targetState, transitionCondition, TransitionType, additionalAttribute)
        {
            if (sendState != null)
            {
                this.sourceState = sendState;
            }

            if (sendingFailedCondition != null)
            {
                this.sendingFailedCondition = sendingFailedCondition;
            }
        }

        /// <summary>
        /// Method that sets the send state attribute of the instance
        /// </summary>
        /// <param name="sendState"></param>
        public void setSourceState(ISendState sendState)
        {
            this.sourceState = sendState;
        }

        /// <summary>
        /// Method that sets the sending failed condition attribute of the instance
        /// </summary>
        /// <param name="sendingFailedCondition"></param>
        public void setTransitionCondition(ISendingFailedCondition sendingFailedCondition)
        {
            this.sendingFailedCondition = sendingFailedCondition;
        }

        /// <summary>
        /// Method that returns the send state attribute of the instance
        /// </summary>
        /// <returns>The send state attribute of the instance</returns>
        public ISendState getSourceSendState()
        {
            return sourceState;
        }

        /// <summary>
        ///  Method that returns the sending failed condition attribute of the instance
        /// </summary>
        /// <returns>The sending failed condition attribute of the instance</returns>
        public ISendingFailedCondition getSendingFailedCondition()
        {
            return sendingFailedCondition;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        new public string getTmpSourceState()
        {
            return tmpSourceState;
        }

        /// <summary>
        /// 
        /// </summary>
        public string getTmpSendingFailedCondition()
        {
            return tmpSendingFailedCondition;
        }

        /// <summary>
        /// Factory method that creates and returns a new empty instance of the sending failed transition class
        /// </summary>
        /// <returns>A new empty instance of the sending failed transition class</returns>
        new public SendingFailedTransition factoryMethod()
        {
            SendingFailedTransition sendingFailedTransition = new SendingFailedTransition();

            return sendingFailedTransition;
        }

        /// <summary>
        /// Method that creates an new empty instance of the sending failed transition class
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="attributeType"></param>
        /// <returns></returns>
        public override bool createInstance(List<string> attribute, List<string> attributeType)
        {
            base.createInstance(attribute, attributeType);
            bool result = false;
            List<int> toBeRemoved = new List<int>();

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
                    if (new SendingFailedCondition().GetType().IsInstanceOfType(allElements[s]))
                    {
                        this.sendingFailedCondition = (SendingFailedCondition)allElements[s];
                        int place = getAdditionalAttribute().IndexOf(s);
                        getAdditionalAttributeType().RemoveAt(place);
                        getAdditionalAttribute().Remove(s);
                        //tmp.Remove(s);
                    }

                    if (new SendState().GetType().IsInstanceOfType(allElements[s]))
                    {
                        this.sourceState = (SendState)allElements[s];
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
                if (sourceState != null)
                {
                    sw.WriteLine("      <standard-pass-ont:hasSourceState" + " rdf:resource=\"" + sourceState.getModelComponentID() + "\" ></standard-pass-ont:hasSourceState>");
                }

                if (sendingFailedCondition != null)
                {
                    sw.WriteLine("      <standard-pass-ont:hasTransitionCondition" + " rdf:resource=\"" + sendingFailedCondition.getModelComponentID() + "\" ></standard-pass-ont:hasTransitionCondition>");
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
