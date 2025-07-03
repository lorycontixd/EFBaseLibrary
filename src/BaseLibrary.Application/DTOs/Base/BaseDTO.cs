using System.Text.Json.Serialization;

namespace BaseLibrary.Application.DTOs.Base
{
    /// <summary>
    /// Base class for all Data Transfer Objects (DTOs) that include an ID property.
    /// </summary>
    public abstract class BaseDto : IDto
    {
        public int Id { get; set; }
    }

    /// <summary>
    /// Base class for Data Transfer Objects (DTOs) that include auditing information.
    /// Typically these are used for response DTOs, such as those returned by GET requests.
    /// </summary>
    public abstract class AuditableDto : BaseDto
    {
        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [JsonPropertyName("updatedAt")]
        public DateTime? UpdatedAt { get; set; }
        [JsonPropertyName("createdBy")]
        public string? CreatedBy { get; set; }
        [JsonPropertyName("updatedBy")]
        public string? UpdatedBy { get; set; }
    }

    /// <summary>
    /// Base class for Data Transfer Objects (DTOs) used for creating new entities.
    /// Post requests typically do not require an ID.
    /// </summary>
    public abstract class CreateDto : BaseDto
    {
    }

    /// <summary>
    /// Base class for Data Transfer Objects (DTOs) used for updating existing entities.
    /// </summary>
    public abstract class UpdateDto : BaseDto
    {
    }

    /// <summary>
    /// Base class for Data Transfer Objects (DTOs) used for deleting entities.
    /// </summary>
    public abstract class DeleteDto : BaseDto
    {
    }

    /// <summary>
    /// Base class for Data Transfer Objects (DTOs) that represent a list of entities.
    /// </summary>
    public abstract class ListDto : BaseDto
    {
    }
}