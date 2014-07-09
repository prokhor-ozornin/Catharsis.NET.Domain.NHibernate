using Catharsis.Commons;
using FluentNHibernate.Testing;

namespace Catharsis.Domain.NHibernate
{
  /// <summary>
  ///   <para>Tests set for class <see cref="VideoMapping"/>.</para>
  /// </summary>
  public sealed class VideoMappingTests : EntityMappingTestsBase<Video>
  {
    protected override void TestMappings(PersistenceSpecification<Video> specification)
    {
      Assertion.NotNull(specification);

      var category = new VideosCategory("category.name");
      specification.TransactionalSave(category);

      specification.CheckProperty(mapping => mapping.Id, (long) 1);
      specification.CheckProperty(mapping => mapping.Version, (long) 1);
      specification.CheckProperty(mapping => mapping.Bitrate, (short) 16);
      specification.CheckReference(mapping => mapping.Category, category);
      specification.CheckProperty(mapping => mapping.Duration, (long) 10);
      specification.CheckProperty(mapping => mapping.File, "file");
      specification.CheckProperty(mapping => mapping.Height, (short) 480);
      specification.CheckProperty(mapping => mapping.Width, (short) 640);
    }
  }
}