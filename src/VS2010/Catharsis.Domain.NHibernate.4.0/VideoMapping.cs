using Catharsis.Commons;

namespace Catharsis.Domain.NHibernate
{
  /// <summary>
  ///   <para>NHibernate ORM relational mapping for <see cref="Video"/> entity.</para>
  /// </summary>
  public sealed class VideoMapping : EntityMapping<Video>
  {
    /// <summary>
    ///   <para>Creates and setup new mapping.</para>
    /// </summary>
    public VideoMapping()
    {
      this.Map(video => video.Bitrate).Check("Bitrate >= 0").Index("IX__{0}__Bitrate".FormatSelf(typeof(Video).Name)).Not.Nullable();
      this.References(video => video.Category).Cascade.All().Column("CategoryId").Fetch.Join().ForeignKey("FK__{0}__{1}".FormatSelf(typeof(Video).Name, typeof(VideosCategory).Name)).Index("IX__{0}__CategoryId".FormatSelf(typeof(Video).Name));
      this.Map(video => video.Duration).Check("Duration >= 0").Index("IX__{0}__Duration".FormatSelf(typeof(Video).Name)).Not.Nullable();
      this.Map(video => video.File).Column("`File`").Length(1024).Not.Nullable();
      this.Map(video => video.Height).Check("Height >= 0").Index("IX__{0}__Height".FormatSelf(typeof(Video).Name)).Not.Nullable();
      this.Map(video => video.Width).Check("Width >= 0").Index("IX__{0}__Width".FormatSelf(typeof(Video).Name)).Not.Nullable();
    }
  }
}