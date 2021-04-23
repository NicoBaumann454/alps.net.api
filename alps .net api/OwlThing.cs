namespace alps.net_api
{

    /// <summary>
    /// Interface of the Owl thing class
    /// </summary>
    public interface IOwlThing
    {

    }

    /// <summary>
    /// The base class within the owl onthology
    /// Builds the base of all the inherited classes but has no attributes
    /// </summary>
    public class OwlThing : IOwlThing
    {
        private string type;

        /// <summary>
        /// Method that sets the type which this Object is
        /// </summary>
        public void setType(string type)
        {
            //Zugriff sollte ich einschraenken so dass man lediglich valide typen eingeben kann (also nur mit den korrekten URIs)
            this.type = type;
        }

        /// <summary>
        /// Method that returns the type of the object
        /// </summary>
        /// <returns></returns>
        public string getType()
        {
            return this.type;
        }
    }
}
