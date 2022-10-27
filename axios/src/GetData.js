import React,{useState,useEffect} from "react";
import ProjectService from './ProjectService'

export default function GetData() {
    const [projects, setProjects] = useState([]);

    useEffect(() => {
        ProjectService.getAll().then((response) => {
            setProjects(response.data);
            console.log(response.data);
        });
    }, []);
    const projectsArr = projects.map((project) => {
        return(
        <div>
            <ul>
                <li>
                    State:{project.State.StateName}|Location:{project.Location.LocationName}|Project name:{project.ProjectName}|Category:{project.Category}
                </li>
            </ul>
        </div>
    )});
    return (
        <div>
            {projectsArr}
        </div>
    );
}