using System.Collections.Generic;
using System.IO;

namespace alps.net_api
{
    /// <summary>
    /// Class that represents an ALPS SBD component
    /// </summary>
    public class ALPSSBDComponent : ALPSModelElement, IALPSSBDComponent
    {

        private ISubjectBehavior subjectBehavior;
        private string tmpSubjectBahavior = "";

        /// <summary>
        /// Constructor that creates an empty instance of the ALPS SBD Component class
        /// </summary>
        public ALPSSBDComponent()
        {
            setModelComponentID("ALPSSBDComponent");
            setComment("The standart Object of the ALPSSBDComponent Class");
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
        /// Method that sets the tmp subject behavior attribute
        /// </summary>
        /// <param name="tmpSubjectBehavior"></param>
        public void setTmpSubjectBehavior(string tmpSubjectBehavior)
        {
            this.tmpSubjectBahavior = tmpSubjectBehavior;
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
        /// Method that creates a new Instance of the SLPSSBDComponent class
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="attributeType"></param>
        /// <returns></returns>
        public override bool createInstance(List<string> attribute, List<string> attributeType)
        {
            base.createInstance(attribute, attributeType);

            emptyAdditionalAttribute();

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

        }


        /// <summary>
        /// Method that exports an ALPS SBD element to the file given in the filename
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
                    sw.WriteLine("      <standard-pass-ont:belongsToSubjectBehavior" + " rdf:resource=\"" + subjectBehavior.getModelComponentID() + "\" ></standard-pass-ont:belongsToSubjectBehavior>");
                }

                if (last)
                {
                    sw.WriteLine("      <rdf:type rdf:resource=" + "\"&abstract-pass-ont;" + this.GetType().ToString().Split('.')[2] + "\" ></rdf:type>");
                    sw.WriteLine("  </owl:NamedIndividual>");
                }
            }
        }
    }
}
