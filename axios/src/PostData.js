import React, { useState } from "react";
import ProjectService from './ProjectService'

export default function UpdateData() {
    const [project, setProject] = useState(
        {
            Location: {
                PostalCode: 0,
                LocationName: ""
            },
            State: {
                StateId: 1
            },
            ProjectName: "",
            Summary: "",
            Category: ""
        }
    );
    const handleInputChange = event => {
        const { name, value } = event.target;
        setProject({ ...project, [name]: value });
    };
    /*useEffect(() => {
        ProjectService.update('D7B22584-7221-4FED-A2C4-2C1977854603').then((response) => {
            setProject(response.data);
            console.log(response.data);
        });
    }, []);*/
    const post = () => {
        ProjectService.create(project)
          .then(response => {
            setProject(response.data);
            console.log(response.data);
          })
          .catch(e => {
            console.log(e);
          });
      };
    return (
        <div>
            {project ? (
                <div className="edit-form">
                    <h4>Post project</h4>
                    <form>
                        <div className="form-group">
                            <label htmlFor="ProjectName">Project name   </label>
                            <input
                                type="text"
                                className="form-control"
                                id="ProjectName"
                                name="ProjectName"
                                value={project.ProjectName}
                                onChange={handleInputChange}
                            />
                        </div><div className="form-group">
                            <label htmlFor="Summary">Summary  </label>
                            <input
                                type="text"
                                className="form-control"
                                id="Summary"
                                name="Summary"
                                value={project.Summary}
                                onChange={handleInputChange}
                            />
                        </div>
                        <div className="form-group">
                            <label htmlFor="Category">Category  </label>
                            <input
                                type="text"
                                className="form-control"
                                id="Category"
                                name="Category"
                                value={project.Category}
                                onChange={handleInputChange}
                            />
                        </div>
                    </form>


                    <button
                        type="submit"
                        onClick={post(project)}
                    >
                    Add
                    </button>
                </div>
            ) : (
                <div>
                    <br />
                    <p>Please click on a project...</p>
                </div>
            )}
        </div>
    );
}