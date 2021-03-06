using Catharsis.Commons;

namespace Catharsis.Domain.NHibernate
{
  /// <summary>
  ///   <para>NHibernate ORM relational mapping for <see cref="City"/> entity.</para>
  /// </summary>
  public sealed class CityMapping : EntityMapping<City>
  {
    /// <summary>
    ///   <para>Creates and setup new mapping.</para>
    /// </summary>
    public CityMapping()
    {
      this.Cache.ReadWrite();
      this.References(city => city.Country).Cascade.All().Column("CountryId").Fetch.Join().ForeignKey("FK__{0}__{1}".FormatSelf(typeof(City).Name, typeof(Country).Name)).Index("IX__{0}__CountryId".FormatSelf(typeof(City).Name)).Not.Nullable();
      this.Map(city => city.Name).Index("IX__{0}__Name".FormatSelf(typeof(City).Name)).Not.Nullable();
      this.Map(city => city.Region).Index("IX__{0}__Region".FormatSelf(typeof(City).Name));
    }
  }
}