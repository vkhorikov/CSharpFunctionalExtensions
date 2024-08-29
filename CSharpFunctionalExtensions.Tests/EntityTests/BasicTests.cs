using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.EntityTests
{
    public class BasicTests
    {
        [Fact]
        public void Derived_entities_are_not_equal()
        {
            var entity1 = new MyEntity(1);
            var entity2 = new MyDerivedEntity(1);

            bool equals1 = entity1.Equals(entity2);
            bool equals2 = entity1 == entity2;

            equals1.Should().BeFalse();
            equals2.Should().BeFalse();
        }

        [Fact]
        public void Entities_of_different_types_are_not_equal()
        {
            var entity1 = new MyEntity(1);
            var entity2 = new MySecondEntity(1);

            bool equals1 = entity1.Equals(entity2);
            bool equals2 = entity1 == entity2;

            equals1.Should().BeFalse();
            equals2.Should().BeFalse();
        }

        [Fact]
        public void Two_entities_of_the_same_id_are_equal()
        {
            var entity1 = new MyEntity(1);
            var entity2 = new MyEntity(1);

            bool equals1 = entity1.Equals(entity2);
            bool equals2 = entity1 == entity2;

            equals1.Should().BeTrue();
            equals2.Should().BeTrue();
        }

        [Fact]
        public void Two_entities_of_different_ids_are_not_equal()
        {
            var entity1 = new MyEntity(1);
            var entity2 = new MyEntity(2);

            bool equals1 = entity1.Equals(entity2);
            bool equals2 = entity1 == entity2;

            equals1.Should().BeFalse();
            equals2.Should().BeFalse();
        }

        [Fact]
        public void Entities_with_default_ids_are_not_equal()
        {
            var entity1 = new MyEntity(0);
            var entity2 = new MyEntity(0);

            bool equals1 = entity1.Equals(entity2);
            bool equals2 = entity1 == entity2;

            equals1.Should().BeFalse();
            equals2.Should().BeFalse();
        }

        [Fact]
        public void Id_can_be_a_custom_value_object()
        {
            Guid guid = Guid.NewGuid();
            var entity1 = new EntityWithCustomId(new MyId("1", guid));
            var entity2 = new EntityWithCustomId(new MyId("1", guid));

            bool equals1 = entity1.Equals(entity2);
            bool equals2 = entity1 == entity2;

            equals1.Should().BeTrue();
            equals2.Should().BeTrue();
        }

        [Fact]
        public void Comparison_to_null()
        {
            MyEntity entity1 = new MyEntity(1);
            MyEntity entity2 = null;
            MyEntity entity3 = null;

            (entity1 == null).Should().BeFalse();
            (entity2 == null).Should().BeTrue();
            (entity1.Equals(null)).Should().BeFalse();
            (entity2 == entity3).Should().BeTrue();
        }

        [Fact]
        public void Two_entities_with_nullable_id_are_not_equal()
        {
            MyEntityWithStringId entity1 = MyEntityWithStringId.Create();
            MyEntityWithStringId entity2 = MyEntityWithStringId.Create();

            (entity1 == entity2).Should().BeFalse();
        }

        public class MyEntityWithStringId : Entity<string>
        {
            public static MyEntityWithStringId Create()
            {
                return new MyEntityWithStringId();
            }
        }

        public class MyEntity : Entity
        {
            public MyEntity(long id)
                :base(id)
            {
            }
        }

        public class MySecondEntity : Entity
        {
            public MySecondEntity(long id)
                : base(id)
            {
            }
        }

        public class MyDerivedEntity : MyEntity
        {
            public MyDerivedEntity(long id)
                : base(id)
            {
            }
        }

        public class MyId : ComparableValueObject
        {
            public string Value1 { get; }
            public Guid Value2 { get; }

            public MyId(string value1, Guid value2)
            {
                Value1 = value1;
                Value2 = value2;
            }

            protected override IEnumerable<IComparable> GetComparableEqualityComponents()
            {
                yield return Value1;
                yield return Value2;
            }
        }

        public class EntityWithCustomId : Entity<MyId>
        {
            public EntityWithCustomId(MyId id)
                : base(id)
            {
            }
        }
    }
}
