using System.Collections.Generic;
using System.IO;

namespace alps.net_api
{
    /// <summary>
    /// Method that represents an abstract PASS transition
    /// </summary>
    public class AbstractPASSTransition : ALPSSBDComponent, IAbstractPASSTransition
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
        /// Name of the class
        /// </summary>
        new public const string className = "AbstractPASSTransition";

        /// <summary>
        /// Constructor that creates a new empty instance of the transition class
        /// </summary>
        public AbstractPASSTransition()
        {
            setModelComponentID("AbstractPASSTransition");
            setComment("The standart Element for AbstractPassTransition");
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
        public AbstractPASSTransition(List<string> additionalAttribute, string modelComponentID, List<string> modelComponentLabel, string comment, SubjectBehavior subjectBehavior, Action belongsToaction, State sourceState, State targetState, TransitionCondition transitionCondition)
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
        /// Factory method that creates and returns a new empty instance of the transition class
        /// </summary>
        /// <returns>A new empty instance of the transition class</returns>
        new public AbstractPASSTransition factoryMethod()
        {
            AbstractPASSTransition transition = new AbstractPASSTransition();

            return transition;
        }

        /// <summary>
        /// Method that creates a new instance of the abstract PASS state class
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

                if (s.Contains("belongsTo"))
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
                    if (new Action().GetType().IsInstanceOfType(allElements[s]))
                    {
                        this.belongsToAction = (Action)allElements[s];
                        int place = getAdditionalAttribute().IndexOf(s);
                        getAdditionalAttributeType().RemoveAt(place);
                        getAdditionalAttribute().Remove(s);
                    }

                    if (new State().GetType().IsInstanceOfType(allElements[s]))
                    {
                        this.targetState = (State)allElements[s];
                        int place = getAdditionalAttribute().IndexOf(s);
                        getAdditionalAttributeType().RemoveAt(place);
                        getAdditionalAttribute().Remove(s);
                        //tmp.Remove(s);
                    }

                    if (new State().GetType().IsInstanceOfType(allElements[s]))
                    {
                        this.sourceState = (State)allElements[s];
                        int place = getAdditionalAttribute().IndexOf(s);
                        getAdditionalAttributeType().RemoveAt(place);
                        getAdditionalAttribute().Remove(s);
                        //tmp.Remove(s);
                    }

                    if (new TransitionCondition().GetType().IsInstanceOfType(allElements[s]))
                    {
                        this.transitionCondition = (TransitionCondition)allElements[s];
                        int place = getAdditionalAttribute().IndexOf(s);
                        getAdditionalAttributeType().RemoveAt(place);
                        getAdditionalAttribute().Remove(s);
                        //tmp.Remove(s);
                    }
                }
            }
        }

        /// <summary>
        /// Method that exports an abstract PASS Transition to the file given in the filename
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

                if (targetState != null)
                {
                    sw.WriteLine("      <standard-pass-ont:hasTargetState" + " rdf:resource=\"" + targetState.getModelComponentID() + "\" ></standard-pass-ont:hasTargetState>");
                }

                if (transitionCondition != null)
                {
                    sw.WriteLine("      <standard-pass-ont:hasTransitionCondition" + " rdf:resource=\"" + transitionCondition.getModelComponentID() + "\" ></standard-pass-ont:hasTransitionCondition>");
                }

                if (belongsToAction != null)
                {
                    sw.WriteLine("      <standard-pass-ont:belongsTo" + " rdf:resource=\"" + belongsToAction.getModelComponentID() + "\" ></standard-pass-ont:belongsTo>");
                }

                if (last)
                {
                    sw.WriteLine("      <rdf:type rdf:resource=" + "\"&abstract-pass-ont;" + this.GetType().ToString().Split('.')[2] + "\" ></rdf:type>");
                    sw.WriteLine("  </owl:NamedIndividual>");
                }
            }
        }
    }
}
