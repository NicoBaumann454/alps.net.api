using System.Collections.Generic;
using System.IO;

namespace alps.net_api
{
    /// <summary>
    /// Class that represents a BehaviorDescriptionComponent
    /// </summary>

    public class BehaviorDescriptionComponent : PASSProcessModelElement, IBehaviorDescriptionComponent
    {

        private ISubjectBehavior subjectBehavior;
        private string tmpSubjectBahavior;
        /// <summary>
        /// Constructor that creates an empty instance of the Behavior Description Component class
        /// </summary>
        public BehaviorDescriptionComponent()
        {
            setModelComponentID("BehaviorDescriptionComponent");
            setComment("The standart Element for BehaviorDescriptionComponent");
        }

        /// <summary>
        /// Constructor that creates a new fully specified instance of the Behavior Description Component class
        /// </summary>
        /// <param name="additionalAttribute"></param>
        /// <param name="modelComponentID"></param>
        /// <param name="modelComponentLabel"></param>
        /// <param name="comment"></param>
        /// <param name="subjectBehavior"></param>
        public BehaviorDescriptionComponent(List<string> additionalAttribute, string modelComponentID, List<string> modelComponentLabel, string comment, SubjectBehavior subjectBehavior)
        {
            setAdditionalAttribute(additionalAttribute);
            setModelComponentID(modelComponentID);
            setModelComponentLabel(modelComponentLabel);
            setComment(comment);
            setBelongsToSubjectBehavior(subjectBehavior);
        }

        /// <summary>
        /// Constructor that creates an instance of the behavior description component
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="additionalAttribute"></param>
        public BehaviorDescriptionComponent(string label, string comment = "", List<string> additionalAttribute = null) : base(label, comment, additionalAttribute)
        {

        }

        /// <summary>
        /// Method that sets the subject behavior attribute of the Behavior Description Component class
        /// </summary>
        /// <param name="subjectBehavior"></param>
        public void setBelongsToSubjectBehavior(ISubjectBehavior subjectBehavior)
        {
            this.subjectBehavior = subjectBehavior;
        }

        /// <summary>
        /// Method that returns the subject behavior of the Behavior Description Component class
        /// </summary>
        /// <returns>The subject behavior of the Behavior Description Component class</returns>
        public ISubjectBehavior getSubjectBehavior()
        {
            return subjectBehavior;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getTmpSubjectBehavior()
        {
            return tmpSubjectBahavior;
        }

        /// <summary>
        /// Factory Method that creates a new empty instance of the Behavior Description Component class
        /// </summary>
        /// <returns>A new empty instance of the Behavior Description Component class</returns>
        new public BehaviorDescriptionComponent factoryMethod()
        {
            BehaviorDescriptionComponent behaviorDescriptionComponent = new BehaviorDescriptionComponent();

            return behaviorDescriptionComponent;
        }

        /// <summary>
        /// Method that creates a new instance of the behavior description class
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="attributeType"></param>
        /// <returns></returns>
        public override bool createInstance(List<string> attribute, List<string> attributeType)
        {
            base.createInstance(attribute, attributeType);

            emptyAdditionalAttribute();

            bool result = false;
            int counter = 0;
            List<int> toBeRemoved = new List<int>();

            foreach (string s in attributeType)
            {

                if (s.Contains("belongsTo"))
                {
                    tmpSubjectBahavior = attribute[counter];
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
                    if (new SubjectBehavior().GetType().IsInstanceOfType(allElements[s]) && getAdditionalAttributeType()[getAdditionalAttribute().IndexOf(s)].Contains("belongsTo"))
                    {
                        this.subjectBehavior = (SubjectBehavior)allElements[s];
                        int place = getAdditionalAttribute().IndexOf(s);
                        if (place >= 0)
                        {
                            getAdditionalAttributeType().RemoveAt(place);
                            getAdditionalAttribute().Remove(s);
                        }
                        //tmp.Remove(s);
                    }
                }
            }



        }

        /// <summary>
        /// Method that exports an behavior description component to the file given in the filename
        /// </summary>
        /// <param name="last"></param>
        /// <param name="filename"></param>
        public override void exporting(bool last, string filename)
        {
            base.exporting(false, filename);

            using (StreamWriter sw = File.AppendText("../../../../" + filename + ".owl"))
            {

                if (subjectBehavior != null)
                {
                    sw.WriteLine("      <standard-pass-ont:belongsTo" + " rdf:resource=\"" + subjectBehavior.getModelComponentID() + "\" ></standard-pass-ont:belongsTo>");
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