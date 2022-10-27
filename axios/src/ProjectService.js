import http from "./http-common";

const getAll = () => {
  return http.get("/Project/GetAllProjects");
};

const get = id => {
  return http.get(`/Project/GetProject/${id}`);
};

const update = (id, data) => {
  return http.put(`/Project/UpdateProject/${id}`, data);
};
const create = data => {
  return http.post("/Project/PostProject", data);
};

/*const remove = id => {
  return http.delete(`/tutorials/${id}`);
};

const removeAll = () => {
  return http.delete(`/tutorials`);
};*/

const ProjectService = {
  getAll,
  get,
  update, 
  create
};

export default ProjectService;