namespace alps.net_api
{
    /// <summary>
    /// Interface to the DoTransition class
    /// </summary>

    public interface IDoTransition : ITransition
    {
        // Kann auch mit uint gemacht werden, aber ich denke es ist sicherer wenn ich das
        //ganze mit int mache und dann eine Exception bzw umschreiben in uint mache um sicher zu sein
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nonNegativInteger"></param>
        void setPriorityNumber(int nonNegativInteger);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        int getPriorityNumber();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        new DoTransition factoryMethod();
    }

}
