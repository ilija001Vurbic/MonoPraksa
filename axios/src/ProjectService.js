import http from "./http-common";

const getAll = () => {
  return http.get("/Project/GetAllProjects");
};

const get = id => {
  return http.get(`/Project/GetProject/${id}`);
};

const ProjectService = {
  getAll,
  get,
};

export default ProjectService;