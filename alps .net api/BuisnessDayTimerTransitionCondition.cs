using System.Collections.Generic;
using System.IO;
using VDS.RDF;

namespace alps.net_api
{
    /// <summary>
    /// Class that represents an buisness day timer transition condition
    /// </summary>
    public class BuisnessDayTimerTransitionCondition : TimeTransitionCondition, IBusinessDayTimerTransitionCondition
    {
        /*
        new public BuisnessDayTimerTransitionCondition factoryMethod()
        {
            BuisnessDayTimerTransitionCondition buisnessDayTimerTransitionCondition = new BuisnessDayTimerTransitionCondition();

            return buisnessDayTimerTransitionCondition;
        }
        */

        /// <summary>
        /// 
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="toolSpecificDefintion"></param>
        /// <param name="timeValue"></param>
        /// <param name="additionalAttribute"></param>
        public BuisnessDayTimerTransitionCondition(string label, string comment = "", string toolSpecificDefintion = "", string timeValue = "", List<string> additionalAttribute = null) : base(label, comment, toolSpecificDefintion, timeValue, additionalAttribute)
        {

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
