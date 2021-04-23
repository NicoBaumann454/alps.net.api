using System.Collections.Generic;
using System.IO;

namespace alps.net_api
{
    /// <summary>
    /// Class that represents a BusinessDayTimerTransitionCondition
    /// </summary>

    public class BusinessDayTimerTransitionCondition : TimerTransitionCondition, IBusinessDayTimerTransitionCondition
    {
        /// <summary>
        /// Constructor that creates a empty instance of the Buisness Day Timer Transition Condition class
        /// </summary>
        public BusinessDayTimerTransitionCondition()
        {
            setModelComponentID("BusinessDayTimerTransitionCondition");
            setComment("The standart Element for BusinessDayTimerTransitionCondition");
        }

        /// <summary>
        /// Constructor that creates a fully specified instance of the Buisness Day Timer Transition Condition class
        /// </summary>
        /// <param name="additionalAttribute"></param>
        /// <param name="modelComponentID"></param>
        /// <param name="modelComponentLabel"></param>
        /// <param name="comment"></param>
        /// <param name="subjectBehavior"></param>
        /// <param name="toolSpecificDefintion"></param>
        /// <param name="timeValue"></param>
        public BusinessDayTimerTransitionCondition(List<string> additionalAttribute, string modelComponentID, List<string> modelComponentLabel, string comment, SubjectBehavior subjectBehavior, string toolSpecificDefintion, string timeValue)
        {
            setAdditionalAttribute(additionalAttribute);
            setModelComponentID(modelComponentID);
            setModelComponentLabel(modelComponentLabel);
            setComment(comment);
            setBelongsToSubjectBehavior(subjectBehavior);
            setToolSpecificDefiniton(toolSpecificDefintion);
            setTimeValue(timeValue);

        }

        /*
        new public BuisnessDayTimerTransitionCondition factoryMethod()
        {
            BuisnessDayTimerTransitionCondition buisnessDayTimerTransitionCondition = new BuisnessDayTimerTransitionCondition();

            return buisnessDayTimerTransitionCondition;
        }
        */

        /// <summary>
        /// Method that creates a new instance of the buisness day timer transition condition
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="attributeType"></param>
        /// <returns></returns>
        public override bool createInstance(List<string> attribute, List<string> attributeType)
        {
            base.createInstance(attribute, attributeType);

            emptyAdditionalAttribute();

            return true;

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
        /// Method that exports an buisness day timer transition condition to the file given in the filename
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
