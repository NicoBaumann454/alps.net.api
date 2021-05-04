using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VDS.RDF;

namespace alps.net_api
{
    /// <summary>
    /// Class where other programmers can change things within the api
    /// </summary>
    public class ExternalAccess
    {
        /// <summary>
        /// The empty constructor
        /// </summary>
        public ExternalAccess() { }

        /// <summary>
        /// Here the you can create your own instances of classes which you created yourself
        /// </summary>
        /// <param name="name"></param>
        /// <param name="files"></param>
        /// <returns>Your newly created instances</returns>
        public PASSProcessModelElement externalCreateInstance(string name, List<Graph> files)
        {
            /*
             * Example on how to write the externalCreateInstance() method for your own class based on the actual implementation within the api
             * switch (name)
                {

                    case "FullySpecifiedSubject":

                        FullySpecifiedSubject fullySpecifiedSubject = new FullySpecifiedSubject();

                        count = 0;
                        foreach (Graph j in files)
                        {
                            foreach (Triple l in files[count].Triples)
                            {
                                if (l.Subject.ToString().Equals(i.Key))
                                {
                                    if (l.Predicate.ToString().Contains("hasModelComponentID"))
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Subject.ToString());
                                    }
                                    else
                                    {
                                        attributeType.Add(l.Predicate.ToString());
                                        attribute.Add(l.Object.ToString());
                                    }
                                    fullySpecifiedSubject.addAttribute(l.Predicate.ToString(), l.Object.ToString());

                                }
                            }
                            count++;
                        }
                    }
             */

            return null; 
        }

        /// <summary>
        /// This Method can used when the normal completeObject Method throws an error (for the case that the new Class 
        /// contains a dictionary of dbjects which already have to be created before adding them to the attribute). To actually 
        /// use it properly, the class should set the public attribute external = true of the PASSProcessModelElement class.
        /// (Note: Can usually be ignored)
        /// </summary>
        /// <param name="pASSProcessModelElement"></param>
        public void externalCompleteObjects(PASSProcessModelElement pASSProcessModelElement)
        {

        }

        /// <summary>
        /// This method contemplates the externalCompleteObject class and usually just houses the foreach loop which completes
        /// the Objects which could't be completed beforhand 
        /// (Note: Can usually be ignored)
        /// </summary>
        public void externalFinalComplete()
        {
            /*
             * Example on how to write this method based on the implementation in the PassProcessModel class
            foreach (MessageExchangeList i in messageExchangeLists)
            {
                List<string> tmp = new List<string>();

                Dictionary<string, string> tmmp = i.getSingleAttribute();
                Dictionary<string, Dictionary<string, string>> tmmp1 = i.getMultiAttributes();

                foreach (KeyValuePair<string, string> k in tmmp)
                {
                    tmp.Add(k.Value);
                }
                foreach (KeyValuePair<string, Dictionary<string, string>> k in tmmp1)
                {
                    Dictionary<string, string> test = k.Value;

                    foreach (KeyValuePair<string, string> j in test)
                    {
                        tmp.Add(j.Value);
                    }
                }

                i.completeObject(ref allElements, ref tmp);
            }
             */
        }
    }
}
