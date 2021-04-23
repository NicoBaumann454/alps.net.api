using System.Collections.Generic;
using System.IO;

namespace alps.net_api
{
    /// <summary>
    /// Method that repesents an abstract state
    /// </summary>
    public class AbstractState : ALPSSBDComponent, IAbstractState
    {
        private ITransition incomingTransition;
        private ITransition outgoingTransition;
        private IFunctionSpecification functionSpecification;
        private IGuardBehavior guardBehavior;
        private IAction action;
        private string tmpIncomingTransition;
        private string tmpOutgoingTransition;
        private string tmpFunctionSpecification;
        private string tmpGuardBehavior;
        private string tmpAction;
        /// <summary>
        /// Constructor that creates a new empty instance of the abstract state class
        /// </summary>
        public AbstractState()
        {
            setModelComponentID("AbstractState");
            setComment("The standart Element for AbstractState");
        }

        /// <summary>
        /// Constructor that creates a new fully specified instance of the abstract state class
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
        public AbstractState(List<string> additionalAttribute, string modelComponentID, List<string> modelComponentLabel, string comment, SubjectBehavior subjectBehavior, Transition incomingTransition, Transition outgoingTransition, FunctionSpecification functionSpecification, GuardBehavior guardBehavior, Action action)
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
        }

        /// <summary>
        /// Method that sets the incoming transition attribute of the instance
        /// </summary>
        /// <param name="transition"></param>
        public void setIncomingTransition(ITransition transition)
        {
            this.incomingTransition = transition;
        }

        /// <summary>
        /// Method that returns the incoming transition attribute of the instance
        /// </summary>
        /// <returns>The incoming transition attribute of the instance</returns>
        public ITransition getIncomingTransition()
        {
            return incomingTransition;
        }

        /// <summary>
        /// Method that sets the outgoing transition attribute of the instance
        /// </summary>
        /// <param name="transition"></param>
        public void setOutgoingTransition(ITransition transition)
        {
            this.outgoingTransition = transition;
        }

        /// <summary>
        /// Method that returns the outgoing transition attribute of the instance
        /// </summary>
        /// <returns>The outgoing transition attribute of the instance</returns>
        public ITransition getOutgoingTransition()
        {
            return outgoingTransition;
        }

        /// <summary>
        /// Method that sets the function specification attribute of the instance
        /// </summary>
        /// <param name="functionSpecification"></param>
        public void setFunctionSpecification(IFunctionSpecification functionSpecification)
        {
            this.functionSpecification = functionSpecification;
        }

        /// <summary>
        /// Method that returns the function specification attribute of the instance
        /// </summary>
        /// <returns>The function specification attribute of the instance</returns>
        public IFunctionSpecification getFunctionSpecification()
        {
            return functionSpecification;
        }

        /// <summary>
        /// Method that sets the guard behavior attribute of the instance
        /// </summary>
        /// <param name="guardBehavior"></param>
        public void setGuardBehavior(IGuardBehavior guardBehavior)
        {
            this.guardBehavior = guardBehavior;
        }

        /// <summary>
        /// Method that returns the guard behavior attribute of the instance
        /// </summary>
        /// <returns>The guard behavior attribute of the instance</returns>
        public IGuardBehavior getGuardBehavior()
        {
            return guardBehavior;
        }

        /// <summary>
        /// Method that sets the action attribute of the instance
        /// </summary>
        /// <param name="action"></param>
        public void setAction(IAction action)
        {
            this.action = action;
        }

