using System.Collections.Generic;
using System.IO;
using VDS.RDF;

namespace alps.net_api
{
    /// <summary>
    /// Class that represents a reminder transition
    /// </summary>
    public class ReminderTransition : TimeTransition, IReminderTransition
    {
        /// <summary>
        /// Name of the class
        /// </summary>
        new public const string className = "ReminderTransition";

        /// <summary>
        /// Constructor that creates a new empty instance of the reminder transition class
        /// </summary>
        public ReminderTransition()
        {
            setModelComponentID("ReminderTransition");
            setComment("The standart Element for ReminderTransition");
        }

        /// <summary>
        /// Constructor that creates a new fully specified instance of the reminder transition class
        /// </summary>
        /// <param name="additionalAttribute"></param>
        /// <param name="modelComponentID"></param>
        /// <param name="modelComponentLabel"></param>
        /// <param name="comment"></param>
        /// <param name="subjectBehavior"></param>
        /// <param name="belongsToaction"></param>
        /// <param name="sourceState"></param>
        /// <param name="targetState"></param>
        /// <param name="transitionCondition"></param>
        public ReminderTransition(List<string> additionalAttribute, string modelComponentID, List<string> modelComponentLabel, string comment, SubjectBehavior subjectBehavior, Action belongsToaction, State sourceState, State targetState, TransitionCondition transitionCondition)
        {
            setAdditionalAttribute(additionalAttribute);
            setModelComponentID(modelComponentID);
            setModelComponentLabel(modelComponentLabel);
            setComment(comment);
            setBelongsToSubjectBehavior(subjectBehavior);
            setBelongsToAction(belongsToaction);
            setSourceState(sourceState);
            setTargetState(targetState);
            setTransitionCondition(transitionCondition);

        }

        /// <summary>
        /// Constructor that creates a new fully specified instance of the reminder transition class
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="action"></param>
        /// <param name="sourceState"></param>
        /// <param name="targetState"></param>
        /// <param name="transitionCondition"></param>
        /// <param name="TransitionType"></param>
        /// <param name="additionalAttribute"></param>
        public ReminderTransition(string label, string comment = "", IAction action = null, IState sourceState = null, IState targetState = null, ITransitionCondition transitionCondition = null, transitionType TransitionType = transitionType.Standard, List<string> additionalAttribute = null) : base(label, comment, action, sourceState, targetState, transitionCondition, TransitionType, additionalAttribute)
        {

        }

        /// <summary>
        /// Factory method that creates and returns a new empty instance of the reminder transition class
        /// </summary>
        /// <returns>A new empty instance of the reminder transition class</returns>
        new public ReminderTransition factoryMethod()
        {
            ReminderTransition reminderTransition = new ReminderTransition();

            return reminderTransition;
        }

        /// <summary>
        /// Method that creates a new instance of the reminder transition class
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