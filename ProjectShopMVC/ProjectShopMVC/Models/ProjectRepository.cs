namespace ProjectShopMVC.Models
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ProjectDbContext _projectDbContext;

        public ProjectRepository(ProjectDbContext projectDbContext)
        {
            _projectDbContext = projectDbContext;
        }

        public IEnumerable<Project> AllProjects 
            => _projectDbContext.Projects;

        public IEnumerable<Project> ProjectsOfTheWeek
             => _projectDbContext.Projects.Where(x => x.IsProjectOfTheWeek);

        public Project? GetProjectById(int projectId)
        {
             return _projectDbContext.Projects.FirstOrDefault(x => x.ProjectId == projectId);
        }
    }
}
