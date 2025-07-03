namespace BaseLibrary.Application.Dto.Base
{
    public interface IDto
    {
    }

    public interface IdDto : IDto
    {
        int Id { get; set; }
    }
}
