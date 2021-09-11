using System;
using System.Collections.Generic;
using System.IO;
using VDS.RDF;

namespace alps.net_api
{
    /// <summary>
    /// Class that represents a DayTimerTranstitionCondition
    /// </summary>

    public class DayTimerTransitionCondition : TimerTransitionCondition, IDayTimerTransitionCondition
    {
        private string dateTimeValue;
        /// <summary>
        /// Name of the class
        /// </summary>
        new public const string className = "DayTimerTransitionCondition";

        /// <summary>
        /// Constructor that creates a new empty instance of the day timer transition condition class
        /// </summary>
        public DayTimerTransitionCondition()
        {
            setModelComponentID("DayTimerTransitionCondition");
            setComment("The standart Element for DayTimerTransitionCondition");
        }

        /// <summary>
        /// Constructor that creates a new fully specified instance of the day timer transition condition class
        /// </summary>
        /// <param name="additionalAttribute"></param>
        /// <param name="modelComponentID"></param>
        /// <param name="modelComponentLabel"></param>
        /// <param name="comment"></param>
        /// <param name="subjectBehavior"></param>
        /// <param name="toolSpecificDefintion"></param>
        /// <param name="timeValue"></param>
        /// <param name="dateTimeValue"></param>
        public DayTimerTransitionCondition(List<string> additionalAttribute, string modelComponentID, List<string> modelComponentLabel, string comment, SubjectBehavior subjectBehavior, string toolSpecificDefintion, string timeValue, string dateTimeValue)
        {
            setAdditionalAttribute(additionalAttribute);
            setModelComponentID(modelComponentID);
            setModelComponentLabel(modelComponentLabel);
            setComment(comment);
            setBelongsToSubjectBehavior(subjectBehavior);
            setToolSpecificDefiniton(toolSpecificDefintion);
            setTimeValue(timeValue);
            setDateTimeValue(dateTimeValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="toolSpecificDefintion"></param>
        /// <param name="timeValue"></param>
        /// <param name="additionalAttribute"></param>
        public DayTimerTransitionCondition(string label, string comment = "", string toolSpecificDefintion = "", string timeValue = "", List<string> additionalAttribute = null) : base(label, comment, toolSpecificDefintion, timeValue, additionalAttribute)
        {

        }

        /// <summary>
        /// Method that sets the date time value attribute
        /// </summary>
        /// <param name="dateTimeValue"></param>
        public void setDateTimeValue(string dateTimeValue)
        {
            this.dateTimeValue = dateTimeValue;
        }

        /// <summary>
        /// Method that returns the date time value attribute
        /// </summary>
        /// <returns>The date time value attribute</returns>
        public string getDateTimeValue()
        {
            return dateTimeValue;
        }

        /// <summary>
        /// Factory method that creates and returns a new instance of the day timer transition condition class
        /// </summary>
        /// <returns>A new instance of the day timer transition condition class</returns>
        new public DayTimerTransitionCondition factoryMethod()
        {
            DayTimerTransitionCondition dayTimerTransitionCondition = new DayTimerTransitionCondition();

            return dayTimerTransitionCondition;
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
        /// Method that exports a day timer transition condition object to the file given in the filename
        /// </summary>
        /// <param name="last"></param>
        /// <param name="filename"></param>
        public override void exporting(bool last, string filename)
        {
            base.exporting(false, filename);

            using (StreamWriter sw = File.AppendText("../../../../" + filename + ".owl"))
            {

                if (dateTimeValue != null)
                {
                    //sw.WriteLine("      <standard-pass-ont:hasEndState" + " rdf:resource=\"" + dateTimeValue + "\" ></standard-pass-ont:hasEndState>");
                }

                Console.WriteLine("################## nochmal drüber schauen in daytimetransitionCondition ++++++++++++++++++++++");

                if (last)
                {
                    sw.WriteLine("      <rdf:type rdf:resource=" + "\"&standard-pass-ont;" + this.GetType().ToString().Split('.')[2] + "\" ></rdf:type>");
                    sw.WriteLine("  </owl:NamedIndividual>");
                }
            }
        }
    }
}
