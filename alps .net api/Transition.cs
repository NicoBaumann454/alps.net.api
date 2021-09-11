using System;
using System.Collections.Generic;
using System.IO;
using VDS.RDF;

namespace alps.net_api
{
    /// <summary>
    /// Class that represents a transition class
    /// </summary>
    public class Transition : BehaviorDescriptionComponent, ITransition
    {
        private IAction belongsToAction;
        private IState sourceState;
        private IState targetState;
        private ITransitionCondition transitionCondition;
        private string tmpBelonstToAction;
        private string tmpSourceState;
        private string tmpTargetState;
        private string tmpTransitionCondition;

        /// <summary>
        /// enum which describes all the possible states a transition can have
        /// </summary>
        public enum transitionType
        {
            /// <summary>
            /// Standart transition type (if no further specification is give, all transitions are standart)
            /// </summary>
            Standard,
            /// <summary>
            /// Finalized transition type
            /// </summary>
            Finalized,
            /// <summary>
            /// Precedence transition type
            /// </summary>
            Precedence,
            /// <summary>
            /// Trigger transition type
            /// </summary>
            Trigger,
            /// <summary>
            /// Advice transition type
            /// </summary>
            Advice
        }

        private transitionType TransitionType;

        /// <summary>
        /// Name of the class
        /// </summary>
        new public const string className = "Transition";

        /// <summary>
        /// Constructor that creates a new empty instance of the transition class
        /// </summary>
        public Transition()
        {
            setModelComponentID("Transition");
            setComment("The standart Element for Transition");
        }

        /// <summary>
        /// Constructor that creates a new fully specified instance of the transition class
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
        public Transition(List<string> additionalAttribute, string modelComponentID, List<string> modelComponentLabel, string comment, SubjectBehavior subjectBehavior, Action belongsToaction, State sourceState, State targetState, TransitionCondition transitionCondition)
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
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="action"></param>
        /// <param name="sourceState"></param>
        /// <param name="targetState"></param>
        /// <param name="transitionCondition"></param>
        /// <param name="additionalAttribute"></param>
        /// <param name="TransitionType"></param>
        public Transition(string label, string comment = "", IAction action = null, IState sourceState = null, IState targetState = null, ITransitionCondition transitionCondition = null, transitionType TransitionType = transitionType.Standard, List<string> additionalAttribute = null) : base(label, comment, additionalAttribute)
        {
            if (action != null)
            {
                this.belongsToAction = action;
            }

            if (targetState != null)
            {
                this.targetState = targetState;
            }

            if (sourceState != null)
            {
                this.sourceState = sourceState;
            }

            if (transitionCondition != null)
            {
                this.transitionCondition = transitionCondition;
            }

            this.TransitionType = TransitionType;
        }

        /// <summary>
        /// Method that sets the action attribute of the instance
        /// </summary>
        /// <param name="action"></param>
        public void setBelongsToAction(IAction action)
        {
            this.belongsToAction = action;
        }

        /// <summary>
        /// Method that sets the source state attribute of the instance
        /// </summary>
        /// <param name="sourceState"></param>
        public void setSourceState(IState sourceState)
        {
            this.sourceState = sourceState;
        }

        /// <summary>
        /// Method that sets the target state attribute of the instance
        /// </summary>
        /// <param name="targetState"></param>
        public void setTargetState(IState targetState)
        {
            this.targetState = targetState;
        }

        /// <summary>
        /// Method that sets the transition condition attribute of the instance
        /// </summary>
        /// <param name="transitionCondition"></param>
        public void setTransitionCondition(ITransitionCondition transitionCondition)
        {
            this.transitionCondition = transitionCondition;
        }

        /// <summary>
        /// Method that returns the action attribute of the instance
        /// </summary>
        /// <returns>The action attribute of the instance</returns>
        public IAction getBelongsToAction()
        {
            return belongsToAction;
        }

        /// <summary>
        /// Method that returns the source state attribute of the instance
        /// </summary>
        /// <returns>The source state attribute of the instance</returns>
        public IState getSourceState()
        {
            return sourceState;
        }

        /// <summary>
        /// Method that returns the target action attribute of the instance
        /// </summary>
        /// <returns>The target action attribute of the instance</returns>
        public IState getTargetState()
        {
            return targetState;
        }

