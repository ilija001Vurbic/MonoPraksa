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

/*import axios from "axios";
import React, {Component} from "react";

class GetData extends Component{
    state={
        items:[]
    }
    singleState={
        project:{}
    }
    componentWillMount(){
        axios.get('https://localhost:44362/api/Project/GetAllProjects').then((response)=>{
                this.setState({
                    items: response.data,
                })
        });
        axios.get('https://localhost:44362/api/Project/GetProject/D7B22584-7221-4FED-A2C4-2C1977854603').then((response)=>{
                this.setSignleState({
                    project: response.data,
                })
        });
    }
    render(){
        let items=this.state.items.map((item)=>{
            return(
                <div className="GetData">
                   <ul>
                           <li key={item.ProjectID}>
                               State:{item.State.StateName}|Location:{item.Location.LocationName}|Project name:{item.ProjectName}|Category:{item.Category}
                           </li>
                   </ul>
                </div>
        )});
        let project=this.singleState.project.map((project)=>{
            return(
                <div className="GetSingleData">
                   <ul>
                           <p key={project.ProjectID}>
                               State:{project.State.StateName}|Location:{project.Location.LocationName}|Project name:{project.ProjectName}|Category:{project.Category}
                           </p>
                   </ul>
                </div>
        )});
            return(
             <div className="GetData">
                <ul>
                    {items}
                </ul>
                <p>{project}</p>
             </div>
            )
        
    }
}
export default GetData;*/