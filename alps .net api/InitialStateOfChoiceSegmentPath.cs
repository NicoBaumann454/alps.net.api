using System;
using System.Collections.Generic;
using System.IO;
using VDS.RDF;

namespace alps.net_api
{
    /// <summary>
    /// Class that represents InitialStateOfChoiceSegmentPath
    /// </summary>

    public class InitialStateOfChoiceSegmentPath : State, IInitialstateOfChoiceSegmentPath
    {
        private IChoiceSegmentPath choiceSegmentPath;
        private string tmpChoiceSegmentPath;
        /// <summary>
        /// Name of the class
        /// </summary>
        new public const string className = "InitialStateOfChoiceSegmentPath";

        /// <summary>
        /// Constructor that creates a new empty instance of the initial state of choice segment path class
        /// </summary>
        public InitialStateOfChoiceSegmentPath()
        {
            setModelComponentID("InitialStateOfChoiceSegmentPath");
            setComment("The standart Element for InitialStateOfChoiceSegmentPath");
        }

        /// <summary>
        /// Constructor that creates a new fully specified instance of the initial state of choice segment path class
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
        /// <param name="choiceSegmentPath"></param>
        public InitialStateOfChoiceSegmentPath(List<string> additionalAttribute, string modelComponentID, List<string> modelComponentLabel, string comment, SubjectBehavior subjectBehavior, Transition incomingTransition, Transition outgoingTransition, FunctionSpecification functionSpecification, GuardBehavior guardBehavior, Action action, ChoiceSegmentPath choiceSegmentPath)
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
            setBelongsToChoiceSegmentPath(choiceSegmentPath);

        }

        /// <summary>
        /// Constructor that creates a new fully specified instance of the initial state of choice segment class
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="action"></param>
        /// <param name="guardBehavior"></param>
        /// <param name="functionSpecification"></param>
        /// <param name="incomingTransition"></param>
        /// <param name="outgoingTransition"></param>
        /// <param name="choiceSegmentPath"></param>
        /// <param name="additionalAttribute"></param>
        public InitialStateOfChoiceSegmentPath(string label, string comment = "", IAction action = null, IGuardBehavior guardBehavior = null, IFunctionSpecification functionSpecification = null, ITransition incomingTransition = null, ITransition outgoingTransition = null, IChoiceSegmentPath choiceSegmentPath = null, List<string> additionalAttribute = null) : base(label, comment, action, guardBehavior, functionSpecification, incomingTransition, outgoingTransition, additionalAttribute)
        {
            if (choiceSegmentPath != null)
            {
                this.choiceSegmentPath = choiceSegmentPath;
            }
        }

        /// <summary>
        /// Method that sets the choice segment path attribute of the instance
        /// </summary>
        /// <param name="choiceSegmentPath"></param>
        public void setBelongsToChoiceSegmentPath(IChoiceSegmentPath choiceSegmentPath)
        {
            this.choiceSegmentPath = choiceSegmentPath;
        }

        /// <summary>
        /// Method that returns the choice segment path attribute of the instance
        /// </summary>
        /// <returns>The choice segment path attribute of the instance</returns>
        public IChoiceSegmentPath getChoiceSegmentPath()
        {
            return choiceSegmentPath;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getTmpChoiceSegmentPath()
        {
            return tmpChoiceSegmentPath;
        }

        /// <summary>
        /// Factory method that creates and returns a new empty instance of the initial state of choice segment path class
        /// </summary>
        /// <returns></returns>
        new public InitialStateOfChoiceSegmentPath factoryMethod()
        {
            InitialStateOfChoiceSegmentPath initialStateOfChoiceSegmentPath = new InitialStateOfChoiceSegmentPath();

            return initialStateOfChoiceSegmentPath;
        }

        /// <summary>
        /// Method that creates a new instance of the initial state of choice segment path class
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
                    if (new ChoiceSegmentPath().GetType().IsInstanceOfType(allElements[s]))
                    {
                        this.choiceSegmentPath = (ChoiceSegmentPath)allElements[s];
                        int place = getAdditionalAttribute().IndexOf(s);
                        getAdditionalAttributeType().RemoveAt(place);
                        getAdditionalAttribute().Remove(s);
                    }
                }
            }
        }

        /// <summary>
        /// Method that exports a initial state of choice segment path object to the file given in the filename
        /// </summary>
        /// <param name="last"></param>
        /// <param name="filename"></param>
        public override void exporting(bool last, string filename)
        {
            base.exporting(false, filename);

            using (StreamWriter sw = File.AppendText("../../../../" + filename + ".owl"))
            {

                if (choiceSegmentPath != null)
                {
                    sw.WriteLine("      <standard-pass-ont:belongsTo" + " rdf:resource=\"" + choiceSegmentPath.getModelComponentID() + "\" ></standard-pass-ont:belongsTo>");
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