        /// <summary>
        /// Method that returns the transition condition attribute of the instance
        /// </summary>
        /// <returns>The transition condition attribute of the instance</returns>
        public ITransitionCondition getTransitionCondition()
        {
            return transitionCondition;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getTmpBelonstToAction()
        {
            return tmpBelonstToAction;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getTmpSourceState()
        {
            return tmpSourceState;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getTmpTargetState()
        {
            return tmpTargetState;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getTmpTransitionCondition()
        {
            return tmpTransitionCondition;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        public void setTransitionType(string type)
        {
            if (type.Equals("Standard"))
            {
                this.TransitionType = transitionType.Standard;
            }
        }

        /// <summary>
        /// Factory method that creates and returns a new empty instance of the transition class
        /// </summary>
        /// <returns>A new empty instance of the transition class</returns>
        new public Transition factoryMethod()
        {
            Transition transition = new Transition();

            return transition;
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

                if (s.Contains("containsAction"))
                {
                    tmpBelonstToAction = attribute[counter];
                    toBeRemoved.Add(counter);
                }

                if (s.Contains("hasSourceState"))
                {
                    tmpSourceState = attribute[counter];
                    toBeRemoved.Add(counter);
                }

                if (s.Contains("hasTargetState"))
                {
                    tmpTargetState = attribute[counter];
                    toBeRemoved.Add(counter);
                }

                if (s.Contains("hasTransitionCondition"))
                {
                    tmpTransitionCondition = attribute[counter];
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
                    if (new Action().GetType().IsInstanceOfType(allElements[s]) && getAdditionalAttributeType()[getAdditionalAttribute().IndexOf(s)].Contains("belongsToAction"))
                    {
                        this.belongsToAction = (Action)allElements[s];
                        int place = getAdditionalAttribute().IndexOf(s);
                        if (place >= 0)
                        {
                            getAdditionalAttributeType().RemoveAt(place);
                            getAdditionalAttribute().Remove(s);
                        }
                    }

                    if (new State().GetType().IsInstanceOfType(allElements[s]) || new SendState().GetType().IsInstanceOfType(allElements[s]) || new ReceiveState().GetType().IsInstanceOfType(allElements[s]) || new DoState().GetType().IsInstanceOfType(allElements[s]) && getAdditionalAttributeType()[getAdditionalAttribute().IndexOf(s)].Contains("State"))
                    {
                        
                        if (getAdditionalAttribute().IndexOf(allElements[s].getModelComponentID()) >= 0)
                        {
                            int remove = 0;

                            foreach (string nervNed in getAdditionalAttributeType())
                            {
                                if (nervNed.Contains("Source"))
                                {
                                    if (getAdditionalAttribute()[getAdditionalAttributeType().IndexOf(nervNed)].Equals(allElements[s].getModelComponentID()))
                                    {
                                        this.sourceState = (State)allElements[s];
                                        //Console.WriteLine(allElements[s].getModelComponentID() + "       " + this.getModelComponentID() + "     Source");
                                        remove = getAdditionalAttributeType().IndexOf(nervNed);
                                    }
                                   
                                }
                                else
                                {
                                    if (nervNed.Contains("Target"))
                                    {
                                        if (getAdditionalAttribute()[getAdditionalAttributeType().IndexOf(nervNed)].Equals(allElements[s].getModelComponentID()))
                                        {
                                            this.targetState = (State)allElements[s];
                                            //Console.WriteLine(this.getModelComponentID() + "       " + allElements[s].getModelComponentID() +   "     Target");
                                            remove = getAdditionalAttributeType().IndexOf(nervNed);
                                        }
                                    }
                                }
                            }

                            getAdditionalAttribute().RemoveAt(remove);
                            getAdditionalAttributeType().RemoveAt(remove);
                        }
                    }

                    if (new TransitionCondition().GetType().IsInstanceOfType(allElements[s]))
                    {
                        this.transitionCondition = (TransitionCondition)allElements[s];
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
        /// <param name="last"></param>
        /// <param name="filename"></param>
        public override void exporting(bool last, string filename)
        {
            base.exporting(false, filename);

            using (StreamWriter sw = File.AppendText("../../../../" + filename + ".owl"))
            {
                if (belongsToAction != null)
                {
                    sw.WriteLine("      <standard-pass-ont:belongsTo" + " rdf:resource=\"" + belongsToAction.getModelComponentID() + "\" ></standard-pass-ont:belongsTo>");
                }

                if (sourceState != null)
                {
                    sw.WriteLine("      <standard-pass-ont:hasSourceState" + " rdf:resource=\"" + sourceState.getModelComponentID() + "\" ></standard-pass-ont:hasSourceState>");
                }

                if (targetState != null)
                {
                    sw.WriteLine("      <standard-pass-ont:hasTargetState" + " rdf:resource=\"" + targetState.getModelComponentID() + "\" ></standard-pass-ont:hasTargetState>");
                }

                if (last)
                {
                    if (TransitionType == transitionType.Standard)
                    {
                        sw.WriteLine("      <rdf:type rdf:resource=" + "\"&standard-pass-ont;" + "StandardTransition" + "\" ></rdf:type>");
                        sw.WriteLine("  </owl:NamedIndividual>");
                    }
                    else
                    {
                        sw.WriteLine("      <rdf:type rdf:resource=" + "\"&standard-pass-ont;" + this.GetType().ToString().Split('.')[2] + "\" ></rdf:type>");
                        sw.WriteLine("  </owl:NamedIndividual>");
                    }   
                }
            }
        }
    }
}
