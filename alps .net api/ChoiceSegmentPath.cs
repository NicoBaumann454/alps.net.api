using System;
using System.Collections.Generic;
using System.IO;
using VDS.RDF;

namespace alps.net_api
{
    /// <summary>
    /// Class that represents a Choice Segment Path
    /// </summary>
    public class ChoiceSegmentPath : State, IChoiceSegmentPath
    {
        private IState endState;
        private IState initialState;
        private bool optionalToEndChoiceSegmentPath = false;
        private bool optionalToStartChoiceSegmentPath = false;
        private bool mandatoryToStartChoiceSegmentPath = false;
        private bool mandatoryToEndChoiceSegmentPath = false;
        private string tmpEndState;
        private string tmpInitialState;
        private string tmpOptionalToEndChoiceSegmentPath;
        private string tmpOptionalToStartChoiceSegmentPath;
        /// <summary>
        /// Name of the class
        /// </summary>
        new public const string className = "ChoiceSegmentPath";

        /// <summary>
        /// Constructor that creates a new empty instance of the Choice Segment Path class
        /// </summary>
        public ChoiceSegmentPath()
        {
            setModelComponentID("ChoiceSegmentPath");
            setComment("The standart Element for ChoiceSegmentPath");
        }

        /// <summary>
        /// Constructor that creates a new fully specified instance of the Choice Segment Path class
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
        /// <param name="endState"></param>
        /// <param name="initialState"></param>
        /// <param name="optionalToEndChoiceSegmentPath"></param>
        /// <param name="optionalToStartChoiceSegmentPath"></param>
        public ChoiceSegmentPath(List<string> additionalAttribute, string modelComponentID, List<string> modelComponentLabel, string comment, SubjectBehavior subjectBehavior, Transition incomingTransition, Transition outgoingTransition, FunctionSpecification functionSpecification, GuardBehavior guardBehavior, Action action, State endState, State initialState, bool optionalToEndChoiceSegmentPath, bool optionalToStartChoiceSegmentPath)
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
            setEndState(endState);
            setInitialState(initialState);
            setIsOptionalToEndChoiceSegmentPath(optionalToEndChoiceSegmentPath);
            setIsOptionalToStartChoiceSegmentPath(optionalToStartChoiceSegmentPath);
        }

        /// <summary>
        /// Constructor that creates a new fully Specified instance of the choice segment path class
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="action"></param>
        /// <param name="guardBehavior"></param>
        /// <param name="functionSpecification"></param>
        /// <param name="incomingTransition"></param>
        /// <param name="outgoingTransition"></param>
        /// <param name="choiceSegment"></param>
        /// <param name="containsState"></param>
        /// <param name="endState"></param>
        /// <param name="initialStateOfChoiceSegmentPath"></param>
        /// <param name="isOptionalToEndChoiceSegmentPath"></param>
        /// <param name="isOptionalToStartChoiceSegmentPath"></param>
        /// <param name="isMandatoryToEndChoiceSegmentPath"></param>
        /// <param name="isMandatoryToStartEndChoiceSegmentPath"></param>
        /// <param name="additionalAttribute"></param>
        public ChoiceSegmentPath(string label, string comment = "", IAction action = null, IGuardBehavior guardBehavior = null, IFunctionSpecification functionSpecification = null, ITransition incomingTransition = null, ITransition outgoingTransition = null, IChoiceSegment choiceSegment = null, IState containsState = null, IEndState endState = null, InitialStateOfChoiceSegmentPath initialStateOfChoiceSegmentPath = null, bool isOptionalToEndChoiceSegmentPath = false, bool isOptionalToStartChoiceSegmentPath = false, bool isMandatoryToEndChoiceSegmentPath = false, bool isMandatoryToStartEndChoiceSegmentPath = false, List<string> additionalAttribute = null) : base(label, comment, action, guardBehavior, functionSpecification, incomingTransition, outgoingTransition, additionalAttribute)
        {
            if (action != null)
            {
                setAction(action);
            }

            if (guardBehavior != null)
            {
                setGuardBehavior(guardBehavior);
            }

            if (functionSpecification != null)
            {
                setFunctionSpecification(functionSpecification);
            }

            if (incomingTransition != null)
            {
                setIncomingTransition(incomingTransition);
            }

            if (outgoingTransition != null)
            {
                setOutgoingTransition(outgoingTransition);
            }

            if (endState != null)
            {
                setEndState(endState);
            }

            if (containsState != null)
            {
                setInitialState(containsState);
            }

            if (initialStateOfChoiceSegmentPath != null)
            {
                this.initialState = initialStateOfChoiceSegmentPath;
            }

            if (optionalToEndChoiceSegmentPath == true && mandatoryToEndChoiceSegmentPath == false)
            {
                this.optionalToEndChoiceSegmentPath = isOptionalToEndChoiceSegmentPath;
            }

            this.optionalToEndChoiceSegmentPath = isOptionalToEndChoiceSegmentPath;
            this.optionalToStartChoiceSegmentPath = isOptionalToStartChoiceSegmentPath;
            this.mandatoryToEndChoiceSegmentPath = isMandatoryToEndChoiceSegmentPath;
            this.mandatoryToStartChoiceSegmentPath = isMandatoryToEndChoiceSegmentPath;
        }

