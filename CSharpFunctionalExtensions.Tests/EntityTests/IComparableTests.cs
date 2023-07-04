using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.EntityTests
{
    public class IComparableTests
    {
        [Fact]
        public void Can_sort_entities()
        {
            var entity1 = new MyEntity(1);
            var entity2 = new MyEntity(2);
            var entity3 = new MyEntity(3);
            var entity4 = new MyEntity(4);

            MyEntity[] myEntities = new[] { entity3, entity1, entity4, entity2 }
                .OrderBy(x => x)
                .ToArray();

            myEntities[0].Should().BeSameAs(entity1);
            myEntities[1].Should().BeSameAs(entity2);
            myEntities[2].Should().BeSameAs(entity3);
            myEntities[3].Should().BeSameAs(entity4);
        }

        [Fact]
        public void Entities_with_different_id_types_are_comparatively_null()
        {
            var longEntity = new MyEntity(1);
            var guidEntity = new MyOtherEntity(new Guid("282e6fe9-a272-45da-aa16-757449ab2818"));

            int result1 = longEntity.CompareTo(guidEntity);
            int result2 = guidEntity.CompareTo(longEntity);

            result1.Should().Be(1);
            result2.Should().Be(1);
        }

        [Fact]
        public void Can_sort_entity_that_is_null()
        {
            var entity1 = new MyEntity(1);
            var entity2 = new MyEntity(2);

            MyEntity[] entities = new[] { entity1, entity2, null }
                .OrderBy(x => x)
                .ToArray();

            entities[0].Should().BeNull();
            entities[1].Should().BeSameAs(entity1);
            entities[2].Should().BeSameAs(entity2);
        }
        
        private class MyEntity : Entity
        {
            public MyEntity(long id)
                : base(id)
            {
            }
        }
        
        private class MyOtherEntity : Entity<Guid>
        {
            public MyOtherEntity(Guid id)
                : base(id)
            {
            }
        }
    }
}
