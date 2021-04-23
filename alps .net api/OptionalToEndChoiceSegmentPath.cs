using System.Collections.Generic;

namespace alps.net_api
{
    /// <summary>
    /// Class that represents a optional to end choice segment path 
    /// </summary>
    public class OptionalToEndChoiceSegmentPath : ChoiceSegmentPath, IOptionalToEndChoiceSegmentPath
    {
        private IAction belongsToAction;
        private IChoiceSegmentPath choiceSegmentPath;
        private string tmpBelongsToAction;
        private string tmpChoiceSegmentPath;
        /// <summary>
        /// Name of the class
        /// </summary>
        new public const string className = "OptionalToEndChoiceSegmentPath";

        /// <summary>
        /// Constructor that creates a new empty instance of the optional to end choice segment path class
        /// </summary>
        public OptionalToEndChoiceSegmentPath()
        {
            setModelComponentID("OptionalToEndChoiceSegmentPath");
            setComment("The standart Element for OptionalToEndChoiceSegmentPath");
        }

        /// <summary>
        /// Constructor that creates a new fully specified instance of the optional to end choice segment path class
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
        /// <param name="belongsToaction"></param>
        /// <param name="choiceSegmentPath"></param>
        public OptionalToEndChoiceSegmentPath(List<string> additionalAttribute, string modelComponentID, List<string> modelComponentLabel, string comment, SubjectBehavior subjectBehavior, Transition incomingTransition, Transition outgoingTransition, FunctionSpecification functionSpecification, GuardBehavior guardBehavior, Action action, State endState, State initialState, bool optionalToEndChoiceSegmentPath, bool optionalToStartChoiceSegmentPath, Action belongsToaction, ChoiceSegmentPath choiceSegmentPath)
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
            setBelongsToAction(belongsToaction);
            setChoiceSegmentPath(choiceSegmentPath);
        }

        /// <summary>
        /// Method that sets the action attribute of the instance
        /// </summary>
        /// <param name="action"></param>
        public void setBelongsToAction(IAction action)
        {
            this.belongsToAction = action;
        }

        /// <summary>
        /// Method that returns the action attribute of the instance
        /// </summary>
        /// <returns>The action attribute of the instance</returns>
        public IAction getBelongsToAction()
        {
            return belongsToAction;
        }

        /// <summary>
        /// Method that sets the choice segment path attribute of the instance
        /// </summary>
        /// <param name="choiceSegmentPath"></param>
        public void setChoiceSegmentPath(IChoiceSegmentPath choiceSegmentPath)
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
        public string getTmpBelongsToAction()
        {
            return tmpBelongsToAction;
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
        /// Factory method that creates and returns a new empty instance of the optional to end choice segment path class
        /// </summary>
        /// <returns>A new empty instance of the optional to end choice segment path class</returns>
        new public OptionalToEndChoiceSegmentPath factoryMethod()
        {
            OptionalToEndChoiceSegmentPath optionalToEndChoiceSegmentPath = new OptionalToEndChoiceSegmentPath();

            return optionalToEndChoiceSegmentPath;
        }

        /// <summary>
        /// Method that creates a new instance of the optional to End choice segment path class
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
                    if (new Action().GetType().IsInstanceOfType(allElements[s]))
                    {
                        this.belongsToAction = (Action)allElements[s];
                        tmp.Remove(s);
                    }

                    if (new ChoiceSegmentPath().GetType().IsInstanceOfType(allElements[s]))
                    {
                        this.choiceSegmentPath = (ChoiceSegmentPath)allElements[s];
                        tmp.Remove(s);
                    }
                }
            }
        }
    }
}
