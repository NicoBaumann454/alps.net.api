using System.Collections.Generic;
using System.IO;

namespace alps.net_api
{
    /// <summary>
    /// Class that represents an action
    /// </summary>
    public class Action : BehaviorDescriptionComponent, IAction
    {
        private IState state;
        private Dictionary<string, ITransition> transition = new Dictionary<string, ITransition>();
        private string tmpState;
        private string tmpTrasition;
        /// <summary>
        /// Constructor that creates a new empty instance of the action class
        /// </summary>
        public Action()
        {
            setModelComponentID("Action");
            setComment("The standart Element for Action");
        }

        /// <summary>
        /// Creates a new fully specified instance of the action class
        /// </summary>
        /// <param name="additionalAttribute"></param>
        /// <param name="modelComponentID"></param>
        /// <param name="modelComponentLabel"></param>
        /// <param name="comment"></param>
        /// <param name="subjectBehavior"></param>
        /// <param name="state"></param>
        /// <param name="transition"></param>
        public Action(List<string> additionalAttribute, string modelComponentID, List<string> modelComponentLabel, string comment, SubjectBehavior subjectBehavior, State state, Transition transition)
        {
            setAdditionalAttribute(additionalAttribute);
            setModelComponentID(modelComponentID);
            setModelComponentLabel(modelComponentLabel);
            setComment(comment);
            setBelongsToSubjectBehavior(subjectBehavior);
            setContainsState(state);
            setContainsTransition(transition);
        }

        /// <summary>
        /// Constructor that creates a new fully specified instance of the action class
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="state"></param>
        /// <param name="transitions"></param>
        /// <param name="additionalAttribute"></param>
        public Action(string label, string comment = "", IState state = null, Dictionary<string, ITransition> transitions = null, List<string> additionalAttribute = null) : base(label, comment, additionalAttribute)
        {
            if (state != null)
            {
                this.state = state;
            }

            if (transitions != null)
            {
                this.transition = transitions;
            }
        }

        /// <summary>
        /// Sets the state Attribute of the action class
        /// </summary>
        /// <param name="state"></param>
        public void setContainsState(IState state)
        {
            this.state = state;
        }

        /// <summary>
        /// Returns the state attribute of the action class
        /// </summary>
        /// <returns>The state attribute of the action class</returns>
        public IState getState()
        {
            return state;
        }

        /// <summary>
        /// Sets the transition attribute of the action class
        /// </summary>
        /// <param name="transition"></param>
        public void setContainsTransition(ITransition transition)
        {
            this.transition.Add(transition.getModelComponentID(), transition);
        }

        /// <summary>
        /// Gets the transition attribute of the action class
        /// </summary>
        /// <returns>The transition of the action class</returns>
        public Dictionary<string, ITransition> getTransition()
        {
            return transition;
        }

        /// <summary>
        /// Method that creates a new empty instance of the action class
        /// </summary>
        /// <returns>A new empty instance of the action class</returns>
        new public Action factoryMethod()
        {
            Action action = new Action();

            return action;
        }

        /// <summary>
        /// Creates a new instance of the action class
        /// </summary>
        /// <returns>A boolean that shows if the creation worked</returns>
        public override bool createInstance(List<string> attribute, List<string> attributeType)
        {
            base.createInstance(attribute, attributeType);

            emptyAdditionalAttribute();

            bool result = false;
            int counter = 0;
            List<int> toBeRemoved = new List<int>();

            foreach (string s in attributeType)
            {

                if (s.Contains("containsState"))
                {
                    tmpState = attribute[counter];
                    toBeRemoved.Add(counter);
                }

                if (s.Contains("containsTransition"))
                {
                    tmpTrasition = attribute[counter];
                    toBeRemoved.Add(counter);
                }

                counter++;
            }

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
                    if (new State().GetType().IsInstanceOfType(allElements[s]))
                    {
                        this.state = (State)allElements[s];
                        int place = getAdditionalAttribute().IndexOf(s);
                        getAdditionalAttributeType().RemoveAt(place);
                        getAdditionalAttribute().Remove(s);
                        //tmp.Remove(s);
                    }

                    if (new Transition().GetType().IsInstanceOfType(allElements[s]))
                    {
                        this.transition.Add(allElements[s].getModelComponentID(), (Transition)allElements[s]);
                        int place = getAdditionalAttribute().IndexOf(s);
                        getAdditionalAttributeType().RemoveAt(place);
                        getAdditionalAttribute().Remove(s);
                        //tmp.Remove(s);
                    }
                }
            }

        }

        /// <summary>
        /// Method that exports an action obejct to the file given in the filename
        /// </summary>
        /// <param name="last"></param>
        /// <param name="filename"></param>
        public override void exporting(bool last, string filename)
        {
            base.exporting(false, filename);

            using (StreamWriter sw = File.AppendText("../../../../" + filename + ".owl"))
            {

                if (state != null)
                {
                    sw.WriteLine("      <standard-pass-ont:contains" + " rdf:resource=\"" + state.getModelComponentID() + "\" ></standard-pass-ont:contains>");
                }

                foreach (KeyValuePair<string, ITransition> s in transition)
                {
                    sw.WriteLine("      <standard-pass-ont:contains" + " rdf:resource=\"" + s.Value.getModelComponentID() + "\" ></standard-pass-ont:contains>");
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