        /// <summary>
        /// Method that sets the end state attribute
        /// </summary>
        /// <param name="state"></param>
        public void setEndState(IState state)
        {
            this.endState = state;
        }

        /// <summary>
        /// Method that returns the end state attribute
        /// </summary>
        /// <returns>The end state attribute</returns>
        public IState getEndState()
        {
            return endState;
        }

        /// <summary>
        /// Method that sets the initial state attribute
        /// </summary>
        /// <param name="state"></param>
        public void setInitialState(IState state)
        {
            this.initialState = state;
        }

        /// <summary>
        /// Method that returns the initial state attribute
        /// </summary>
        /// <returns>The initial state attribute</returns>
        public IState getInitialState()
        {
            return initialState;
        }

        /// <summary>
        /// Method that sets the optional to end choice segment path attribute
        /// </summary>
        /// <param name="endChoice"></param>
        public void setIsOptionalToEndChoiceSegmentPath(bool endChoice)
        {
            this.optionalToEndChoiceSegmentPath = endChoice;
        }

        //Hier muss noch eine exception hin ?
        /// <summary>
        /// Method that returns the optional to end choice segment path attribute
        /// </summary>
        /// <returns>The optional to end choice segment path attribute</returns>
        public bool getIsOptionalToEndChoiceSegmentPath()
        {
            return optionalToEndChoiceSegmentPath;
        }

        /// <summary>
        /// Method that sets the optional to start choice segment path attribute
        /// </summary>
        /// <param name="endChoice"></param>
        public void setIsOptionalToStartChoiceSegmentPath(bool endChoice)
        {
            this.optionalToStartChoiceSegmentPath = endChoice;
        }

        //Hier muss ebenfalls eine exception ?
        /// <summary>
        /// Method that returns the optional to start choice segment path attribute
        /// </summary>
        /// <returns>The optional to start choice segment path attribute</returns>
        public bool getIsOptionalToStartChoiceSegmentPath()
        {
            return optionalToStartChoiceSegmentPath;
        }

        /// <summary>
        /// Method that sets the tmp end state attribute
        /// </summary>
        /// <param name="tmpEndState"></param>
        public void setTmpEndState(string tmpEndState)
        {
            this.tmpEndState = tmpEndState;
        }

        /// <summary>
        /// Method that returns the tmpEndState
        /// </summary>
        /// <returns></returns>
        public string getTmpEndState()
        {
            return tmpEndState;
        }

        /// <summary>
        /// Factory method that creates and returns a new empty instance of the choice segment path class
        /// </summary>
        /// <returns>A new empty instance of the choice segment path class</returns>
        new public ChoiceSegmentPath factoryMethod()
        {
            ChoiceSegmentPath choiceSegmentPath = new ChoiceSegmentPath();

            return choiceSegmentPath;
        }

