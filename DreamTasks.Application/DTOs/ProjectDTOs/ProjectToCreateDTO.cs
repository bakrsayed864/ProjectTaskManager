namespace Application.DTOs.ProjectDTOs;

public class ProjectToCreateDTO
{
    [Required]
    [Length(5,100, ErrorMessage ="Name should be grater than 5 and less than 100 character")]
    public string Name { get; set; } = string.Empty;
    [Required]
    [Length(10,200, ErrorMessage = "Description should be grater than 10 and less than 200 character")]
    public string Description { get; set; } = string.Empty;

}
