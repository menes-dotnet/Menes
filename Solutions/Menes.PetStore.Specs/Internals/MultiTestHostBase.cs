// <copyright file="MultiTestHostBase.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.PetStore.Specs.Internals
{
    /// <summary>
    /// Base class for tests that need to run for both Functions emulation and direct ASP.NET
    /// pipeline hosting.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Tests can derive from this and set the following class-level attribute:
    /// </para>
    /// <code><![CDATA[
    /// [TestFixtureSource(nameof(FixtureArgs))]
    /// ]]></code>
    /// <para>
    /// This needs to be specified on each deriving class, because NUnit does not walk up the
    /// inheritance chain when looking for test fixture sources.
    /// </para>
    /// <para>
    /// Deriving classes should also define a constructor that has the same signature as this
    /// class's constructor, forwarding the argument on. This, in conjunction with the test
    /// fixture source attribute, will cause NUnit to run the fixture for this class multiple
    /// times, once for each of the host types specified in <see cref="FixtureArgs"/>.
    /// </para>
    /// <para>
    /// When using SpecFlow, bindings can detect the mode by casting the reference in
    /// <c>TestExecutionContext.CurrentContext.TestObject</c> to <see cref="IMultiModeTest{TestHostTypes}"/>
    /// and then inspecting the <see cref="IMultiModeTest{TestHostTypes>.TestType"/> property.
    /// </para>
    /// </remarks>
    public class MultiTestHostBase : IMultiModeTest<TestHostTypes>
    {
        protected static readonly object[] FixtureArgs =
        {
            new object[] { TestHostTypes.EmulateFunctionWithActionResult },
            new object[] { TestHostTypes.AspNetDirectPipeline },
        };

        /// <summary>
        /// Creates a <see cref="MultiTestHostBase"/>.
        /// </summary>
        /// <param name="testType">
        /// Hosting style to test for.
        /// </param>
        private protected MultiTestHostBase(TestHostTypes testType)
        {
            this.TestType = testType;
        }

        /// <inheritdoc />
        public TestHostTypes TestType { get; }
    }
}