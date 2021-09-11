using System;
using System.Collections.Generic;
using VDS.RDF;
using System.IO;

namespace alps.net_api
{
    /// <summary>
    /// Class that represents an Macro behavior of a Subject
    /// </summary>

    public class MacroBehavior : SubjectBehavior, IMacroBehavior
    {
        private List<StateReference> stateReferences = new List<StateReference>();
        private List<string> tmpStateReference = new List<string>();
        /// <summary>
        /// Name of the class
        /// </summary>
        new public const string className = "MacroBehavior";

        /// <summary>
        /// Constructor that creates a new empty instance of the macro behavior class
        /// </summary>
        public MacroBehavior()
        {
            setModelComponentID("MacroBehavior");
            setComment("The standart Element for MacroBehavior");
        }

        /// <summary>
        /// Constructor that creates a new fully specified instance of the macro behavior class
        /// </summary>
        /// <param name="additionalAttribute"></param>
        /// <param name="modelComponentID"></param>
        /// <param name="modelComponentLabel"></param>
        /// <param name="comment"></param>
        /// <param name="behaviorDescriptionComponent"></param>
        /// <param name="endState"></param>
        /// <param name="initialStateOfBehavior"></param>
        /// <param name="priorityNumber"></param>
        /// <param name="stateReferences"></param>
        public MacroBehavior(List<string> additionalAttribute, string modelComponentID, List<string> modelComponentLabel, string comment, BehaviorDescriptionComponent behaviorDescriptionComponent, State endState, InitialStateOfBehavior initialStateOfBehavior, int priorityNumber, List<StateReference> stateReferences)
        {
            setAdditionalAttribute(additionalAttribute);
            setModelComponentID(modelComponentID);
            setModelComponentLabel(modelComponentLabel);
            setComment(comment);
            setContainsBehaviorDescribingComponent(behaviorDescriptionComponent);
            setEndState(endState);
            setInitialState(initialStateOfBehavior);
            setPriorityNumber(priorityNumber);
            setContainsStateReference(stateReferences);

        }

        /// <summary>
        /// Method that sets the state references attribute of the instance
        /// </summary>
        /// <param name="stateReferences"></param>
        public void setContainsStateReference(List<StateReference> stateReferences)
        {
            this.stateReferences = stateReferences;
        }

        /// <summary>
        /// Method that returns the state references attribute of the instance
        /// </summary>
        /// <returns></returns>
        public List<StateReference> getStateReferences()
        {
            return stateReferences;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<string> getTmpStateReference()
        {
            return tmpStateReference;
        }

        /// <summary>
        /// Factory method that creates and returns a new empty instance of the macro bahavior class
        /// </summary>
        /// <returns></returns>
        new public MacroBehavior factoryMethod()
        {
            MacroBehavior macroBehavior = new MacroBehavior();

            return macroBehavior;
        }

        /// <summary>
        /// Method that creates a new instance of the macro behavior class
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
                    if (new StateReference().GetType().IsInstanceOfType(allElements[s]))
                    {
                        this.stateReferences.Add((StateReference)allElements[s]);
                        int place = getAdditionalAttribute().IndexOf(s);
                        getAdditionalAttributeType().RemoveAt(place);
                        getAdditionalAttribute().Remove(s);
                        //tmp.Remove(s);
                    }
                }
            }
        }


        /// <summary>
        /// Method that exports an macro behavior object to the file given in the filename
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
