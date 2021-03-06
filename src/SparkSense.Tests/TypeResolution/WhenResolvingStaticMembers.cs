﻿using System.Reflection;
using NUnit.Framework;
using SparkSense.Tests.Scenarios;

namespace SparkSense.Tests.TypeResolution
{
    public class WhenResolvingStaticMembers : TypeResolutionScenario
    {
        public WhenResolvingStaticMembers()
        {
            GivenReferencedTypes(new[] {typeof (StubType)});
            WhenLookingUpStaticMembers();
        }

        [Test]
        public void ShouldFilterOutBackingAndInstanceMembers()
        {
            TheResolvedMembers
                .ShouldNotContain(m => m.Name == "get_StubStaticProperty")
                .ShouldNotContain(m => m.Name == "StubInstanceProperty")
                .ShouldNotContain(m => m.Name == "StubInstanceMethod");
        }

        [Test]
        public void ShouldResolvePublicStaticField()
        {
            TheResolvedMembers
                .ShouldContain(m => m.Name == "StubStaticField")
                .MemberType
                .ShouldBe(MemberTypes.Field);
        }

        [Test]
        public void ShouldResolvePublicStaticMethod()
        {
            TheResolvedMembers
                .ShouldContain(m => m.Name == "StubStaticMethod")
                .MemberType
                .ShouldBe(MemberTypes.Method);
        }

        [Test]
        public void ShouldResolvePublicStaticProperty()
        {
            TheResolvedMembers
                .ShouldContain(m => m.Name == "StubStaticProperty")
                .MemberType
                .ShouldBe(MemberTypes.Property);
        }
    }
}