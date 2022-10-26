import React,{useState,useEffect} from "react";
import ProjectService from './ProjectService'

export default function GetSingleData() {
    const [project, setProject] = useState({});

    useEffect(() => {
        ProjectService.get('D7B22584-7221-4FED-A2C4-2C1977854603').then((response) => {
            setProject(response.data);
            console.log(response.data);
        });
    }, []);
    return (
        <div>
            <p>{project.State.StateName}</p>
            <p>{project.Location.LocationName}</p>
            <p>{project.ProjectName}</p>
            <p>{project.Category}</p>
        </div>
    );
}