        /// <summary>
        /// Method that creates a new instance of the choice segment path class
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="attributeType"></param>
        /// <returns></returns>
        public override bool createInstance(List<string> attribute, List<string> attributeType)
        {
            base.createInstance(attribute, attributeType);

            emptyAdditionalAttribute();

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
                        if (getAdditionalAttribute().IndexOf(allElements[s].getModelComponentID()) >= 0)
                        {
                            if (getAdditionalAttributeType()[getAdditionalAttribute().IndexOf(allElements[s].getModelComponentID())].Contains("EndState"))
                            {
                                this.endState = (State)allElements[s];
                                int place = getAdditionalAttribute().IndexOf(s);
                                if (place >= 0)
                                {
                                    getAdditionalAttributeType().RemoveAt(place);
                                    getAdditionalAttribute().Remove(s);
                                }
                            }
                            else
                            {
                                this.initialState = (State)allElements[s];
                                int place = getAdditionalAttribute().IndexOf(s);
                                if (place >= 0)
                                {
                                    getAdditionalAttributeType().RemoveAt(place);
                                    getAdditionalAttribute().Remove(s);
                                }
                            }
                        }
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

            string[] splittedURI;
            splittedURI = nameString.Split('^');
            nameString = "http://www.imi.kit.edu/dimension/exampleProcess#" + splittedURI[0];

            Uri name = new Uri(nameString);
            //Console.WriteLine(name);
            //Console.WriteLine();

            if (endState != null)
            {
                subject = g.CreateUriNode(name);
                predicate = g.CreateUriNode("rdf:belongsToAction");
                objec = g.CreateUriNode("standard-pass-ont:" + endState.getModelComponentID());

                test = new Triple(subject, predicate, objec);
                g.Assert(test);

                //Console.WriteLine(name + "  " + "http://www.w3.org/1999/02/22-rdf-syntax-ns#type" + "  " + "http://www.w3.org/2002/07/owl#NamedIndividual");
            }

            if (initialState != null)
            {
                subject = g.CreateUriNode(name);
                predicate = g.CreateUriNode("rdf:hasSourceState");
                objec = g.CreateUriNode("standard-pass-ont:" + initialState.getModelComponentID());

                test = new Triple(subject, predicate, objec);
                //Console.WriteLine(test.Subject.ToString() + " " + test.Predicate.ToString() + " " + test.Object.ToString());
                g.Assert(test);

            }


            subject = g.CreateUriNode(name);
            predicate = g.CreateUriNode("rdf:hasTargetState");
            objec = g.CreateUriNode("standard-pass-ont:" + optionalToEndChoiceSegmentPath);

            test = new Triple(subject, predicate, objec);
            //Console.WriteLine(test.Subject.ToString() + " " + test.Predicate.ToString() + " " + test.Object.ToString());
            g.Assert(test);



            subject = g.CreateUriNode(name);
            predicate = g.CreateUriNode("rdf:hasTransitionCondition");
            objec = g.CreateUriNode("standard-pass-ont:" + optionalToStartChoiceSegmentPath);

            test = new Triple(subject, predicate, objec);
            //Console.WriteLine(test.Subject.ToString() + " " + test.Predicate.ToString() + " " + test.Object.ToString());
            g.Assert(test);

            //Console.WriteLine();
            //Console.WriteLine();

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

                if (endState != null)
                {
                    sw.WriteLine("      <standard-pass-ont:hasEndState" + " rdf:resource=\"" + endState.getModelComponentID() + "\" ></standard-pass-ont:hasEndState>");
                }

                if (initialState != null)
                {
                    sw.WriteLine("      <standard-pass-ont:hasInitialState" + " rdf:resource=\"" + initialState.getModelComponentID() + "\" ></standard-pass-ont:hasInitialState>");
                }

                Console.WriteLine(" **************** In ChoiceSegmentPath fehlt noch eine menge ******************");

                if (last)
                {
                    sw.WriteLine("      <rdf:type rdf:resource=" + "\"&standard-pass-ont;" + this.GetType().ToString().Split('.')[2] + "\" ></rdf:type>");
                    sw.WriteLine("  </owl:NamedIndividual>");
                }
            }
        }
    }
}
