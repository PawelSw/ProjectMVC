namespace ProjectShopMVC.Models
{
    public interface IProjectRepository
    {
        IEnumerable<Project> AllProjects { get; }
        IEnumerable<Project> ProjectsOfTheWeek { get; }
        Project? GetProjectById(int projectId);
    }
}
