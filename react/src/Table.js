import React, { useState } from 'react';
  
function CarForm(props) {
  const [manufacturer, setManufacturer] = useState('');
  const [model, setModel] = useState('');
  const [country, setCountry] = useState('');
  const [price, setPrice] = useState('');
  
  const changeManufacturer = (event) => {
    setManufacturer(event.target.value);
  };
  
  const changeModel = (event) => {
    setModel(event.target.value);
  };
  const changeCountry = (event) => {
    setCountry(event.target.value);
  };
  const changePrice = (event) => {
    setPrice(event.target.value);
  };
  
  const transferValue = (event) => {
    event.preventDefault();
    const val = {
      manufacturer,
      model,
      country,
      price,
    };
    props.func(val);
    clearState();
  };
  
  const clearState = () => {
    setManufacturer('');
    setModel('');
    setCountry('');
    setPrice('');
  };
  
  return (
    <div id="form">
      <label>Manufacturer</label>
      <input type="text" value={manufacturer} onChange={changeManufacturer} />
      <br/>
      <label>Model</label>
      <input type="text" value={model} onChange={changeModel} />
      <br/>
      <label>Country</label>
      <input type="text" value={country} onChange={changeCountry} />
      <br/>
      <label>Price</label>
      <input type="text" value={price} onChange={changePrice} />
      <br/>
      <button onClick={transferValue} id="button"> Add to table</button>
    </div>
  );
}
  
export default CarForm;