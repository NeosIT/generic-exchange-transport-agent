namespace NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl.Enums
{
    /// <summary>
    /// Defines what kind of comparision on 
    /// subfilter type / value should be applied
    /// </summary>
    public enum FilterOperatorEnum
    {
        /// <summary>
        /// Value should be equal
        /// </summary>
        Equals = 0,

        /// <summary>
        /// Value should not be equal
        /// </summary>
        NotEquals = 1,

        /// <summary>
        /// Value should start with
        /// </summary>
        StartsWith = 2,

        /// <summary>
        /// Value should end with
        /// </summary>
        EndsWith = 3,

        /// <summary>
        /// Value should contain
        /// </summary>
        Contains = 4,

        /// <summary>
        /// Value should match regex
        /// </summary>
        Regex = 5,
    }
}
