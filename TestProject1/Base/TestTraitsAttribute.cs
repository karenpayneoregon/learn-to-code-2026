namespace TestProject1.Base
{

    /// <summary>
    /// Declarative class for using Trait enum about for traits on test method.
    /// </summary>
    public class TestTraitsAttribute : TestCategoryBaseAttribute
    {
        private readonly Trait[] _traits;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestTraitsAttribute"/> class with the specified traits.
        /// </summary>
        /// <param name="traits">An array of <see cref="Trait"/> values representing the traits to associate with the test method.</param>
        public TestTraitsAttribute(params Trait[] traits)
        {
            _traits = traits;
        }

        /// <summary>
        /// Gets the list of test categories associated with the traits specified in the attribute.
        /// </summary>
        /// <remarks>
        /// The test categories are derived from the <see cref="Trait"/> enumeration values provided
        /// when the <see cref="TestTraitsAttribute"/> is applied.
        /// </remarks>
        /// <value>
        /// A list of strings representing the names of the test categories.
        /// </value>
        public override IList<string> TestCategories 
            => _traits.Select(trait => Enum.GetName(typeof(Trait), trait)).ToList();
    }

}