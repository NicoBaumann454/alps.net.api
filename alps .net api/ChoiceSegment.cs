using System;
using System.Collections.Generic;
using System.IO;
using VDS.RDF;

namespace alps.net_api
{
    /// <summary>
    /// Class that represents a Choice Segment
    /// </summary>
    public class ChoiceSegment : State, IChoiceSegment
    {
        private Dictionary<string, IChoiceSegmentPath> choiceSegmentPaths = new Dictionary<string, IChoiceSegmentPath>();
        private string tmpChoiceSegmentPath = "";
        /// <summary>
        /// Constructor that creates a new empty instance of the Choice Segment class
        /// </summary>
        public ChoiceSegment()
        {
            setModelComponentID("ChoiceSegment");
            setComment("The standart Element for ChoiceSegment");
        }

        /// <summary>
        /// Constructor that creates a new fully specified instance of the Choice Segment class
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
        /// <param name="choiceSegmentPaths"></param>
        public ChoiceSegment(List<string> additionalAttribute, string modelComponentID, List<string> modelComponentLabel, string comment, SubjectBehavior subjectBehavior, Transition incomingTransition, Transition outgoingTransition, FunctionSpecification functionSpecification, GuardBehavior guardBehavior, Action action, Dictionary<string, IChoiceSegmentPath> choiceSegmentPaths)
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
            setContainsChoiceSegmentPath(choiceSegmentPaths);
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
        /// <param name="choiceSegmentPath"></param>
        /// <param name="additionalAttribute"></param>
        public ChoiceSegment(string label, string comment = "", IAction action = null, IGuardBehavior guardBehavior = null, IFunctionSpecification functionSpecification = null, ITransition incomingTransition = null, ITransition outgoingTransition = null, Dictionary<string, IChoiceSegmentPath> choiceSegmentPath = null, List<string> additionalAttribute = null) : base(label, comment, action, guardBehavior, functionSpecification, incomingTransition, outgoingTransition, additionalAttribute)
        {
            if (choiceSegmentPath != null)
            {
                this.choiceSegmentPaths = choiceSegmentPath;
            }
        }

        /// <summary>
        /// Method that sets the choice segment path attribute 
        /// </summary>
        /// <param name="choiceSegmentPaths"></param>
        public void setContainsChoiceSegmentPath(Dictionary<string, IChoiceSegmentPath> choiceSegmentPaths)
        {
            this.choiceSegmentPaths = choiceSegmentPaths;
        }

        /// <summary>
        /// Method that returns a list of choice segment paths
        /// </summary>
        /// <returns>A list of choice segment paths</returns>
        public Dictionary<string, IChoiceSegmentPath> getChoiceSegmentPath()
        {
            return choiceSegmentPaths;
        }

        /// <summary>
        /// Factory Method that creats and returns a new empty instance of the choice segment class
        /// </summary>
        /// <returns>A new empty instance of the choice segment class</returns>
        new public ChoiceSegment factoryMethod()
        {
            ChoiceSegment choiceSegment = new ChoiceSegment();

            return choiceSegment;
        }

        /// <summary>
        /// Method that creates a new instance of the choice segment class
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
                    if (new ChoiceSegmentPath().GetType().IsInstanceOfType(allElements[s]))
                    {
                        this.choiceSegmentPaths.Add(allElements[s].getModelComponentID(), (ChoiceSegmentPath)allElements[s]);
                        int place = getAdditionalAttribute().IndexOf(s);
                        getAdditionalAttributeType().RemoveAt(place);
                        getAdditionalAttribute().Remove(s);
                    }

                }
            }
        }

        /// <summary>
        /// Method that exports a choice segment object to the file given in the filename
        /// </summary>
        /// <param name="last"></param>
        /// <param name="filename"></param>
        public override void exporting(bool last, string filename)
        {
            base.exporting(false, filename);

            using (StreamWriter sw = File.AppendText("../../../../" + filename + ".owl"))
            {
                foreach (KeyValuePair<string, IChoiceSegmentPath> i in choiceSegmentPaths)
                {
                    if (i.Value != null)
                    {
                        sw.WriteLine("      <standard-pass-ont:contains" + " rdf:resource=\"" + i.Value.getModelComponentID() + "\" ></standard-pass-ont:contains>");
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
