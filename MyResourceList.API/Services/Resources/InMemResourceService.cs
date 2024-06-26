﻿using MyResourceList.API.Models;

namespace MyResourceList.API.Services.Resources
{
    public class InMemResourceService : IResourceService
    {
        private readonly Dictionary<Guid, Resource> _db = new();

        public bool CheckResourceExists(Guid id)
        {
            return _db.ContainsKey(id);
        }

        public bool CreateResource(Resource resource)
        {
            if (CheckResourceExists(resource.Id))
            {
                return false;
            }
            _db.Add(resource.Id, resource);
            return true;
        }

        public Resource GetResource(Guid id)
        {
            return _db[id];
        }

        public List<Resource> GetAllResources()
        {
            return _db.Values.ToList();
        }

        public bool UpsertResource(Guid id, Resource new_resource)
        {
            if (!CheckResourceExists(id))
            {
                _db[id] = new_resource;
                return true;
            }
            var old_resource = _db[id];
            if (old_resource == null)
            {
                return false;
            }
            _db[id] = new Resource(
                id: id,
                title: new_resource.Title,
                description: new_resource.Description,
                url: new_resource.Url,
                type: new_resource.Type,
                resourceTags: new_resource.ResourceTags,
                status: new_resource.Status,
                rating: new_resource.Rating,
                stages: new_resource.Stages,
                progress: new_resource.Progress,
                comments: new_resource.Comments,
                createdAt: old_resource.CreatedAt,
                modifiedAt: new_resource.ModifiedAt
            );
            return true;
        }

        public bool DeleteResource(Guid id)
        {
            if (!CheckResourceExists(id))
            {
                return false;
            }
            _db.Remove(id);
            return true;
        }
    }
}
