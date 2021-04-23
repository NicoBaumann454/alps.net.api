namespace alps.net_api
{
    /// <summary>
    /// Interface to the interface subject class
    /// </summary>

    public interface IInterfaceSubject : ISubject
    {
        // Sollte eigentlich eine Methode containsBehavior haben, da aber max 0 gilt 
        // existiert diese nicht
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fullySpecifiedSubject"></param>
        void setReferences(IFullySpecifiedSubject fullySpecifiedSubject);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IFullySpecifiedSubject getFullySpecifiedSubject();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        new InterfaceSubject factoryMethod();
    }

}
