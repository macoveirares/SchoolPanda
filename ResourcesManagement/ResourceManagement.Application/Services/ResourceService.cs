using Omu.ValueInjecter;
using ResourceManagement.Application.DTO;
using ResourceManagement.Application.Logic;
using ResourceManagement.Data.Infrastructure;
using ResourceManagement.Domain.Entities;
using System;
using System.Collections.Generic;

namespace ResourceManagement.Application.Services
{
    public interface IResourceService
    {
        void CreateResource(ResourceDto resource);
        void DeleteResource(int id);
        ResourceDto GetResource(int id);
    }

    public class ResourceService : IResourceService
    {
        private readonly IRepository<Resource> _resourceRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBlobRepository<ResourceReference> _blobRepository;

        public ResourceService(IRepository<Resource> resourceRepository, IUnitOfWork unitOfWork, IBlobRepository<ResourceReference> blobRepository)
        {
            _resourceRepository = resourceRepository;
            _unitOfWork = unitOfWork;
            _blobRepository = blobRepository;
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

        public ResourceDto GetResource(int id)
        {
            var entity = _resourceRepository.GetById(id);
            var resource = (ResourceDto)new Resource().InjectFrom(entity);
            resource.Url = _blobRepository.GetUrlByName(resource.Name);
            return resource;
        }
    }
}