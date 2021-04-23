using System.Collections.Generic;
using System.IO;

namespace alps.net_api
{
    /// <summary>
    /// Class that represents an FullySpecifiedSubject
    /// </summary>

    public class FullySpecifiedSubject : Subject, IFullySpecifiedSubject
    {
        private ISubjectBehavior subjectBaseBehavior;
        private ISubjectBehavior subjectBehavior;
        private ISubjectDataDefinition subjectDataDefinition;
        private IInputPoolConstraint inputPoolConstraint;
        private string tmpSubjectBaseBehavior;
        private string tmpSubjectBehavior;
        private string tmpSubjectDataDefinition;
        private string tmpInputPoolConstraint;
        /// <summary>
        /// Name of the class
        /// </summary>
        new public static string className = "FullySpecifiedSubject";

        /// <summary>
        /// Constructor that creates a new empty instance of the fully specified subject class
        /// </summary>
        public FullySpecifiedSubject()
        {
            setModelComponentID("FullySpecifiedSubject");
            setComment("The standart Element for FullySpecifiedSubject");
        }

        /// <summary>
        /// Constructor that creates a new fully specified instance of the fully specified subject class
        /// </summary>
        /// <param name="additionalAttribute"></param>
        /// <param name="modelComponentID"></param>
        /// <param name="modelComponentLabel"></param>
        /// <param name="comment"></param>
        /// <param name="incomingMessageExchange"></param>
        /// <param name="instanceRestriction"></param>
        /// <param name="outgoingMessageExchange"></param>
        /// <param name="subjectBaseBehavior"></param>
        /// <param name="subjectBehavior"></param>
        /// <param name="subjectDataDefinition"></param>
        /// <param name="inputPoolConstraint"></param>
        public FullySpecifiedSubject(List<string> additionalAttribute, string modelComponentID, List<string> modelComponentLabel, string comment, MessageExchange incomingMessageExchange, int instanceRestriction, MessageExchange outgoingMessageExchange, SubjectBaseBehavior subjectBaseBehavior, SubjectBehavior subjectBehavior, SubjectDataDefinition subjectDataDefinition, InputPoolConstraint inputPoolConstraint)
        {
            setAdditionalAttribute(additionalAttribute);
            setModelComponentID(modelComponentID);
            setModelComponentLabel(modelComponentLabel);
            setComment(comment);
            setIncomingMessageExchange(incomingMessageExchange);
            setMaximumSubjectInstanceRestriction(instanceRestriction);
            setOutgoingMessageExchange(outgoingMessageExchange);
            setContainsBaseBehavior(subjectBaseBehavior);
            setContainsBehavior(subjectBehavior);
            setDataDefintion(subjectDataDefinition);
            setInputPoolConstraint(inputPoolConstraint);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="incomingMessageExchange"></param>
        /// <param name="outgoingMessageExchange"></param>
        /// <param name="maxSubjectInstanceRestriction"></param>
        /// <param name="additionalAttribute"></param>
        /// <param name="inputPoolConstraint"></param>
        /// <param name="subjectDataDefinition"></param>
        public FullySpecifiedSubject(string label, string comment = "", IMessageExchange incomingMessageExchange = null, IMessageExchange outgoingMessageExchange = null, int maxSubjectInstanceRestriction = 1, ISubjectDataDefinition subjectDataDefinition = null, IInputPoolConstraint inputPoolConstraint = null, List<string> additionalAttribute = null) : base(label, comment, incomingMessageExchange, outgoingMessageExchange, maxSubjectInstanceRestriction, additionalAttribute)
        {
            if (inputPoolConstraint != null)
            {
                this.inputPoolConstraint = inputPoolConstraint;
            }

            if (subjectDataDefinition != null)
            {
                this.subjectDataDefinition = subjectDataDefinition;
            }

            string subjectBahaviorLabel = "subjectBehaviorTo" + label;
            SubjectBehavior subjectBehavior = new SubjectBehavior(subjectBahaviorLabel, "This is the subject behavior to the fully specified subject: " + this.getModelComponentID());

            this.subjectBehavior = subjectBehavior;
        }

        /// <summary>
        /// Method that sets the subject base behavior attribute 
        /// </summary>
        /// <param name="subjectBaseBehavior"></param>
        public void setContainsBaseBehavior(ISubjectBehavior subjectBaseBehavior)
        {
            this.subjectBaseBehavior = subjectBaseBehavior;
        }

        /// <summary>
        /// Method that sets the subject behavior attribute
        /// </summary>
        /// <param name="subjectBehavior"></param>
        public void setContainsBehavior(ISubjectBehavior subjectBehavior)
        {
            this.subjectBehavior = subjectBehavior;
        }

        /// <summary>
        /// Method that sets the subject data definition attribute
        /// </summary>
        /// <param name="subjectDataDefinition"></param>
        public void setDataDefintion(ISubjectDataDefinition subjectDataDefinition)
        {
            this.subjectDataDefinition = subjectDataDefinition;
        }

        /// <summary>
        /// Method that sets the input pool constraint attribute
        /// </summary>
        /// <param name="inputPoolConstraint"></param>
        public void setInputPoolConstraint(IInputPoolConstraint inputPoolConstraint)
        {
            this.inputPoolConstraint = inputPoolConstraint;
        }

        /// <summary>
        /// Method that returns the subject base behavior attribute
        /// </summary>
        /// <returns>The subject base behavior attribute</returns>
        public ISubjectBehavior getSubjectBaseBehavior()
        {
            if (tmpSubjectBaseBehavior != "")
            {
                return this.subjectBaseBehavior;
            }

            SubjectBaseBehavior subjectBaseBehavior = new SubjectBaseBehavior();

            return subjectBaseBehavior;
        }

        /// <summary>
        /// Method that returns the subject behavior attribute
        /// </summary>
        /// <returns>The subject behavior attribute</returns>
        public ISubjectBehavior getSubjectBehavior()
        {
            if (tmpSubjectBehavior != "")
            {
                return this.subjectBehavior;
            }

            SubjectBehavior subjectBehavior = new SubjectBehavior();

            return subjectBehavior;
        }

        /// <summary>
        /// Method that returns the subject data definition attribute
        /// </summary>
        /// <returns>The subject data definition attribute</returns>
        public ISubjectDataDefinition getSubjectDataDefinition()
        {
            return subjectDataDefinition;
        }

        /// <summary>
        /// Method that returns the input pool constraint attribute
        /// </summary>
        /// <returns>The input pool constraint attribute</returns>
        public IInputPoolConstraint getInputPoolConstraint()
        {
            return inputPoolConstraint;
        }

        /// <summary>
        /// Method that creates and returns a new empty instance of the fully specified subjcet class
        /// </summary>
        /// <returns>A new empty instance of the fully specified subjcet class</returns>
        new public FullySpecifiedSubject factoryMethod()
        {
            FullySpecifiedSubject fullySpecifiedSubject = new FullySpecifiedSubject();

            return fullySpecifiedSubject;
        }


        /// <summary>
        /// Method that creates a new Instance of the Fully Specified Subject class with all the string attributes being set
        /// </summary>
        /// <param name="attributeType"></param>
        /// <param name="attribute"></param>
        /// <returns></returns>
        new public bool createInstance(List<string> attribute, List<string> attributeType)
        {
            base.createInstance(attribute, attributeType);

            emptyAdditionalAttribute();

            bool result = false;
            int counter = 0;
            List<int> toBeRemoved = new List<int>();

            foreach (string s in attributeType)
            {

                if (s.Contains("containsBaseBehavior"))
                {
                    tmpSubjectBaseBehavior = attribute[counter];
                    toBeRemoved.Add(counter);
                }

                if (s.Contains("containsBehavior"))
                {
                    tmpSubjectBehavior = attribute[counter];
                    toBeRemoved.Add(counter);
                }

                if (s.Contains("hasInputPoolConstraint"))
                {
                    tmpInputPoolConstraint = attribute[counter];
                    toBeRemoved.Add(counter);
                }

                if (s.Contains("hasSubjectDataDefintion"))
                {
                    tmpSubjectDataDefinition = attribute[counter];
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
                    if (new SubjectBehavior().GetType().IsInstanceOfType(allElements[s]))
                    {
                        this.subjectBaseBehavior = (SubjectBehavior)allElements[s];
                        int place = getAdditionalAttribute().IndexOf(s);
                        if (place >= 0)
                        {
                            getAdditionalAttributeType().RemoveAt(place);
                            getAdditionalAttribute().Remove(s);
                        }
                    }

                    if (new SubjectBehavior().GetType().IsInstanceOfType(allElements[s]))
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

                    if (new SubjectDataDefinition().GetType().IsInstanceOfType(allElements[s]))
                    {
                        this.subjectDataDefinition = (SubjectDataDefinition)allElements[s];
                        int place = getAdditionalAttribute().IndexOf(s);
                        if (place >= 0)
                        {
                            getAdditionalAttributeType().RemoveAt(place);
                            getAdditionalAttribute().Remove(s);
                        }
                        //tmp.Remove(s);
                    }

                    if (new InputPoolConstraint().GetType().IsInstanceOfType(allElements[s]))
                    {
                        this.inputPoolConstraint = (InputPoolConstraint)allElements[s];
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
        /// Method that exports an fully specified subject to the file given by filename
        /// </summary>
        /// <param name="last"></param>
        /// <param name="filename"></param>
        public override void exporting(bool last, string filename)
        {
            base.exporting(false, filename);

            using (StreamWriter sw = File.AppendText("../../../../" + filename + ".owl"))
            {

                if (subjectBaseBehavior != null)
                {
                    sw.WriteLine("      <standard-pass-ont:containsBaseBehavior" + " rdf:resource=\"" + subjectBaseBehavior.getModelComponentID() + "\" ></standard-pass-ont:containsBaseBehavior>");
                }

                if (subjectBehavior != null)
                {
                    sw.WriteLine("      <standard-pass-ont:containsBehavior" + " rdf:resource=\"" + subjectBehavior.getModelComponentID() + "\" ></standard-pass-ont:containsBehavior>");
                }

                if (subjectDataDefinition != null)
                {
                    sw.WriteLine("      <standard-pass-ont:hasDataDefintion" + " rdf:resource=\"" + subjectDataDefinition.getModelComponentID() + "\" ></standard-pass-ont:hasDataDefintion>");
                }

                if (inputPoolConstraint != null)
                {
                    sw.WriteLine("      <standard-pass-ont:hasInputPoolConstraint" + " rdf:resource=\"" + inputPoolConstraint.getModelComponentID() + "\" ></standard-pass-ont:hasInputPoolConstraint>");
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
