using System.Collections.Generic;
using System.IO;
using VDS.RDF;

namespace alps.net_api
{
    //Ich muss noch Implementiert werden !!!!!!!!!!!!!!!!!!!!

    /// <summary>
    /// Class that represents a day time timer transition condition 
    /// </summary>
    public class DayTimeTimerTransitionCondition : TimerTransitionCondition, IDayTimeTimerTransitionCondition
    {
        /// <summary>
        /// Constructor that creates a new fully specified Instance of the day time timer transition condition class
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="toolSpecificDefintion"></param>
        /// <param name="timeValue"></param>
        /// <param name="additionalAttribute"></param>
        public DayTimeTimerTransitionCondition(string label, string comment = "", string toolSpecificDefintion = "", string timeValue = "", List<string> additionalAttribute = null) : base(label, comment, toolSpecificDefintion, timeValue, additionalAttribute)
        {

        }

        /// <summary>
        /// Method that exports a day time timer transition condition object to the file given in the filename
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
