using System;
using System.Collections.Generic;
using System.IO;
using VDS.RDF;

namespace alps.net_api
{
    /// <summary>
    /// Class that represents a year month timer transition condition
    /// </summary>
    public class YearMonthTimerTransitionCondition : TimerTransitionCondition, IYearMonthTimerTransitionCondition
    {
        private string yearMonthDuration = "";
        /// <summary>
        /// Name of the class
        /// </summary>
        new public const string className = "YearMonthTimerTransitionCondition";

        /// <summary>
        /// Constructor that creates a new empty instance of the year month timer transition condition class
        /// </summary>
        public YearMonthTimerTransitionCondition()
        {
            setModelComponentID("YearMonthTimerTransitionCondition");
            setComment("The standart Element for YearMonthTimerTransitionCondition");
        }

        /// <summary>
        /// Constructor that creates a new fully specified instance of the year month timer transition condition class
        /// </summary>
        /// <param name="additionalAttribute"></param>
        /// <param name="modelComponentID"></param>
        /// <param name="modelComponentLabel"></param>
        /// <param name="comment"></param>
        /// <param name="subjectBehavior"></param>
        /// <param name="toolSpecificDefintion"></param>
        /// <param name="timeValue"></param>
        /// <param name="yearMonthDuration"></param>
        public YearMonthTimerTransitionCondition(List<string> additionalAttribute, string modelComponentID, List<string> modelComponentLabel, string comment, SubjectBehavior subjectBehavior, string toolSpecificDefintion, string timeValue, string yearMonthDuration)
        {
            setAdditionalAttribute(additionalAttribute);
            setModelComponentID(modelComponentID);
            setModelComponentLabel(modelComponentLabel);
            setComment(comment);
            setBelongsToSubjectBehavior(subjectBehavior);
            setToolSpecificDefiniton(toolSpecificDefintion);
            setTimeValue(timeValue);
            setYearMonthDuration(yearMonthDuration);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="toolSpecificDefintion"></param>
        /// <param name="timeValue"></param>
        /// <param name="additionalAttribute"></param>
        public YearMonthTimerTransitionCondition(string label, string comment = "", string toolSpecificDefintion = "", string timeValue = "", List<string> additionalAttribute = null) : base(label, comment, toolSpecificDefintion, timeValue, additionalAttribute)
        {

        }

        /// <summary>
        /// Method that sets the year month duration attribute
        /// </summary>
        /// <param name="yearMonthDuration"></param>
        public void setYearMonthDuration(string yearMonthDuration)
        {
            this.yearMonthDuration = yearMonthDuration;
        }

        /// <summary>
        /// Method that returns the year month duration attribute
        /// </summary>
        /// <returns>The year month Duration attribute</returns>
        public string getYearMonthDuration()
        {
            return yearMonthDuration;
        }

        /// <summary>
        /// Factory method that creates and returns a new empty instance of the year month timer transition condition 
        /// </summary>
        /// <returns></returns>
        new public YearMonthTimerTransitionCondition factoryMethod()
        {
            YearMonthTimerTransitionCondition yearMonthTimerTransitionCondition = new YearMonthTimerTransitionCondition();

            return yearMonthTimerTransitionCondition;
        }

        /// <summary>
        /// Method that creates a new instance of the year month timer transition condition class
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
        /// <param name="last"></param>
        /// <param name="filename"></param>
        public override void exporting(bool last, string filename)
        {
            base.exporting(false, filename);

            using (StreamWriter sw = File.AppendText("../../../../" + filename + ".owl"))
            {

                if (yearMonthDuration != null)
                {
                    //sw.WriteLine("      <standard-pass-ont:containsBaseBehavior" + " rdf:resource=\"" + lowerBound + "\" ></standard-pass-ont:containsBaseBehavior>");
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