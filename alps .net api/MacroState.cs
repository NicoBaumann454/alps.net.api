using System;
using System.Collections.Generic;
using VDS.RDF;

namespace alps.net_api
{
    /// <summary>
    /// Class that represents an macro state
    /// </summary>

    public class MacroState : State, IMacroState
    {
        private IMacroBehavior referenceMacroBehavior;
        private Dictionary<string, IStateReference> stateReference;
        private string tmpReferenceMacroBehavior;
        /// <summary>
        /// Name of the class
        /// </summary>
        new public const string className = "Macrostate";

        /// <summary>
        /// Constructor that creates a new empty instace of the macro state class
        /// </summary>
        public MacroState()
        {
            setModelComponentID("MacroState");
            setComment("The standart Element for MacroState");
        }

        /// <summary>
        /// Constructor that creates a new fully specified instace of the macro state class
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
        /// <param name="macroBehavior"></param>
        public MacroState(List<string> additionalAttribute, string modelComponentID, List<string> modelComponentLabel, string comment, SubjectBehavior subjectBehavior, Transition incomingTransition, Transition outgoingTransition, FunctionSpecification functionSpecification, GuardBehavior guardBehavior, Action action, MacroBehavior macroBehavior)
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
            setReferencesMacroBehavior(macroBehavior);
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
        /// <param name="stateReference"></param>
        /// <param name="macroBehavior"></param>
        /// <param name="additionalAttribute"></param>
        public MacroState(string label, string comment = "", IAction action = null, IGuardBehavior guardBehavior = null, IFunctionSpecification functionSpecification = null, ITransition incomingTransition = null, ITransition outgoingTransition = null, Dictionary<string, IStateReference> stateReference = null, IMacroBehavior macroBehavior = null, List<string> additionalAttribute = null) : base(label, comment, action, guardBehavior, functionSpecification, incomingTransition, outgoingTransition, additionalAttribute)
        {
            if (macroBehavior != null)
            {
                this.referenceMacroBehavior = macroBehavior;
            }

            if (stateReference != null)
            {
                this.stateReference = stateReference;
            }
        }

        /// <summary>
        /// Method that sets the macro behavior attribute of the instance
        /// </summary>
        /// <param name="macroBehavior"></param>
        public void setReferencesMacroBehavior(IMacroBehavior macroBehavior)
        {
            this.referenceMacroBehavior = macroBehavior;
        }

        /// <summary>
        /// Method that returns the macro behavior attribute of the instance
        /// </summary>
        /// <returns>The macro behavior attribute of the instance</returns>
        public IMacroBehavior getReferenceMacroBehavior()
        {
            return referenceMacroBehavior;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateReference"></param>
        public void setStateReference(IStateReference stateReference)
        {
            this.stateReference.Add(stateReference.getModelComponentID(), stateReference);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, IStateReference> getStateReference()
        {
            return stateReference;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getTmpReferenceMacroBehavior()
        {
            return tmpReferenceMacroBehavior;
        }

        /// <summary>
        /// Factory method that creates and returns a new empty instance of the macro state class
        /// </summary>
        /// <returns>A new empty instance of the macro state class</returns>
        new public MacroState factoryMethod()
        {
            MacroState macroState = new MacroState();

            return macroState;
        }

        /// <summary>
        /// Method that creates a new instance of the macro state class
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
                    if (new MacroBehavior().GetType().IsInstanceOfType(allElements[s]))
                    {
                        this.referenceMacroBehavior = (MacroBehavior)allElements[s];
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

            if (referenceMacroBehavior != null)
            {
                subject = g.CreateUriNode(name);
                predicate = g.CreateUriNode("rdf:referencesMacroBehavior");
                objec = g.CreateUriNode("standard-pass-ont:" + referenceMacroBehavior.getModelComponentID());

                test = new Triple(subject, predicate, objec);
                g.Assert(test);

                //Console.WriteLine(name + "  " + "http://www.w3.org/1999/02/22-rdf-syntax-ns#type" + "  " + "http://www.w3.org/2002/07/owl#NamedIndividual");
            }

            foreach (KeyValuePair<string, IStateReference> s in stateReference)
            {
                if (s.Value != null)
                {
                    subject = g.CreateUriNode(name);
                    predicate = g.CreateUriNode("rdf:hasStateReference");
                    objec = g.CreateUriNode("standard-pass-ont:" + s.Value.getModelComponentID());

                    test = new Triple(subject, predicate, objec);
                    //Console.WriteLine(test.Subject.ToString() + " " + test.Predicate.ToString() + " " + test.Object.ToString());
                    g.Assert(test);

                }
            }

        }
    }
}
