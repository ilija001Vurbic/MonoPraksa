import React,{useState,useEffect} from "react";
import ProjectService from './ProjectService'

export default function GetSingleData() {
    const [project, setProject] = useState(
        {
            Location: {
                PostalCode: 0,
                LocationName: ""
            },
            State: {
                StateName: ""
            },
            ProjectName: "",
            Summary: "",
            Category: ""
        }
    );

    useEffect(() => {
        ProjectService.get('D7B22584-7221-4FED-A2C4-2C1977854603').then((response) => {
            setProject(response.data);
            console.log(response.data);
        });
    }, []);
    return (
        <div>
            <h1>Single project</h1>
            <p>State: {project.State.StateName}</p>
            <p>Location: {project.Location.LocationName}</p>
            <p>Project name: {project.ProjectName}</p>
            <p>Category: {project.Category}</p>
        </div>
    );
}