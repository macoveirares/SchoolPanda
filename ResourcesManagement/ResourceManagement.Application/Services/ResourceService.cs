using Omu.ValueInjecter;
using ResourceManagement.Application.DTO;
using ResourceManagement.Application.Logic;
using ResourceManagement.Data.Infrastructure;
using ResourceManagement.Domain.Entities;
using System.Linq;

namespace ResourceManagement.Application.Services
{
    public interface IResourceService
    {
        void CreateResource(ResourceDto resource);
        void DeleteResource(int id);
        ResourceDto GetResource(int id);
        ResourcesDetails GetAllLabs(int userId);
    }

    public class ResourceService : IResourceService
    {
        private readonly IRepository<Resource> _resourceRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBlobRepository<ResourceReference> _blobRepository;
        private readonly UserManagementMicroservice userManagementMicroservice;

        public ResourceService(IRepository<Resource> resourceRepository, IUnitOfWork unitOfWork, IBlobRepository<ResourceReference> blobRepository)
        {
            _resourceRepository = resourceRepository;
            _unitOfWork = unitOfWork;
            _blobRepository = blobRepository;
            userManagementMicroservice = new UserManagementMicroservice();
        }

        public void CreateResource(ResourceDto resource)
        {
            var entity = (Resource)new Resource().InjectFrom(resource);
            entity.Id = 0;
            _resourceRepository.Insert(entity);
            _unitOfWork.Save();   
        }

        public void DeleteResource(int id)
        {
            var entity = _resourceRepository.GetById(id);
            _resourceRepository.Delete(entity);
            _unitOfWork.Save();
        }

        public ResourcesDetails GetAllLabs(int userId)
        {
            var details = new ResourcesDetails();
            var courses = userManagementMicroservice.GetCourseByUser(userId);
            var resources = _resourceRepository.Query(a => courses.Select(a => a.Id).ToList().Contains(a.CourseId.Value)).ToList();

            return details;
        }

        public ResourceDto GetResource(int id)
        {
            var entity = _resourceRepository.GetById(id);
            var resource = (ResourceDto)new ResourceDto().InjectFrom(entity);
            resource.Url = _blobRepository.GetUrlByName(resource.Name);
            return resource;
        }
    }
}