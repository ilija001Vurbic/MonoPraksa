
import React, { useState } from 'react';
import CarForm from './Table';
import jsonData from './data.json';
  
function TableData() {
  const [carData, setCarData] = useState(jsonData);
  
  const tableRows = carData.map((info) => {
    return (
      <tr>
        <td>{info.id}</td>
        <td>{info.manufacturer}</td>
        <td>{info.model}</td>
        <td>{info.country}</td>
        <td>{info.price}</td>
      </tr>
    );
  });
  
  const addRows = (data) => {
    const totalCars = carData.length;
    data.id = totalCars + 1;
    const updatedCarData = [...carData];
    updatedCarData.push(data);
    setCarData(updatedCarData);
    jsonData.setItem(updatedCarData, JSON.stringify(updatedCarData));
  };
  return (
    <div>
      <table className="table table-stripped">
        <thead>
          <tr>
            <th>ID</th>
            <th>Manufacturer</th>
            <th>Model</th>
            <th>Country of origin</th>
            <th>Price</th>
          </tr>
        </thead>
        <tbody>{tableRows}</tbody>
      </table>
      <CarForm func={addRows}/>
    </div>
  );
}
  
export default TableData;