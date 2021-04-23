using System.Collections.Generic;
using System.IO;
using VDS.RDF;

namespace alps.net_api
{
    /// <summary>
    /// Class that represents a subject base behavior class
    /// </summary>
    public class SubjectBaseBehavior : SubjectBehavior, ISubjectBaseBehavior
    {
        /// <summary>
        /// Name of the class
        /// </summary>
        new public const string className = "SubjectBaseBehavior";

        /// <summary>
        /// Constructor that creates a new empty instance of the subject base behavior class
        /// </summary>
        public SubjectBaseBehavior()
        {
            setModelComponentID("SubjectBaseBehavior");
            setComment("The standart Element for SubjectBaseBehavior");
        }

        /// <summary>
        /// Constructor that creates a new fully specified instance of the subject base behavior class
        /// </summary>
        /// <param name="additionalAttribute"></param>
        /// <param name="modelComponentID"></param>
        /// <param name="modelComponentLabel"></param>
        /// <param name="comment"></param>
        /// <param name="behaviorDescriptionComponent"></param>
        /// <param name="endState"></param>
        /// <param name="initialStateOfBehavior"></param>
        /// <param name="priorityNumber"></param>
        public SubjectBaseBehavior(List<string> additionalAttribute, string modelComponentID, List<string> modelComponentLabel, string comment, BehaviorDescriptionComponent behaviorDescriptionComponent, State endState, InitialStateOfBehavior initialStateOfBehavior, int priorityNumber)
        {
            setAdditionalAttribute(additionalAttribute);
            setModelComponentID(modelComponentID);
            setModelComponentLabel(modelComponentLabel);
            setComment(comment);
            setContainsBehaviorDescribingComponent(behaviorDescriptionComponent);
            setEndState(endState);
            setInitialState(initialStateOfBehavior);
            setPriorityNumber(priorityNumber);
        }

        /// <summary>
        /// Factory method that creates and returns a new empty instance of the subject base behavior class
        /// </summary>
        /// <returns>A new empty instance of the subject base behavior class</returns>
        new public SubjectBaseBehavior factoryMethod()
        {
            SubjectBaseBehavior subjectBaseBehavior = new SubjectBaseBehavior();

            return subjectBaseBehavior;
        }

        /// <summary>
        /// Method that creates a new instance of the subject behavior class
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
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="g"></param>
        public override void export(ref Graph g)
        {
            base.export(ref g);
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
                if (last)
                {
                    sw.WriteLine("      <rdf:type rdf:resource=" + "\"&standard-pass-ont;" + this.GetType().ToString().Split('.')[2] + "\" ></rdf:type>");
                    sw.WriteLine("  </owl:NamedIndividual>");
                }
            }
        }
    }
}
