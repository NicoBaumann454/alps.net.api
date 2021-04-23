using System.Collections.Generic;
using System.IO;
using VDS.RDF;

namespace alps.net_api
{
    /// <summary>
    /// Class that represents a time based reminder transition condition
    /// </summary>
    public class TimeBasedReminderTransitionCondition : ReminderEventTransitionCondition, ITimeBasedReminderTransitionCondition
    {
        /// <summary>
        /// Name of the class
        /// </summary>
        new public const string className = "TimeBasedReminderTransitionCondition";

        /// <summary>
        /// Constructor that creates a new empty instance of the time based reminder transition condition class
        /// </summary>
        public TimeBasedReminderTransitionCondition()
        {
            setModelComponentID("TimeBasedReminderTransitionCondition");
            setComment("The standart Element for TimeBasedReminderTransitionCondition");
        }

        /// <summary>
        /// Constructor that creates a new fully specified instance of the time based reminder transition condition class
        /// </summary>
        public TimeBasedReminderTransitionCondition(List<string> additionalAttribute, string modelComponentID, List<string> modelComponentLabel, string comment, SubjectBehavior subjectBehavior, string toolSpecificDefintion, string timeValue)
        {
            setAdditionalAttribute(additionalAttribute);
            setModelComponentID(modelComponentID);
            setModelComponentLabel(modelComponentLabel);
            setComment(comment);
            setBelongsToSubjectBehavior(subjectBehavior);
            setToolSpecificDefiniton(toolSpecificDefintion);
            setTimeValue(timeValue);
        }

        /// <summary>
        /// Factory method that creates and returns a new empty instance of the time based reminder transition condition class
        /// </summary>
        /// <returns>A new empty instance of the time based reminder transition condition class</returns>
        new public TimeBasedReminderTransitionCondition factoryMethod()
        {
            TimeBasedReminderTransitionCondition timeBasedReminderTransitionCondition = new TimeBasedReminderTransitionCondition();

            return timeBasedReminderTransitionCondition;
        }

        /// <summary>
        /// Method that creates a new instance of the time based reminder transition condition class
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
