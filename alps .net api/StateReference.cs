using System;
using System.Collections.Generic;
using System.IO;
using VDS.RDF;

namespace alps.net_api
{
    /// <summary>
    /// Class that represents a state reference class
    /// </summary>
    public class StateReference : State, IStateReference
    {
        private IState referenceState;
        private string tmpReferenceState;
        /// <summary>
        /// Name of the class
        /// </summary>
        new public const string className = "StateReference";

        /// <summary>
        /// Constructor that creates a new empty instance of the state refrence class
        /// </summary>
        public StateReference()
        {
            setModelComponentID("StateReference");
            setComment("The standart Element for StateReference");
        }

        /// <summary>
        /// Constructor that creates a new fully specified instance of the state refrence class
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
        /// <param name="referenceState"></param>
        public StateReference(List<string> additionalAttribute, string modelComponentID, List<string> modelComponentLabel, string comment, SubjectBehavior subjectBehavior, Transition incomingTransition, Transition outgoingTransition, FunctionSpecification functionSpecification, GuardBehavior guardBehavior, Action action, State referenceState)
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
            setReferencesState(referenceState);
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
        /// <param name="state"></param>
        /// <param name="additionalAttribute"></param>
        public StateReference(string label, string comment = "", IAction action = null, IGuardBehavior guardBehavior = null, IFunctionSpecification functionSpecification = null, ITransition incomingTransition = null, ITransition outgoingTransition = null, IState state = null, List<string> additionalAttribute = null) : base(label, comment, action, guardBehavior, functionSpecification, incomingTransition, outgoingTransition, additionalAttribute)
        {
            if (state != null)
            {
                this.referenceState = state;
            }
        }

        /// <summary>
        /// Method that sets the state attribute of the instance
        /// </summary>
        /// <param name="state"></param>
        public void setReferencesState(IState state)
        {
            this.referenceState = state;
        }

        /// <summary>
        /// Method that returns the state attribute of the instance
        /// </summary>
        /// <returns>The state attribute of the instance</returns>
        public IState getReferencesState()
        {
            return referenceState;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getTmpReferenceState()
        {
            return tmpReferenceState;
        }

        /// <summary>
        /// Factory method that creates and returns a new empty instance of the state reference class
        /// </summary>
        /// <returns>A new empty instance of the state reference class</returns>
        new public StateReference factoryMethod()
        {
            StateReference stateReference = new StateReference();

            return stateReference;
        }

        /// <summary>
        /// Method that creates a new instance of the state reference class
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
                    if (new State().GetType().IsInstanceOfType(allElements[s]))
                    {
                        this.referenceState = (State)allElements[s];
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
                if (referenceState != null)
                {
                    sw.WriteLine("      <standard-pass-ont:references" + " rdf:resource=\"" + referenceState.getModelComponentID() + "\" ></standard-pass-ont:references>");
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