        /// <summary>
        /// Method that returns the action attribute of the instance
        /// </summary>
        /// <returns>The action attribute of the instance</returns>
        public IAction getAction()
        {
            return action;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getTmpIncomingTransition()
        {
            return tmpIncomingTransition;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getTmpOutgoingTransition()
        {
            return tmpOutgoingTransition;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getTmpFunctionSpecification()
        {
            return tmpFunctionSpecification;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getTmpGuardBehavior()
        {
            return tmpGuardBehavior;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getTmpAction()
        {
            return tmpAction;
        }

        /// <summary>
        /// Factory method that creates a new empty instance of the stat class
        /// </summary>
        /// <returns></returns>
        new public State factoryMethod()
        {
            State state = new State();

            return state;
        }


        /// <summary>
        /// Method that creates a new instance of the abstract state class
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

                if (s.Contains("hasIncomingTransition"))
                {
                    tmpIncomingTransition = attribute[counter];
                    toBeRemoved.Add(counter);
                }

                if (s.Contains("hasOutgoingTransition"))
                {
                    tmpOutgoingTransition = attribute[counter];
                    toBeRemoved.Add(counter);
                }

                if (s.Contains("hasFunctionSpecification"))
                {
                    tmpFunctionSpecification = attribute[counter];
                    toBeRemoved.Add(counter);
                }

                if (s.Contains("guardedBy"))
                {
                    tmpGuardBehavior = attribute[counter];
                    toBeRemoved.Add(counter);
                }

                if (s.Contains("belongsTo"))
                {
                    tmpAction = attribute[counter];
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
                    if (new Transition().GetType().IsInstanceOfType(allElements[s]))
                    {
                        this.incomingTransition = (Transition)allElements[s];
                        int place = getAdditionalAttribute().IndexOf(s);
                        if (place >= 0)
                        {
                            getAdditionalAttributeType().RemoveAt(place);
                            getAdditionalAttribute().Remove(s);
                        }
                        //tmp.Remove(s);
                    }

                    if (new Transition().GetType().IsInstanceOfType(allElements[s]))
                    {
                        this.outgoingTransition = (Transition)allElements[s];
                        int place = getAdditionalAttribute().IndexOf(s);
                        if (place >= 0)
                        {
                            getAdditionalAttributeType().RemoveAt(place);
                            getAdditionalAttribute().Remove(s);
                        }
                        //tmp.Remove(s);
                    }

                    if (new GuardBehavior().GetType().IsInstanceOfType(allElements[s]))
                    {
                        this.guardBehavior = (GuardBehavior)allElements[s];
                        int place = getAdditionalAttribute().IndexOf(s);
                        if (place >= 0)
                        {
                            getAdditionalAttributeType().RemoveAt(place);
                            getAdditionalAttribute().Remove(s);
                        }
                        //tmp.Remove(s);
                    }

                    if (new FunctionSpecification().GetType().IsInstanceOfType(allElements[s]))
                    {
                        this.functionSpecification = (FunctionSpecification)allElements[s];
                        int place = getAdditionalAttribute().IndexOf(s);
                        if (place >= 0)
                        {
                            getAdditionalAttributeType().RemoveAt(place);
                            getAdditionalAttribute().Remove(s);
                        }
                        //tmp.Remove(s);
                    }

                    if (new Action().GetType().IsInstanceOfType(allElements[s]))
                    {
                        this.action = (Action)allElements[s];
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
        /// Method that exports an abstract state object to the file given in the filename
        /// </summary>
        /// <param name="last"></param>
        /// <param name="filename"></param>
        public override void exporting(bool last, string filename)
        {
            base.exporting(false, filename);

            using (StreamWriter sw = File.AppendText("../../../../" + filename + ".owl"))
            {

                if (action != null)
                {
                    sw.WriteLine("      <standard-pass-ont:belongsTo" + " rdf:resource=\"" + action.getModelComponentID() + "\" ></standard-pass-ont:belongsTo>");
                }

                if (functionSpecification != null)
                {
                    sw.WriteLine("      <standard-pass-ont:hasFunctionSpecification" + " rdf:resource=\"" + functionSpecification.getModelComponentID() + "\" ></standard-pass-ont:hasFunctionSpecification>");
                }

                if (guardBehavior != null)
                {
                    sw.WriteLine("      <standard-pass-ont:hasGuardBehavior" + " rdf:resource=\"" + guardBehavior.getModelComponentID() + "\" ></standard-pass-ont:hasGuardBehavior>");
                }

                if (incomingTransition != null)
                {
                    sw.WriteLine("      <standard-pass-ont:hasIncomingTransition" + " rdf:resource=\"" + incomingTransition.getModelComponentID() + "\" ></standard-pass-ont:hasIncomingTransition>");
                }

                if (outgoingTransition != null)
                {
                    sw.WriteLine("      <standard-pass-ont:hasOutgoingTransition" + " rdf:resource=\"" + outgoingTransition.getModelComponentID() + "\" ></standard-pass-ont:hasOutgoingTransition>");
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
