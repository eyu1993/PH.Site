namespace PH.Site.Model.BaseModel
{
    /// <summary>
    /// 聚合根接口，实现了该接口的为聚合根实例,由于聚合根也是领域实体的一种，所以也要实现IEntity接口
    /// 一个聚合根需要实现一个仓储
    /// </summary>
    public interface IAggregateRoot : IEntity
    {
    }
}
