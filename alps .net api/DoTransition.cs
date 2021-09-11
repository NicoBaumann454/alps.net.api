using System;
using System.Collections.Generic;
using System.IO;
using VDS.RDF;

namespace alps.net_api
{
    /// <summary>
    /// Class that represents a DoTransition
    /// </summary>

    public class DoTransition : Transition, IDoTransition
    {
        private int priorityNumber = 0;
        /// <summary>
        /// Name of the class
        /// </summary>
        new public const string className = "DoTransition";

        /// <summary>
        /// Constructor that creates a new empty instance of the do transition class
        /// </summary>
        public DoTransition()
        {
            setModelComponentID("DoTransition");
            setComment("The standart Element for DoTransition");
        }

        /// <summary>
        /// Constructor that creates a new fully specified instance of the do transition class
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
        /// <param name="nonNegativInteger"></param>
        public DoTransition(List<string> additionalAttribute, string modelComponentID, List<string> modelComponentLabel, string comment, SubjectBehavior subjectBehavior, Action belongsToaction, State sourceState, State targetState, TransitionCondition transitionCondition, int nonNegativInteger)
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
            setPriorityNumber(nonNegativInteger);

        }

        /// <summary>
        /// Constructor that creates a new fully specified instance of the do transition class
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="action"></param>
        /// <param name="sourceState"></param>
        /// <param name="targetState"></param>
        /// <param name="transitionCondition"></param>
        /// <param name="priorityNumber"></param>
        /// <param name="TransitionType"></param>
        /// <param name="additionalAttribute"></param>
        public DoTransition(string label, string comment = "", IAction action = null, IState sourceState = null, IState targetState = null, ITransitionCondition transitionCondition = null, int priorityNumber = 0, transitionType TransitionType = transitionType.Standard, List<string> additionalAttribute = null) : base(label, comment, action, sourceState, targetState, transitionCondition, TransitionType, additionalAttribute)
        {
            this.priorityNumber = priorityNumber;
        }

        /// <summary>
        /// Method that sets the priority number attribute
        /// </summary>
        /// <param name="nonNegativInteger"></param>
        public void setPriorityNumber(int nonNegativInteger)
        {
            this.priorityNumber = nonNegativInteger;
        }

        /// <summary>
        /// Method that returns the priority number attribute
        /// </summary>
        /// <returns>The priority number attribute</returns>
        public int getPriorityNumber()
        {
            return priorityNumber;
        }

        /// <summary>
        /// Factory method that creates and returns a new empty instance of the do transition class
        /// </summary>
        /// <returns></returns>
        new public DoTransition factoryMethod()
        {
            DoTransition doTransition = new DoTransition();

            return doTransition;
        }

        /// <summary>
        /// Method that creates a new instance of the do transition class
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="attributeType"></param>
        /// <returns></returns>
        public override bool createInstance(List<string> attribute, List<string> attributeType)
        {
            base.createInstance(attribute, attributeType);
            bool result = false;
            int counter = 0;
            List<int> toBeRemoved = new List<int>();

            foreach (string s in attributeType)
            {

                if (s.Contains("hasPriorityNumber"))
                {
                    //Hier muss ich noch herausfinden wie ich aus dem String den int mache, das sollte an sich gehen, sonst wird aus dem int ein String gemacht 
                    //(verschiebt aber nur das Problem von jetzt zu später)

                    //priorityNumber = attribute[counter];

                    string tmpPriorityNumber = s.Split('^')[0];

                    toBeRemoved.Add(counter);
                }

                counter++;
            }

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
        /// Method that exports a do transition object to the file given in the filename
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
